namespace Tanks
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resultL = new System.Windows.Forms.Label();
            this.scoreL = new System.Windows.Forms.Label();
            this.StartGameBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 250);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // resultL
            // 
            this.resultL.AutoSize = true;
            this.resultL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultL.ForeColor = System.Drawing.Color.Red;
            this.resultL.Location = new System.Drawing.Point(715, 117);
            this.resultL.MinimumSize = new System.Drawing.Size(100, 40);
            this.resultL.Name = "resultL";
            this.resultL.Size = new System.Drawing.Size(110, 40);
            this.resultL.TabIndex = 1;
            this.resultL.Text = "GameOver";
            this.resultL.Visible = false;
            // 
            // scoreL
            // 
            this.scoreL.AutoSize = true;
            this.scoreL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreL.ForeColor = System.Drawing.Color.Navy;
            this.scoreL.Location = new System.Drawing.Point(715, 166);
            this.scoreL.MinimumSize = new System.Drawing.Size(100, 40);
            this.scoreL.Name = "scoreL";
            this.scoreL.Size = new System.Drawing.Size(100, 40);
            this.scoreL.TabIndex = 2;
            this.scoreL.Text = "Score: 0";
            // 
            // StartGameBut
            // 
            this.StartGameBut.Location = new System.Drawing.Point(719, 12);
            this.StartGameBut.Name = "StartGameBut";
            this.StartGameBut.Size = new System.Drawing.Size(96, 30);
            this.StartGameBut.TabIndex = 3;
            this.StartGameBut.Text = "Start Game";
            this.StartGameBut.UseVisualStyleBackColor = true;
            this.StartGameBut.Click += new System.EventHandler(this.StartGameBut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 702);
            this.Controls.Add(this.StartGameBut);
            this.Controls.Add(this.scoreL);
            this.Controls.Add(this.resultL);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(853, 741);
            this.MinimumSize = new System.Drawing.Size(853, 741);
            this.Name = "MainForm";
            this.Text = "Tanks";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label resultL;
        private System.Windows.Forms.Label scoreL;
        private System.Windows.Forms.Button StartGameBut;
    }
}

