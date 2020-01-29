using System;
using System.Drawing;
using System.Windows.Forms;

namespace DirectoryStructureAnalyser
{
    /// <summary>
    /// A tre view for analysing a folder structure.
    /// </summary>
    public class AnalyserTreeView : TreeView
    {
        /// <summary>
        /// Adds a folder structure to the tree view.
        /// </summary>
        /// <param name="settings">An object representing the settings for adding the folder structure.</param>
        public void AddFileFolderStructure(AnalyseSettings settings)
        {
            addDirectoryToTree(settings.RootFolder, Nodes, settings);
        }

        /// <summary>
        /// Adds a folder to the tree view.
        /// </summary>
        /// <param name="directory">The folder to add to the tree view.</param>
        /// <param name="parentNode">The parent node collection.</param>
        /// <param name="settings">The settings for the folder structure analyse.</param>
        private void addDirectoryToTree(Folder directory, TreeNodeCollection parentNode, AnalyseSettings settings)
        {
            var descriptionFormat = "{0} - {1} MB";
            var description = String.Format(descriptionFormat, directory.Info.Name, directory.SizeInMB);
            var directoryNode = addNode(parentNode, description, directory.SizeInMB, settings, directory);

            var underline = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
            directoryNode.NodeFont = underline;

            foreach (var child in directory.SubFolders)
            {
                addDirectoryToTree(child, directoryNode.Nodes, settings);
            }

            foreach (var file in directory.Info.GetFiles())
            {
                var sizeInMB = ByteSizeConverter.MbFromByte(file.Length);
                var fileDescription = String.Format(descriptionFormat, file.Name, sizeInMB);
                addNode(directoryNode.Nodes, fileDescription, sizeInMB, settings, file);
            }
        }

        /// <summary>
        /// Adds a node to the node collection in the tree view.
        /// </summary>
        /// <param name="parent">The parent node collection.</param>
        /// <param name="description">The description of the node.</param>
        /// <param name="sizeInMB">The size in MB of the node and its subnodes.</param>
        /// <param name="settings">The settings for the folder structure analyse.</param>
        /// <param name="tag">An object to hang on to the node.</param>
        /// <returns>The added tree node.</returns>
        private static TreeNode addNode(TreeNodeCollection parent, string description, double sizeInMB, AnalyseSettings settings, object tag)
        {
            var node = parent.Add(description);
            node.Tag = tag;

            if (sizeInMB >= settings.BigFolderMbyteSize)
            {
                node.ForeColor = settings.BigFolderColour;
            }

            return node;
        }
    }
}
