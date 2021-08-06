using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINE_Backup_Create
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void parsonListButton_Click(object sender, EventArgs e)
        {
            parsonListForm listForm = new parsonListForm(ref this.parsonListBox);
            listForm.Show();

        }

        private void sayAddButton_Click(object sender, EventArgs e)
        {
            int listSelectedIndex = parsonListBox.SelectedIndex;

            if (listSelectedIndex < 0 ||
                sayTextBox.Text == string.Empty)
                return;

            if (parsonListBox.SelectedItem.ToString() == "【なし】")
                saysListBox.Items.Add(sayTextBox.Text);
            else
            {
                string listText =
                    sayTimePicker.Value.ToString("hh:mm") + "\t" +
                    parsonListBox.SelectedItem.ToString() + "\t" +
                    sayTextBox.Text;
                saysListBox.Items.Add(listText);
            }

            sayTextBox.Text = string.Empty;
        }

        private void saysListRemoveButton_Click(object sender, EventArgs e)
        {
            int listSelectedIndex = saysListBox.SelectedIndex;

            if (listSelectedIndex < 0)
                return;

            saysListBox.Items.RemoveAt(listSelectedIndex);
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string saveDate = saveDateTimePicker.Value.ToString("yyyy/MM/dd hh:mm");
            int saysListCount = saysListBox.Items.Count;

            if (title == string.Empty ||
                saveDate == string.Empty ||
                saysListCount == 0)
                return;

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "バックアップファイル(*.txt)|*.txt";
            save.FileName = title + ".txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Encoding sjisEnc = Encoding.GetEncoding("UTF-8");
                using (StreamWriter writer = new StreamWriter(save.FileName, false, sjisEnc))
                {
                    writer.WriteLine(title);
                    writer.WriteLine("保存日時：" + saveDate);
                    writer.WriteLine();

                    foreach (string text in saysListBox.Items)
                    {
                        writer.WriteLine(text);
                    }
                }
            }

            MessageBox.Show("保存が完了しました。", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string dateText = DateTime.Now.ToString("yyyy/MM/dd");
            sayTextBox.Text = dateText;
        }

        private void saysListBox_KeyDown(object sender, KeyEventArgs e)
        {
            int listSelectedIndex = saysListBox.SelectedIndex;

            if (listSelectedIndex < 0)
                return;


            if (e.KeyCode == Keys.U &&
                listSelectedIndex - 1 > -1)
            {
                string tmp = saysListBox.Items[listSelectedIndex].ToString();
                saysListBox.Items[listSelectedIndex] = saysListBox.Items[listSelectedIndex - 1];
                saysListBox.Items[listSelectedIndex - 1] = tmp;

                saysListBox.SelectedIndex = listSelectedIndex - 1;
            }
            else if (e.KeyCode == Keys.D &&
                listSelectedIndex + 1 < saysListBox.Items.Count)
            {
                string tmp = saysListBox.Items[listSelectedIndex].ToString();
                saysListBox.Items[listSelectedIndex] = saysListBox.Items[listSelectedIndex + 1];
                saysListBox.Items[listSelectedIndex + 1] = tmp;

                saysListBox.SelectedIndex = listSelectedIndex + 1;
            }

        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "バックアップファイル(*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamReader file =
                    new System.IO.StreamReader(open.FileName, System.Text.Encoding.UTF8))
                {
                    string line;
                    string title = titleTextBox.Text;
                    string saveDate = saveDateTimePicker.Value.ToString("yyyy/MM/dd hh:mm");
                    string emptyText = "";
                    string sParson = "";
                    ArrayList saysList = new ArrayList();
                    ArrayList parsonList = new ArrayList();
                    int i = 0;
                    int emptyCoutn = 0;

                    while ((line = file.ReadLine()) != null)
                    {
                        if (i == 0)
                            title = line;
                        else if (i == 1)
                            saveDate = line;
                        else
                        {
                            if (line != string.Empty)
                            {
                                if (line == string.Empty)
                                {
                                    emptyCoutn++;
                                    emptyText += "\r\n";
                                }
                                else
                                {
                                    string[] messageData = line.Split('\t');
                                    int msDataLenght = messageData.Length;
                                    if (msDataLenght == 1)
                                    {
                                        if (Regex.IsMatch(line,
                                            @"^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)" +
                                            @"(?<month>0?[1-9]|1[012])\k<datesep>" +
                                            @"(?<day>0?[1-9]|[12][0-9]|3[01])"))
                                        {
                                            //data.SendMessage.Add(line);
                                            if (emptyText != string.Empty &&
                                                saysList.Count != 0)
                                                saysList[saysList.Count - 1]
                                                    += "\r\n" + emptyText.Remove(emptyText.Length - 2, 2);

                                            emptyCoutn = 0;
                                            emptyText = "";
                                            saysList.Add(line);
                                        }
                                        else
                                        {
                                            emptyCoutn++;
                                            emptyText += line + "\r\n";
                                        }
                                    }
                                    else if (msDataLenght == 3)
                                    {
                                        if (!sParson.Contains(messageData[1]))
                                        {
                                            sParson += messageData[1];
                                            parsonList.Add(messageData[1]);
                                        }
                                        if (emptyCoutn != 0)
                                        {
                                            saysList[saysList.Count - 1]
                                                += "\r\n" + emptyText.Remove(emptyText.Length - 2, 2);
                                            emptyCoutn = 0;
                                            emptyText = "";
                                        }
                                        saysList.Add(line);
                                    }
                                }
                            }
                        }
                        i++;
                    }

                    if (emptyText != string.Empty)
                    {
                        saysList[saysList.Count - 1] += emptyText;
                    }

                    titleTextBox.Text = title;
                    saveDate = saveDate.Replace("保存日時：", "");
                    saveDateTimePicker.Value = DateTime.Parse(saveDate);

                    parsonListBox.Items.Clear();
                    parsonListBox.Items.Add("【なし】");
                    foreach (string tmp in parsonList)
                        parsonListBox.Items.Add(tmp);

                    sayTextBox.Text = string.Empty;

                    saysListBox.Items.Clear();
                    foreach (string tmp in saysList)
                        saysListBox.Items.Add(tmp);
                }
            }

        }

        private void saysListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int listSelectedIndex = saysListBox.SelectedIndex;

            if (listSelectedIndex < 0)
                return;

            string[] saysData =
                saysListBox.Items[listSelectedIndex].ToString().Split('\t');

            if (saysData.Length == 0)
                return;
            else if (saysData.Length == 1)
            {
                if (Regex.IsMatch(saysData[0],
                        @"^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)" +
                        @"(?<month>0?[1-9]|1[012])\k<datesep>" +
                        @"(?<day>0?[1-9]|[12][0-9]|3[01])"))
                {
                    parsonListBox.SelectedIndex = 0;
                    sayTextBox.Text = saysData[0];
                }
            }
            else if (saysData.Length == 2)
                sayTextBox.Text = saysListBox.Items[listSelectedIndex].ToString();
            else if (saysData.Length == 3)
            {
                DateTime now = DateTime.Now;
                string[] timeSplit = saysData[0].Split(':');
                int hour = int.Parse(timeSplit[0]);
                int minutes = int.Parse(timeSplit[1]);
                DateTime sayTime =
                    new DateTime(now.Year, now.Month, now.Day, hour, minutes, 0);
                sayTimePicker.Value = sayTime;

                parsonListBox.SelectedItem = saysData[1];

                sayTextBox.Text = saysData[2];
            }
        }

        private void sayChengeButton_Click(object sender, EventArgs e)
        {
            int listSelectedIndex = saysListBox.SelectedIndex;

            if (listSelectedIndex < 0)
                return;

            if (saysListBox.SelectedItem.ToString() == "【なし】")
                saysListBox.Items[listSelectedIndex] = sayTextBox.Text;
            else
            {
                string listText =
                    sayTimePicker.Value.ToString("hh:mm") + "\t" +
                    parsonListBox.SelectedItem.ToString() + "\t" +
                    sayTextBox.Text;
                saysListBox.Items[listSelectedIndex] = listText;
            }
        }

        private void テキストリスト全削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = string.Empty;
            saveDateTimePicker.Value = DateTime.Now;
            parsonListBox.Items.Clear();
            parsonListBox.Items.Add("【なし】");

            DateTime now = DateTime.Now;
            DateTime sayTime =
                    new DateTime(now.Year, now.Month, now.Day, 10, 0, 0);
            sayTimePicker.Value = sayTime;
            sayTextBox.Text = string.Empty;
            saysListBox.Items.Clear();
        }

        private void 会話人物全削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parsonListBox.Items.Clear();
            parsonListBox.Items.Add("【なし】");
        }

        private void テキストリスト全削除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saysListBox.Items.Clear();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
