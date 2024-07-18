using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class FormViewScreen : Form
    {
        public FormViewScreen()
        {
            InitializeComponent();
        }


        public void SetImage(Image image)
        {
            try
            {
                if(image!=null)
                {
                    pictureBox1.Image= image;
                }
            }
            catch { 

            }
        }
    }
}
