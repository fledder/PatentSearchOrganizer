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
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("8765432");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("8776543");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("References", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("9987654");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("9988765");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Referenced By", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("9876543", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbHighlyRelevant = new System.Windows.Forms.Button();
            this.pbModeratelyRelevant = new System.Windows.Forms.Button();
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
            this.notYetReviewedButton = new System.Windows.Forms.Button();
            this.cbNonRelevant = new System.Windows.Forms.CheckBox();
            this.pbFetchAllGoogle = new System.Windows.Forms.Button();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSave = new System.Windows.Forms.Button();
            this.pbDelete = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.figures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.figurePictureBox)).BeginInit();
            this.specification.SuspendLayout();
            this.briefData.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tree.Location = new System.Drawing.Point(12, 61);
            this.tree.Name = "tree";
            treeNode8.Name = "8765432";
            treeNode8.Text = "8765432";
            treeNode9.Name = "8776543";
            treeNode9.Text = "8776543";
            treeNode10.Name = "References";
            treeNode10.Text = "References";
            treeNode11.Name = "9987654";
            treeNode11.Text = "9987654";
            treeNode12.Name = "9988765";
            treeNode12.Text = "9988765";
            treeNode13.Name = "Referenced By";
            treeNode13.Text = "Referenced By";
            treeNode14.Name = "9876543";
            treeNode14.Text = "9876543";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.tree.Size = new System.Drawing.Size(183, 521);
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
            this.pbHighlyRelevant.Location = new System.Drawing.Point(729, 116);
            this.pbHighlyRelevant.Name = "pbHighlyRelevant";
            this.pbHighlyRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbHighlyRelevant.TabIndex = 3;
            this.pbHighlyRelevant.Text = "Highly Relevant";
            this.pbHighlyRelevant.UseVisualStyleBackColor = true;
            this.pbHighlyRelevant.Click += new System.EventHandler(this.pbHighlyRelevant_Click);
            // 
            // pbModeratelyRelevant
            // 
            this.pbModeratelyRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbModeratelyRelevant.Location = new System.Drawing.Point(729, 149);
            this.pbModeratelyRelevant.Name = "pbModeratelyRelevant";
            this.pbModeratelyRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbModeratelyRelevant.TabIndex = 3;
            this.pbModeratelyRelevant.Text = "Moderately Relevant";
            this.pbModeratelyRelevant.UseVisualStyleBackColor = true;
            this.pbModeratelyRelevant.Click += new System.EventHandler(this.pbModeratelyRelevant_Click);
            // 
            // pbMinimallyRelevant
            // 
            this.pbMinimallyRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimallyRelevant.Location = new System.Drawing.Point(729, 182);
            this.pbMinimallyRelevant.Name = "pbMinimallyRelevant";
            this.pbMinimallyRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbMinimallyRelevant.TabIndex = 3;
            this.pbMinimallyRelevant.Text = "Minimally Relevant";
            this.pbMinimallyRelevant.UseVisualStyleBackColor = true;
            this.pbMinimallyRelevant.Click += new System.EventHandler(this.pbMinimallyRelevant_Click);
            // 
            // pbNotRelevant
            // 
            this.pbNotRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNotRelevant.Location = new System.Drawing.Point(729, 215);
            this.pbNotRelevant.Name = "pbNotRelevant";
            this.pbNotRelevant.Size = new System.Drawing.Size(144, 27);
            this.pbNotRelevant.TabIndex = 3;
            this.pbNotRelevant.Text = "Not Relevant (Suppress)";
            this.pbNotRelevant.UseVisualStyleBackColor = true;
            this.pbNotRelevant.Click += new System.EventHandler(this.pbNotRelevant_Click);
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
            this.figures.Size = new System.Drawing.Size(514, 393);
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
            this.specification.Size = new System.Drawing.Size(514, 393);
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
            this.specificationBrowser.Size = new System.Drawing.Size(508, 387);
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
            this.briefData.Size = new System.Drawing.Size(514, 393);
            this.briefData.TabIndex = 0;
            this.briefData.Text = "Brief Overview";
            this.briefData.UseVisualStyleBackColor = true;
            // 
            // claimsWebBrowser
            // 
            this.claimsWebBrowser.AllowNavigation = false;
            this.claimsWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.claimsWebBrowser.Location = new System.Drawing.Point(7, 191);
            this.claimsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.claimsWebBrowser.Name = "claimsWebBrowser";
            this.claimsWebBrowser.Size = new System.Drawing.Size(501, 199);
            this.claimsWebBrowser.TabIndex = 2;
            // 
            // itemAbstract
            // 
            this.itemAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemAbstract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.itemAbstract.Location = new System.Drawing.Point(7, 66);
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
            this.itemTitle.Size = new System.Drawing.Size(505, 57);
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
            this.mainTabs.Size = new System.Drawing.Size(522, 419);
            this.mainTabs.TabIndex = 2;
            // 
            // fetchDataGoogleButton
            // 
            this.fetchDataGoogleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fetchDataGoogleButton.Location = new System.Drawing.Point(729, 320);
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
            this.addUSButton.Location = new System.Drawing.Point(729, 455);
            this.addUSButton.Name = "addUSButton";
            this.addUSButton.Size = new System.Drawing.Size(144, 27);
            this.addUSButton.TabIndex = 5;
            this.addUSButton.Text = "Add US patent / pub";
            this.addUSButton.UseVisualStyleBackColor = true;
            this.addUSButton.Click += new System.EventHandler(this.addUSButton_Click);
            // 
            // patPubTextBox
            // 
            this.patPubTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.patPubTextBox.Location = new System.Drawing.Point(725, 429);
            this.patPubTextBox.Mask = "00000000000";
            this.patPubTextBox.Name = "patPubTextBox";
            this.patPubTextBox.Size = new System.Drawing.Size(148, 20);
            this.patPubTextBox.TabIndex = 6;
            // 
            // cpcSearchButton
            // 
            this.cpcSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpcSearchButton.Location = new System.Drawing.Point(729, 548);
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
            this.cpcSearchTerm.Location = new System.Drawing.Point(729, 522);
            this.cpcSearchTerm.Name = "cpcSearchTerm";
            this.cpcSearchTerm.Size = new System.Drawing.Size(143, 20);
            this.cpcSearchTerm.TabIndex = 8;
            // 
            // notYetReviewedButton
            // 
            this.notYetReviewedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notYetReviewedButton.Location = new System.Drawing.Point(729, 83);
            this.notYetReviewedButton.Name = "notYetReviewedButton";
            this.notYetReviewedButton.Size = new System.Drawing.Size(144, 27);
            this.notYetReviewedButton.TabIndex = 3;
            this.notYetReviewedButton.Text = "Not Yet Reviewed";
            this.notYetReviewedButton.UseVisualStyleBackColor = true;
            this.notYetReviewedButton.Click += new System.EventHandler(this.notYetReviewedButton_Click);
            // 
            // cbNonRelevant
            // 
            this.cbNonRelevant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbNonRelevant.AutoSize = true;
            this.cbNonRelevant.Location = new System.Drawing.Point(12, 588);
            this.cbNonRelevant.Name = "cbNonRelevant";
            this.cbNonRelevant.Size = new System.Drawing.Size(122, 17);
            this.cbNonRelevant.TabIndex = 9;
            this.cbNonRelevant.Text = "Show Non-Relevant";
            this.cbNonRelevant.UseVisualStyleBackColor = true;
            this.cbNonRelevant.CheckedChanged += new System.EventHandler(this.cbNonRelevant_CheckedChanged);
            // 
            // pbFetchAllGoogle
            // 
            this.pbFetchAllGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFetchAllGoogle.Location = new System.Drawing.Point(729, 353);
            this.pbFetchAllGoogle.Name = "pbFetchAllGoogle";
            this.pbFetchAllGoogle.Size = new System.Drawing.Size(144, 27);
            this.pbFetchAllGoogle.TabIndex = 10;
            this.pbFetchAllGoogle.Text = "Fetch All (Google)";
            this.pbFetchAllGoogle.UseVisualStyleBackColor = true;
            this.pbFetchAllGoogle.Click += new System.EventHandler(this.pbFetchAllGoogle_Click);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNotes.Location = new System.Drawing.Point(205, 510);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(452, 72);
            this.rtbNotes.TabIndex = 11;
            this.rtbNotes.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Notes";
            // 
            // pbSave
            // 
            this.pbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSave.Location = new System.Drawing.Point(663, 510);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(56, 72);
            this.pbSave.TabIndex = 13;
            this.pbSave.Text = "Save";
            this.pbSave.UseVisualStyleBackColor = true;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDelete.Location = new System.Drawing.Point(729, 248);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(144, 27);
            this.pbDelete.TabIndex = 3;
            this.pbDelete.Text = "Permanently Delete";
            this.pbDelete.UseVisualStyleBackColor = true;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(885, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "tsbRefresh";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 617);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.pbFetchAllGoogle);
            this.Controls.Add(this.cbNonRelevant);
            this.Controls.Add(this.cpcSearchTerm);
            this.Controls.Add(this.cpcSearchButton);
            this.Controls.Add(this.patPubTextBox);
            this.Controls.Add(this.addUSButton);
            this.Controls.Add(this.fetchDataGoogleButton);
            this.Controls.Add(this.pbDelete);
            this.Controls.Add(this.pbNotRelevant);
            this.Controls.Add(this.pbMinimallyRelevant);
            this.Controls.Add(this.pbModeratelyRelevant);
            this.Controls.Add(this.notYetReviewedButton);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button pbHighlyRelevant;
        private System.Windows.Forms.Button pbModeratelyRelevant;
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
        private System.Windows.Forms.Button notYetReviewedButton;
        private System.Windows.Forms.CheckBox cbNonRelevant;
        private System.Windows.Forms.Button pbFetchAllGoogle;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pbSave;
        private System.Windows.Forms.Button pbDelete;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

