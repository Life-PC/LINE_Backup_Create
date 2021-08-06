using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINE_Backup_Create
{
    public partial class parsonListForm : Form
    {
        ListBox List;
        public parsonListForm(ref ListBox list)
        {
            InitializeComponent();

            List = list;
        }

        private void addParsonButton_Click(object sender, EventArgs e)
        {
            string parsonName = parsonTextBox.Text;
            if (parsonName == string.Empty)
                return;

            parsonListBox.Items.Add(parsonName);
            List.Items.Add(parsonName);

            parsonListBox.SelectedItem = parsonListBox.Items.Count - 1;

            parsonTextBox.Text = string.Empty;
        }

        private void removeParsonButton_Click(object sender, EventArgs e)
        {
            int listSelectedIndex = parsonListBox.SelectedIndex;

            if (listSelectedIndex < 0 ||
                parsonListBox.SelectedItem.ToString() == "【なし】")
                return;

            parsonListBox.Items.RemoveAt(listSelectedIndex);
            List.Items.RemoveAt(listSelectedIndex);

            parsonTextBox.Text = string.Empty;
        }

        private void parsonTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string parsonName = parsonTextBox.Text;
            if (e.KeyCode == Keys.Enter &&
                parsonName != string.Empty)
            {
                parsonListBox.Items.Add(parsonName);
                List.Items.Add(parsonName);

                parsonListBox.SelectedItem = parsonListBox.Items.Count - 1;

                parsonTextBox.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                int listSelectedIndex = parsonListBox.SelectedIndex - 1;

                if (listSelectedIndex < 0)
                    return;

                parsonListBox.SelectedIndex = listSelectedIndex;
                parsonTextBox.Text = parsonListBox.Items[listSelectedIndex].ToString();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                int listSelectedIndex = parsonListBox.SelectedIndex + 1;
                int listCount = parsonListBox.Items.Count;

                if (listSelectedIndex <= listCount)
                    return;

                parsonListBox.SelectedIndex = listSelectedIndex;
                parsonTextBox.Text = parsonListBox.Items[listSelectedIndex].ToString();
            }
        }

        private void parsonListForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = parsonTextBox;
            parsonTextBox.Focus();
        }
    }
}
