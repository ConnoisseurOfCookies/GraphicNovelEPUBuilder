using EpubHandler;
using System.Runtime.CompilerServices;

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

            await t1;

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
    }
}