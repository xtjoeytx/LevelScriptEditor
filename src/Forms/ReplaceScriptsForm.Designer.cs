
namespace LevelScriptEditor.Forms
{
	partial class ReplaceScriptsForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.markScriptsCheckBox = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelIdenticalScripts = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.origScriptTextBox = new System.Windows.Forms.TextBox();
			this.origDescTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.origImageTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.newScriptTextBox = new System.Windows.Forms.TextBox();
			this.newDescTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.newImageTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(358, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Original Script";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.button1.Location = new System.Drawing.Point(380, 98);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(124, 29);
			this.button1.TabIndex = 10;
			this.button1.Text = "Replace Scripts";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ReplaceScriptsButtonClick);
			// 
			// markScriptsCheckBox
			// 
			this.markScriptsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.markScriptsCheckBox.AutoSize = true;
			this.markScriptsCheckBox.Location = new System.Drawing.Point(384, 11);
			this.markScriptsCheckBox.Name = "markScriptsCheckBox";
			this.markScriptsCheckBox.Size = new System.Drawing.Size(195, 24);
			this.markScriptsCheckBox.TabIndex = 11;
			this.markScriptsCheckBox.Text = "Mark scripts as complete";
			this.markScriptsCheckBox.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.labelIdenticalScripts);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.markScriptsCheckBox);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(12, 365);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(744, 145);
			this.panel1.TabIndex = 12;
			// 
			// labelIdenticalScripts
			// 
			this.labelIdenticalScripts.AutoSize = true;
			this.labelIdenticalScripts.Location = new System.Drawing.Point(503, 66);
			this.labelIdenticalScripts.Name = "labelIdenticalScripts";
			this.labelIdenticalScripts.Size = new System.Drawing.Size(17, 20);
			this.labelIdenticalScripts.TabIndex = 13;
			this.labelIdenticalScripts.Text = "0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(380, 66);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(117, 20);
			this.label7.TabIndex = 12;
			this.label7.Text = "Identical Scripts:";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.MinimumSize = new System.Drawing.Size(512, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.origScriptTextBox);
			this.splitContainer1.Panel1.Controls.Add(this.origDescTextBox);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.origImageTextBox);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.newScriptTextBox);
			this.splitContainer1.Panel2.Controls.Add(this.newDescTextBox);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label5);
			this.splitContainer1.Panel2.Controls.Add(this.newImageTextBox);
			this.splitContainer1.Panel2.Controls.Add(this.label6);
			this.splitContainer1.Size = new System.Drawing.Size(744, 347);
			this.splitContainer1.SplitterDistance = 372;
			this.splitContainer1.SplitterIncrement = 2;
			this.splitContainer1.TabIndex = 13;
			// 
			// origScriptTextBox
			// 
			this.origScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.origScriptTextBox.Location = new System.Drawing.Point(7, 106);
			this.origScriptTextBox.Multiline = true;
			this.origScriptTextBox.Name = "origScriptTextBox";
			this.origScriptTextBox.ReadOnly = true;
			this.origScriptTextBox.Size = new System.Drawing.Size(360, 233);
			this.origScriptTextBox.TabIndex = 16;
			// 
			// origDescTextBox
			// 
			this.origDescTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.origDescTextBox.Location = new System.Drawing.Point(98, 74);
			this.origDescTextBox.MinimumSize = new System.Drawing.Size(64, 4);
			this.origDescTextBox.Name = "origDescTextBox";
			this.origDescTextBox.ReadOnly = true;
			this.origDescTextBox.Size = new System.Drawing.Size(267, 27);
			this.origDescTextBox.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 20);
			this.label3.TabIndex = 14;
			this.label3.Text = "Description";
			// 
			// origImageTextBox
			// 
			this.origImageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.origImageTextBox.Location = new System.Drawing.Point(98, 42);
			this.origImageTextBox.MinimumSize = new System.Drawing.Size(64, 4);
			this.origImageTextBox.Name = "origImageTextBox";
			this.origImageTextBox.ReadOnly = true;
			this.origImageTextBox.Size = new System.Drawing.Size(267, 27);
			this.origImageTextBox.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 20);
			this.label4.TabIndex = 12;
			this.label4.Text = "Image";
			// 
			// newScriptTextBox
			// 
			this.newScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newScriptTextBox.Location = new System.Drawing.Point(4, 106);
			this.newScriptTextBox.Multiline = true;
			this.newScriptTextBox.Name = "newScriptTextBox";
			this.newScriptTextBox.Size = new System.Drawing.Size(360, 233);
			this.newScriptTextBox.TabIndex = 22;
			// 
			// newDescTextBox
			// 
			this.newDescTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newDescTextBox.Location = new System.Drawing.Point(97, 72);
			this.newDescTextBox.MinimumSize = new System.Drawing.Size(64, 4);
			this.newDescTextBox.Name = "newDescTextBox";
			this.newDescTextBox.Size = new System.Drawing.Size(267, 27);
			this.newDescTextBox.TabIndex = 21;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(6, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(358, 20);
			this.label2.TabIndex = 17;
			this.label2.Text = "New Script";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 20);
			this.label5.TabIndex = 20;
			this.label5.Text = "Description";
			// 
			// newImageTextBox
			// 
			this.newImageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newImageTextBox.Location = new System.Drawing.Point(97, 40);
			this.newImageTextBox.MinimumSize = new System.Drawing.Size(64, 4);
			this.newImageTextBox.Name = "newImageTextBox";
			this.newImageTextBox.Size = new System.Drawing.Size(267, 27);
			this.newImageTextBox.TabIndex = 19;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 20);
			this.label6.TabIndex = 18;
			this.label6.Text = "Image";
			// 
			// ReplaceScriptsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 515);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(560, 512);
			this.Name = "ReplaceScriptsForm";
			this.Text = "Replace Similar Scripts";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox markScriptsCheckBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox origDescTextBox;
		private System.Windows.Forms.TextBox newScriptTextBox;
		private System.Windows.Forms.TextBox origScriptTextBox;
		private System.Windows.Forms.TextBox origImageTextBox;
		private System.Windows.Forms.TextBox newDescTextBox;
		private System.Windows.Forms.TextBox newImageTextBox;
		private System.Windows.Forms.Label labelIdenticalScripts;
		private System.Windows.Forms.Label label7;
	}
}