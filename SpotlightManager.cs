using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpotlightWallpaper
{
    class SpotlightManager
    {
        private const string SpotlightAssetPath = "Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
        private const string SpotlightDirectoryName = "SpotlightWallpaper";

        static void Main(string[] args)
        {
            string AssetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), SpotlightAssetPath);
            string OutputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), SpotlightDirectoryName);

            if (!Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }


            string[] FileNames = Directory.GetFiles(AssetPath);

            foreach (string FilePath in FileNames)
            {
                Image imageFile = Image.FromFile(FilePath);

                if (imageFile.Width == 1920 && imageFile.Height == 1080)
                {
                    string OutputFilePath = Path.Combine(OutputDirectory, Path.GetFileName(FilePath) + ".jpg");
                    File.Copy(FilePath, OutputFilePath, true);
                }
            }
        }
    }
}
