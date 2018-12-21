using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLAPI.Item
{
    public partial class DetailItem : Form
    {
        private LOLItem item;
        private LOLItem lItem;

        public DetailItem()
        {
            InitializeComponent();
        }
        
        public DetailItem(LOLItem lItem) : this()
        {
            this.lItem = lItem;
        }

        private void DetailItem_Load(object sender, EventArgs e)
        {
            this.Name = "Item";

            pictureBox1.Image = item.Image;
            lblName.Text = "이름 : " + item.Name;
            lblDesc.Text = "설명 : " + item.Description;
            lblPrice.Text = item.Gold + "Gold";

        }
    }
}
