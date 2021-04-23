namespace School
{
    partial class DataBaseForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pupilsButton = new MaterialSkin.Controls.MaterialButton();
            this.teacherButton = new MaterialSkin.Controls.MaterialButton();
            this.eventsButton = new MaterialSkin.Controls.MaterialButton();
            this.exitButton = new MaterialSkin.Controls.MaterialButton();
            this.tasksButton = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pupilsButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.teacherButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.eventsButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.exitButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tasksButton, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 69);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.0181F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.25339F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pupilsButton
            // 
            this.pupilsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pupilsButton.AutoSize = false;
            this.pupilsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pupilsButton.Depth = 0;
            this.pupilsButton.DrawShadows = true;
            this.pupilsButton.HighEmphasis = true;
            this.pupilsButton.Icon = null;
            this.pupilsButton.Location = new System.Drawing.Point(51, 6);
            this.pupilsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pupilsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.pupilsButton.Name = "pupilsButton";
            this.pupilsButton.Size = new System.Drawing.Size(220, 75);
            this.pupilsButton.TabIndex = 11;
            this.pupilsButton.Text = "Учащиеся";
            this.pupilsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.pupilsButton.UseAccentColor = false;
            this.pupilsButton.UseVisualStyleBackColor = true;
            this.pupilsButton.Click += new System.EventHandler(this.pupilsButton_Click);
            // 
            // teacherButton
            // 
            this.teacherButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.teacherButton.AutoEllipsis = true;
            this.teacherButton.AutoSize = false;
            this.teacherButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.teacherButton.Depth = 0;
            this.teacherButton.DrawShadows = true;
            this.teacherButton.HighEmphasis = true;
            this.teacherButton.Icon = null;
            this.teacherButton.Location = new System.Drawing.Point(51, 94);
            this.teacherButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.teacherButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.teacherButton.Name = "teacherButton";
            this.teacherButton.Size = new System.Drawing.Size(220, 75);
            this.teacherButton.TabIndex = 10;
            this.teacherButton.Text = "Учителя";
            this.teacherButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.teacherButton.UseAccentColor = false;
            this.teacherButton.UseVisualStyleBackColor = true;
            this.teacherButton.Click += new System.EventHandler(this.teacherButton_Click);
            // 
            // eventsButton
            // 
            this.eventsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eventsButton.AutoSize = false;
            this.eventsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.eventsButton.Depth = 0;
            this.eventsButton.DrawShadows = true;
            this.eventsButton.HighEmphasis = true;
            this.eventsButton.Icon = null;
            this.eventsButton.Location = new System.Drawing.Point(51, 182);
            this.eventsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.eventsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(220, 75);
            this.eventsButton.TabIndex = 12;
            this.eventsButton.Text = "Журнал событий";
            this.eventsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.eventsButton.UseAccentColor = false;
            this.eventsButton.UseVisualStyleBackColor = true;
            this.eventsButton.Click += new System.EventHandler(this.eventsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.exitButton.AutoSize = false;
            this.exitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exitButton.Depth = 0;
            this.exitButton.DrawShadows = true;
            this.exitButton.HighEmphasis = true;
            this.exitButton.Icon = null;
            this.exitButton.Location = new System.Drawing.Point(85, 384);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.exitButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(152, 52);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Выйти из аккаунта";
            this.exitButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.exitButton.UseAccentColor = false;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // tasksButton
            // 
            this.tasksButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tasksButton.AutoSize = false;
            this.tasksButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tasksButton.Depth = 0;
            this.tasksButton.DrawShadows = true;
            this.tasksButton.HighEmphasis = true;
            this.tasksButton.Icon = null;
            this.tasksButton.Location = new System.Drawing.Point(51, 270);
            this.tasksButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tasksButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.tasksButton.Name = "tasksButton";
            this.tasksButton.Size = new System.Drawing.Size(220, 75);
            this.tasksButton.TabIndex = 14;
            this.tasksButton.Text = "Журнал задач";
            this.tasksButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.tasksButton.UseAccentColor = false;
            this.tasksButton.UseVisualStyleBackColor = true;
            this.tasksButton.Click += new System.EventHandler(this.tasksButton_Click);
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 517);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DataBaseForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Базы данные";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataBaseForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton pupilsButton;
        private MaterialSkin.Controls.MaterialButton teacherButton;
        private MaterialSkin.Controls.MaterialButton eventsButton;
        private MaterialSkin.Controls.MaterialButton exitButton;
        private MaterialSkin.Controls.MaterialButton tasksButton;
    }
}