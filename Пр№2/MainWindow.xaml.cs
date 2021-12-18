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
using Microsoft.Win32;
using LibMas;
using Lib_11;

namespace Пр_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] matrix;
        private void CreateMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(numberColumn.Text, out int columnCount) == true && Int32.TryParse(numberString.Text, out int stringCount) == true)
            {
                actionArray.CreateArray(out matrix, columnCount, stringCount);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void FillMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(startOfRange.Text, out int startRange) == true && Int32.TryParse(endOfRange.Text, out int endRange) == true && Int32.TryParse(numberColumn.Text, out int columnCount) == true && Int32.TryParse(numberString.Text, out int stringCount) == true)
            {
                actionArray.FillArray(out matrix, startRange, endRange, stringCount, columnCount);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                Class1.Calculate(matrix, out int numberString);
                numberOfString.Text = numberString.ToString();
            }
            else MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                actionArray.ClearArray(ref matrix);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actionArray.SaveArray(matrix);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

            actionArray.OpenArray(out matrix);
            DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №3\nВыполнил студент группы ИСП-31 Обухов С\nЗадание:Дана матрица размера M × N. Найти количество ее строк, элементы которых упорядочены по возрастанию. ");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int indexColumn = e.Column.DisplayIndex;
                int indexRow = e.Row.GetIndex();
                matrix[indexRow, indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
