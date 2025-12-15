using ModelLogic1;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab3._1
{
    public partial class GroupForm : Form
    {
        public GroupForm(ILogic logic)
        {
            InitializeComponent();
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Number", 70);
            listView1.Columns.Add("Nation", 100);
            listView1.Columns.Add("Height", 70);
            listView1.Columns.Add("Weight", 70);
            var groups = new Dictionary<Position, ListViewGroup>();
            foreach (Position pos in Enum.GetValues(typeof(Position)))
            {
                var group = new ListViewGroup(pos.ToString());
                groups[pos] = group;
                listView1.Groups.Add(group);
            }
            var Players = logic.LoadAllEntities();
            foreach (var player in Players)
            {
                var item = new ListViewItem(player.Name);
                item.SubItems.Add(player.Number.ToString());
                item.SubItems.Add(player.Nation);
                item.SubItems.Add(player.Height.ToString());
                item.SubItems.Add(player.Weight.ToString());

                item.Group = groups[player.Position];
                listView1.Items.Add(item);
            }
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
