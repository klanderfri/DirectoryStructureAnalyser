using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryStructureAnalyser
{
    public partial class AnalyserForm : Form
    {
        public AnalyserForm()
        {
            InitializeComponent();
        }

        private void btnSelectRootDirectory_Click(object sender, EventArgs e)
        {
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
            if (!String.IsNullOrWhiteSpace(tbxRootDirectoryPath.Text))
            {
                twDirectoryTree.Nodes.Clear();
                var root = new Folder(tbxRootDirectoryPath.Text);
                addDirectoryToTree(root, twDirectoryTree.Nodes);
                twDirectoryTree.Nodes[0].Expand();
            }
        }

        private void addDirectoryToTree(Folder directory, TreeNodeCollection parentNode)
        {
            var descriptionFormat = "{0} - {1} MB";
            var description = String.Format(descriptionFormat, directory.Info.Name, directory.SizeInMB);
            var directoryNode = addNode(parentNode, description, directory.SizeInMB, directory);

            var underline = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
            directoryNode.NodeFont = underline;

            foreach (var child in directory.SubFolders)
            {
                addDirectoryToTree(child, directoryNode.Nodes);
            }

            foreach (var file in directory.Info.GetFiles())
            {
                var sizeInMB = Converter.MbFromByte(file.Length);
                var fileDescription = String.Format(descriptionFormat, file.Name, sizeInMB);
                addNode(directoryNode.Nodes, fileDescription, sizeInMB, file);
            }
        }

        private TreeNode addNode(TreeNodeCollection parent, string description, double sizeInMB, object tag)
        {
            var node = parent.Add(description);
            node.Tag = tag;

            if (sizeInMB > 100)
            {
                node.ForeColor = Color.Red;
            }

            return node;
        }

        private void twDirectoryTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
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

    public class Converter
    {
        public static double MbFromByte(long sizeInBytes)
        {
            return Math.Round(sizeInBytes / Math.Pow(1024, 2), 1);
        }
    }

    public class Folder
    {
        public DirectoryInfo Info { get; private set; }
        public long SizeInBytes { get; private set; }
        public double SizeInMB
        {
            get { return Converter.MbFromByte(SizeInBytes); }
        }

        public List<Folder> SubFolders { get; private set; }

        public Folder(string folderpath)
        {
            Info = new DirectoryInfo(folderpath);
            fillSubfolders();
            calculateSize();
        }

        private void fillSubfolders()
        {
            SubFolders = new List<Folder>();

            foreach (var child in Info.GetDirectories())
            {
                SubFolders.Add(new Folder(child.FullName));
            }
        }

        private void calculateSize()
        {
            SizeInBytes = 0;

            foreach (var child in SubFolders)
            {
                SizeInBytes += child.SizeInBytes;
            }

            var files = Info.GetFiles();
            foreach (var file in files)
            {
                SizeInBytes += file.Length;
            }
        }
    }
}
