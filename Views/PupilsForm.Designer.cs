namespace School
{
    partial class PupilsForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.pupilsListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.updateButton = new MaterialSkin.Controls.MaterialButton();
            this.addButton = new MaterialSkin.Controls.MaterialButton();
            this.deleteButton = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.findTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.findRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.cancelRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pupilsListView
            // 
            this.pupilsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pupilsListView.AutoSizeTable = false;
            this.pupilsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pupilsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pupilsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12});
            this.tableLayoutPanel1.SetColumnSpan(this.pupilsListView, 4);
            this.pupilsListView.ContextMenuStrip = this.contextMenuStrip1;
            this.pupilsListView.Depth = 0;
            this.pupilsListView.FullRowSelect = true;
            this.pupilsListView.HideSelection = false;
            this.pupilsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.pupilsListView.Location = new System.Drawing.Point(3, 3);
            this.pupilsListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.pupilsListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.pupilsListView.MouseState = MaterialSkin.MouseState.OUT;
            this.pupilsListView.Name = "pupilsListView";
            this.pupilsListView.OwnerDraw = true;
            this.pupilsListView.Size = new System.Drawing.Size(1154, 504);
            this.pupilsListView.TabIndex = 1;
            this.pupilsListView.UseCompatibleStateImageBehavior = false;
            this.pupilsListView.View = System.Windows.Forms.View.Details;
            this.pupilsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.pupilsListView_ColumnClick);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ID";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ФИО";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Дата рождения";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Возраст";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Класс";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Домашний адрес";
            this.columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Льготная категория";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Контактные Данные";
            this.columnHeader7.Width = 170;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Дата Приема";
            this.columnHeader8.Width = 125;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Дата Выбытия";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ФИО родителя";
            this.columnHeader11.Width = 250;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Телефон родителя";
            this.columnHeader12.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletMenuItem,
            this.updateMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 76);
            // 
            // deletMenuItem
            // 
            this.deletMenuItem.Name = "deletMenuItem";
            this.deletMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deletMenuItem.Text = "Удалить";
            this.deletMenuItem.Click += new System.EventHandler(this.deletMenuItem_Click);
            // 
            // updateMenuItem
            // 
            this.updateMenuItem.Name = "updateMenuItem";
            this.updateMenuItem.Size = new System.Drawing.Size(165, 22);
            this.updateMenuItem.Text = "Обновить";
            this.updateMenuItem.Click += new System.EventHandler(this.updateMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem1.Text = "Создать таблицу";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Заявка на оздоровление детей льготных категорий"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.14839F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.14839F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.14839F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.55482F));
            this.tableLayoutPanel1.Controls.Add(this.updateButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pupilsListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.94709F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.05291F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 567);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.updateButton.AutoSize = false;
            this.updateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateButton.Depth = 0;
            this.updateButton.DrawShadows = true;
            this.updateButton.HighEmphasis = true;
            this.updateButton.Icon = null;
            this.updateButton.Location = new System.Drawing.Point(305, 516);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.updateButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(158, 45);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "Обновить";
            this.updateButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.updateButton.UseAccentColor = false;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addButton.AutoSize = false;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.Depth = 0;
            this.addButton.DrawShadows = true;
            this.addButton.HighEmphasis = true;
            this.addButton.Icon = null;
            this.addButton.Location = new System.Drawing.Point(49, 516);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(158, 45);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить";
            this.addButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addButton.UseAccentColor = false;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.deleteButton.AutoSize = false;
            this.deleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteButton.Depth = 0;
            this.deleteButton.DrawShadows = true;
            this.deleteButton.HighEmphasis = true;
            this.deleteButton.Icon = null;
            this.deleteButton.Location = new System.Drawing.Point(561, 516);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.deleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(158, 45);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.deleteButton.UseAccentColor = false;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.15144F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.84856F));
            this.tableLayoutPanel2.Controls.Add(this.findTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.findRadioButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cancelRadioButton, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(771, 513);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 51);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // findTextBox
            // 
            this.findTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.findTextBox.Depth = 0;
            this.findTextBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.findTextBox.Location = new System.Drawing.Point(3, 3);
            this.findTextBox.MaxLength = 50;
            this.findTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.findTextBox.Multiline = false;
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(280, 50);
            this.findTextBox.TabIndex = 0;
            this.findTextBox.Text = "";
            // 
            // findRadioButton
            // 
            this.findRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findRadioButton.Depth = 0;
            this.findRadioButton.Location = new System.Drawing.Point(286, 0);
            this.findRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.findRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.findRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.findRadioButton.Name = "findRadioButton";
            this.findRadioButton.Ripple = true;
            this.findRadioButton.Size = new System.Drawing.Size(100, 25);
            this.findRadioButton.TabIndex = 1;
            this.findRadioButton.TabStop = true;
            this.findRadioButton.Text = "Найти";
            this.findRadioButton.UseVisualStyleBackColor = true;
            this.findRadioButton.Click += new System.EventHandler(this.findRadioButton_Click);
            // 
            // cancelRadioButton
            // 
            this.cancelRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelRadioButton.Depth = 0;
            this.cancelRadioButton.Location = new System.Drawing.Point(286, 25);
            this.cancelRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cancelRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelRadioButton.Name = "cancelRadioButton";
            this.cancelRadioButton.Ripple = true;
            this.cancelRadioButton.Size = new System.Drawing.Size(100, 26);
            this.cancelRadioButton.TabIndex = 2;
            this.cancelRadioButton.TabStop = true;
            this.cancelRadioButton.Text = "Отмена";
            this.cancelRadioButton.UseVisualStyleBackColor = true;
            this.cancelRadioButton.Click += new System.EventHandler(this.cancelRadioButton_Click);
            // 
            // PupilsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 643);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(650, 330);
            this.Name = "PupilsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учащиеся";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView pupilsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton addButton;
        private MaterialSkin.Controls.MaterialButton updateButton;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deletMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private MaterialSkin.Controls.MaterialButton deleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialTextBox findTextBox;
        private MaterialSkin.Controls.MaterialRadioButton findRadioButton;
        private MaterialSkin.Controls.MaterialRadioButton cancelRadioButton;
    }
}