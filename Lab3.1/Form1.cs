using ModelLogic1;
using Ninject;
using ProjectLogic;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace Lab3._1
{

    public partial class Form1 : Form, IFormView
    {
        public event EventHandler ButtonAddClicked;
        public event EventHandler ButtonDeleteClicked;
        public event EventHandler ButtonEditClicked;
        public event EventHandler ButtonGroupPositionClicked;
        public event EventHandler ButtonGroupNationClicked;
        public event EventHandler ButtonGroupFormClicked;
        public event EventHandler CheckBoxPositionChanged;
        public event EventHandler CheckBoxNationChanged;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        public string SelectedPosition
        {
            get
            {
                if (!checkBox1.Checked)
                    return null;
                return comboBox1.Text;
            }
        }

        public string SelectedNation
        {
            get
            {
                if (!checkBox2.Checked)
                    return null;
                return comboBox2.Text;
            }
        }

        public int? SelectedPlayerId
        {
            get
            {
                if (dataGridView1.SelectedCells.Count == 0)
                    return null;
                return Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            }
        }

        public void ShowPlayers(IEnumerable<PlayerDto> players)
        {
            dataGridView1.DataSource = new BindingList<PlayerDto>(players.ToList());
        }

        public void ResetFilters()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        public void SetPositions(IEnumerable<string> positions)
        {
            comboBox1.Items.Clear();
            foreach (var p in positions)
                comboBox1.Items.Add(p);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        public void SetNations(IEnumerable<string> nations)
        {
            comboBox2.Items.Clear();
            foreach (var n in nations)
                comboBox2.Items.Add(n);
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonAddClicked?.Invoke(this, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonDeleteClicked?.Invoke(this, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonEditClicked?.Invoke(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonGroupPositionClicked?.Invoke(this, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonGroupNationClicked?.Invoke(this, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonGroupFormClicked?.Invoke(this, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ButtonGroupPositionClicked?.Invoke(this, e); 
            CheckBoxPositionChanged?.Invoke(this, e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNationChanged?.Invoke(this, e);
        }
    }
}
