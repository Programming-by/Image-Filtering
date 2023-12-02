using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Image_Filtering_Project
{
    public class clsUtil
    {
        public static string GenerateGuid()
        {
            Guid NewGuid = Guid.NewGuid();

            return NewGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                  DirectoryInfo FilePath = Directory.CreateDirectory(FolderPath);
                  return true;

                } catch (Exception ex)
                {
                  MessageBox.Show("Error creating folder: " + ex.Message);
                  return false;
                }
            }
            return true;
         }

        public static string ReplaceFileNameWithGuid(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string ext = fi.Extension;

            return GenerateGuid() + ext;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {

            string DestinationFolder = @"C:\ImageFilters\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGuid(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = destinationFile;
            return true;

        }

    }
}
