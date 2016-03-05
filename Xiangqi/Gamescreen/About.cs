using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xiangqi.Gamescreen
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Text = "About Xiangqi";
            this.labelProductName.Text = "Author: Soufiane Abba";
            this.labelVersion.Text = "Version: 1.0";
            this.labelCopyright.Text = "Soufiane Abba © 2016";
            this.labelCompanyName.Text = "Tafersit";
            this.textBoxDescription.Text = "About Xiangqi";

            CenterToScreen();
        }

        private void AboutOkBtnClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
