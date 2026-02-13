using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTreeEditor {
    /// <summary>
    /// Class for storing statistics about an XML document
    /// </summary>
    public class XmlDocumentInfo {
        public string FileName { get; set; } = string.Empty;
        public int MaxDepth { get; set; }
        public int MaxChildren { get; set; }
        public int MinAttributes { get; set; }
        public int MaxAttributes { get; set; }
    }
}
