namespace WindowsFormsApplication1.MyForms
{
    partial class Depart
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.progressBarVol = new System.Windows.Forms.ProgressBar();
            this.labelVol = new System.Windows.Forms.Label();
            this.numVol = new System.Windows.Forms.NumericUpDown();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonAbort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numVol)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(142, 112);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Пуск";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // progressBarVol
            // 
            this.progressBarVol.Location = new System.Drawing.Point(61, 60);
            this.progressBarVol.Name = "progressBarVol";
            this.progressBarVol.Size = new System.Drawing.Size(220, 20);
            this.progressBarVol.TabIndex = 2;
            // 
            // labelVol
            // 
            this.labelVol.AutoSize = true;
            this.labelVol.Location = new System.Drawing.Point(10, 63);
            this.labelVol.Name = "labelVol";
            this.labelVol.Size = new System.Drawing.Size(13, 13);
            this.labelVol.TabIndex = 3;
            this.labelVol.Text = "0";
            // 
            // numVol
            // 
            this.numVol.DecimalPlaces = 3;
            this.numVol.Location = new System.Drawing.Point(297, 60);
            this.numVol.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numVol.Name = "numVol";
            this.numVol.Size = new System.Drawing.Size(73, 20);
            this.numVol.TabIndex = 4;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(12, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(20, 24);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "0";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(142, 141);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(87, 170);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(81, 23);
            this.buttonContinue.TabIndex = 7;
            this.buttonContinue.Text = "Продолжить";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(174, 170);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(89, 23);
            this.buttonAbort.TabIndex = 8;
            this.buttonAbort.Text = "Остановить";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // Depart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 299);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.numVol);
            this.Controls.Add(this.labelVol);
            this.Controls.Add(this.progressBarVol);
            this.Controls.Add(this.buttonStart);
            this.Name = "Depart";
            this.Text = "Depart";
            this.Load += new System.EventHandler(this.Depart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ProgressBar progressBarVol;
        private System.Windows.Forms.Label labelVol;
        private System.Windows.Forms.NumericUpDown numVol;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonAbort;

    }
}