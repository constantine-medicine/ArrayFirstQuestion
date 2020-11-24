using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayFirstQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учету финансов
            // и протестрировать его работу!
            // Суть задачи в следующем:
            // Руководство фирмы по 12 месяцев ведет учет расходов и поступлений средств.
            // За год получены два массива - расходов и поступлений.
            // Определить прибыли по месяцам 
            // Количество месяцев с положительной прибылью
            // Добавить возможность вывода трех худших показателей по месяцам с худшей прибылью,
            // если есть несколько месяцев, в которых худшая прибыль совпала - вместе их все
            // Организовать дружелюбный интерфейс взаимодействия и вывода на экран

            // Пример:

            // Месяц     Доход, тыс. руб.     Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1             100 000                80 000                 20 000
            //     2             120 000               120 000                      0
            //     3              90 000                65 000                 25 000
            //     4              65 000                30 000                 35 000

            string[] tableScoreName = { "Месяц", "Доход, тыс. руб.", "Расход, тыс. руб.", "Прибыль, тыс. руб." };

            int[,] tableScore = new int[12, 4];
            int counter = 0;

            int[] profit = new int[tableScore.GetLength(0)];

            Random rand = new Random();

            for (int i = 0; i < tableScore.GetLength(0); i++)
            {
                //Console.Write($"\nВведите доход в {i + 1} месяце: ");         // релизация ручного ввода данных в массив
                //int income = int.Parse(Console.ReadLine());                   //
                //                                                              // 
                //Console.Write($"\nВведите расход в {i + 1} месяце: ");        //
                //int consump = int.Parse(Console.ReadLine());                  //

                int income = rand.Next(2);                                 // заполняет массив случайными числами для простоты вывода 
                int consump = rand.Next(2);                                // 


                tableScore[i, 0] = i + 1;                                       // заполняет первый столбец массива (Месяц)
                tableScore[i, 1] = income;                                      // заполняет второй столбец массива (Доход, тыс. руб.)
                tableScore[i, 2] = consump;                                     // заполняет третий столбец массива (Расход, тыс. руб.)
                tableScore[i, 3] = income - consump;                            // расчитывает и заполняет четвертый столбец массива (Прибыль, тыс. руб.)
                profit[i] = tableScore[i, 3];                                   // заполняет данными прибыли новый одномерный массив

                if (tableScore[i, 3] > 0) counter++;                            // подсчет месяцев с положительной прибылью
            }
            Console.WriteLine();

            foreach (var item in tableScoreName)                                // выводит в консоль название таблицы
            {
                Console.Write("{0, 20}", item);
            }
            Console.WriteLine();

            for (int i = 0; i < tableScore.GetLength(0); i++)                   // выводит в консоль расчетные данные
            {
                for (int j = 0; j < tableScore.GetLength(1); j++)
                {
                    Console.Write("{0, 20}", tableScore[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[] profitCopy = new int[profit.Length];                          // инициализация будущей копии массива прибыли для последующей сортировки и сравнения

            Array.Copy(profit, profitCopy, profit.Length);
            Array.Sort(profitCopy);

            int firstBadIndex = profitCopy[0];                                  // извлекаем три худших показателя из массива выручки в переменные
            int secondBadIndex = 0;
            int thirdBadIndex = 0;

            for (int i = 1; i < profitCopy.Length; i++)
            {
                if (profitCopy[i] > firstBadIndex)
                {
                    secondBadIndex = profitCopy[i];
                    break;
                }
            }

            for (int i = 2; i < profitCopy.Length; i++)
            {
                if (profitCopy[i] > secondBadIndex)
                {
                    thirdBadIndex = profitCopy[i];
                    break;
                }
            }

            Array.Resize(ref profitCopy, 3);                                    // изменяем количество элементов в копии массива выручки       
                                                                                
            profitCopy[0] = firstBadIndex;                                      // заполняем отредактированный массив копии выручки худшими ее элементами
            profitCopy[1] = secondBadIndex;
            profitCopy[2] = thirdBadIndex;
            int counterMounth = 0;                                              // заводим переменную - счетчик месяцев, чтобы выходить из цикла

            Console.Write("Худшие месяцы по трем худшим показателям: ");

            for (int i = 0; i < profitCopy.Length; i++)
            {
                for (int j = 0; j < profit.Length; j++)
                {
                    if (profitCopy[i] == profit[j])
                    {
                        Console.Write($"{j + 1} ");
                        counterMounth++;
                    }
                }
                
                if (counterMounth == 12) break;
            }
            Console.WriteLine();

            Console.Write($"\nКоличество месяцев с положительной прибылью: {counter}");

            Console.ReadKey();
        }
    }
}
