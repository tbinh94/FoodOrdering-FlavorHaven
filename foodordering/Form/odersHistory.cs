using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class odersHistory : Form
    {
        public List<OderDTO> listOder;

        public odersHistory()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            listOder = new OderBL().getOderByUserID(Form1.iduser);
            listOder.Reverse();
            this.Width = fLP.Width + 35;

        }

        private void odersHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            //int i = 0;
            foreach (var order in listOder)
            {
                OderPerItem frm = new OderPerItem(order);
                frm.Margin = new Padding(10, 0, 0, 10);

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
