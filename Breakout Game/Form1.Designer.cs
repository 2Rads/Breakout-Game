
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
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayBox
            // 
            this.DisplayBox.Location = new System.Drawing.Point(12, 12);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.Size = new System.Drawing.Size(1040, 657);
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
            // BreakoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.DisplayBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BreakoutForm";
            this.Text = "Breakout Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BreakoutForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BreakoutForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayBox;
        private System.Windows.Forms.Timer Timer;
    }
}

