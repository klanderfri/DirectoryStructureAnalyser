using System.Collections.Generic;
using System.IO;

namespace DirectoryStructureAnalyser
{
    /// <summary>
    /// Class for object representing a folder in a file-folder tree structure.
    /// </summary>
    public class Folder
    {
        public DirectoryInfo Info { get; private set; }
        public long SizeInBytes { get; private set; }
        public double SizeInMB
        {
            get { return ByteSizeConverter.MbFromByte(SizeInBytes); }
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
            
            foreach (var file in Info.GetFiles())
            {
                SizeInBytes += file.Length;
            }
        }
    }
}
