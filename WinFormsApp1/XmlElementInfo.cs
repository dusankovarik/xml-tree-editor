using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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


        public XmlElementInfo(XElement element) {
            // Calculate depth
            Depth = CalculateDepth(element);

            // Calculate position among siblings
            PositionAmongSiblings = CalculatePosition(element);

            // Get attributes
            foreach (XAttribute attr in element.Attributes()) {
                Attributes[attr.Name.LocalName] = attr.Value;
            }

            // Get text content (only if it is a leaf element with text)
            if (!element.Elements().Any()) {
                Text = element.Value;
            }
        }

        /// <summary>
        /// Calculates the depth of the XML element (distance from root)
        /// </summary>
        /// <param name="element">XML element</param>
        /// <returns>Depth of the XML element</returns>
        private int CalculateDepth(XElement element) {
            int depth = 1;
            XElement? current = element.Parent;

            while (current != null) {
                depth++;
                current = current.Parent;
            }

            return depth;
        }

        /// <summary>
        /// Calculates the position of the XML element among its siblings (1-based)
        /// </summary>
        /// <param name="element">XML element</param>
        /// <returns>Position of the XML element among its siblings</returns>
        private int CalculatePosition(XElement element) {
            if (element.Parent == null) {
                return 1; // Root element is always position 1
            }

            var siblings = element.Parent.Elements().ToList();
            return siblings.IndexOf(element) + 1; // Convert to 1-based index
        }
    }
}
