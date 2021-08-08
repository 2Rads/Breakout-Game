
namespace Breakout_Game
{
    partial class BreakoutForm
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
            this.components = new System.ComponentModel.Container();
            this.DisplayBox = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LivesLbl = new System.Windows.Forms.Label();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.RestartBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayBox
            // 
            this.DisplayBox.BackColor = System.Drawing.Color.Black;
            this.DisplayBox.Location = new System.Drawing.Point(12, 49);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.Size = new System.Drawing.Size(1040, 620);
            this.DisplayBox.TabIndex = 0;
            this.DisplayBox.TabStop = false;
            this.DisplayBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayBox_Paint);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 15;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LivesLbl
            // 
            this.LivesLbl.AutoSize = true;
            this.LivesLbl.BackColor = System.Drawing.Color.Transparent;
            this.LivesLbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LivesLbl.ForeColor = System.Drawing.Color.White;
            this.LivesLbl.Location = new System.Drawing.Point(12, 1);
            this.LivesLbl.Name = "LivesLbl";
            this.LivesLbl.Size = new System.Drawing.Size(122, 45);
            this.LivesLbl.TabIndex = 0;
            this.LivesLbl.Text = "Lives: 5";
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreLbl.ForeColor = System.Drawing.Color.White;
            this.ScoreLbl.Location = new System.Drawing.Point(902, 1);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(132, 45);
            this.ScoreLbl.TabIndex = 0;
            this.ScoreLbl.Text = "Score: 0";
            // 
            // RestartBtn
            // 
            this.RestartBtn.BackColor = System.Drawing.Color.Transparent;
            this.RestartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RestartBtn.Image = global::Breakout_Game.Properties.Resources.RestartIcon;
            this.RestartBtn.Location = new System.Drawing.Point(635, 1);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(51, 48);
            this.RestartBtn.TabIndex = 0;
            this.RestartBtn.TabStop = false;
            this.RestartBtn.UseVisualStyleBackColor = false;
            this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
            // 
            // BreakoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.RestartBtn);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.LivesLbl);
            this.Controls.Add(this.DisplayBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BreakoutForm";
            this.Text = "Breakout Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BreakoutForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BreakoutForm_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BreakoutForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayBox;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LivesLbl;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.Button RestartBtn;
    }
}

