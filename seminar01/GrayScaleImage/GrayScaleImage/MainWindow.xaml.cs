using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrayScaleImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage originalImage;
        private byte[] originalImageBytes;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg)|*.jpg; *.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true){
                showImage(openFileDialog.FileName);

                redFilterButton.IsEnabled = true;
                invertButton.IsEnabled = true;
                processingButton.IsEnabled = true;

            }
        }

        private void showImage(string fileName) {
            Image image = new Image();
            originalImage = new BitmapImage();
            originalImage.BeginInit();
            originalImage.UriSource = new Uri(fileName, UriKind.RelativeOrAbsolute);
            originalImage.EndInit();
            image.Source = originalImage;
            image.Stretch = Stretch.Uniform;
            originalImageBytes = ImageToByte(originalImage);
            originalPanel.Children.Add(image);

        }

        public byte[] ImageToByte(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private void setGrayscale(byte[] grayImage) {            
            // TODO: convert image to gray-scale, changing all pixels
        }
        private void setInvert(byte[] grayImage)
        {
            // TODO: invert image, each pixel = 255 - pixel_value
        }
        private void setRedFilter(byte[] grayImage)
        {
            // TODO: show only red chanel
        }
        private BitmapSource ToBitmapImage(byte[] grayImage)
        {
            // TODO: convert byteArray to BitmapSource 
            return null;
        }

        private void redFilterButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: add red filter
        }
        private void invertButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: add invert
        }
        private void processingButton_Click(object sender, RoutedEventArgs e)
        {
            ToBitmapImage(originalImageBytes);
            // TODO: add gray scale
        }
    }
}
