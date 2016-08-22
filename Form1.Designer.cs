namespace LyricGenerator
{
    partial class MainForm
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
            this.Input = new System.Windows.Forms.RichTextBox();
            this.saveChain = new System.Windows.Forms.Button();
            this.loadChain = new System.Windows.Forms.Button();
            this.generateText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(25, 50);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(390, 480);
            this.Input.TabIndex = 0;
            this.Input.Text = "";
            // 
            // saveChain
            // 
            this.saveChain.Location = new System.Drawing.Point(846, 107);
            this.saveChain.Name = "saveChain";
            this.saveChain.Size = new System.Drawing.Size(75, 23);
            this.saveChain.TabIndex = 1;
            this.saveChain.Text = "Save Chain";
            this.saveChain.UseVisualStyleBackColor = true;
            // 
            // loadChain
            // 
            this.loadChain.Location = new System.Drawing.Point(846, 168);
            this.loadChain.Name = "loadChain";
            this.loadChain.Size = new System.Drawing.Size(75, 23);
            this.loadChain.TabIndex = 2;
            this.loadChain.Text = "Load Chain";
            this.loadChain.UseVisualStyleBackColor = true;
            // 
            // generateText
            // 
            this.generateText.Location = new System.Drawing.Point(478, 274);
            this.generateText.Name = "generateText";
            this.generateText.Size = new System.Drawing.Size(126, 23);
            this.generateText.TabIndex = 3;
            this.generateText.Text = "Generate Text";
            this.generateText.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 555);
            this.Controls.Add(this.generateText);
            this.Controls.Add(this.loadChain);
            this.Controls.Add(this.saveChain);
            this.Controls.Add(this.Input);
            this.Name = "MainForm";
            this.Text = "Lyric Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Input;
        private System.Windows.Forms.Button saveChain;
        private System.Windows.Forms.Button loadChain;
        private System.Windows.Forms.Button generateText;
    }
}

