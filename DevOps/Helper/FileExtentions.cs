using System.Collections.Generic;

namespace DevOps.Helper
{
    public static class FileExtentions
    {
        public static List<string> SupportedExtensions()
        {
            return new List<string>
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".PNG"
            };
        }
    }
}
