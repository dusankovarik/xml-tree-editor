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

            // Set icon index based on whether node is leaf or branch
            // 0 = folder icon (has children), 1 = file icon (leaf)
            node.ImageIndex = hasChildElements ? 0 : 1;
            node.SelectedImageIndex = node.ImageIndex;

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
    }
}
