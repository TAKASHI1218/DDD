namespace DDD.WinForm
{
    partial class WeatherLatestViews
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            DataDateLabel = new Label();
            ConditionLabel = new Label();
            TemperatureLabel = new Label();
            LatestButton = new Button();
            AreasComboBox = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 88);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 0;
            label1.Text = "地域";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 139);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 1;
            label2.Text = "日時";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 194);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 2;
            label3.Text = "状態";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 247);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 3;
            label4.Text = "温度";
            // 
            // DataDateLabel
            // 
            DataDateLabel.AutoSize = true;
            DataDateLabel.Location = new Point(174, 139);
            DataDateLabel.Name = "DataDateLabel";
            DataDateLabel.Size = new Size(59, 25);
            DataDateLabel.TabIndex = 4;
            DataDateLabel.Text = "label5";
            // 
            // ConditionLabel
            // 
            ConditionLabel.AutoSize = true;
            ConditionLabel.Location = new Point(174, 194);
            ConditionLabel.Name = "ConditionLabel";
            ConditionLabel.Size = new Size(59, 25);
            ConditionLabel.TabIndex = 5;
            ConditionLabel.Text = "label6";
            // 
            // TemperatureLabel
            // 
            TemperatureLabel.AutoSize = true;
            TemperatureLabel.Location = new Point(174, 247);
            TemperatureLabel.Name = "TemperatureLabel";
            TemperatureLabel.Size = new Size(59, 25);
            TemperatureLabel.TabIndex = 6;
            TemperatureLabel.Text = "label7";
            // 
            // LatestButton
            // 
            LatestButton.Location = new Point(387, 88);
            LatestButton.Name = "LatestButton";
            LatestButton.Size = new Size(112, 34);
            LatestButton.TabIndex = 8;
            LatestButton.Text = "直近値";
            LatestButton.UseVisualStyleBackColor = true;
            LatestButton.Click += LatestButton_Click;
            // 
            // AreasComboBox
            // 
            AreasComboBox.FormattingEnabled = true;
            AreasComboBox.Location = new Point(174, 85);
            AreasComboBox.Name = "AreasComboBox";
            AreasComboBox.Size = new Size(182, 33);
            AreasComboBox.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(86, 27);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 10;
            button1.Text = "List";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // WeatherLatestViews
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(AreasComboBox);
            Controls.Add(LatestButton);
            Controls.Add(TemperatureLabel);
            Controls.Add(ConditionLabel);
            Controls.Add(DataDateLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WeatherLatestViews";
            Text = "WeatherLatestViews";
            Load += WeathreLatestViews_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label DataDateLabel;
        private Label ConditionLabel;
        private Label TemperatureLabel;
        private Button LatestButton;
        private ComboBox AreasComboBox;
        private Button button1;
    }
}
