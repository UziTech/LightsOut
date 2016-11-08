using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class Options : Form
    {
        public int _rows = Properties.Settings.Default.rows;
        public int _cols = Properties.Settings.Default.cols;
        public bool _easy = Properties.Settings.Default.easy;
        public bool _medium = Properties.Settings.Default.med;
        public bool _hard = Properties.Settings.Default.hard;
        public Options()
        {
            InitializeComponent();
            rowTextBox.Text = _rows.ToString();
            colTextBox.Text = _cols.ToString();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (easyRB.Checked)
                {
                    _easy = true;
                    _medium = false;
                    _hard = false;
                }
                else if (mediumRB.Checked)
                {
                    _easy = false;
                    _medium = true;
                    _hard = false;
                }
                else
                {
                    _easy = false;
                    _medium = false;
                    _hard = true;
                }
                if (Convert.ToInt32(rowTextBox.Text) < 31 && Convert.ToInt32(rowTextBox.Text) > 9 && Convert.ToInt32(colTextBox.Text) < 51 && Convert.ToInt32(colTextBox.Text) > 9)
                {
                    _rows = Convert.ToInt32(rowTextBox.Text);
                    _cols = Convert.ToInt32(colTextBox.Text);
                }
                Properties.Settings.Default.rows = _rows;
                Properties.Settings.Default.cols = _cols;
                Properties.Settings.Default.easy = _easy;
                Properties.Settings.Default.med = _medium;
                Properties.Settings.Default.hard = _hard;
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            easyRB.Checked = _easy;
            mediumRB.Checked = _medium;
            hardRB.Checked = _hard;
            this.Close();
        }
    }
}