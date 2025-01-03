using System;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace PlanetShoes.Utils
{
    public static class ImageHelper
    {
        // 1. Buscar uma imagem em um diretório do usuário
        public static string GetImagePathFromUser()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return null;
        }

        // 2. Converter a imagem em um array de bytes
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                throw new FileNotFoundException("O arquivo de imagem não foi encontrado.");
            }

            // Verifica o tamanho da imagem (limite de 2MB)
            FileInfo fileInfo = new FileInfo(imagePath);
            if (fileInfo.Length > 2 * 1024 * 1024) // 2MB
            {
                throw new InvalidOperationException("A imagem excede o tamanho máximo permitido de 2MB.");
            }

            return File.ReadAllBytes(imagePath);
        }

        // 3. Reverter a imagem de um array de bytes para uma ImageBox
        public static BitmapImage ConvertByteArrayToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                throw new ArgumentNullException(nameof(imageData), "Os dados da imagem não podem ser nulos ou vazios.");
            }

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze(); // Congela a imagem para uso seguro em threads

            return image;
        }

        // 4. Limitar o tamanho da imagem importada a 2MB
        public static bool IsImageWithinSizeLimit(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                throw new FileNotFoundException("O arquivo de imagem não foi encontrado.");
            }

            FileInfo fileInfo = new FileInfo(imagePath);
            return fileInfo.Length <= 2 * 1024 * 1024; // 2MB
        }
    }
}