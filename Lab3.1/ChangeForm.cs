using ModelLogic1;
using ProjectLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Lab3._1
{
    public partial class ChangeForm : Form, IChangeFromView
    {
        public event EventHandler SaveButtonClicked;

        public ChangeForm()
        {
            InitializeComponent();
        }

        private int _playerId;

        public int PlayerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }

        public string PlayerName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string PlayerNumber
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string PlayerNation
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string PlayerPosition
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }

        public string PlayerHeight
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string PlayerWeight
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public void SetPositions(IEnumerable<string> positions)
        {
            comboBox1.Items.Clear();
            foreach (string p in positions)
            {
                comboBox1.Items.Add(p);
            }
        }

        public void CloseView()
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveButtonClicked?.Invoke(this, e);
            MessageBox.Show("aaaaaa");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
