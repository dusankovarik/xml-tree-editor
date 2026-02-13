using System;
using System.Collections.Generic;
using System.Text;

namespace XmlTreeEditor {
    /// <summary>
    /// Class for storing information about selected XML element
    /// </summary>
    public class XmlElementInfo {
        public int Depth { get; set; }
        public int PositionAmongSiblings { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
            = new Dictionary<string, string>();
        public string Text { get; set; } = string.Empty;
    }
}
