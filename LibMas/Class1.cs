using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows;

namespace LibMas
{
    public class Class
    {
        public static void sozdatMas(out int[] mas, int Count)
        {
            mas = new int[Count];
        }
        public static void zapolnitMas(out int[] mas, int nachDiapoz, int konDiapoz, int Count)
        {
            mas = new int[Count];
            Random Rand = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Rand.Next(nachDiapoz, konDiapoz);
                if (mas[i] == 0) i--;
            }
        }
        public static void OchistMas(ref int[] mas)
        {
            for (int i = 0; i < mas.Length; i++) mas[i] = 0;
        }
        public static void saveMas(int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (mas != null)
            {
                //if (save.ShowDialog() == true)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(mas.Length);
                    for (int i = 0; i < mas.Length; i++)
                        file.WriteLine(mas[i]);
                    file.Close();
                }
            }
        }
        public static void openMas(int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            //if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int len = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len];
                for (int i = 0; i < mas.Length; i++)
                    mas[i] = Convert.ToInt32(file.ReadLine());
                file.Close();
                //DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }
    }
}
