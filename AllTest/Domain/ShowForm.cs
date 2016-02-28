using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    public partial class ShowForm : Form
    {
        public ShowForm()
        {
            InitializeComponent();
        }

        public void GetText(List<string> lStr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string dString in lStr)
            {
                sb.AppendLine(dString);
            }
            textBoxShow.Text = sb.ToString();
            //.AppendText(dString);
            //textBoxShow.AppendText("\n");
        }
    }
}
