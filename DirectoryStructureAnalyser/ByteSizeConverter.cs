using System;

namespace DirectoryStructureAnalyser
{
    /// <summary>
    /// Class for converting byte sizes.
    /// </summary>
    public class ByteSizeConverter
    {
        /// <summary>
        /// Converts bytes into MB.
        /// </summary>
        /// <param name="sizeInBytes">The size, in bytes, to convert to MB.</param>
        /// <returns>The size in MB.</returns>
        public static double MbFromByte(long sizeInBytes)
        {
            return Math.Round(sizeInBytes / Math.Pow(1024, 2), 1);
        }
    }
}
