using LiveCharts.Wpf;
using LiveCharts;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Model;
using WpfApp.ViewModel;
using System.Data;
using System.Security.Policy;
using System.Runtime.Serialization;
using LiveCharts.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.FileHelper
{
    public class FileUtility
    {
        string filePath;
        Dan initialData;
        VmMainWindow VmMainW;
        
        public FileUtility(string filePath, Dan initialData, VmMainWindow DataContext)
        {
            this.filePath = filePath;
            this.initialData = initialData;
            VmMainW = DataContext;
        }

        public void FillFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath, append: false))
            {
                sw.WriteLine($"Х начальное: {initialData.iStart}");
                sw.WriteLine($"Х конечное: {initialData.iEnd}");
                sw.WriteLine($"Шаг x: {initialData.hstep}");
                sw.WriteLine($"Точность: {initialData.epsilon}");
                sw.WriteLine($"Шаг интерполяции (g): {initialData.gstep}");

                sw.WriteLine("\nМассив A\n");
                initialData.arrayA = Arrays.MakeArrayA(initialData.iStart, initialData.iEnd, initialData.hstep, initialData.epsilon, initialData.dimension, initialData.precision);
                initialData.controlArray = Arrays.MakeControlArray(initialData.iStart, initialData.iEnd, initialData.hstep, initialData.epsilon, initialData.dimension, initialData.precision);

                sw.WriteLine($"x\ty\tКонтрольная формула");

                int arrayIndex = 0;
                //Запись массива A и массива контрольных формул в файл
                if (initialData.hstep > 0) // Проверка на ввод отрицательного начального значения
                {
                    for (double i = initialData.iStart; i <= initialData.iEnd; i += initialData.hstep)
                    {
                        sw.WriteLine($"{Math.Round(i, initialData.precision)}\t{initialData.arrayA[arrayIndex]}\t{initialData.controlArray[arrayIndex]}");
                        arrayIndex++;
                    }
                }
                else
                {
                    for (double i = initialData.iStart; i >= initialData.iEnd; i += initialData.hstep)
                    {
                        sw.WriteLine($"{Math.Round(i, 1)}\t{initialData.arrayA[arrayIndex]}\t{initialData.controlArray[arrayIndex]}");
                        arrayIndex++;
                    }
                }

                VmMainW.ListA = VmMainW.GetListFromArray(initialData.arrayA, initialData.controlArray); // Добавление массива в коллекцию для вывода в DataGrid


                sw.WriteLine("\nМассив B\n");

                initialData.arrayB = Arrays.MakeArrayB(initialData.dimension);

                for (int i = 0; i < initialData.dimension; i++)
                {
                    for (int j = 0; j < initialData.dimension; j++)
                    {
                        sw.Write($"{initialData.arrayB[i, j]}\t");
                    }
                    sw.WriteLine();
                }

                VmMainW.ListB = VmMainW.GetListFromArrayB(initialData.arrayB);


                sw.WriteLine("\nМассив C\n");

                initialData.arrayC = Arrays.MakeArrayC(initialData.arrayA, initialData.arrayB);

                for (int i = 0; i < initialData.dimension; i++)
                {
                    sw.Write($"{initialData.arrayC[i]}\n ");
                }

                VmMainW.ListC = VmMainW.GetListFromArray(initialData.arrayC);


                sw.WriteLine("\n\nМассив Y\n");

                sw.WriteLine("x \t Канонический полином");

                initialData.arrayY = Arrays.MakeArrayY(initialData.arrayC, initialData.gstep);

                for (int arrayYIndex = 0; arrayYIndex < initialData.arrayY.GetLength(0); arrayYIndex++)
                {
                    sw.WriteLine($"{initialData.arrayY[arrayYIndex, 0]} \t {initialData.arrayY[arrayYIndex, 1]}");
                }

                VmMainW.ListY = VmMainW.GetListFromArray(initialData.arrayY);


                sw.WriteLine($"\nСортированный массив Y\n");
                sw.WriteLine("x \t Y");

                initialData.sortedArrayY = Arrays.ShellSort(initialData.arrayY);

                for (int arrayYIndex = 0; arrayYIndex < initialData.arrayY.GetLength(0); arrayYIndex++)
                {
                    sw.WriteLine($"{initialData.sortedArrayY[arrayYIndex, 0]} \t {initialData.sortedArrayY[arrayYIndex, 1]}");
                }

                VmMainW.ListSortedY = VmMainW.GetListFromArray(initialData.sortedArrayY);
            };

            VmMainW.AxisXLabels = VmMainW.ListY.Select(r => r.x.ToString("N2")).ToArray(); //Массив для подписей к точкам на графике

            VmMainW.Series = new SeriesCollection // Коллекция для графика
            {
                new LineSeries
                {
                    Title = "Y",
                    Values = VmMainW.ListY.Select(r => r.y).AsChartValues(),
                },
                new LineSeries
                {
                    Title = "Сортированный Y",
                    Values = VmMainW.ListSortedY.Select(r => r.y).AsChartValues(),
                }
            };


            VmMainW.LoadFileContent(filePath);
            MessageBox.Show("Файл заполнен");
            VmMainW.IsTabsEnable = true;
        }
    }
}
   
