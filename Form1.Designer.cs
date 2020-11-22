namespace AutoMergeTools
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonChooseSolution = new System.Windows.Forms.Button();
            this.buttonChooseOutputFile = new System.Windows.Forms.Button();
            this.textBoxProject = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonProcessStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChooseSolution
            // 
            this.buttonChooseSolution.Location = new System.Drawing.Point(565, 36);
            this.buttonChooseSolution.Name = "buttonChooseSolution";
            this.buttonChooseSolution.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseSolution.TabIndex = 0;
            this.buttonChooseSolution.Text = "...";
            this.buttonChooseSolution.UseVisualStyleBackColor = true;
            this.buttonChooseSolution.Click += new System.EventHandler(this.buttonChooseSolution_Click);
            // 
            // buttonChooseOutputFile
            // 
            this.buttonChooseOutputFile.Location = new System.Drawing.Point(564, 87);
            this.buttonChooseOutputFile.Name = "buttonChooseOutputFile";
            this.buttonChooseOutputFile.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseOutputFile.TabIndex = 1;
            this.buttonChooseOutputFile.Text = "...";
            this.buttonChooseOutputFile.UseVisualStyleBackColor = true;
            this.buttonChooseOutputFile.Click += new System.EventHandler(this.buttonChooseOutputFile_Click);
            // 
            // textBoxProject
            // 
            this.textBoxProject.Location = new System.Drawing.Point(13, 36);
            this.textBoxProject.Name = "textBoxProject";
            this.textBoxProject.Size = new System.Drawing.Size(546, 22);
            this.textBoxProject.TabIndex = 2;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 87);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(546, 22);
            this.textBoxOutput.TabIndex = 2;
            // 
            // buttonProcessStart
            // 
            this.buttonProcessStart.Location = new System.Drawing.Point(510, 143);
            this.buttonProcessStart.Name = "buttonProcessStart";
            this.buttonProcessStart.Size = new System.Drawing.Size(130, 25);
            this.buttonProcessStart.TabIndex = 3;
            this.buttonProcessStart.Text = "Start Process";
            this.buttonProcessStart.UseVisualStyleBackColor = true;
            this.buttonProcessStart.Click += new System.EventHandler(this.buttonProcessStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Solution File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 181);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonProcessStart);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxProject);
            this.Controls.Add(this.buttonChooseOutputFile);
            this.Controls.Add(this.buttonChooseSolution);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseSolution;
        private System.Windows.Forms.Button buttonChooseOutputFile;
        private System.Windows.Forms.TextBox textBoxProject;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonProcessStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

