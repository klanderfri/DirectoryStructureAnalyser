using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DirectoryStructureAnalyser
{
    public partial class AnalyserForm : Form
    {
        public AnalyserForm()
        {
            InitializeComponent();

            tbxRootDirectoryPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnSelectRootDirectory_Click(object sender, EventArgs e)
        {
            //Select root folder.

            using (var directorySelecter = new FolderBrowserDialog())
            {
                if (directorySelecter.ShowDialog() == DialogResult.OK)
                {
                    tbxRootDirectoryPath.Text = directorySelecter.SelectedPath;
                }
            }
        }

        private void btnAnalyseStructure_Click(object sender, EventArgs e)
        {
            //Analyse tree.

            if (!String.IsNullOrWhiteSpace(tbxRootDirectoryPath.Text))
            {
                twDirectoryTree.Nodes.Clear();
                var root = new Folder(tbxRootDirectoryPath.Text);
                twDirectoryTree.AddFileFolderStructure(root);
                twDirectoryTree.Nodes[0].Expand();
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
