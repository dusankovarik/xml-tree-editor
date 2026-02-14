namespace XmlTreeEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            toolStripButtonOpen = new ToolStripButton();
            toolStripButtonSave = new ToolStripButton();
            toolStripButtonClose = new ToolStripButton();
            splitContainerMain = new SplitContainer();
            treeViewXml = new TreeView();
            groupBoxElementInfo = new GroupBox();
            labelElementText = new Label();
            label12 = new Label();
            labelElementAttributes = new Label();
            label10 = new Label();
            labelElementPosition = new Label();
            label8 = new Label();
            labelElementDepth = new Label();
            label6 = new Label();
            groupBoxFileInfo = new GroupBox();
            labelMaxDepth = new Label();
            labelMaxAttributes = new Label();
            labelMinAttributes = new Label();
            labelMaxChildren = new Label();
            labelFileName = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            groupBoxElementInfo.SuspendLayout();
            groupBoxFileInfo.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonOpen, toolStripButtonSave, toolStripButtonClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(984, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            toolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonOpen.Image = (Image)resources.GetObject("toolStripButtonOpen.Image");
            toolStripButtonOpen.ImageTransparentColor = Color.Magenta;
            toolStripButtonOpen.Name = "toolStripButtonOpen";
            toolStripButtonOpen.Size = new Size(47, 22);
            toolStripButtonOpen.Text = "Otevřít";
            toolStripButtonOpen.Click += toolStripButtonOpen_Click;
            // 
            // toolStripButtonSave
            // 
            toolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonSave.Image = (Image)resources.GetObject("toolStripButtonSave.Image");
            toolStripButtonSave.ImageTransparentColor = Color.Magenta;
            toolStripButtonSave.Name = "toolStripButtonSave";
            toolStripButtonSave.Size = new Size(41, 22);
            toolStripButtonSave.Text = "Uložit";
            toolStripButtonSave.Click += toolStripButtonSave_Click;
            // 
            // toolStripButtonClose
            // 
            toolStripButtonClose.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonClose.Image = (Image)resources.GetObject("toolStripButtonClose.Image");
            toolStripButtonClose.ImageTransparentColor = Color.Magenta;
            toolStripButtonClose.Name = "toolStripButtonClose";
            toolStripButtonClose.Size = new Size(41, 22);
            toolStripButtonClose.Text = "Zavřít";
            toolStripButtonClose.Click += toolStripButtonClose_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 25);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(treeViewXml);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(groupBoxElementInfo);
            splitContainerMain.Panel2.Controls.Add(groupBoxFileInfo);
            splitContainerMain.Size = new Size(984, 636);
            splitContainerMain.SplitterDistance = 380;
            splitContainerMain.TabIndex = 1;
            // 
            // treeViewXml
            // 
            treeViewXml.Dock = DockStyle.Fill;
            treeViewXml.LabelEdit = true;
            treeViewXml.Location = new Point(0, 0);
            treeViewXml.Name = "treeViewXml";
            treeViewXml.Size = new Size(380, 636);
            treeViewXml.TabIndex = 0;
            treeViewXml.AfterSelect += treeViewXml_AfterSelect;
            // 
            // groupBoxElementInfo
            // 
            groupBoxElementInfo.Controls.Add(labelElementText);
            groupBoxElementInfo.Controls.Add(label12);
            groupBoxElementInfo.Controls.Add(labelElementAttributes);
            groupBoxElementInfo.Controls.Add(label10);
            groupBoxElementInfo.Controls.Add(labelElementPosition);
            groupBoxElementInfo.Controls.Add(label8);
            groupBoxElementInfo.Controls.Add(labelElementDepth);
            groupBoxElementInfo.Controls.Add(label6);
            groupBoxElementInfo.Dock = DockStyle.Top;
            groupBoxElementInfo.Location = new Point(0, 180);
            groupBoxElementInfo.Name = "groupBoxElementInfo";
            groupBoxElementInfo.Padding = new Padding(10);
            groupBoxElementInfo.Size = new Size(600, 250);
            groupBoxElementInfo.TabIndex = 1;
            groupBoxElementInfo.TabStop = false;
            groupBoxElementInfo.Text = "Informace o vybraném elementu";
            // 
            // labelElementText
            // 
            labelElementText.Location = new Point(10, 195);
            labelElementText.Name = "labelElementText";
            labelElementText.Size = new Size(550, 40);
            labelElementText.TabIndex = 7;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(10, 170);
            label12.Name = "label12";
            label12.Size = new Size(31, 15);
            label12.TabIndex = 6;
            label12.Text = "Text:";
            // 
            // labelElementAttributes
            // 
            labelElementAttributes.Location = new Point(10, 100);
            labelElementAttributes.Name = "labelElementAttributes";
            labelElementAttributes.Size = new Size(550, 60);
            labelElementAttributes.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 75);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 4;
            label10.Text = "Atributy:";
            // 
            // labelElementPosition
            // 
            labelElementPosition.Location = new Point(150, 50);
            labelElementPosition.Name = "labelElementPosition";
            labelElementPosition.Size = new Size(400, 15);
            labelElementPosition.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 50);
            label8.Name = "label8";
            label8.Size = new Size(132, 15);
            label8.TabIndex = 2;
            label8.Text = "Pořadí mezi sourozenci:";
            // 
            // labelElementDepth
            // 
            labelElementDepth.Location = new Point(150, 25);
            labelElementDepth.Name = "labelElementDepth";
            labelElementDepth.Size = new Size(400, 15);
            labelElementDepth.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 25);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 0;
            label6.Text = "Hloubka zanoření:";
            // 
            // groupBoxFileInfo
            // 
            groupBoxFileInfo.Controls.Add(labelMaxDepth);
            groupBoxFileInfo.Controls.Add(labelMaxAttributes);
            groupBoxFileInfo.Controls.Add(labelMinAttributes);
            groupBoxFileInfo.Controls.Add(labelMaxChildren);
            groupBoxFileInfo.Controls.Add(labelFileName);
            groupBoxFileInfo.Controls.Add(label5);
            groupBoxFileInfo.Controls.Add(label4);
            groupBoxFileInfo.Controls.Add(label3);
            groupBoxFileInfo.Controls.Add(label2);
            groupBoxFileInfo.Controls.Add(label1);
            groupBoxFileInfo.Dock = DockStyle.Top;
            groupBoxFileInfo.Location = new Point(0, 0);
            groupBoxFileInfo.Name = "groupBoxFileInfo";
            groupBoxFileInfo.Padding = new Padding(10);
            groupBoxFileInfo.Size = new Size(600, 180);
            groupBoxFileInfo.TabIndex = 0;
            groupBoxFileInfo.TabStop = false;
            groupBoxFileInfo.Text = "Informace o souboru";
            // 
            // labelMaxDepth
            // 
            labelMaxDepth.Location = new Point(150, 50);
            labelMaxDepth.Name = "labelMaxDepth";
            labelMaxDepth.Size = new Size(400, 15);
            labelMaxDepth.TabIndex = 3;
            // 
            // labelMaxAttributes
            // 
            labelMaxAttributes.Location = new Point(150, 125);
            labelMaxAttributes.Name = "labelMaxAttributes";
            labelMaxAttributes.Size = new Size(400, 15);
            labelMaxAttributes.TabIndex = 9;
            // 
            // labelMinAttributes
            // 
            labelMinAttributes.Location = new Point(150, 100);
            labelMinAttributes.Name = "labelMinAttributes";
            labelMinAttributes.Size = new Size(400, 15);
            labelMinAttributes.TabIndex = 7;
            // 
            // labelMaxChildren
            // 
            labelMaxChildren.Location = new Point(150, 75);
            labelMaxChildren.Name = "labelMaxChildren";
            labelMaxChildren.Size = new Size(400, 15);
            labelMaxChildren.TabIndex = 5;
            // 
            // labelFileName
            // 
            labelFileName.Location = new Point(150, 25);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(400, 15);
            labelFileName.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 125);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 8;
            label5.Text = "Max. počet atributů:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 100);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 6;
            label4.Text = "Min. počet atributů:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 75);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 4;
            label3.Text = "Max. počet potomků:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 50);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 2;
            label2.Text = "Maximální hloubka:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Název souboru:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(splitContainerMain);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XML Tree Editor";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            groupBoxElementInfo.ResumeLayout(false);
            groupBoxElementInfo.PerformLayout();
            groupBoxFileInfo.ResumeLayout(false);
            groupBoxFileInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonOpen;
        private ToolStripButton toolStripButtonSave;
        private ToolStripButton toolStripButtonClose;
        private SplitContainer splitContainerMain;
        private TreeView treeViewXml;
        private GroupBox groupBoxElementInfo;
        private GroupBox groupBoxFileInfo;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label labelMaxAttributes;
        private Label labelMinAttributes;
        private Label labelMaxChildren;
        private Label labelFileName;
        private Label labelMaxDepth;
        private Label labelElementText;
        private Label label12;
        private Label labelElementAttributes;
        private Label label10;
        private Label labelElementPosition;
        private Label label8;
        private Label labelElementDepth;
        private Label label6;
    }
}
