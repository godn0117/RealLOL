using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.mainControl1.BringToFront();
            this.btnHome.BringToFront();
            this.btnExitApi.BringToFront();
        }

        private void btnChampion_Click(object sender, EventArgs e)
        {
            this.controlChampion1.BringToFront();
            panel3.Height = btnChampion.Height;
            panel3.Top = btnChampion.Top;
            panel3.Visible = true;
            this.btnHome.BringToFront();
            this.btnExitApi.BringToFront();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.mainControl1.BringToFront();
            panel3.Visible = false;
            this.mainControl1.textBox1.Clear();
            this.btnHome.BringToFront();
            this.btnExitApi.BringToFront();

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.controlItems1.BringToFront();
            panel3.Height = btnItem.Height;
            panel3.Top = btnItem.Top;
            panel3.Visible = true;
            this.btnHome.BringToFront();
            this.btnExitApi.BringToFront();

        }

        private void btnSpell_Click(object sender, EventArgs e)
        {
            this.controlSpell1.BringToFront();
            panel3.Height = btnSpell.Height;
            panel3.Top = btnSpell.Top;
            panel3.Visible = true;
            this.btnHome.BringToFront();
            this.btnExitApi.BringToFront();

        }

        private void btnRune_Click(object sender, EventArgs e)
        {
            this.controlRune1.BringToFront();
            panel3.Height = btnRune.Height;
            panel3.Top = btnRune.Top;
            panel3.Visible = true;
            this.btnHome.BringToFront();
            this.btnExitApi.BringToFront();

        }

        private void btnExitApi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
