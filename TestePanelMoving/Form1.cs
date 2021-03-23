using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePanelMoving
{
    public partial class Form1 : Form
    {
        private short LabelWidth = 70;
        private short LabelSpace = 3;

        private static Point LabelLocationStart = new Point(251, 34);

        public Form1()
        {
            InitializeComponent();
            AtivarPanel1();
            CheckAllBoxes();
        }

        private void CheckAllBoxes()
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
        }

        private void AtivarLabel1_Click(object sender, EventArgs e)
        {
            AtivarPanel1();
        }

        private void AtivarPanel1()
        {
            panel1.Visible = true;
            DesativarPanel2();
            DesativarPanel3();
        }
        private void AtivarPanel2()
        {
            panel2.Visible = true;
            DesativarPanel1();
            DesativarPanel3();
        }
        private void AtivarPanel3()
        {
            panel3.Visible = true;
            DesativarPanel2();
            DesativarPanel1();
        }
        private void DesativarPanel1()
        {
            panel1.Visible = false;
        }
        private void DesativarPanel2()
        {
            panel2.Visible = false;
        }
        private void DesativarPanel3()
        {
            panel3.Visible = false;
        }

        private void AtivarLabel2_Click(object sender, EventArgs e)
        {
            AtivarPanel2();
        }

        private void AtivarLabel3_Click(object sender, EventArgs e)
        {
            AtivarPanel3();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            labelAtivarLabel1.Visible = checkBox1.Checked;
            panel1.Visible = checkBox1.Checked;
            PosicionaLabels();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            labelAtivarLabel2.Visible = checkBox2.Checked;
            panel2.Visible = checkBox2.Checked;
            PosicionaLabels();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            labelAtivarLabel3.Visible = checkBox3.Checked;
            panel3.Visible = checkBox3.Checked;
            PosicionaLabels();
        }

        private void PosicionaLabels()
        {
            Point nextLabelLocation = LabelLocationStart;
            bool labelSelected = false;
            if (checkBox1.Checked)
            {
                labelAtivarLabel1.Location = LabelLocationStart;
                nextLabelLocation = new Point(
                    LabelLocationStart.X + LabelWidth + LabelSpace,
                    LabelLocationStart.Y);

                labelSelected = true;
                AtivarLabel1_Click(this, null);
            }

            if (checkBox2.Checked)
            {
                labelAtivarLabel2.Location = nextLabelLocation;

                nextLabelLocation = new Point(
                    nextLabelLocation.X + LabelWidth + LabelSpace,
                    nextLabelLocation.Y);

                if (!labelSelected)
                    AtivarLabel2_Click(this, null);

                labelSelected = true;
            }

            if (checkBox3.Checked)
            {
                labelAtivarLabel3.Location = nextLabelLocation;

                if (!labelSelected)
                    AtivarLabel3_Click(this, null);
            }
        }
    }
}
