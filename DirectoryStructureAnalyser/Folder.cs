using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryStructureAnalyser
{
    /// <summary>
    /// Class for object representing a folder in a file-folder tree structure.
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// The information about the folder.
        /// </summary>
        public DirectoryInfo Info { get; private set; }

        /// <summary>
        /// The byte size of the folder and its content.
        /// </summary>
        public long SizeInBytes { get; private set; }

        /// <summary>
        /// The MB size of the folder and its content.
        /// </summary>
        public double SizeInMB
        {
            get { return ByteSizeConverter.MbFromByte(SizeInBytes); }
        }
        
        /// <summary>
        /// The subfolders of the folder.
        /// </summary>
        public List<Folder> SubFolders { get; private set; } = new List<Folder>();

        /// <summary>
        /// The subfolders that are not available for the application.
        /// </summary>
        public List<string> UnavailableFolders { get; private set; } = new List<string>();

        /// <summary>
        /// Creates an object representing a folder in a file-folder tree structure.
        /// </summary>
        /// <param name="folderpath">The physical path to the folder.</param>
        public Folder(string folderpath)
        {
            Info = new DirectoryInfo(folderpath);

            fillSubfolders();
            calculateSize();
        }

        /// <summary>
        /// Adds the subfolder structure to the subfolder list.
        /// </summary>
        private void fillSubfolders()
        {
            foreach (var child in Info.GetDirectories())
            {
                try
                {
                    SubFolders.Add(new Folder(child.FullName));
                }
                catch (UnauthorizedAccessException)
                {
                    UnavailableFolders.Add(child.FullName);
                }
            }
        }

        /// <summary>
        /// Calculates the size of the folder and its content.
        /// </summary>
        private void calculateSize()
        {
            SizeInBytes = 0;

            foreach (var child in SubFolders)
            {
                SizeInBytes += child.SizeInBytes;
            }
            
            foreach (var file in Info.GetFiles())
            {
                SizeInBytes += file.Length;
            }
        }

        /// <summary>
        /// Finds all the unavailable subfolders withing the folder.
        /// </summary>
        /// <returns>The unavailable subfolders.</returns>
        public List<string> GetAllUnavailableFoldersInTree()
        {
            var unavailableFolders = new List<string>();

            unavailableFolders.AddRange(UnavailableFolders);

            foreach (var folder in SubFolders)
            {
                unavailableFolders.AddRange(folder.GetAllUnavailableFoldersInTree());
            }

            return unavailableFolders;
        }
    }
}
