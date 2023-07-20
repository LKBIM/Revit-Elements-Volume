
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LKBIM
{
    public partial class _606Form : System.Windows.Forms.Form
    {
        private bool dragging = false;
        private Point startpoint = new Point(0,0);

        private _606Form()
        {
            InitializeComponent();
        }

        public _606Form(string a, double obj)
            : this()
        {
            Number.Text = a;
            Volume.Text = obj.ToString();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _606Form_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void _606Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startpoint = new Point(e.X, e.Y);
        }

        private void _606Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void _606Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X-this.startpoint.X, p.Y-this.startpoint.Y);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Volume.Text);
        }
    }
}