using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ParallelStaff.FileManager.Common.Enums;

namespace ParallelStaff.FileManager.Core
{
    public class FileManager
    {
        static public void Copy(DirectoryInfo sourceFolder, DirectoryInfo destFolder, OperationMenu operation)
        {
            if (operation == OperationMenu.Copiar)
            {
                DirectoryCopy(sourceFolder, destFolder);
            }
            else
            {
                DirectoryCup(sourceFolder, destFolder);
            }
        }
        private static void DirectoryCopy(DirectoryInfo sourceFolder, DirectoryInfo destFolder)
        {
            Directory.CreateDirectory(destFolder.FullName);
            foreach (var file in sourceFolder.GetFiles())
            {
                file.CopyTo(Path.Combine(destFolder.FullName, file.Name), true);

            }

            foreach (var sourcedirectory in sourceFolder.GetDirectories())
            {
                var targetdirectory = destFolder.CreateSubdirectory(sourcedirectory.Name);
                DirectoryCopy(sourcedirectory, targetdirectory);
            }
        }
        private static void DirectoryCup(DirectoryInfo sourceFolder, DirectoryInfo destFolder)
        {
            Directory.Move(sourceFolder.FullName, destFolder.FullName);
        }
    }
}
