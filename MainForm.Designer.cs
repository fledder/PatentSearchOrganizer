namespace PatentSearchOrganizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("8765432");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("8776543");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("References", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("9987654");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("9988765");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Referenced By", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("9876543", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.tree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbHighlyRelevant = new System.Windows.Forms.Button();
            this.pbSomewhatRelevant = new System.Windows.Forms.Button();
            this.pbMinimallyRelevant = new System.Windows.Forms.Button();
            this.pbNotRelevant = new System.Windows.Forms.Button();
            this.figures = new System.Windows.Forms.TabPage();
            this.lastImageButton = new System.Windows.Forms.Button();
            this.nextImageButton = new System.Windows.Forms.Button();
            this.previousImageButton = new System.Windows.Forms.Button();
            this.firstImageButton = new System.Windows.Forms.Button();
            this.figurePictureBox = new System.Windows.Forms.PictureBox();
            this.specification = new System.Windows.Forms.TabPage();
            this.specificationBrowser = new System.Windows.Forms.WebBrowser();
            this.briefData = new System.Windows.Forms.TabPage();
            this.claimsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.itemAbstract = new System.Windows.Forms.RichTextBox();
            this.itemTitle = new System.Windows.Forms.Label();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.fetchDataGoogleButton = new System.Windows.Forms.Button();
            this.addUSButton = new System.Windows.Forms.Button();
            this.patPubTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cpcSearchButton = new System.Windows.Forms.Button();
            this.cpcSearchTerm = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.figures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.figurePictureBox)).BeginInit();
            this.specification.SuspendLayout();
            this.briefData.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tree.Location = new System.Drawing.Point(12, 61);
            this.tree.Name = "tree";
            treeNode1.Name = "8765432";
            treeNode1.Text = "8765432";
            treeNode2.Name = "8776543";
            treeNode2.Text = "8776543";
            treeNode3.Name = "References";
            treeNode3.Text = "References";
            treeNode4.Name = "9987654";
            treeNode4.Text = "9987654";
            treeNode5.Name = "9988765";
            treeNode5.Text = "9988765";
            treeNode6.Name = "Referenced By";
            treeNode6.Text = "Referenced By";
            treeNode7.Name = "9876543";
            treeNode7.Text = "9876543";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.tree.Size = new System.Drawing.Size(183, 544);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pbHighlyRelevant
            // 
            this.pbHighlyRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHighlyRelevant.Location = new System.Drawing.Point(729, 83);
            this.pbHighlyRelevant.Name = "pbHighlyRelevant";
            this.pbHighlyRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbHighlyRelevant.TabIndex = 3;
            this.pbHighlyRelevant.Text = "Highly Relevant";
            this.pbHighlyRelevant.UseVisualStyleBackColor = true;
            // 
            // pbSomewhatRelevant
            // 
            this.pbSomewhatRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSomewhatRelevant.Location = new System.Drawing.Point(729, 116);
            this.pbSomewhatRelevant.Name = "pbSomewhatRelevant";
            this.pbSomewhatRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbSomewhatRelevant.TabIndex = 3;
            this.pbSomewhatRelevant.Text = "Somewhat Relevant";
            this.pbSomewhatRelevant.UseVisualStyleBackColor = true;
            // 
            // pbMinimallyRelevant
            // 
            this.pbMinimallyRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimallyRelevant.Location = new System.Drawing.Point(729, 149);
            this.pbMinimallyRelevant.Name = "pbMinimallyRelevant";
            this.pbMinimallyRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbMinimallyRelevant.TabIndex = 3;
            this.pbMinimallyRelevant.Text = "Minimally Relevant";
            this.pbMinimallyRelevant.UseVisualStyleBackColor = true;
            // 
            // pbNotRelevant
            // 
            this.pbNotRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNotRelevant.Location = new System.Drawing.Point(729, 182);
            this.pbNotRelevant.Name = "pbNotRelevant";
            this.pbNotRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbNotRelevant.TabIndex = 3;
            this.pbNotRelevant.Text = "Not Relevant (Suppress)";
            this.pbNotRelevant.UseVisualStyleBackColor = true;
            // 
            // figures
            // 
            this.figures.Controls.Add(this.lastImageButton);
            this.figures.Controls.Add(this.nextImageButton);
            this.figures.Controls.Add(this.previousImageButton);
            this.figures.Controls.Add(this.firstImageButton);
            this.figures.Controls.Add(this.figurePictureBox);
            this.figures.Location = new System.Drawing.Point(4, 22);
            this.figures.Name = "figures";
            this.figures.Padding = new System.Windows.Forms.Padding(3);
            this.figures.Size = new System.Drawing.Size(514, 518);
            this.figures.TabIndex = 1;
            this.figures.Text = "Figures";
            this.figures.UseVisualStyleBackColor = true;
            // 
            // lastImageButton
            // 
            this.lastImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lastImageButton.Location = new System.Drawing.Point(433, 4);
            this.lastImageButton.Name = "lastImageButton";
            this.lastImageButton.Size = new System.Drawing.Size(75, 23);
            this.lastImageButton.TabIndex = 1;
            this.lastImageButton.Text = "Last";
            this.lastImageButton.UseVisualStyleBackColor = true;
            this.lastImageButton.Click += new System.EventHandler(this.lastImageButton_Click);
            // 
            // nextImageButton
            // 
            this.nextImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextImageButton.Location = new System.Drawing.Point(352, 4);
            this.nextImageButton.Name = "nextImageButton";
            this.nextImageButton.Size = new System.Drawing.Size(75, 23);
            this.nextImageButton.TabIndex = 1;
            this.nextImageButton.Text = "Next";
            this.nextImageButton.UseVisualStyleBackColor = true;
            this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
            // 
            // previousImageButton
            // 
            this.previousImageButton.Location = new System.Drawing.Point(87, 4);
            this.previousImageButton.Name = "previousImageButton";
            this.previousImageButton.Size = new System.Drawing.Size(75, 23);
            this.previousImageButton.TabIndex = 1;
            this.previousImageButton.Text = "Previous";
            this.previousImageButton.UseVisualStyleBackColor = true;
            this.previousImageButton.Click += new System.EventHandler(this.previousImageButton_Click);
            // 
            // firstImageButton
            // 
            this.firstImageButton.Location = new System.Drawing.Point(6, 4);
            this.firstImageButton.Name = "firstImageButton";
            this.firstImageButton.Size = new System.Drawing.Size(75, 23);
            this.firstImageButton.TabIndex = 1;
            this.firstImageButton.Text = "First";
            this.firstImageButton.UseVisualStyleBackColor = true;
            this.firstImageButton.Click += new System.EventHandler(this.firstImageButton_Click);
            // 
            // figurePictureBox
            // 
            this.figurePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.figurePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.figurePictureBox.Location = new System.Drawing.Point(6, 33);
            this.figurePictureBox.Name = "figurePictureBox";
            this.figurePictureBox.Size = new System.Drawing.Size(502, 479);
            this.figurePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.figurePictureBox.TabIndex = 0;
            this.figurePictureBox.TabStop = false;
            // 
            // specification
            // 
            this.specification.Controls.Add(this.specificationBrowser);
            this.specification.Location = new System.Drawing.Point(4, 22);
            this.specification.Name = "specification";
            this.specification.Padding = new System.Windows.Forms.Padding(3);
            this.specification.Size = new System.Drawing.Size(514, 518);
            this.specification.TabIndex = 3;
            this.specification.Text = "Specification";
            this.specification.UseVisualStyleBackColor = true;
            // 
            // specificationBrowser
            // 
            this.specificationBrowser.AllowNavigation = false;
            this.specificationBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationBrowser.Location = new System.Drawing.Point(3, 3);
            this.specificationBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.specificationBrowser.Name = "specificationBrowser";
            this.specificationBrowser.Size = new System.Drawing.Size(508, 512);
            this.specificationBrowser.TabIndex = 0;
            // 
            // briefData
            // 
            this.briefData.Controls.Add(this.claimsWebBrowser);
            this.briefData.Controls.Add(this.itemAbstract);
            this.briefData.Controls.Add(this.itemTitle);
            this.briefData.Location = new System.Drawing.Point(4, 22);
            this.briefData.Name = "briefData";
            this.briefData.Padding = new System.Windows.Forms.Padding(3);
            this.briefData.Size = new System.Drawing.Size(514, 518);
            this.briefData.TabIndex = 0;
            this.briefData.Text = "Brief Overview";
            this.briefData.UseVisualStyleBackColor = true;
            // 
            // claimsWebBrowser
            // 
            this.claimsWebBrowser.AllowNavigation = false;
            this.claimsWebBrowser.Location = new System.Drawing.Point(7, 172);
            this.claimsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.claimsWebBrowser.Name = "claimsWebBrowser";
            this.claimsWebBrowser.Size = new System.Drawing.Size(501, 343);
            this.claimsWebBrowser.TabIndex = 2;
            // 
            // itemAbstract
            // 
            this.itemAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemAbstract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.itemAbstract.Location = new System.Drawing.Point(7, 46);
            this.itemAbstract.Name = "itemAbstract";
            this.itemAbstract.Size = new System.Drawing.Size(501, 120);
            this.itemAbstract.TabIndex = 1;
            this.itemAbstract.Text = "";
            // 
            // itemTitle
            // 
            this.itemTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.itemTitle.Location = new System.Drawing.Point(3, 3);
            this.itemTitle.Name = "itemTitle";
            this.itemTitle.Size = new System.Drawing.Size(505, 40);
            this.itemTitle.TabIndex = 0;
            this.itemTitle.Text = "Title of the Item";
            this.itemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainTabs
            // 
            this.mainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabs.Controls.Add(this.briefData);
            this.mainTabs.Controls.Add(this.specification);
            this.mainTabs.Controls.Add(this.figures);
            this.mainTabs.Location = new System.Drawing.Point(201, 61);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(522, 544);
            this.mainTabs.TabIndex = 2;
            // 
            // fetchDataGoogleButton
            // 
            this.fetchDataGoogleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fetchDataGoogleButton.Location = new System.Drawing.Point(729, 233);
            this.fetchDataGoogleButton.Name = "fetchDataGoogleButton";
            this.fetchDataGoogleButton.Size = new System.Drawing.Size(144, 27);
            this.fetchDataGoogleButton.TabIndex = 4;
            this.fetchDataGoogleButton.Text = "Fetch Data (Google)";
            this.fetchDataGoogleButton.UseVisualStyleBackColor = true;
            this.fetchDataGoogleButton.Click += new System.EventHandler(this.fetchDataGoogleButton_Click);
            // 
            // addUSButton
            // 
            this.addUSButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addUSButton.Location = new System.Drawing.Point(729, 343);
            this.addUSButton.Name = "addUSButton";
            this.addUSButton.Size = new System.Drawing.Size(144, 27);
            this.addUSButton.TabIndex = 5;
            this.addUSButton.Text = "Add US patent / pub";
            this.addUSButton.UseVisualStyleBackColor = true;
            this.addUSButton.Click += new System.EventHandler(this.addUSButton_Click);
            // 
            // patPubTextBox
            // 
            this.patPubTextBox.Location = new System.Drawing.Point(725, 317);
            this.patPubTextBox.Mask = "00000000000";
            this.patPubTextBox.Name = "patPubTextBox";
            this.patPubTextBox.Size = new System.Drawing.Size(148, 20);
            this.patPubTextBox.TabIndex = 6;
            // 
            // cpcSearchButton
            // 
            this.cpcSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpcSearchButton.Location = new System.Drawing.Point(729, 482);
            this.cpcSearchButton.Name = "cpcSearchButton";
            this.cpcSearchButton.Size = new System.Drawing.Size(144, 27);
            this.cpcSearchButton.TabIndex = 7;
            this.cpcSearchButton.Text = "CPC search";
            this.cpcSearchButton.UseVisualStyleBackColor = true;
            this.cpcSearchButton.Click += new System.EventHandler(this.cpcSearchButton_Click);
            // 
            // cpcSearchTerm
            // 
            this.cpcSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpcSearchTerm.Location = new System.Drawing.Point(729, 456);
            this.cpcSearchTerm.Name = "cpcSearchTerm";
            this.cpcSearchTerm.Size = new System.Drawing.Size(143, 20);
            this.cpcSearchTerm.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 617);
            this.Controls.Add(this.cpcSearchTerm);
            this.Controls.Add(this.cpcSearchButton);
            this.Controls.Add(this.patPubTextBox);
            this.Controls.Add(this.addUSButton);
            this.Controls.Add(this.fetchDataGoogleButton);
            this.Controls.Add(this.pbNotRelevant);
            this.Controls.Add(this.pbMinimallyRelevant);
            this.Controls.Add(this.pbSomewhatRelevant);
            this.Controls.Add(this.pbHighlyRelevant);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Patent Search Organizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.figures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.figurePictureBox)).EndInit();
            this.specification.ResumeLayout(false);
            this.briefData.ResumeLayout(false);
            this.mainTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button pbHighlyRelevant;
        private System.Windows.Forms.Button pbSomewhatRelevant;
        private System.Windows.Forms.Button pbMinimallyRelevant;
        private System.Windows.Forms.Button pbNotRelevant;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabPage figures;
        private System.Windows.Forms.Button lastImageButton;
        private System.Windows.Forms.Button nextImageButton;
        private System.Windows.Forms.Button previousImageButton;
        private System.Windows.Forms.Button firstImageButton;
        private System.Windows.Forms.PictureBox figurePictureBox;
        private System.Windows.Forms.TabPage specification;
        private System.Windows.Forms.WebBrowser specificationBrowser;
        private System.Windows.Forms.TabPage briefData;
        private System.Windows.Forms.WebBrowser claimsWebBrowser;
        private System.Windows.Forms.RichTextBox itemAbstract;
        private System.Windows.Forms.Label itemTitle;
        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.Button fetchDataGoogleButton;
        private System.Windows.Forms.Button addUSButton;
        private System.Windows.Forms.MaskedTextBox patPubTextBox;
        private System.Windows.Forms.Button cpcSearchButton;
        private System.Windows.Forms.TextBox cpcSearchTerm;
    }
}

