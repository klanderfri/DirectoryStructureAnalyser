namespace DirectoryStructureAnalyser
{
    partial class AnalyserForm
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
            this.btnAnalyseStructure = new System.Windows.Forms.Button();
            this.twDirectoryTree = new DirectoryStructureAnalyser.AnalyserTreeView();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.prgAnalyseSettings = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btnAnalyseStructure
            // 
            this.btnAnalyseStructure.Location = new System.Drawing.Point(146, 829);
            this.btnAnalyseStructure.Name = "btnAnalyseStructure";
            this.btnAnalyseStructure.Size = new System.Drawing.Size(140, 49);
            this.btnAnalyseStructure.TabIndex = 2;
            this.btnAnalyseStructure.Text = "Analyse Structure";
            this.btnAnalyseStructure.UseVisualStyleBackColor = true;
            this.btnAnalyseStructure.Click += new System.EventHandler(this.btnAnalyseStructure_Click);
            // 
            // twDirectoryTree
            // 
            this.twDirectoryTree.Location = new System.Drawing.Point(475, 12);
            this.twDirectoryTree.Name = "twDirectoryTree";
            this.twDirectoryTree.Size = new System.Drawing.Size(639, 908);
            this.twDirectoryTree.TabIndex = 3;
            this.twDirectoryTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.twDirectoryTree_NodeMouseDoubleClick);
            // 
            // prgAnalyseSettings
            // 
            this.prgAnalyseSettings.Location = new System.Drawing.Point(12, 12);
            this.prgAnalyseSettings.Name = "prgAnalyseSettings";
            this.prgAnalyseSettings.Size = new System.Drawing.Size(427, 764);
            this.prgAnalyseSettings.TabIndex = 4;
            // 
            // AnalyserForm
            // 
            this.AcceptButton = this.btnAnalyseStructure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 932);
            this.Controls.Add(this.prgAnalyseSettings);
            this.Controls.Add(this.twDirectoryTree);
            this.Controls.Add(this.btnAnalyseStructure);
            this.Name = "AnalyserForm";
            this.Text = "Directory Structure Analyser";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAnalyseStructure;
        private AnalyserTreeView twDirectoryTree;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.PropertyGrid prgAnalyseSettings;
    }
}

