namespace GlobalGameJam2015Presentation
{
	partial class InfoWindow
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblSlide = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.lblDelta = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.timerTicker = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.lblDelta);
			this.panel1.Controls.Add(this.lblTotal);
			this.panel1.Controls.Add(this.lblSlide);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(845, 286);
			this.panel1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(47, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 77);
			this.label2.TabIndex = 1;
			this.label2.Text = "Total:";
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(281, 95);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(325, 77);
			this.lblTotal.TabIndex = 3;
			this.lblTotal.Text = "00:00:00";
			// 
			// lblSlide
			// 
			this.lblSlide.AutoSize = true;
			this.lblSlide.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSlide.Location = new System.Drawing.Point(281, 9);
			this.lblSlide.Name = "lblSlide";
			this.lblSlide.Size = new System.Drawing.Size(325, 77);
			this.lblSlide.TabIndex = 5;
			this.lblSlide.Text = "00:00:00";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(53, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(213, 77);
			this.label1.TabIndex = 6;
			this.label1.Text = "Slide:";
			// 
			// txtNotes
			// 
			this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtNotes.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNotes.Location = new System.Drawing.Point(0, 286);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ReadOnly = true;
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(845, 334);
			this.txtNotes.TabIndex = 1;
			this.txtNotes.Text = "Sample Text";
			// 
			// lblDelta
			// 
			this.lblDelta.AutoSize = true;
			this.lblDelta.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDelta.Location = new System.Drawing.Point(281, 185);
			this.lblDelta.Name = "lblDelta";
			this.lblDelta.Size = new System.Drawing.Size(325, 77);
			this.lblDelta.TabIndex = 3;
			this.lblDelta.Text = "00:00:00";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(3, 185);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(263, 77);
			this.label6.TabIndex = 1;
			this.label6.Text = "DELTA:";
			// 
			// timerTicker
			// 
			this.timerTicker.Enabled = true;
			this.timerTicker.Interval = 250;
			this.timerTicker.Tick += new System.EventHandler(this.timerTicker_Tick);
			// 
			// InfoWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(845, 620);
			this.Controls.Add(this.txtNotes);
			this.Controls.Add(this.panel1);
			this.MinimizeBox = false;
			this.Name = "InfoWindow";
			this.Text = "Slide Info";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblSlide;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblDelta;
		private System.Windows.Forms.Timer timerTicker;
	}
}