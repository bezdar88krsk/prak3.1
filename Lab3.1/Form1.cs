using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectLogic;
using ModelLogic1;
namespace Lab3._1
{
    
    public partial class Form1 : Form
    {
        Logic logic = new Logic();
        public Form1()
        {
            InitializeComponent();
            logic.AddPlayer(22, "a", "a", Position.Center, 2, 2);
            dataGridView1.ReadOnly = true;
            LoadPlayers();
            comboBox1.SelectedIndex = 0;

        }
        private void LoadPlayers()
        {
            
            var players = logic.LoadAllPlayers();
            dataGridView1.DataSource = new BindingList<Player>(players);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form addForm = new AddForm(logic);
            addForm.ShowDialog();
            LoadPlayers(); 
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int playerId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                logic.RemovePlayerByID(playerId);
                LoadPlayers(); // Перезагрузка после удаления
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int playerId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                ChangeForm changeForm = new ChangeForm(playerId, logic);
                changeForm.ShowDialog();
                LoadPlayers(); // Перезагрузка после изменения
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var groupedPlayers = logic.GroupByPosition(logic.ConvertPosition(comboBox1.Text));
            dataGridView1.DataSource = new BindingList<Player>(groupedPlayers);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Visible = checkBox1.Checked;
            comboBox1.Visible = checkBox1.Checked;

            if (!checkBox1.Checked)
            {
                LoadPlayers();
            }
            else
            {
                comboBox2.Items.Clear();
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
                LoadPlayers();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var groupedPlayers = logic.GroupByNation(comboBox2.Text);
            dataGridView1.DataSource = new BindingList<Player>(groupedPlayers);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm(logic);
            groupForm.ShowDialog();
        }
    }
}
