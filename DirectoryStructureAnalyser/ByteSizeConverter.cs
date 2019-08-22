using System;

namespace DirectoryStructureAnalyser
{
    public class ByteSizeConverter
    {
        public static double MbFromByte(long sizeInBytes)
        {
            return Math.Round(sizeInBytes / Math.Pow(1024, 2), 1);
        }
    }
}
