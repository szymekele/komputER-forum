using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace komputerforum
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.Size = new Size(1280, 960);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}
