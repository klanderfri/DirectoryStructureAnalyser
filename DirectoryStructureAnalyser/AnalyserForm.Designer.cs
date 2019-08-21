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
            this.tbxRootDirectoryPath = new System.Windows.Forms.TextBox();
            this.btnSelectRootDirectory = new System.Windows.Forms.Button();
            this.btnAnalyseStructure = new System.Windows.Forms.Button();
            this.twDirectoryTree = new System.Windows.Forms.TreeView();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.SuspendLayout();
            // 
            // tbxRootDirectoryPath
            // 
            this.tbxRootDirectoryPath.Location = new System.Drawing.Point(12, 12);
            this.tbxRootDirectoryPath.Name = "tbxRootDirectoryPath";
            this.tbxRootDirectoryPath.Size = new System.Drawing.Size(465, 20);
            this.tbxRootDirectoryPath.TabIndex = 0;
            // 
            // btnSelectRootDirectory
            // 
            this.btnSelectRootDirectory.Location = new System.Drawing.Point(483, 10);
            this.btnSelectRootDirectory.Name = "btnSelectRootDirectory";
            this.btnSelectRootDirectory.Size = new System.Drawing.Size(129, 23);
            this.btnSelectRootDirectory.TabIndex = 1;
            this.btnSelectRootDirectory.Text = "Select Root Directory";
            this.btnSelectRootDirectory.UseVisualStyleBackColor = true;
            this.btnSelectRootDirectory.Click += new System.EventHandler(this.btnSelectRootDirectory_Click);
            // 
            // btnAnalyseStructure
            // 
            this.btnAnalyseStructure.Location = new System.Drawing.Point(618, 10);
            this.btnAnalyseStructure.Name = "btnAnalyseStructure";
            this.btnAnalyseStructure.Size = new System.Drawing.Size(126, 23);
            this.btnAnalyseStructure.TabIndex = 2;
            this.btnAnalyseStructure.Text = "Analyse Structure";
            this.btnAnalyseStructure.UseVisualStyleBackColor = true;
            this.btnAnalyseStructure.Click += new System.EventHandler(this.btnAnalyseStructure_Click);
            // 
            // twDirectoryTree
            // 
            this.twDirectoryTree.Location = new System.Drawing.Point(12, 54);
            this.twDirectoryTree.Name = "twDirectoryTree";
            this.twDirectoryTree.Size = new System.Drawing.Size(732, 807);
            this.twDirectoryTree.TabIndex = 3;
            this.twDirectoryTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.twDirectoryTree_NodeMouseDoubleClick);
            // 
            // AnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 873);
            this.Controls.Add(this.twDirectoryTree);
            this.Controls.Add(this.btnAnalyseStructure);
            this.Controls.Add(this.btnSelectRootDirectory);
            this.Controls.Add(this.tbxRootDirectoryPath);
            this.Name = "AnalyserForm";
            this.Text = "Directory Structure Analyser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxRootDirectoryPath;
        private System.Windows.Forms.Button btnSelectRootDirectory;
        private System.Windows.Forms.Button btnAnalyseStructure;
        private System.Windows.Forms.TreeView twDirectoryTree;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
    }
}

