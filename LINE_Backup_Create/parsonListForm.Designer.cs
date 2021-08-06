namespace LINE_Backup_Create
{
    partial class parsonListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parsonListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.parsonTextBox = new System.Windows.Forms.TextBox();
            this.addParsonButton = new System.Windows.Forms.Button();
            this.removeParsonButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parsonListBox);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(267, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会話人物リスト";
            // 
            // parsonListBox
            // 
            this.parsonListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parsonListBox.FormattingEnabled = true;
            this.parsonListBox.ItemHeight = 15;
            this.parsonListBox.Items.AddRange(new object[] {
            "【なし】"});
            this.parsonListBox.Location = new System.Drawing.Point(4, 19);
            this.parsonListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.parsonListBox.Name = "parsonListBox";
            this.parsonListBox.Size = new System.Drawing.Size(259, 102);
            this.parsonListBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.parsonTextBox);
            this.groupBox2.Location = new System.Drawing.Point(17, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登場人物";
            // 
            // parsonTextBox
            // 
            this.parsonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parsonTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.parsonTextBox.Location = new System.Drawing.Point(3, 18);
            this.parsonTextBox.Name = "parsonTextBox";
            this.parsonTextBox.Size = new System.Drawing.Size(261, 22);
            this.parsonTextBox.TabIndex = 0;
            this.parsonTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.parsonTextBox_KeyDown);
            // 
            // addParsonButton
            // 
            this.addParsonButton.Location = new System.Drawing.Point(17, 205);
            this.addParsonButton.Name = "addParsonButton";
            this.addParsonButton.Size = new System.Drawing.Size(75, 23);
            this.addParsonButton.TabIndex = 2;
            this.addParsonButton.Text = "追加";
            this.addParsonButton.UseVisualStyleBackColor = true;
            this.addParsonButton.Click += new System.EventHandler(this.addParsonButton_Click);
            // 
            // removeParsonButton
            // 
            this.removeParsonButton.Location = new System.Drawing.Point(209, 205);
            this.removeParsonButton.Name = "removeParsonButton";
            this.removeParsonButton.Size = new System.Drawing.Size(75, 23);
            this.removeParsonButton.TabIndex = 3;
            this.removeParsonButton.Text = "削除";
            this.removeParsonButton.UseVisualStyleBackColor = true;
            this.removeParsonButton.Click += new System.EventHandler(this.removeParsonButton_Click);
            // 
            // parsonListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 247);
            this.Controls.Add(this.removeParsonButton);
            this.Controls.Add(this.addParsonButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "parsonListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会話人物";
            this.Load += new System.EventHandler(this.parsonListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox parsonListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox parsonTextBox;
        private System.Windows.Forms.Button addParsonButton;
        private System.Windows.Forms.Button removeParsonButton;
    }
}