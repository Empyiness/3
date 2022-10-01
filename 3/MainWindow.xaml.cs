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
using LibMatrix;
using Lib_12;

namespace _3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            matrix = new Matrix<int>();
            DataGridMatrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }
        Matrix<int> matrix;

        private void Generate(object sender, RoutedEventArgs e)
        {
            int rowcount = 5;
            int columncount = 4;
            int min = 1;
            int max = 30;
            if (RowBox.Text != "")
            {
                if (!Int32.TryParse(RowBox.Text, out rowcount))
                {
                    MessageBox.Show("Введите число!");
                    RowBox.Clear();
                    RowBox.Focus();
                    return;
                }
            }
            if (ColumnBox.Text != "")
            {
                if (!Int32.TryParse(ColumnBox.Text, out columncount))
                {
                    MessageBox.Show("Введите число!");
                    ColumnBox.Clear();
                    ColumnBox.Focus();
                    return;
                }
            }
            if (MinBox.Text != "")
            {
                if (!Int32.TryParse(MinBox.Text, out min))
                {
                    MessageBox.Show("Введите число!");
                    MinBox.Clear();
                    MinBox.Focus();
                    return;
                }
            }
            if (MaxBox.Text != "")
            {
                if (!Int32.TryParse(MaxBox.Text, out max))
                {
                    MessageBox.Show("Введите число!");
                    MaxBox.Clear();
                    MaxBox.Focus();
                    return;
                }
            }
            matrix = new Matrix<int>(rowcount, columncount);
            matrix.Generate(min, max);
            SumBox.Text = matrix.Sum().ToString();
            DataGridMatrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string path = @".\matrix" + matrix.Extension;
            matrix.Save(path);
            DataGridMatrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            string path = @".\matrix" + matrix.Extension;
            matrix.Load(path);
            DataGridMatrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            matrix.DefaultInit();
            DataGridMatrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Митин А ИСП-31, Найти сумму чисел >15. Результат вывести на экран.");
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
