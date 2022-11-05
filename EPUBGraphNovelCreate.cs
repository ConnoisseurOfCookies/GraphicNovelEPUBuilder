using EpubHandler;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace epubGUI
{
    public partial class EPUBGraphNovelCreate : Form
    {

        public EPUBGraphNovelCreate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void CloseApplication(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private async void Generate(object sender, EventArgs e)
        {

            EPUBSettings settings = new EPUBSettings()
            {
                ContentSource = this.txbSource.Text,
                OutputDirectory = this.txbTrgt.Text,
                Title = this.txbTitle.Text,
                Author = this.txbAuth.Text,
                Description = this.txbDscr.Text,
                Language = this.txbLang.Text,
                Multiple = this.cbxMultiFile.Checked,
                CoverPhoto = this.coverPreview.ImageLocation,
                Compression = this.barCompression.Value
            };
            if(this.txbTags.Text.Length > 0 )
            {
                settings.Tags = this.txbTags.ToString().Split(',').ToList();
            }
          
           

            Task t1 = Task.Run(() => {

                EpubHandler.EPUBParse.BuildEpub(settings);
                
            });


            this.lblBusy.Visible = true;
            this.Cursor = Cursors.AppStarting;
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Cursor = Cursors.No;
            this.lblWhile.Visible = true;
            this.lblDone.Visible = false;

            await t1;

            this.lblDone.Visible = true;
            this.lblWhile.Visible = false;
            this.btnGenerate.Cursor = Cursors.Default;
            this.btnGenerate.Enabled = true;
            this.Cursor = Cursors.Default;
            this.lblBusy.Visible = false;

        }


        private void btnSrceDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog getSrce = new FolderBrowserDialog();
            if(getSrce.ShowDialog() == DialogResult.OK)
            {
                this.txbSource.Text = getSrce.SelectedPath;
            }


        }

        private void EPUBGraphNovelCreate_Load(object sender, EventArgs e)
        {

        }

        private void btnTrgtDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog getSrce = new FolderBrowserDialog();
            if (getSrce.ShowDialog() == DialogResult.OK)
            {
                this.txbTrgt.Text = getSrce.SelectedPath;
            }
        }

        private void cbxMultiFile_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lblAuth_Click(object sender, EventArgs e)
        {

        }

        private void lblDescr_Click(object sender, EventArgs e)
        {

        }

        private void txbTags_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCoverPrev_Click(object sender, EventArgs e)
        {
            if(this.txbSource.Text.Length == 0 || this.txbSource.Text == null) 
            {
                return; 
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();   
            openFileDialog.InitialDirectory = this.btnSrceDir.Text;
            openFileDialog.Multiselect = false;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.coverPreview.ImageLocation = openFileDialog.FileName;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void txbTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void barCompression_Scroll(object sender, EventArgs e)
        {
            this.lblCompression.Text = "Quality: " + this.barCompression.Value.ToString();
        }

        private void lblDone_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Select Folder",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Choose Folder" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button btnFolderSelect = new Button() { Text = "Select Folder", Left = 245, Width = 100, Top = 90 };
            Button btnBeginRenaming = new Button() { Text = "Begin Renaming", Left = 350, Width = 115, Top = 90, DialogResult = DialogResult.OK };
            CheckBox multi = new CheckBox() { Checked = false, Left = 50, Top = 90, Text = "Multiple" };
            ToolTip toolTip = new ToolTip() { };

            toolTip.SetToolTip(multi, "Perform operation on multiple folders in directory");


            btnFolderSelect.Click += (sender, e) => { 
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                }   

                
            };

            btnBeginRenaming.Click += (sender, e) =>
            {
                if(Directory.Exists(textBox.Text))
                {
                    if (multi.Checked)
                    {
                        List<string> folders = Directory.GetDirectories(textBox.Text).ToList();

                        foreach (string folder in folders)
                        {
                            EPUBParse.RenameFilesInFolder(folder, new EPUBSettings { Title = "Berserk" });
                        }
                    }

                    EpubHandler.EPUBParse.RenameFilesInFolder(textBox.Text, new EPUBSettings { Title = "Berserk" });
                }
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(btnFolderSelect);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(multi);
            prompt.AcceptButton = btnFolderSelect;
            prompt.Controls.Add(btnBeginRenaming);
      
            

            string s = prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";


        }

        private void btnFolderNamechanger_Click(object sender, EventArgs e)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Select Folder",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Choose Folder" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button btnFolderSelect = new Button() { Text = "Select Folder", Left = 240, Width = 100, Top = 100 };
            Button btnCloseForm = new Button() { Text = "Begin Renaming", Left = 350, Width = 115, Top = 100, DialogResult = DialogResult.OK };

            btnFolderSelect.Click += (sender, e) => {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                }

                
            };


            btnCloseForm.Click += (sender, e) =>
            {
                if (Directory.Exists(textBox.Text))
                {


                            EPUBParse.RenameFoldersInFolder(textBox.Text, new EPUBSettings { Title = "Berserk" });
   
                 
                }
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(btnFolderSelect);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = btnFolderSelect;
            prompt.Controls.Add(btnCloseForm);

            string s = prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}