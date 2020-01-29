using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace DirectoryStructureAnalyser
{
    /// <summary>
    /// Class for object holding the settings for a folder structure analyse.
    /// </summary>
    public class AnalyseSettings
    {
        /// <summary>
        /// Creates an object holding the settings for a folder structure analyse.
        /// </summary>
        public AnalyseSettings()
        {
            RootFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            BigFolderMbyteSize = 100;
        }

        [Category("Analyse")]
        [Description("The path to the root folder of the structure to analyse.")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string RootFolderPath { get; set; }
        
        [Category("Analyse")]
        [Description("The root folder of the structure to analyse.")]
        [Browsable(false)]
        public Folder RootFolder
        {
            get { return new Folder(RootFolderPath); }
        }

        [Category("Analyse")]
        [Description("The size in MB when a folder is to be considered big.")]
        public int BigFolderMbyteSize { get; set; }
    }
}
