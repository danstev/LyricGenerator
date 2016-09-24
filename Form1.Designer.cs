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
            this.SaveText = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.chainStats = new System.Windows.Forms.RichTextBox();
            this.ExportStats = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.removeNonsense = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(45, 96);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(420, 434);
            this.Input.TabIndex = 0;
            this.Input.Text = "";
            // 
            // saveChain
            // 
            this.saveChain.BackColor = System.Drawing.SystemColors.Control;
            this.saveChain.Location = new System.Drawing.Point(45, 35);
            this.saveChain.Name = "saveChain";
            this.saveChain.Size = new System.Drawing.Size(75, 23);
            this.saveChain.TabIndex = 1;
            this.saveChain.Text = "Save Chain";
            this.saveChain.UseVisualStyleBackColor = false;
            this.saveChain.Click += new System.EventHandler(this.saveChain_Click);
            // 
            // loadChain
            // 
            this.loadChain.Location = new System.Drawing.Point(126, 35);
            this.loadChain.Name = "loadChain";
            this.loadChain.Size = new System.Drawing.Size(75, 23);
            this.loadChain.TabIndex = 2;
            this.loadChain.Text = "Load Chain";
            this.loadChain.UseVisualStyleBackColor = true;
            this.loadChain.Click += new System.EventHandler(this.loadChain_Click);
            // 
            // generateText
            // 
            this.generateText.Location = new System.Drawing.Point(471, 35);
            this.generateText.Name = "generateText";
            this.generateText.Size = new System.Drawing.Size(126, 23);
            this.generateText.TabIndex = 3;
            this.generateText.Text = "Generate Text";
            this.generateText.UseVisualStyleBackColor = true;
            this.generateText.Click += new System.EventHandler(this.generateText_Click);
            // 
            // SaveText
            // 
            this.SaveText.Location = new System.Drawing.Point(603, 35);
            this.SaveText.Name = "SaveText";
            this.SaveText.Size = new System.Drawing.Size(75, 23);
            this.SaveText.TabIndex = 4;
            this.SaveText.Text = "Save Text";
            this.SaveText.UseVisualStyleBackColor = true;
            this.SaveText.Click += new System.EventHandler(this.SaveText_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(471, 96);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(420, 434);
            this.Output.TabIndex = 5;
            this.Output.Text = "";
            // 
            // chainStats
            // 
            this.chainStats.Location = new System.Drawing.Point(911, 96);
            this.chainStats.Name = "chainStats";
            this.chainStats.Size = new System.Drawing.Size(123, 268);
            this.chainStats.TabIndex = 6;
            this.chainStats.Text = "";
            // 
            // ExportStats
            // 
            this.ExportStats.Location = new System.Drawing.Point(911, 35);
            this.ExportStats.Name = "ExportStats";
            this.ExportStats.Size = new System.Drawing.Size(75, 23);
            this.ExportStats.TabIndex = 7;
            this.ExportStats.Text = "Export Stats";
            this.ExportStats.UseVisualStyleBackColor = true;
            this.ExportStats.Click += new System.EventHandler(this.ExportStats_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // removeNonsense
            // 
            this.removeNonsense.AutoSize = true;
            this.removeNonsense.Location = new System.Drawing.Point(911, 370);
            this.removeNonsense.Name = "removeNonsense";
            this.removeNonsense.Size = new System.Drawing.Size(117, 17);
            this.removeNonsense.TabIndex = 8;
            this.removeNonsense.Text = "Remove Nonsense";
            this.removeNonsense.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 555);
            this.Controls.Add(this.removeNonsense);
            this.Controls.Add(this.ExportStats);
            this.Controls.Add(this.chainStats);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.SaveText);
            this.Controls.Add(this.generateText);
            this.Controls.Add(this.loadChain);
            this.Controls.Add(this.saveChain);
            this.Controls.Add(this.Input);
            this.Name = "MainForm";
            this.Text = "Lyric Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Input;
        private System.Windows.Forms.Button saveChain;
        private System.Windows.Forms.Button loadChain;
        private System.Windows.Forms.Button generateText;
        private System.Windows.Forms.Button SaveText;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.RichTextBox chainStats;
        private System.Windows.Forms.Button ExportStats;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox removeNonsense;
    }
}

