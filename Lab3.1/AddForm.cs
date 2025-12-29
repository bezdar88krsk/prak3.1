using ProjectLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab3._1
{
    public partial class AddForm : Form, IAddFormView
    {
        public event EventHandler AddButtonClicked;

        public AddForm()
        {
            InitializeComponent();
        }

        public string PlayerName => textBox1.Text;
        public string PlayerNumber => textBox2.Text;
        public string PlayerNation => textBox3.Text;
        public string PlayerPosition => comboBox1.Text;
        public string PlayerHeight => textBox4.Text;
        public string PlayerWeight => textBox5.Text;

        public void SetPositions(IEnumerable<string> positions)
        {
            comboBox1.Items.Clear();
            foreach (var p in positions)
                comboBox1.Items.Add(p);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        public void CloseView()
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
