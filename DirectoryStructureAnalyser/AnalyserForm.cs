using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DirectoryStructureAnalyser
{
    public partial class AnalyserForm : Form
    {
        /// <summary>
        /// Holds the settings for the folder structure analyse.
        /// </summary>
        private AnalyseSettings Settings { get; set; }

        public AnalyserForm()
        {
            InitializeComponent();

            Settings = new AnalyseSettings();
            prgAnalyseSettings.SelectedObject = Settings;
        }
        
        private void btnAnalyseStructure_Click(object sender, EventArgs e)
        {
            //Analyse tree.

            if (!String.IsNullOrWhiteSpace(Settings.RootFolderPath))
            {
                twDirectoryTree.Nodes.Clear();

                using (var waiting = new WaitForm(addFolderStructureToTreeView))
                {
                    waiting.ShowDialog();
                }
            }
        }

        private void addFolderStructureToTreeView()
        {
            //Performs the operations needed to add the folder structer to the tree view.
            
            if (twDirectoryTree.InvokeRequired)
            {
                twDirectoryTree.BeginInvoke((MethodInvoker)delegate
                {
                    twDirectoryTree.AddFileFolderStructure(Settings);
                    twDirectoryTree.Nodes[0].Expand();
                });
            }
        }

        private void twDirectoryTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Open node file/folder.

            var directory = e.Node.Tag as Folder;
            var file = e.Node.Tag as FileInfo;
            if (directory != null)
            {
                Process.Start(directory.Info.FullName);
            }
            else if (file != null)
            {
                Process.Start(file.Directory.FullName);
            }
        }
    }
}
