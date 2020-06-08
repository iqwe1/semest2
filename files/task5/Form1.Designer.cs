namespace Task_5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameFileTextBox
            // 
            this.nameFileTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameFileTextBox.Location = new System.Drawing.Point(31, 40);
            this.nameFileTextBox.Name = "nameFileTextBox";
            this.nameFileTextBox.Size = new System.Drawing.Size(675, 29);
            this.nameFileTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ім\'я файлу який треба знайти";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathTextBox.Location = new System.Drawing.Point(31, 109);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(675, 29);
            this.pathTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(27, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Де потрібно шукати";
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SearchButton.Location = new System.Drawing.Point(299, 161);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(123, 39);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Пошук";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(734, 221);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameFileTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SearchButton;
    }
}

