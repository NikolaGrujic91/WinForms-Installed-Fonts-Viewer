using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsInstalledFontsViewer
{
    public partial class Form1 : Form
    {
        #region Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            var fonts = new System.Drawing.Text.InstalledFontCollection();

            foreach (FontFamily family in fonts.Families)
            {
                this.comboBoxFonts.Items.Add(family.Name);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this.comboBoxFonts.Text == string.Empty)
            {
                return;
            }

            this.SetFont(new Font(this.comboBoxFonts.Text, 20));
        }

        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxFonts.Text != string.Empty)
            {
                this.Invalidate();
            }
        }

        #endregion

        #region Methods

        private void SetFont(Font font)
        {
            try
            {
                this.TrySetFont(font);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void TrySetFont(Font font)
        {
            this.labelText.Font = font;
            this.labelText.Text = this.comboBoxFonts.Text;
        }

        #endregion
    }
}
