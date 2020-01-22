using System;
using System.Drawing;
using System.Windows.Forms;

namespace DirectoryStructureAnalyser
{
    public class AnalyserTreeView : TreeView
    {
        public void AddFileFolderStructure(Folder root)
        {
            addDirectoryToTree(root, Nodes);
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
                var sizeInMB = ByteSizeConverter.MbFromByte(file.Length);
                var fileDescription = String.Format(descriptionFormat, file.Name, sizeInMB);
                addNode(directoryNode.Nodes, fileDescription, sizeInMB, file);
            }
        }

        private static TreeNode addNode(TreeNodeCollection parent, string description, double sizeInMB, object tag)
        {
            var node = parent.Add(description);
            node.Tag = tag;

            if (sizeInMB > 100)
            {
                node.ForeColor = Color.Red;
            }

            return node;
        }
    }
}
