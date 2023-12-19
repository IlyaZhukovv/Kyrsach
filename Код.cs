using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace exambplee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 40); // Устанавливаем размер консоли на 70 столбцов и 40 строк
            Console.SetBufferSize(70, 40); // Устанавливаем размер буфера консоли на 70 столбцов и 40 строк
            Console.BufferHeight = Int16.MaxValue - 1; // Устанавливаем максимальную высоту буфера консоли
            Console.ForegroundColor = ConsoleColor.Green; // Устанавливает цвет для символов

            string title = "МИНИСТЕРСТВО НАУКИ И ВЫСШЕГО ОБРАЗОВАНИЯ РОССИЙСКОЙ ФЕДЕРАЦИИ";
            string university = "ПЕНЗЕНСКИЙ ГОСУДАРСТВЕННЫЙ УНИВЕРСИТЕТ\r\n";
            string department = "    Кафедра: «Вычислительная техника»\r\n\n\n\n\n";
            string report = "ОТЧЕТ\r\n";
            string name = "По курсовой работе";
            string named = "На тему: Реализация алгоритма Прима";
            string discipline = "        По дисциплине: «Л и ОА в ИЗ»\r\n\n\n\n\n\n\n";
            string group = "Выполнил: ст. гр. 22ВВ4";
            string student = "Жуков И.О.\r\n";
            string teacher = "Приняли: Юрова О.В.\r\n";
            string city = "Пенза 2023";
            string teacher2 = "Акифьев И.В.\r\n\n\n\n\n\n\n";

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 3)) + "}", university));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (department.Length / 2)) + "}", department));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (department.Length / 8)) + "}", report));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (name.Length / 2)) + "}", name));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (name.Length / 1)) + "}", named));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (discipline.Length / 2)) + "}", discipline));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 1) + (group.Length / 25)) + "}", group));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 1) + (group.Length / 20)) + "}", student));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 1) + (teacher.Length / 35)) + "}", teacher));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 1) + (teacher2.Length / 3)) + "}", teacher2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (city.Length / 2)) + "}", city));

            Console.WriteLine("\n\n" + "Нажмите любую клавишу для продолжения...");
            Console.Read();
            Console.Clear();
            Console.ReadLine();

            string menuOption;
            do
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1.Случайное заполнение графа");
                Console.WriteLine("2.Ручное заполнение графа");
                Console.WriteLine("3.Выбрать граф из текстового документа");
                Console.WriteLine("4.Просмотр графов в текстовом документе(для использования)");
                Console.WriteLine("5.Просмотр сохраненных графов");
                Console.WriteLine("6.Выход");

                Console.Write("Ваш выбор: ");
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        //создается новый список строк с именем "output".
                        List<string> output2 = new List<string>();
                        int size2;
                        while (true)
                        {
                            Console.Write("Введите размер матрицы: ");

                            string input = Console.ReadLine();

                            //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1, то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (int.TryParse(input, out size2) && size2 != -1 && size2 != 0)
                            {
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                        }
                        output2.Add("Размер матрицы: " + size2.ToString());

                        int[,] adjacencyMatrix = GenerateAdjacencyMatrix(size2);
                        output2.Add("Невзвешенная матрица смежности для неориентированного графа:");
                        string matrixOutput2 = PrintMatrix(adjacencyMatrix);
                        output2.Add(matrixOutput2);
                        Console.WriteLine(matrixOutput2);

                        int[,] weightedMatrix = ConvertToWeightedMatrix(adjacencyMatrix);
                        Console.WriteLine("Взвешенная матрица смежности для неориентированного графа:");
                        string weightedMatrixOutput = PrintMatrix(weightedMatrix);
                        output2.Add("Взвешенная матрица смежности для неориентированного графа:");
                        output2.Add(weightedMatrixOutput);
                        Console.WriteLine(weightedMatrixOutput);

                        int startVertex2;
                        while (true)
                        {
                            Console.Write("Введите вершину, с которой начать обход: ");

                            string input = Console.ReadLine();

                            //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1 и меньше значения переменной "size2", то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (int.TryParse(input, out startVertex2) && startVertex2 != 0 && startVertex2 != -1 && startVertex2 < size2)
                            {
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное ненулевое число.");
                        }

                        output2.Add("Вершина, с которой начинается обход: " + startVertex2.ToString());
                        int[,] minimumSpanningTree2 = PrimAlgorithm(weightedMatrix, startVertex2);

                        Console.WriteLine("Минимальное остовное дерево по алгоритму Прима:");
                        string minimumSpanningTreeOutput2 = PrintMatrix(minimumSpanningTree2);
                        output2.Add(minimumSpanningTreeOutput2);
                        Console.WriteLine(minimumSpanningTreeOutput2);

                        output2.Add("Обход графа через самые минимальные ребра выше:");
                        Console.WriteLine("Обход графа через самые минимальные ребра:");

                        //используется StreamWriter для записи результата работы кода в файл output.txt. 
                        using (StreamWriter writer = new StreamWriter("C:/Users/Илюха/source/repos/example2228/output.txt", true))
                        {
                            int totalDistance2 = CalculateTotalDistance(minimumSpanningTree2, startVertex2, writer);
                            output2.Add("Итоговая сумма минимального расстояния обхода графа: " + totalDistance2.ToString());
                            Console.WriteLine("Итоговая сумма минимального расстояния обхода графа: " + totalDistance2.ToString());
                        }

                        string saveChoice;
                        while (true)
                        {
                            Console.Write("Хотите сохранить результат работы кода? (да/нет): ");

                            string input = Console.ReadLine();

                            //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                            {
                                saveChoice = input;
                                break;
                            }
                            //Если введенное значение не прошло проверку, выводится сообщение об ошибке "Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.", и цикл продолжает выполняться заново.
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                        }
                        if (saveChoice.ToLower() == "да")
                        {
                            string outputPath2 = "C:/Users/Илюха/source/repos/example2228/output.txt";

                            //Используя класс "StreamWriter", создается объект "writer" для записи в файл по указанному пути.
                            using (StreamWriter writer = new StreamWriter(outputPath2, true))
                            {
                                //Происходит запись каждой строки из массива "output2" в файл с помощью цикла "foreach" и метода "WriteLine()".
                                foreach (string line in output2)
                                {
                                    //Закрывается объект "writer".
                                    writer.WriteLine(line);
                                }
                                writer.Close();
                            }
                            Console.WriteLine("Результат работы кода сохранен в файле output.txt.");
                        }
                        else if (saveChoice.ToLower() == "нет")
                        {
                            Console.WriteLine("Результат работы кода не сохранен.");
                        }
                        break;
                    case "2":
                        //создается новый список строк с именем "output".
                        List<string> output = new List<string>();
                        int size;

                        while (true)
                        {
                            Console.Write("Введите размер матрицы: ");

                            string input = Console.ReadLine();

                            //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1, то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (int.TryParse(input, out size) && size != -1 && size != 0)
                            {
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                        }
                        output.Add("Размер матрицы: " + size.ToString());

                        int[,] weightedMatrix2 = FillAdjacencyMatrix(size);
                        output.Add("Взвешенная матрица смежности для неориентированного графа:");
                        Console.WriteLine("Взвешенная матрица смежности для неориентированного графа:");

                        string matrixOutput = PrintMatrix(weightedMatrix2);
                        output.Add(matrixOutput);
                        Console.WriteLine(matrixOutput);

                        int startVertex;
                        while (true)
                        {
                            Console.Write("Введите вершину, с которой начать обход: ");

                            string input = Console.ReadLine();

                            //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1 и меньше значения переменной "size2", то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (int.TryParse(input, out startVertex) && startVertex != 0 && startVertex != -1 && startVertex < size)
                            {
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное ненулевое число.");
                        }

                        output.Add("Вершина, с которой начинается обход: " + startVertex.ToString());
                        int[,] minimumSpanningTree = PrimAlgorithm(weightedMatrix2, startVertex);


                        Console.WriteLine("Минимальное остовное дерево по алгоритму Прима:");
                        matrixOutput = PrintMatrix(minimumSpanningTree);
                        output.Add(matrixOutput);
                        Console.WriteLine(matrixOutput);

                        output.Add("Обход графа через самые минимальные ребра выше:");
                        Console.WriteLine("Обход графа через самые минимальные ребра:");

                        //используется StreamWriter для записи результата работы кода в файл output.txt. 
                        using (StreamWriter writer = new StreamWriter("C:/Users/Илюха/source/repos/example2228/output.txt", true))
                        {
                            int totalDistance2 = CalculateTotalDistance(minimumSpanningTree, startVertex, writer);
                            output.Add("Итоговая сумма минимального расстояния обхода графа: " + totalDistance2.ToString());
                            Console.WriteLine("Итоговая сумма минимального расстояния обхода графа: " + totalDistance2.ToString());
                        }

                        string saveChoice2;
                        while (true)
                        {
                            Console.Write("Хотите сохранить результат работы кода? (да/нет): ");

                            string input = Console.ReadLine();

                            //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                            {
                                saveChoice2 = input;
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                        }

                        if (saveChoice2.ToLower() == "да")
                        {
                            //Используя класс "StreamWriter", создается объект "writer" для записи в файл по указанному пути.
                            using (StreamWriter writer = new StreamWriter("C:/Users/Илюха/source/repos/example2228/output.txt", true))
                            {
                                foreach (string line in output)
                                {
                                    //Происходит запись каждой строки из массива "output" в файл с помощью цикла "foreach" и метода "WriteLine()".
                                    writer.WriteLine(line);
                                }
                                //закрывается объект "writer"
                                writer.Close();
                            }
                            Console.WriteLine("Результат работы кода сохранен в файле output.txt.");
                        }
                        else
                        {
                            Console.WriteLine("Результат работы кода не сохранен.");
                        }
                        break;
                    case "3":
                        //Создается пустой список строк с именем output3.
                        List<string> output3 = new List<string>();

                        //Считывается содержимое файла matrixReady.txt и сохраняется в массив строк с именем lines.
                        string[] lines = File.ReadAllLines("C:/Users/Илюха/source/repos/example2228/matrixReady.txt");

                        //Получается размерность size3, равная количеству строк в файле.
                        int size3 = lines.Length;

                        //Создается двумерный массив matrix размером size3 на size3.
                        int[,] matrix = new int[size3, size3];

                        //Запускается цикл, который проходит по каждой строке массива lines.
                        for (int i = 0; i < size3; i++)
                        {
                            //Внутри этого цикла строка разделяется на отдельные значения, используя разделитель ' ', и сохраняется в массив строк с именем values.
                            string[] values = lines[i].Split(' ');

                            //Запускается вложенный цикл, который проходит по каждому элементу массива values.
                            for (int j = 0; j < size3; j++)
                            {
                                //Каждый элемент, представляющийся строкой, преобразуется в целое число с помощью метода int.Parse() и сохраняется в соответствующую ячейку массива matrix.
                                matrix[i, j] = int.Parse(values[j]);
                            }
                        }

                        output3.Add("Невзвешенная матрица смежности для неориентированного графа:");
                        string matrixOutput3 = PrintMatrix(matrix);
                        output3.Add(matrixOutput3);
                        Console.WriteLine(matrixOutput3);

                        int[,] weightedMatrix3 = ConvertToWeightedMatrix(matrix);
                        Console.WriteLine("Взвешенная матрица смежности для неориентированного графа:");
                        string weightedMatrixOutput3 = PrintMatrix(weightedMatrix3);
                        output3.Add("Взвешенная матрица смежности для неориентированного графа:");
                        output3.Add(weightedMatrixOutput3);
                        Console.WriteLine(weightedMatrixOutput3);

                        int startVertex3;
                        while (true)
                        {
                            Console.Write("Введите вершину, с которой начать обход: ");

                            string input = Console.ReadLine();

                            //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1 и меньше значения переменной "size3", то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (int.TryParse(input, out startVertex3) && startVertex3 != 0 && startVertex3 != -1 && startVertex3 < size3)
                            {
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное ненулевое число.");
                        }

                        output3.Add("Вершина, с которой начинается обход: " + startVertex3.ToString());
                        int[,] minimumSpanningTree3 = PrimAlgorithm(weightedMatrix3, startVertex3);

                        Console.WriteLine("Минимальное остовное дерево по алгоритму Прима:");
                        string minimumSpanningTreeOutput3 = PrintMatrix(minimumSpanningTree3);
                        output3.Add(minimumSpanningTreeOutput3);
                        Console.WriteLine(minimumSpanningTreeOutput3);

                        output3.Add("Обход графа через самые минимальные ребра выше:");
                        Console.WriteLine("Обход графа через самые минимальные ребра:");

                        //используется StreamWriter для записи результата работы кода в файл output.txt. 
                        using (StreamWriter writer = new StreamWriter("C:/Users/Илюха/source/repos/example2228/output.txt", true))
                        {
                            int totalDistance2 = CalculateTotalDistance(minimumSpanningTree3, startVertex3, writer);
                            output3.Add("Итоговая сумма минимального расстояния обхода графа: " + totalDistance2.ToString());
                            Console.WriteLine("Итоговая сумма минимального расстояния обхода графа: " + totalDistance2.ToString());
                        }

                        string saveChoice3;
                        while (true)
                        {
                            Console.Write("Хотите сохранить результат работы кода? (да/нет): ");

                            string input = Console.ReadLine();

                            //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                            {
                                saveChoice3 = input;
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                        }

                        if (saveChoice3.ToLower() == "да")
                        {
                            string outputPath2 = "C:/Users/Илюха/source/repos/example2228/output.txt";

                            //Используя класс "StreamWriter", создается объект "writer" для записи в файл по указанному пути.
                            using (StreamWriter writer = new StreamWriter(outputPath2, true))
                            {
                                foreach (string line in output3)
                                {
                                    //Происходит запись каждой строки из массива "output" в файл с помощью цикла "foreach" и метода "WriteLine()".
                                    writer.WriteLine(line);
                                }
                                //закрывается объект "writer"
                                writer.Close();
                            }
                            Console.WriteLine("Результат работы кода сохранен в файле output.txt.");
                        }
                        else
                        {
                            Console.WriteLine("Результат работы кода не сохранен.");
                        }
                        break;
                    case "4":
                        //Создается пустой список строк с именем output4
                        List<string> output4 = new List<string>();

                        string viewChoice;
                        while (true)
                        {
                            Console.Write("Хотите посмотреть доступные графы? (да/нет): ");

                            string input = Console.ReadLine();

                            //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                            {
                                viewChoice = input;
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                        }

                        if (viewChoice.ToLower() == "да")
                        {
                            string outputPath2 = "C:/Users/Илюха/source/repos/example2228/matrixReady.txt";

                            //Считывается содержимое файла matrixReady.txt и сохраняется в строку fileContent
                            string fileContent = File.ReadAllText(outputPath2);
                            Console.WriteLine("Содержимое файла matrixReady.txt:");
                            Console.WriteLine(fileContent);

                            string deleteChoice;
                            while (true)
                            {
                                Console.Write("Удалить содержимое файла matrixReady.txt? (да/нет): ");

                                string input = Console.ReadLine();

                                //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                                if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                                {
                                    deleteChoice = input;
                                    break;
                                }

                                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                            }

                            if (deleteChoice.ToLower() == "да")
                            {
                                //перезапись существующего файла с именем "outputPath2" и записи в него пустой строки.
                                File.WriteAllText(outputPath2, string.Empty);
                                Console.WriteLine("Содержимое файла matrixReady.txt успешно удалено.");
                            }
                            else
                            {
                                Console.WriteLine("Содержимое файла matrixReady.txt не было удалено.");
                            }

                            string newMatChoise;
                            string method;
                            while (true)
                            {
                                Console.Write("Перезаписать матрицу в файле matrixReady.txt? (да/нет): ");

                                string input = Console.ReadLine();

                                //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                                if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                                {
                                    newMatChoise = input;
                                    break;
                                }

                                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                            }

                            if (newMatChoise.ToLower() == "да")
                            {
                                while (true)
                                {
                                    Console.Write("Случайное заполнение матрицы? (да/нет): ");

                                    string input = Console.ReadLine();

                                    //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                                    if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                                    {
                                        method = input;
                                        break;
                                    }

                                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                                }

                                if (method.ToLower() == "да")
                                {
                                    int size4;
                                    while (true)
                                    {
                                        Console.Write("Введите размер матрицы: ");

                                        string input = Console.ReadLine();

                                        //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1, то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                                        if (int.TryParse(input, out size4) && size4 != -1 && size4 != 0)
                                        {
                                            break;
                                        }

                                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                                    }

                                    int[,] adjacencyMatrix4 = GenerateAdjacencyMatrix(size4);
                                    string matrixOutput4 = PrintMatrix(adjacencyMatrix4);
                                    output4.Add(matrixOutput4);
                                    Console.WriteLine(matrixOutput4);

                                    //Создается экземпляр класса StringBuilder под названием `matrixString`.
                                    //StringBuilder представляет изменяемую строку для эффективной конкатенации и сборки строк.
                                    StringBuilder matrixString = new StringBuilder();

                                    //выполняется двойной цикл for для итерации по элементам матрицы смежности. 
                                    for (int i = 0; i < size4; i++)
                                    {
                                        for (int j = 0; j < size4; j++)
                                        {
                                            //При каждой итерации, значение элемента `adjacencyMatrix4[i, j]` добавляется в `matrixString` с помощью метода `Append()`.
                                            //Символ пробела также добавляется после каждого значения, чтобы создать отступ между числами. 
                                            matrixString.Append(adjacencyMatrix4[i, j]);
                                            matrixString.Append(" ");
                                        }
                                        //После каждой строки матрицы добавляется символ новой строки с помощью метода `AppendLine()`.
                                        matrixString.AppendLine();
                                    }
                                    //вызывается метод `ToString()` у объекта `matrixString` для получения результирующей строки матрицы.
                                    //Полученная строка матрицы записывается в файл с помощью метода `File.WriteAllText()`.
                                    //Путь к файлу предоставляется в переменной `outputPath2`.
                                    File.WriteAllText(outputPath2, matrixString.ToString());
                                    Console.WriteLine($"Матрица смежности успешно сохранена в файле {outputPath2}.");
                                }
                                else
                                {
                                    int size4;
                                    while (true)
                                    {
                                        Console.Write("Введите размер матрицы: ");

                                        string input = Console.ReadLine();

                                        //Если введенное значение может быть успешно преобразовано в целое число и не равно 0, -1, то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                                        if (int.TryParse(input, out size4) && size4 != -1 && size4 != 0)
                                        {
                                            break;
                                        }

                                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                                    }

                                    int[,] weightedMatrix4 = FillAdjacencyMatrixSingle(size4);

                                    string matrixOutput4 = PrintMatrix(weightedMatrix4);
                                    output4.Add(matrixOutput4);
                                    Console.WriteLine(matrixOutput4);

                                    //Создается экземпляр класса StringBuilder под названием `matrixString`.
                                    //StringBuilder представляет изменяемую строку для эффективной конкатенации и сборки строк.
                                    StringBuilder matrixString = new StringBuilder();

                                    //выполняется двойной цикл for для итерации по элементам матрицы смежности.
                                    for (int i = 0; i < size4; i++)
                                    {
                                        for (int j = 0; j < size4; j++)
                                        {
                                            //При каждой итерации, значение элемента `weightedMatrix4[i, j]` добавляется в `matrixString` с помощью метода `Append()`.
                                            //Символ пробела также добавляется после каждого значения, чтобы создать отступ между числами. 
                                            matrixString.Append(weightedMatrix4[i, j]);
                                            matrixString.Append(" ");
                                        }
                                        //После каждой строки матрицы добавляется символ новой строки с помощью метода `AppendLine()`.
                                        matrixString.AppendLine();
                                    }
                                    //вызывается метод `ToString()` у объекта `matrixString` для получения результирующей строки матрицы.
                                    //Полученная строка матрицы записывается в файл с помощью метода `File.WriteAllText()`.
                                    //Путь к файлу предоставляется в переменной `outputPath2`.
                                    File.WriteAllText(outputPath2, matrixString.ToString());
                                    Console.WriteLine($"Матрица смежности успешно сохранена в файле {outputPath2}.");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine($"Файл {outputPath2} не был изменен.");
                            }
                        }
                        break;
                    case "5":
                        string viewChoice2;
                        while (true)
                        {
                            Console.Write("Просмотреть содержимое файла output.txt? (да/нет): ");

                            string input = Console.ReadLine();

                            //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                            if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                            {
                                viewChoice2 = input;
                                break;
                            }

                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                        }

                        if (viewChoice2.ToLower() == "да")
                        {
                            string outputPath2 = "C:/Users/Илюха/source/repos/example2228/output.txt";
                            string fileContent = File.ReadAllText(outputPath2);
                            Console.WriteLine("Содержимое файла output.txt:");
                            Console.WriteLine(fileContent);

                            string deleteChoice;
                            while (true)
                            {
                                Console.Write("Удалить содержимое файла output.txt? (да/нет): ");

                                string input = Console.ReadLine();

                                //Если введенное значение равно "да" или "нет" (без учета регистра), то условие "if" будет выполнено и цикл будет прерван с помощью "break".
                                if (input.Equals("да", StringComparison.OrdinalIgnoreCase) || input.Equals("нет", StringComparison.OrdinalIgnoreCase))
                                {
                                    deleteChoice = input;
                                    break;
                                }

                                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
                            }

                            if (deleteChoice.ToLower() == "да")
                            {
                                //перезапись существующего файла с именем "outputPath2" и записи в него пустой строки.
                                File.WriteAllText(outputPath2, string.Empty);
                                Console.WriteLine("Содержимое файла output.txt успешно удалено.");
                            }
                            else
                            {
                                Console.WriteLine("Содержимое файла output.txt не было удалено.");
                            }
                        }
                        break;
                    case "6":
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        {
                            Console.WriteLine("Неверная опция, попробуйте ещё раз");
                            break;
                        }
                }
                Console.WriteLine();
            } while (menuOption != "6");
        }
        //Метод, который заполняет матрицу смежности для графа.
        private static int[,] FillAdjacencyMatrixSingle(int size)
        {
            //происходит инициализация двумерного массива adjacencyMatrix с размерностью size x size
            int[,] adjacencyMatrix = new int[size, size];
            Console.WriteLine("Заполните матрицу смежности:");

            //начинается цикл, который перебирает все вершины графа.
            //Внутри цикла есть еще один цикл, который перебирает оставшиеся вершины, начиная с текущей вершины + 1.
            //Это позволяет заполнить только половину матрицы, не включая диагональ, поскольку граф неориентированный
            //и значения ребер сохраняются симметрично относительно главной диагонали матрицы.
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++) // Измененное условие для заполнения только половины матрицы, не включая диагональ
                {
                    //Для каждой пары вершин выводится сообщение с предложением ввести значение для ребра между ними.
                    Console.Write($"Введите значение для ребра между вершинами {i + 1} и {j + 1}: ");

                    //предлагается ввести значения для ребер между каждой парой вершин
                    int edgeValue;

                    //используется цикл while для ввода значения ребра. Если вводимое значение является целым положительным числом,
                    //то оно сохраняется в переменную edgeValue и цикл прерывается. Если введенное значение не соответствует условиям,
                    //выводится сообщение об ошибке и требуется ввести корректное значение.
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input == "0" || input == "1")  // Проверяем, является ли введенное значение 0 или 1
                        {
                            edgeValue = int.Parse(input);
                            break;
                        }

                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите только 0 или 1.");
                    }

                    //Поскольку граф неориентированный, значения ребер сохраняются симметрично относительно главной диагонали матрицы.
                    adjacencyMatrix[i, j] = edgeValue;
                    adjacencyMatrix[j, i] = edgeValue;
                }
            }
            return adjacencyMatrix;
        }
        //Метод, который заполняет матрицу смежности для графа.
        private static int[,] FillAdjacencyMatrix(int size)
        {
            //происходит инициализация двумерного массива adjacencyMatrix с размерностью size x size
            int[,] adjacencyMatrix = new int[size, size];
            Console.WriteLine("Заполните матрицу смежности:");

            //начинается цикл, который перебирает все вершины графа.
            //Внутри цикла есть еще один цикл, который перебирает оставшиеся вершины, начиная с текущей вершины + 1.
            //Это позволяет заполнить только половину матрицы, не включая диагональ, поскольку граф неориентированный
            //и значения ребер сохраняются симметрично относительно главной диагонали матрицы.
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++) // Измененное условие для заполнения только половины матрицы, не включая диагональ
                {
                    //Для каждой пары вершин выводится сообщение с предложением ввести значение для ребра между ними.
                    Console.Write($"Введите значение для ребра между вершинами {i + 1} и {j + 1}: ");

                    //предлагается ввести значения для ребер между каждой парой вершин
                    int edgeValue;

                    //используется цикл while для ввода значения ребра. Если вводимое значение является целым положительным числом,
                    //то оно сохраняется в переменную edgeValue и цикл прерывается. Если введенное значение не соответствует условиям,
                    //выводится сообщение об ошибке и требуется ввести корректное значение.
                    while (true)
                    {
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out edgeValue) && edgeValue != -1)
                        {
                            break;
                        }

                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                    }

                    //Поскольку граф неориентированный, значения ребер сохраняются симметрично относительно главной диагонали матрицы.
                    adjacencyMatrix[i, j] = edgeValue;
                    adjacencyMatrix[j, i] = edgeValue;
                }
            }
            return adjacencyMatrix;
        }
        //Вывод матрицы на экран
        static string PrintMatrix(int[,] matrix)
        {
            //Получаем размерность массива matrix по первому измерению и сохраняет в переменной size.
            int size = matrix.GetLength(0);

            //Создаем пустую строку с именем output, которая будет использоваться для формирования вывода матрицы.
            string output = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //К текущему элементу матрицы matrix[i, j] добавляется форматированная строка,
                    //где число будет отформатировано с выравниванием по левому краю и шириной в 4 символа.
                    //Затем эта строка добавляется к output.
                    output += $"{matrix[i, j],-4}";
                }
                //После каждой строки матрицы добавляется символ новой строки для перехода на следующую строку в выводе.
                output += Environment.NewLine;
            }
            return output;
        }
        //Реализация алгоритма Прима для поиска минимального остовного дерева во взвешенном неориентированном графе
        static int[,] PrimAlgorithm(int[,] matrix, int startVertex)
        {
            //Получаем размерность (количество вершин) графа из переданной матрицы смежности matrix и сохраняем его в переменной size
            int size = matrix.GetLength(0);

            //Создаем новый двумерный массив minimumSpanningTree, который будет хранить минимальное остовное дерево. Размерность массива такая же, как у переданной матрицы matrix
            int[,] minimumSpanningTree = new int[size, size];

            //Создаем новый одномерный массив visited, который будет отслеживать, посещена ли каждая вершина. Изначально все элементы массива установлены в false.
            bool[] visited = new bool[size];

            //Создаем переменную numOfVisited, которая будет отслеживать количество посещенных вершин. Изначально установлено значение 1, так как начальная вершина уже посещена.
            int numOfVisited = 1;

            //Помечаем начальную вершину, соответствующую startVertex, как посещенную.
            visited[startVertex - 1] = true;

            //Входим в цикл while, который будет выполняться до тех пор, пока количество посещенных вершин меньше размерности графа.
            while (numOfVisited < size)
            {
                //Создаем переменную minWeight и устанавливаем ее значение на максимально возможное значение типа int. В этой переменной будет храниться минимальный вес ребра при каждой итерации цикла.
                int minWeight = int.MaxValue;

                //Создаем переменные minFrom и minTo, которые будут хранить номера вершин, соединенных минимальным ребром. Изначально задаем им значение -1, чтобы отслеживать, есть ли вершины, соединенные минимальным ребром.
                int minFrom = -1;
                int minTo = -1;

                //Входим в цикл for, который перебирает все вершины графа.
                for (int i = 0; i < size; i++)
                {
                    //Проверяем, была ли вершина i уже посещена. Если да, выполняем код внутри этого условия.
                    if (visited[i])
                    {
                        //Входим во внутренний цикл for, который перебирает все вершины графа для поиска ребра с минимальным весом.
                        for (int j = 0; j < size; j++)
                        {
                            //Проверяем, является ли вершина j непосещенной, есть ли ребро между вершинами i и j, и является ли его вес меньше текущего минимального веса minWeight.
                            if (!visited[j] && matrix[i, j] > 0 && matrix[i, j] < minWeight)
                            {

                                //Если условие выполнено, обновляем значение minWeight на вес найденного ребра.
                                minWeight = matrix[i, j];

                                //Обновляем значения minFrom и minTo на соответствующие номера вершин, найденных ребром с минимальным весом.
                                minFrom = i + 1;
                                minTo = j + 1;
                            }
                        }
                    }
                }
                //Если найдено ребро с минимальным весом(т.е. "minFrom" и "minTo" не равны -1), то оно добавляется в минимальное остовное дерево "minimumSpanningTree",
                //обновляются массив "visited" и число посещенных вершин увеличивается на 1.
                if (minFrom != -1 && minTo != -1)
                {
                    minimumSpanningTree[minFrom - 1, minTo - 1] = minWeight;
                    minimumSpanningTree[minTo - 1, minFrom - 1] = minWeight;
                    visited[minTo - 1] = true;
                    numOfVisited++;
                }
                //Если не найдено ребро с минимальным весом (т.е. все вершины уже посещены), то цикл прерывается.
                else
                {
                    break;
                }
            }
            //В конце функция возвращает минимальное остовное дерево "minimumSpanningTree".
            return minimumSpanningTree;
        }
        //Метод реализации алгоритма обхода графа в глубину с подсчетом общего расстояния. 
        static int CalculateTotalDistance(int[,] matrix, int startVertex, StreamWriter writer)
        {
            //Получает размерность массива matrix по первому измерению и сохраняет в переменной size.
            int size = matrix.GetLength(0);

            //Создает массив булевых значений visited длиной size, который будет использоваться для отслеживания посещенных вершин.
            bool[] visited = new bool[size];

            //Инициализирует переменную totalDistance нулевым значением, которая будет содержать общее расстояние между вершинами.
            int totalDistance = 0;

            //Вызывает рекурсивную функцию CalculateDistanceRecursive для вычисления расстояния между вершинами, начиная с startVertex.
            //По умолчанию startVertex индексируется с 1, поэтому происходит смещение на 1 при вызове рекурсивной функции.
            CalculateDistanceRecursive(matrix, visited, startVertex - 1, 0, ref totalDistance, writer);

            //Возвращает общее расстояние между вершинами.
            return totalDistance;
        }

        //Это рекурсивная функция, которая вычисляет расстояние между вершинами в графе. Принимает двумерный массив matrix, массив булевых значений visited,
        //текущую вершину currentVertex, уровень отступа indentLevel, переменную totalDistance по ссылке и объект StreamWriter writer.
        static void CalculateDistanceRecursive(int[,] matrix, bool[] visited, int currentVertex, int indentLevel, ref int totalDistance, StreamWriter writer)
        {
            //Устанавливает текущую вершину currentVertex в массиве visited в значение true, чтобы отметить ее как посещенную.
            visited[currentVertex] = true;

            //Запускает цикл, проходящий по всем столбцам в строке currentVertex матрицы matrix.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //Проверяет, существует ли ребро между текущей вершиной currentVertex и вершиной i, а также не была ли вершина i уже посещена.
                if (matrix[currentVertex, i] != 0 && !visited[i])
                {
                    //Увеличивает значение переменной totalDistance на значение ребра между currentVertex и i.
                    totalDistance += matrix[currentVertex, i];

                    //Записывает строку в файл writer, содержащую информацию о ребре между вершинами currentVertex + 1 и i + 1, включая размер ребра.
                    writer.WriteLine(new string(' ', indentLevel * 4) + $"{currentVertex + 1} (size {matrix[currentVertex, i]}) -> {i + 1}");
                    Console.WriteLine(new string(' ', indentLevel * 4) + $"{currentVertex + 1} (size {matrix[currentVertex, i]}) -> {i + 1}");

                    //Рекурсивно вызывает функцию CalculateDistanceRecursive для вершины i, чтобы продолжить вычисление расстояния между вершинами.
                    CalculateDistanceRecursive(matrix, visited, i, indentLevel + 1, ref totalDistance, writer);
                }
            }
        }
        //Метод GenerateAdjacencyMatrix генерирует матрицу смежности для заданного размера графа.
        private static int[,] GenerateAdjacencyMatrix(int size)
        {
            Random r = new Random();

            //создает двумерный массив (матрицу) размерности size x size для хранения смежности вершин. 
            int[,] matrix = new int[size, size];

            //Внутри циклов происходит заполнение этой матрицы. Первый цикл отвечает за итерацию по столбцам матрицы, а второй цикл - по строкам. 
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    //Каждый элемент [i, j] получает случайное число 0 или 1, а элемент [j, i] получает то же значение для обеспечения симметричности графа. 
                    matrix[i, j] = r.Next(0, 2);
                    matrix[j, i] = matrix[i, j];
                }
            }
            return matrix;
        }
        //Метод ConvertToWeightedMatrix принимает матрицу смежности и преобразует ее во взвешенную матрицу.
        private static int[,] ConvertToWeightedMatrix(int[,] adjacencyMatrix)
        {
            int size = adjacencyMatrix.GetLength(0);

            //Создается новая матрица weightedMatrix с размерами такими же, как у матрицы смежности.
            int[,] weightedMatrix = new int[size, size];
            Random r = new Random();

            //Затем используется цикл for для проверки каждого элемента матрицы смежности. 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Если значение элемента [i, j] равно 1 (т.е. есть связь между вершинами i и j), 
                    //то элемент[i, j] взвешивается(получает случайное значение от 1 до 10), 
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        weightedMatrix[i, j] = r.Next(1, 11);

                        //а элемент [j, i] принимает то же самое значение, чтобы обеспечить симметричность графа. 
                        weightedMatrix[j, i] = weightedMatrix[i, j];
                    }
                }
            }
            return weightedMatrix;
        }
    }
}


