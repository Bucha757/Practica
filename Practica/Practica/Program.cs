using System;

namespace Practica
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 0;
            int t = 0;
            int kr;
            do
            {
                Console.Write("Введiть 1 якщо критерiй максимальний, 2 мiнiмальний: ");
                kr = int.Parse(Console.ReadLine());
                if (kr == 1)
                {
                    r = 2;
                    t = 3;
                    break;
                }
                else if (kr == 2)
                {
                    r = 3;
                    t = 2;
                    break;
                }
                else Console.WriteLine("Введено неправильно!");
            } while (true);
            Console.Write("Рядкiв: ");
            int x = int.Parse(Console.ReadLine());
            x++;
            Console.Write("Стовпцiв: ");
            int y = int.Parse(Console.ReadLine());
            y++;
            Console.Write("Коефiцiєнт довiри: ");
            double a = Convert.ToDouble(Console.ReadLine());
            int[,] mas = new int[x, y];
            double[,] func = new double[x, 6];
            int[,] alt = new int[x, y];
            int[] sev = new int[y];
            double[] res = new double[6];
            int[] result = new int[6];
            int w;
            int q = 0;
            Console.WriteLine();

            Console.WriteLine("Заполни матрицу");

            if (kr == 2)
            {
                for (int i = 1; i < 6; i++)
                {
                    res[i] = 99999999;
                }
            } else { res[4] = 99999999; }

            for (int i = 1; i < x; i++)
            {
                func[i, r] = 99999999;
                for (int j = 1; j < y; j++)
                {
                    Console.Write("mas[" + i + "," + j + "]: ");
                    mas[i, j] = int.Parse(Console.ReadLine());
                    func[i, 1] = func[i, 1] + mas[i, j];
                    if (func[i, t] < mas[i, j])
                    {
                        func[i, t] = mas[i, j];
                    }
                    if (func[i, r] > mas[i, j])
                    {
                        func[i, r] = mas[i, j];
                    }
                }
                func[i, 1] = func[i, 1] / (y-1);
            }
            Console.WriteLine();

            for (int i = 1; i < y; i++)
            {
              if (kr == 2) { sev[i] = 99999999; }
                for (int j = 1; j < x; j++)
                {
                    if ( kr == 1 )  {
                        if (sev[i] < mas[j, i])
                        {
                            sev[i] = mas[j, i];
                        } 
                    } else {
                        if (sev[i] > mas[j, i])
                        {
                            sev[i] = mas[j, i];
                        }
                    }
                }
                for (int j = 1; j < x; j++)
                {
                    if(kr == 1) alt[j, i] = sev[i] - mas[j, i];
                    else alt[j, i] =  mas[j, i] - sev[i];

                }
            }
            for (int i = 1; i < x; i++)
            {
               for (int j = 1; j < y; j++)
                {
                    if (func[i, 4] < alt[i, j])
                    {
                        func[i, 4] = alt[i, j];
                    }
                }
                func[i, 5] = func[i, 3] * a + func[i, 2] * (1 - a);
            }

            for (int i = 1; i < x; i++)
            {
                if (kr == 1)
                {
                    if (res[1] < func[i, 1])
                    {
                        res[1] = func[i, 1];
                        result[1] = i;
                    }
                    if (res[2] < func[i, 2])
                    {
                        res[2] = func[i, 2];
                        result[2] = i;
                    }
                    if (res[3] < func[i, 3])
                    {
                        res[3] = func[i, 3];
                        result[3] = i;
                    }
                    if (res[5] < func[i, 5])
                    {
                        res[5] = func[i, 5];
                        result[5] = i;
                    }
                }
                else
                {
                    if (res[1] > func[i, 1])
                    {
                        res[1] = func[i, 1];
                        result[1] = i;
                    }
                    if (res[2] > func[i, 2])
                    {
                        res[2] = func[i, 2];
                        result[2] = i;
                    }
                    if (res[3] > func[i, 3])
                    {
                        res[3] = func[i, 3];
                        result[3] = i;
                    }
                    if (res[5] > func[i, 5])
                    {
                        res[5] = func[i, 5];
                        result[5] = i;
                    }
                }
                if (res[4] > func[i, 4])
                {
                    res[4] = func[i, 4];
                    result[4] = i;
                }
            }

            Console.Write("A/S \t");
            for (int i = 1; i < y; i++)
            {
                Console.Write("S" + i + "\t");
            }
            Console.Write("Лапласа ");
            Console.Write("Вальда ");
            Console.Write("Макс ");
            Console.Write("Севiджа ");
            Console.WriteLine("Гуреiца ");
            for (int i = 1; i < x; i++)
            {
                Console.Write("A" + i + "\t");
                for (int j = 1; j < y; j++)
                {
                    Console.Write( mas[i, j] + "\t");
                }
                for (int j = 1; j < 6; j++)
                {
                    Console.Write(Math.Round(func[i, j], 2) + "\t");
                }
                Console.WriteLine();
            }
            Console.Write("A/S \t");
            for (int i = 1; i < y; i++)
            {
                Console.Write("S" + i + "\t");
            }
            for (int i = 1; i < 6; i++)
            {
                Console.Write("A" + result[i] + "\t");
            }
            Console.WriteLine();
            for (int i = 1; i < x; i++)
            {
                Console.Write("A" + i + "\t");
                for (int j = 1; j < y; j++)
                {
                    Console.Write(alt[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            y = 0;
            for (int i = 1; i < 6; i++)
            {
                w = 0;
                for (int j = 1; j < 6; j++)
                {
                    if (result[i] == result[j])
                    {
                              w++;
                    }
                }
                if (w > y)
                {
                    y = w;
                    q = result[i];
                }
            }
            Console.Write("Вигiднiше обрати A" + q);
            Console.ReadLine();
        }

    }
}
