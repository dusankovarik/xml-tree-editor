using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace XmlTreeEditor {
    /// <summary>
    /// Class for storing and calculating XML document statistics
    /// </summary>
    public class XmlDocumentInfo {
        public string FileName { get; set; } = string.Empty;
        public int MaxDepth { get; set; }
        public int MaxChildren { get; set; }
        public int MinAttributes { get; set; }
        public int MaxAttributes { get; set; }

        /// <summary>
        /// Creates an instance and calculates statistics from XML document
        /// </summary>
        /// <param name="document">XML document</param>
        /// <param name="filePath">XML file path</param>
        public XmlDocumentInfo(XDocument document, string filePath) {
            FileName = Path.GetFileName(filePath);

            if (document.Root == null) {
                MaxDepth = 0;
                MaxChildren = 0;
                MinAttributes = 0;
                MaxAttributes = 0;
                return;
            }

            // Calculate statistics
            MaxChildren = 0;
            MaxDepth = CalculateMaxDepth(document.Root);
            MinAttributes = int.MaxValue;
            MaxAttributes = 0;

            CalculateChildrenAndAttributes(document.Root);

            // If no elements have attributes, set MinAttributes to 0
            if (MinAttributes == int.MaxValue) {
                MinAttributes = 0;
            }
        }

        /// <summary>
        /// Recursively calculates the maximum depth of the XML tree
        /// </summary>
        /// <param name="element">XML element</param>
        /// <returns>Maximum depth of the XML tree</returns>
        private int CalculateMaxDepth(XElement element) {
            if (!element.Elements().Any()) {
                return 1; // Leaf node
            }

            int maxChildDepth = 0;
            foreach (XElement child in element.Elements()) {
                int childDepth = CalculateMaxDepth(child);
                if (childDepth > maxChildDepth) {
                    maxChildDepth = childDepth;
                }
            }

            return 1 + maxChildDepth; // Current node + max depth of children
        }


        /// <summary>
        /// Recursively calculates max children count and min/max attribute counts
        /// </summary>
        /// <param name="element">XML element</param>
        private void CalculateChildrenAndAttributes(XElement element) {
            // Count direct children
            int childrenCount = element.Elements().Count();
            if (childrenCount > MaxChildren) {
                MaxChildren = childrenCount;
            }

            // Count attributes
            int attributesCount = element.Attributes().Count();
            if (attributesCount < MinAttributes) {
                MinAttributes = attributesCount;
            }
            if (attributesCount > MaxAttributes) {
                MaxAttributes = attributesCount;
            }

            // Recursively process all children
            foreach (XElement child in element.Elements()) {
                CalculateChildrenAndAttributes(child);
            }
        }
    }
}
