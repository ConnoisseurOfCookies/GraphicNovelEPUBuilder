namespace epubGUI
{
    partial class EPUBGraphNovelCreate
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
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("One folder = One volume");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Only image files in folder");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Naming convention under labeling");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Ensure naming is chronological and correct", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("If compiling from multiple folders folder name will be appended to Title");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("If multiple, make sure that Cover photo is first (p000)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Bulk renaming folders follows Title-Volume naming convention");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Folder Structure", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Optional can be anything as long as it doesn\'t match another pattern");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Name(opt)-Chapter-Page-(opt)", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Chapters: -000, -001 or c000, c001 etc.");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Pages: p000, p001, etc.");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Volume: (v01), (v02), etc.");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Consider using a bulk renaming utility if dealing with a high volume");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Labeling(files)", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Lossy compression, jpeg format, images only");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("More Quality = Bigger files, Kindle Email Limits you to only 50mb");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("20, the default, looks OK and puts a 200+ page novel(300mb+) down to about 45mb");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("0 looks atrocious, not recommended");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("100 is basically no compression at all, works for shorter comics");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Compression", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("1. Select source folder");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("2. Make sure folder only has image files");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("3. Make sure files are ordered");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("4. If you want to be able to navigate chapters use chapter naming convention");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("5. If you need to rename files from multiple folders select the parent folder and" +
        " tick the \"Multiple\" box");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("File Names", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("1. Select Folder");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("2. Make sure folders are ordered");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("3. Specify Title");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("4. Voila!");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Folder Names", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Bulk Renaming tools", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode32});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPUBGraphNovelCreate));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSrceDir = new System.Windows.Forms.Button();
            this.btnTrgtDir = new System.Windows.Forms.Button();
            this.txbSource = new System.Windows.Forms.TextBox();
            this.txbTrgt = new System.Windows.Forms.TextBox();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuth = new System.Windows.Forms.Label();
            this.txbAuth = new System.Windows.Forms.TextBox();
            this.lblDescr = new System.Windows.Forms.Label();
            this.txbDscr = new System.Windows.Forms.TextBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.txbLang = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.txbTags = new System.Windows.Forms.TextBox();
            this.cbxMultiFile = new System.Windows.Forms.CheckBox();
            this.coverPreview = new System.Windows.Forms.PictureBox();
            this.btnCoverPrev = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblRules = new System.Windows.Forms.Label();
            this.lblBusy = new System.Windows.Forms.Label();
            this.barCompression = new System.Windows.Forms.TrackBar();
            this.lblCompression = new System.Windows.Forms.Label();
            this.lblWhile = new System.Windows.Forms.Label();
            this.lblDone = new System.Windows.Forms.Label();
            this.btnFilenameChanger = new System.Windows.Forms.Button();
            this.btnFolderNamechanger = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coverPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCompression)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(708, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.CloseApplication);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(592, 432);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 40);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.Generate);
            // 
            // btnSrceDir
            // 
            this.btnSrceDir.Location = new System.Drawing.Point(12, 22);
            this.btnSrceDir.Name = "btnSrceDir";
            this.btnSrceDir.Size = new System.Drawing.Size(110, 23);
            this.btnSrceDir.TabIndex = 2;
            this.btnSrceDir.Text = "Source Directory";
            this.btnSrceDir.UseVisualStyleBackColor = true;
            this.btnSrceDir.Click += new System.EventHandler(this.btnSrceDir_Click);
            // 
            // btnTrgtDir
            // 
            this.btnTrgtDir.Location = new System.Drawing.Point(12, 51);
            this.btnTrgtDir.Name = "btnTrgtDir";
            this.btnTrgtDir.Size = new System.Drawing.Size(110, 23);
            this.btnTrgtDir.TabIndex = 3;
            this.btnTrgtDir.Text = "Target Directory";
            this.btnTrgtDir.UseVisualStyleBackColor = true;
            this.btnTrgtDir.Click += new System.EventHandler(this.btnTrgtDir_Click);
            // 
            // txbSource
            // 
            this.txbSource.Location = new System.Drawing.Point(128, 25);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(165, 23);
            this.txbSource.TabIndex = 5;
            // 
            // txbTrgt
            // 
            this.txbTrgt.Location = new System.Drawing.Point(128, 52);
            this.txbTrgt.Name = "txbTrgt";
            this.txbTrgt.Size = new System.Drawing.Size(165, 23);
            this.txbTrgt.TabIndex = 6;
            // 
            // txbTitle
            // 
            this.txbTitle.Location = new System.Drawing.Point(662, 40);
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.Size = new System.Drawing.Size(156, 23);
            this.txbTitle.TabIndex = 7;
            this.txbTitle.TextChanged += new System.EventHandler(this.txbTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(660, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 15);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.Location = new System.Drawing.Point(662, 66);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(44, 15);
            this.lblAuth.TabIndex = 10;
            this.lblAuth.Text = "Author";
            this.lblAuth.Click += new System.EventHandler(this.lblAuth_Click);
            // 
            // txbAuth
            // 
            this.txbAuth.Location = new System.Drawing.Point(662, 84);
            this.txbAuth.Name = "txbAuth";
            this.txbAuth.Size = new System.Drawing.Size(156, 23);
            this.txbAuth.TabIndex = 9;
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Location = new System.Drawing.Point(662, 110);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(67, 15);
            this.lblDescr.TabIndex = 12;
            this.lblDescr.Text = "Description";
            this.lblDescr.Click += new System.EventHandler(this.lblDescr_Click);
            // 
            // txbDscr
            // 
            this.txbDscr.Location = new System.Drawing.Point(662, 128);
            this.txbDscr.Multiline = true;
            this.txbDscr.Name = "txbDscr";
            this.txbDscr.Size = new System.Drawing.Size(156, 110);
            this.txbDscr.TabIndex = 11;
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Location = new System.Drawing.Point(662, 285);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(131, 15);
            this.lblLang.TabIndex = 16;
            this.lblLang.Text = "Language(Abbreviated)";
            // 
            // txbLang
            // 
            this.txbLang.Location = new System.Drawing.Point(660, 303);
            this.txbLang.Name = "txbLang";
            this.txbLang.Size = new System.Drawing.Size(156, 23);
            this.txbLang.TabIndex = 15;
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(660, 241);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(30, 15);
            this.lblTags.TabIndex = 14;
            this.lblTags.Text = "Tags";
            // 
            // txbTags
            // 
            this.txbTags.Location = new System.Drawing.Point(660, 259);
            this.txbTags.Name = "txbTags";
            this.txbTags.Size = new System.Drawing.Size(156, 23);
            this.txbTags.TabIndex = 13;
            this.txbTags.TextChanged += new System.EventHandler(this.txbTags_TextChanged);
            // 
            // cbxMultiFile
            // 
            this.cbxMultiFile.AutoSize = true;
            this.cbxMultiFile.Location = new System.Drawing.Point(299, 25);
            this.cbxMultiFile.Name = "cbxMultiFile";
            this.cbxMultiFile.Size = new System.Drawing.Size(175, 19);
            this.cbxMultiFile.TabIndex = 19;
            this.cbxMultiFile.Text = "Multible Folders In Directory";
            this.cbxMultiFile.UseVisualStyleBackColor = true;
            this.cbxMultiFile.CheckedChanged += new System.EventHandler(this.cbxMultiFile_CheckedChanged);
            // 
            // coverPreview
            // 
            this.coverPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coverPreview.Location = new System.Drawing.Point(12, 241);
            this.coverPreview.Name = "coverPreview";
            this.coverPreview.Size = new System.Drawing.Size(291, 231);
            this.coverPreview.TabIndex = 20;
            this.coverPreview.TabStop = false;
            // 
            // btnCoverPrev
            // 
            this.btnCoverPrev.Location = new System.Drawing.Point(12, 194);
            this.btnCoverPrev.Name = "btnCoverPrev";
            this.btnCoverPrev.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCoverPrev.Size = new System.Drawing.Size(110, 35);
            this.btnCoverPrev.TabIndex = 21;
            this.btnCoverPrev.Text = "Cover Photo";
            this.btnCoverPrev.UseVisualStyleBackColor = true;
            this.btnCoverPrev.Click += new System.EventHandler(this.btnCoverPrev_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(309, 92);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "One folder = One volume";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Only image files in folder";
            treeNode3.Name = "Node18";
            treeNode3.Text = "Naming convention under labeling";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Ensure naming is chronological and correct";
            treeNode5.Name = "Node10";
            treeNode5.Text = "If compiling from multiple folders folder name will be appended to Title";
            treeNode6.Name = "Node11";
            treeNode6.Text = "If multiple, make sure that Cover photo is first (p000)";
            treeNode7.Name = "Node20";
            treeNode7.Text = "Bulk renaming folders follows Title-Volume naming convention";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Folder Structure";
            treeNode9.Name = "Node7";
            treeNode9.Text = "Optional can be anything as long as it doesn\'t match another pattern";
            treeNode10.Name = "Node6";
            treeNode10.Text = "Name(opt)-Chapter-Page-(opt)";
            treeNode11.Name = "Node8";
            treeNode11.Text = "Chapters: -000, -001 or c000, c001 etc.";
            treeNode12.Name = "Node5";
            treeNode12.Text = "Pages: p000, p001, etc.";
            treeNode13.Name = "Node9";
            treeNode13.Text = "Volume: (v01), (v02), etc.";
            treeNode14.Name = "Node19";
            treeNode14.Text = "Consider using a bulk renaming utility if dealing with a high volume";
            treeNode15.Name = "Node4";
            treeNode15.Text = "Labeling(files)";
            treeNode16.Name = "Node17";
            treeNode16.Text = "Lossy compression, jpeg format, images only";
            treeNode17.Name = "Node13";
            treeNode17.Text = "More Quality = Bigger files, Kindle Email Limits you to only 50mb";
            treeNode18.Name = "Node14";
            treeNode18.Text = "20, the default, looks OK and puts a 200+ page novel(300mb+) down to about 45mb";
            treeNode19.Name = "Node15";
            treeNode19.Text = "0 looks atrocious, not recommended";
            treeNode20.Name = "Node16";
            treeNode20.Text = "100 is basically no compression at all, works for shorter comics";
            treeNode21.Name = "Node12";
            treeNode21.Text = "Compression";
            treeNode22.Name = "Node24";
            treeNode22.Text = "1. Select source folder";
            treeNode23.Name = "Node25";
            treeNode23.Text = "2. Make sure folder only has image files";
            treeNode24.Name = "Node26";
            treeNode24.Text = "3. Make sure files are ordered";
            treeNode25.Name = "Node27";
            treeNode25.Text = "4. If you want to be able to navigate chapters use chapter naming convention";
            treeNode26.Name = "Node28";
            treeNode26.Text = "5. If you need to rename files from multiple folders select the parent folder and" +
    " tick the \"Multiple\" box";
            treeNode27.Name = "Node22";
            treeNode27.Text = "File Names";
            treeNode28.Name = "Node29";
            treeNode28.Text = "1. Select Folder";
            treeNode29.Name = "Node30";
            treeNode29.Text = "2. Make sure folders are ordered";
            treeNode30.Name = "Node31";
            treeNode30.Text = "3. Specify Title";
            treeNode31.Name = "Node32";
            treeNode31.Text = "4. Voila!";
            treeNode32.Name = "Node23";
            treeNode32.Text = "Folder Names";
            treeNode33.Name = "Node21";
            treeNode33.Text = "Bulk Renaming tools";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode15,
            treeNode21,
            treeNode33});
            this.treeView1.Size = new System.Drawing.Size(339, 243);
            this.treeView1.TabIndex = 22;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRules.Location = new System.Drawing.Point(315, 60);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(51, 21);
            this.lblRules.TabIndex = 23;
            this.lblRules.Text = "Guide";
            // 
            // lblBusy
            // 
            this.lblBusy.AutoSize = true;
            this.lblBusy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBusy.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBusy.ForeColor = System.Drawing.Color.DimGray;
            this.lblBusy.Location = new System.Drawing.Point(306, 360);
            this.lblBusy.Margin = new System.Windows.Forms.Padding(0);
            this.lblBusy.Name = "lblBusy";
            this.lblBusy.Size = new System.Drawing.Size(508, 41);
            this.lblBusy.TabIndex = 24;
            this.lblBusy.Text = "Busy Compiling Your Graphic Novel...";
            this.lblBusy.Visible = false;
            // 
            // barCompression
            // 
            this.barCompression.Location = new System.Drawing.Point(12, 149);
            this.barCompression.Maximum = 100;
            this.barCompression.Name = "barCompression";
            this.barCompression.Size = new System.Drawing.Size(297, 45);
            this.barCompression.TabIndex = 25;
            this.barCompression.TickFrequency = 5;
            this.barCompression.Value = 20;
            this.barCompression.Scroll += new System.EventHandler(this.barCompression_Scroll);
            // 
            // lblCompression
            // 
            this.lblCompression.AutoSize = true;
            this.lblCompression.Location = new System.Drawing.Point(12, 131);
            this.lblCompression.Name = "lblCompression";
            this.lblCompression.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCompression.Size = new System.Drawing.Size(63, 15);
            this.lblCompression.TabIndex = 26;
            this.lblCompression.Text = "Quality: 20";
            this.lblCompression.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblWhile
            // 
            this.lblWhile.AutoSize = true;
            this.lblWhile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWhile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWhile.ForeColor = System.Drawing.Color.DimGray;
            this.lblWhile.Location = new System.Drawing.Point(315, 401);
            this.lblWhile.Margin = new System.Windows.Forms.Padding(0);
            this.lblWhile.Name = "lblWhile";
            this.lblWhile.Size = new System.Drawing.Size(143, 19);
            this.lblWhile.TabIndex = 27;
            this.lblWhile.Text = "This May Take a While";
            this.lblWhile.Visible = false;
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDone.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDone.ForeColor = System.Drawing.Color.DimGray;
            this.lblDone.Location = new System.Drawing.Point(309, 360);
            this.lblDone.Margin = new System.Windows.Forms.Padding(0);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(117, 41);
            this.lblDone.TabIndex = 28;
            this.lblDone.Text = "Done!!!";
            this.lblDone.Visible = false;
            this.lblDone.Click += new System.EventHandler(this.lblDone_Click);
            // 
            // btnFilenameChanger
            // 
            this.btnFilenameChanger.Location = new System.Drawing.Point(13, 98);
            this.btnFilenameChanger.Name = "btnFilenameChanger";
            this.btnFilenameChanger.Size = new System.Drawing.Size(140, 30);
            this.btnFilenameChanger.TabIndex = 29;
            this.btnFilenameChanger.Text = "File Names";
            this.btnFilenameChanger.UseVisualStyleBackColor = true;
            this.btnFilenameChanger.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnFolderNamechanger
            // 
            this.btnFolderNamechanger.Location = new System.Drawing.Point(153, 98);
            this.btnFolderNamechanger.Name = "btnFolderNamechanger";
            this.btnFolderNamechanger.Size = new System.Drawing.Size(140, 30);
            this.btnFolderNamechanger.TabIndex = 30;
            this.btnFolderNamechanger.Text = "Folder Names";
            this.btnFolderNamechanger.UseVisualStyleBackColor = true;
            this.btnFolderNamechanger.Click += new System.EventHandler(this.btnFolderNamechanger_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Bulk Rename Files or Folders *Recommended";
            // 
            // EPUBGraphNovelCreate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(824, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFolderNamechanger);
            this.Controls.Add(this.btnFilenameChanger);
            this.Controls.Add(this.lblDone);
            this.Controls.Add(this.lblWhile);
            this.Controls.Add(this.lblCompression);
            this.Controls.Add(this.barCompression);
            this.Controls.Add(this.lblBusy);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnCoverPrev);
            this.Controls.Add(this.coverPreview);
            this.Controls.Add(this.cbxMultiFile);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.txbLang);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.txbTags);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.txbDscr);
            this.Controls.Add(this.lblAuth);
            this.Controls.Add(this.txbAuth);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txbTitle);
            this.Controls.Add(this.txbTrgt);
            this.Controls.Add(this.txbSource);
            this.Controls.Add(this.btnTrgtDir);
            this.Controls.Add(this.btnSrceDir);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EPUBGraphNovelCreate";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Generate Graphic Novel";
            this.Load += new System.EventHandler(this.EPUBGraphNovelCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coverPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCompression)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private Button btnClose;
        private Button btnGenerate;
        private Button btnSrceDir;
        private Button btnTrgtDir;
        private TextBox txbSource;
        private TextBox txbTrgt;
        private TextBox txbTitle;
        private Label lblTitle;
        private Label lblAuth;
        private TextBox txbAuth;
        private Label lblDescr;
        private TextBox txbDscr;
        private Label lblLang;
        private TextBox txbLang;
        private Label lblTags;
        private TextBox txbTags;
        private CheckBox cbxMultiFile;
        private PictureBox coverPreview;
        private Button btnCoverPrev;
        private TreeView treeView1;
        private Label lblRules;
        private Label lblBusy;
        private TrackBar barCompression;
        private Label lblCompression;
        private Label lblWhile;
        private Label lblDone;
        private Button btnFilenameChanger;
        private Button btnFolderNamechanger;
        private Label label1;
    }
}