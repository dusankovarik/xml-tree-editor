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

        private void toolStripButtonOpen_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "XML soubory (*.xml)|*.xml|Všechny soubory (*.*)|*.*";
                openFileDialog.Title = "Vyberte XML soubor";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    LoadXmlFile(openFileDialog.FileName);
                }
            }
        }
    }
}
