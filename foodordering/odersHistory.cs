using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace foodordering
{
    public partial class odersHistory : Form
    {
        public List<OderDTO> listOder;
        public odersHistory()
        {
            InitializeComponent();
            this.StartPosition=FormStartPosition.CenterScreen;
            listOder = new OderBL().getOderByUserID(Form1.iduser);
            listOder.Reverse();
            fLP.Width = this.Width - 20;
        }

        private void odersHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            //int i = 0;
            foreach (var order in listOder)
            {

                OderPerItem frm = new OderPerItem(order);
                fLP.Controls.Add(frm);
                frm.Show();
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }

        }

        private void odersHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
