using System;
using System.Collections.Generic;
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
using System.IO;
using System.Text.RegularExpressions;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <p>
        /// В поле filePath хранится путь к файлу
        /// </p>

        string filePath = @"file.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод showButton_Click показывает содержимое файла, при нажатии на кнопку showButton
        /// </summary>

        private void showButton_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader sr = new StreamReader(filePath))
            {
                MessageBox.Show(sr.ReadToEnd());
            }
        }

        /// <summary>
        /// Метод formatButton_Click форматирует текст, при нажатии на кнопку formatButton
        /// </summary>

        private void formatButton_Click(object sender, RoutedEventArgs e)
        {
            string[] str = new string[3];
            string content;
            string searchText = ",";
            string replaceText = " Y: ";

            using (StreamReader reader = new StreamReader(filePath))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    content = reader.ReadLine();
                    str[i] = content;
                }
            }

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Regex.Replace(str[i], searchText, replaceText);
                str[i] = str[i].Insert(0, "X: ");
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    writer.WriteLine(str[i]);
                }
            }
        }

        /// <summary>
        /// Метод writeButton_Click записывает текст из поля textBox в файл, при нажатии на кнопку writeButton
        /// </summary>

        private void writeButton_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
            {
                if (text != "")
                {
                    writer.WriteLine(text);
                }
            }
        }

        /// <summary>
        /// Метод clearButton_Click очищает файл, при нажатии на кнопку writeButton.
        /// </summary>

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false))
            {
                    writer.Write("");
            }
        }
    }
}
