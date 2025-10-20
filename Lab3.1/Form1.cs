using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLogic1;
namespace Lab3._1
{
    
    public partial class Form1 : Form
    {
        Logic logic = new Logic();
        public Form1()
        { 
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = logic.Players;
            logic.AddPlayer(7,"Ronaldo","Portugal",Position.SmallForward,180,75);
            comboBox1.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addForm = new AddForm(logic);
            addForm.ShowDialog();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            dataGridView1.Refresh();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            logic.RemovePlayerByID(Convert.ToInt32(dataGridView1.SelectedCells[0].Value));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm(Convert.ToInt32(dataGridView1.SelectedCells[0].Value), logic);
            changeForm.ShowDialog();
            dataGridView1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logic.GroupByPosition(logic.ConvertPosition(comboBox1.Text), (BindingList<Player>)dataGridView1.DataSource);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Visible = checkBox1.Checked;
            comboBox1.Visible = checkBox1.Checked;
            if (!checkBox1.Checked)
            {
                dataGridView1.DataSource = logic.Players;
            }
            else
            {
                foreach (var nation in logic.GetNations())
                {
                    comboBox2.Items.Add(nation);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button5.Visible = checkBox2.Checked;
            comboBox2.Visible = checkBox2.Checked;
            if (!checkBox2.Checked)
            {
                dataGridView1.DataSource = logic.Players;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logic.GroupByNation(comboBox2.Text, (BindingList<Player>)dataGridView1.DataSource);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm(logic);
            groupForm.ShowDialog();
        }
    }
}
