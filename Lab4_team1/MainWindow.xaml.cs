using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace Lab4_team1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private string selectedFilePath = "";

        public MainWindow() => InitializeComponent();

        private void btGenerateFile_Click(object sender, RoutedEventArgs e)
        {
            selectedFilePath = Directory.GetCurrentDirectory() + "\\Data.txt";

            if (MyFile.GenerateFile(selectedFilePath))
            {
                MessageBox.Show("File was successfully created in the current directory!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                // Micro pause to emulate a difficult task
                System.Threading.Thread.Sleep(1000);

                lbFileSelected.Content = "File Selected: " + selectedFilePath;
            }
            else
                MessageBox.Show("File already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };

            if (openFileDialog.ShowDialog().Value)
            {
                selectedFilePath = openFileDialog.FileName;
                lbFileSelected.Content = "File Selected: " + openFileDialog.FileName;
            }
        }

        private void btModifyFile_Click(object sender, RoutedEventArgs e)
        {
            if(selectedFilePath.Length == 0)
            {
                MessageBox.Show("File Not Selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            if(MyFile.SwapElements(selectedFilePath))
            {
                MessageBox.Show("File was successfully modified!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                lbFileSelected.Content = "File Not Selected";
                File.Delete(selectedFilePath);
                MessageBox.Show("File was corrupted. I had to delete it.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
