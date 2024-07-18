using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class FormScreenShot : Form
    {

        private byte[] data;
        public FormScreenShot(byte[] byteofImg)
        {

            this.data = byteofImg;
            InitializeComponent();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            // Convert byte array to image and save it (for example)
            using (MemoryStream ms = new MemoryStream(data))
            {
                Image image = Image.FromStream(ms);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    saveFileDialog.Title = "Save an Image File";
                    saveFileDialog.FileName = "screenshot.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileExtension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        ImageFormat format = ImageFormat.Png; // Default to PNG
                        if (fileExtension == ".jpg")
                        {
                            format = ImageFormat.Jpeg;
                        }
                        else if (fileExtension == ".bmp")
                        {
                            format = ImageFormat.Bmp;
                        }
                        image.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }

            this.Close();
        }

        private void FormScreenShot_Load(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                this.pictureBox1.Image = Image.FromStream(ms);
            }    
        }
    }
}
