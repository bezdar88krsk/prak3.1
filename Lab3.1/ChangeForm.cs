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
    public partial class ChangeForm : Form
    {
        int PlayerId;
        Logic Logic;
        public ChangeForm()
        {
            InitializeComponent();
        }
        public ChangeForm(int playerId, Logic logic)
        {
            
            InitializeComponent();
            PlayerId = playerId;
            Logic = logic;
            Player player = logic.GetPlayer(PlayerId);
            textBox1.Text = player.Name;
            textBox2.Text = player.Number.ToString();
            textBox3.Text = player.Nation;
            textBox4.Text = player.Height.ToString();
            textBox5.Text = player.Weight.ToString();
            for(int i = 0; i < 4;i++)
            {
                comboBox1.SelectedIndex = i;
                if (comboBox1.Text == player.Position.ToString())
                    break;
            }
            //Logic.ChangePlayer(playerId, 22, "a", "a", Position.SmallForward, 22, 22);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           Logic.ChangePlayer(PlayerId,Convert.ToInt32(textBox2.Text),textBox1.Text,textBox3.Text,Logic.ConvertPosition(comboBox1.Text),Convert.ToInt32(textBox4.Text),Convert.ToInt32(textBox5.Text));
           this.Close();
        }
    }
}
