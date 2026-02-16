using System.Reflection.Metadata;
using System.Xml.Linq;

namespace XmlTreeEditor {
    public partial class MainForm : Form {
        // Current loaded XML document
        private XDocument? currentXmlDocument = null;

        // Path to the currently loaded file
        private string? currentFilePath = null;

        public MainForm() {
            InitializeComponent();
            SetupTreeViewIcons();
        }

        // Event handler for the "Open" button click
        private void toolStripButtonOpen_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "XML soubory (*.xml)|*.xml|Všechny soubory (*.*)|*.*";
                openFileDialog.Title = "Vyberte XML soubor";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    LoadXmlFile(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Loads and processes an XML file
        /// </summary>
        /// <param name="filePath">File path</param>
        private void LoadXmlFile(string filePath) {
            try {
                // Clear previous data
                ClearAll();

                // Load XML document
                currentXmlDocument = XDocument.Load(filePath);
                currentFilePath = filePath;

                // Populate TreeView with XML structure
                PopulateTreeView();

                // Calculate and display document statistics
                DisplayDocumentInfo();
            }
            catch (Exception ex) {
                // Show error message for invalid XML
                MessageBox.Show(
                    $"Chyba pøi naèítání souboru:\n{ex.Message}",
                    "Chyba naèítání XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Clear all data on error
                ClearAll();
            }
        }

        /// <summary>
        /// Clears all UI elements (TreeView and labels)
        /// </summary>
        private void ClearAll() {
            // Clear TreeView
            treeViewXml.Nodes.Clear();

            // Clear file info labels
            labelFileName.Text = string.Empty;
            labelMaxDepth.Text = string.Empty;
            labelMaxChildren.Text = string.Empty;
            labelMinAttributes.Text = string.Empty;
            labelMaxAttributes.Text = string.Empty;

            // Clear element info labels
            labelElementDepth.Text = string.Empty;
            labelElementPosition.Text = string.Empty;
            labelElementAttributes.Text = string.Empty;
            labelElementText.Text = string.Empty;

            // Reset document reference
            currentXmlDocument = null;
            currentFilePath = null;
        }

        /// <summary>
        /// Populates TreeView with XML document structure
        /// </summary>
        private void PopulateTreeView() {
            if (currentXmlDocument?.Root == null) {
                return;
            }

            // Create root node for the XML document
            TreeNode rootNode = CreateTreeNode(currentXmlDocument.Root);
            treeViewXml.Nodes.Add(rootNode);

            // Expand root to show structure
            rootNode.Expand();
        }

        /// <summary>
        /// Recursively creates TreeNode from XElement
        /// </summary>
        /// <param name="element">XML Element</param>
        /// <returns>TreeNode</returns>
        private TreeNode CreateTreeNode(XElement element) {
            // Create node with element name
            TreeNode node = new TreeNode(element.Name.LocalName);

            // Store reference to XElement in Tag property
            node.Tag = element;

            // Check if element has child elements
            bool hasChildElements = element.Elements().Any();

            // Set icon: folder for branches, file for leaves
            node.ImageIndex = hasChildElements ? 0 : 1;
            node.SelectedImageIndex = hasChildElements ? 0 : 1;

            // Recursively add child elements
            foreach (XElement childElement in element.Elements()) {
                TreeNode childNode = CreateTreeNode(childElement);
                node.Nodes.Add(childNode);
            }

            return node;
        }

        /// <summary>
        /// Calculates and displays document statistics
        /// </summary>
        private void DisplayDocumentInfo() {
            if (currentXmlDocument?.Root == null || currentFilePath == null) {
                return;
            }

            // Create instance - statistics are calculated in the constructor
            XmlDocumentInfo info = new XmlDocumentInfo(currentXmlDocument, currentFilePath);

            // Display in labels
            labelFileName.Text = info.FileName;
            labelMaxDepth.Text = info.MaxDepth.ToString();
            labelMaxChildren.Text = info.MaxChildren.ToString();
            labelMinAttributes.Text = info.MinAttributes.ToString();
            labelMaxAttributes.Text = info.MaxAttributes.ToString();
        }

        /// <summary>
        /// Event handler for TreeView node selection
        /// </summary>
        private void treeViewXml_AfterSelect(object sender, TreeViewEventArgs e) {
            if (e.Node?.Tag is XElement element) {
                DisplayElementInfo(element);
            }
        }

        /// <summary>
        /// Displays information about the selected XML element
        /// </summary>
        /// <param name="element">XML element</param>

        private void DisplayElementInfo(XElement element) {
            // Create instance - information is calculated in constructor
            XmlElementInfo info = new XmlElementInfo(element);

            // Display in depth
            labelElementDepth.Text = info.Depth.ToString();

            // Display position among siblings
            labelElementPosition.Text = info.PositionAmongSiblings.ToString();

            // Display attributes
            if (info.Attributes.Count > 0) {
                var attributeLines = info.Attributes.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\"");
                labelElementAttributes.Text = string.Join("\n", attributeLines);
            }
            else {
                labelElementAttributes.Text = "(žádné atributy)";
            }

            // Display text content
            if (!string.IsNullOrEmpty(info.Text)) {
                labelElementText.Text = info.Text;
            }
            else {
                labelElementText.Text = "(žádný text)";
            }
        }

        /// <summary>
        /// Event handler for "Save" button click
        /// </summary>
        private void toolStripButtonSave_Click(object sender, EventArgs e) {
            if (currentXmlDocument?.Root == null) {
                MessageBox.Show(
                    "Není naèten žádný XML soubor.",
                    "Nelze uložit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "XML soubory (*.xml)|*.xml|Všechny soubory (*.*)|*.*";
                saveFileDialog.Title = "Uložit XML soubor";
                saveFileDialog.FileName = Path.GetFileName(currentFilePath ?? "dokument.xml");

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    SaveXmlFile(saveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Saves the XML document with updated element names from TreeView
        /// </summary>
        /// <param name="filePath">File path</param>
        private void SaveXmlFile(string filePath) {
            try {
                if (currentXmlDocument?.Root == null || treeViewXml.Nodes.Count == 0) {
                    return; // No document to save
                }

                // Update element names from TreeView to XDocument
                TreeNode rootNode = treeViewXml.Nodes[0];
                UpdateElementNamesFromTreeView(rootNode);

                // Save to file
                currentXmlDocument.Save(filePath);

                MessageBox.Show(
                    "Soubor byl úspìšnì uložen.",
                    "Uloženo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(
                    $"Chyba pøi ukládání souboru:\n{ex.Message}",
                    "Chyba ukládání XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recursively updates element names in XDocument based on TreeView node names
        /// </summary>
        /// <param name="node">Current TreeView node</param>
        private void UpdateElementNamesFromTreeView(TreeNode node) {
            if (node.Tag is XElement element) {
                // Update element name if it was changed in TreeView
                if (element.Name.LocalName != node.Text) {
                    element.Name = node.Text;
                }
            }

            // Recursively process child nodes
            foreach (TreeNode childNode in node.Nodes) {
                UpdateElementNamesFromTreeView(childNode);
            }
        }

        /// <summary>
        /// Event handler for "Close" button click
        /// </summary>
        private void toolStripButtonClose_Click(object sender, EventArgs e) {
            ClearAll();
        }

        /// <summary>
        /// Creates and configures ImageList for TreeView icons
        /// </summary>
        private void SetupTreeViewIcons() {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            // Icon 0: Folder (just one, not open/closed)
            imageList.Images.Add(CreateFolderIcon());

            // Icon 1: File
            imageList.Images.Add(CreateFileIcon());

            treeViewXml.ImageList = imageList;
        }

        /// <summary>
        /// Creates a simple folder icon
        /// </summary>
        /// <returns>Folder Icon</returns>
        private Bitmap CreateFolderIcon() {
            Bitmap bitmap = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bitmap)) {
                // Yellow folder
                using (Brush folderBrush = new SolidBrush(Color.FromArgb(255, 220, 120)))
                using (Pen folderPen = new Pen(Color.FromArgb(180, 140, 60))) {
                    g.FillRectangle(folderBrush, 2, 6, 12, 7);
                    g.DrawRectangle(folderPen, 2, 6, 12, 7);
                    g.FillRectangle(folderBrush, 2, 4, 6, 3);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Creates a simple file icon
        /// </summary>
        /// <returns>File icon</returns>
        private Bitmap CreateFileIcon() {
            Bitmap bitmap = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bitmap)) {
                // White document
                using (Brush docBrush = Brushes.White)
                using (Pen docPen = new Pen(Color.Gray)) {
                    // Main rectangle
                    g.FillRectangle(docBrush, 4, 2, 8, 12);
                    g.DrawRectangle(docPen, 4, 2, 8, 12);

                    // Folded corner
                    g.DrawLine(docPen, 12, 2, 9, 5);
                    g.DrawLine(docPen, 9, 5, 12, 5);

                    // Lines on document
                    //g.DrawLine(Pens.LightGray, 6, 6, 10, 6);
                    //g.DrawLine(Pens.LightGray, 6, 8, 10, 8);
                    //g.DrawLine(Pens.LightGray, 6, 10, 10, 10);
                }
            }
            return bitmap;
        }

        private void treeViewXml_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            // Check if new label is null or empty (user cancelled or deleted text)
            if (string.IsNullOrWhiteSpace(e.Label)) {
                //Cancel edit and revert to old label
                e.CancelEdit = true;

                // Show warning to user
                MessageBox.Show(
                    "Název elementu nemùže být prázdný.",
                    "Neplatný název",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
