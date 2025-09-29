using ModelLogic1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._1
{
    public partial class AddForm : Form
    {
        Logic Logic = null;
        public AddForm()
        {
            InitializeComponent();
        }
        public AddForm(Logic logic)
        {
            Logic = logic;
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text==""&& textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Все поля должны быть введены");
            }
            Logic.AddPlayer(Convert.ToInt32(textBox2.Text), textBox1.Text, textBox3.Text, Logic.ConvertPosition(comboBox1.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
            this.Close();
        }
    }
}
