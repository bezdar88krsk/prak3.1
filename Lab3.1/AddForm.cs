using ProjectLogic;
using System;
using System.Windows.Forms;
namespace Lab3._1
{
    public partial class AddForm : Form
    {
        ILogic Logic = null;
        public AddForm()
        {
            InitializeComponent();
        }
        public AddForm(ILogic logic)
        {
            Logic = logic;
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (!(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
    string.IsNullOrWhiteSpace(textBox5.Text)))
            {
                Logic.AddEntity(Convert.ToInt32(textBox2.Text), textBox1.Text, textBox3.Text, Logic.ConvertPosition(comboBox1.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));

            }
            this.Close();
        }
    }
}
