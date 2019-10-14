//Methods.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csCourseWork
{
    class Methods : Library
    {
        public static void Initialization()
        {
            try
            {
                int size;
                Console.WriteLine("How many objects will you use[max]?");//запрашиваем ввод максимального количества объектов, то есть пользователь не будет использовать большее количество объектов ни при каких условиях
                size = int.Parse(Console.ReadLine());//ввод количества объектов
                while (size <= 0)
                {
                    Console.WriteLine("Input correct amount of objects[1-2^16]");
                    size = int.Parse(Console.ReadLine());
                }
                Library[] objects = new Library[size];//инициализируем массив объектов

                for (int j = 0; j < size; j++)//присваиваем каждому элементу массива объект типа Library
                    objects[j] = new Library();

                List<Library> libs = new List<Library> { };//создаем список, с которым будем работать в дальшейшем
                Menu(libs, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Initialization();
            }
        }

        private static void Menu(List<Library> lib, Library[] objects)
        {
            try
            {
                Console.WriteLine("Input:");
                Console.WriteLine("1-to add field");
                Console.WriteLine("2-to display field(s)");
                Console.WriteLine("3-to change field");
                Console.WriteLine("4-to delete field");
                Console.WriteLine("5-to write into the file");
                Console.WriteLine("6-to search using keyfield");
                Console.WriteLine("7-to sort objects using one field");
                Console.WriteLine("8-to read info from file");
                Console.WriteLine("9-to insert at chosen place");
                Console.WriteLine("10-to delete using conditional");
                Console.WriteLine("11-to find min and max in diapasone from selected");
                Console.WriteLine("12-to exit");
                int choice;
                choice = int.Parse(Console.ReadLine());
                while (choice > 13 || choice < 1)
                {
                    Console.WriteLine("Wrong number! Use only [1-12]");
                    choice = int.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 1:
                        Add(lib, objects);
                        break;
                    case 2:
                        Display(lib, objects);
                        break;
                    case 3:
                        Change(lib, objects);
                        break;
                    case 4:
                        Delete(lib, objects);
                        break;
                    case 5:
                        FDisplay(lib, objects);
                        break;
                    case 6:
                        Search(lib, objects);
                        break;
                    case 7:
                        Sort(lib, objects);
                        break;
                    case 8:
                        Read(lib, objects);
                        break;
                    case 9:
                        InsertAt(lib, objects);
                        break;
                    case 10:
                        ConditionalDelete(lib, objects);
                        break;
                    case 11:
                        MinMax(lib, objects);
                        break;
                    case 12:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You can only use [1,12] numbers");
                        Menu(lib, objects);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Menu(lib, objects);
            }
        }

        private static void Add(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count < objects.Length)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"input {lib.Count + 1} field");

                    Console.WriteLine("Input inventory number");
                    objects[lib.Count].Number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input author of book");
                    objects[lib.Count].Author = Console.ReadLine();

                    Console.WriteLine("Input book name");
                    objects[lib.Count].Book = Console.ReadLine();

                    Console.WriteLine("Input amount of copies");
                    objects[lib.Count].Copies = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input price of book");
                    objects[lib.Count].Price = Double.Parse(Console.ReadLine());

                    Console.WriteLine("----------------------------");
                    lib.Add(objects[lib.Count]);
                }
                else
                    Console.WriteLine("You cant add objects anymore");
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Add(lib, objects);
            }
        }

        private static void Display(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to display");
                }
                else
                {
                    Console.WriteLine("1-Display chosen field | 2-Display all");
                    int choice;
                    int ind;
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write($"Which element do you want to display?[1-{lib.Count}]:");
                            ind = int.Parse(Console.ReadLine());
                            Console.WriteLine(lib[ind - 1].ToString());
                            break;
                        case 2:
                            for (int j = 0; j < lib.Count; j++)
                            {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine($"Field number:{j + 1}");
                                Console.WriteLine(lib[j].ToString());
                            }
                            break;
                        default:
                            Console.WriteLine("You can only use those numbers here: [1,2]");
                            Display(lib, objects);
                            break;
                    }
                }
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Display(lib, objects);
            }

        }

        private static void Change(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to change");
                }
                else
                {
                    Console.WriteLine($"Choose which field do you want to change [1-{lib.Count}]:");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice > lib.Count && choice > 0)
                    {
                        Console.WriteLine($"Wrong number! Use only [1-{lib.Count}]");
                        choice = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Input inventory number");
                    lib[choice - 1].Number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input author of book");
                    lib[choice - 1].Author = Console.ReadLine();

                    Console.WriteLine("Input book name");
                    lib[choice = 1].Book = Console.ReadLine();

                    Console.WriteLine("Input amount of copies");
                    lib[choice - 1].Copies = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input price of book");
                    lib[choice - 1].Price = Double.Parse(Console.ReadLine());
                }
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Change(lib, objects);
            }
        }

        private static void Delete(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to delete");
                }
                else
                {
                    Console.Write("1-Delete chosen field | 2-Delete all:");
                    int choice;
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            int index;
                            Console.Write($"Which field do you want to remove?[1-{lib.Count}]:");
                            index = int.Parse(Console.ReadLine());
                            if (index <= lib.Count && index >= 0)
                            {
                                lib.RemoveAt(index - 1);
                            }
                            else
                            {
                                Console.WriteLine("You are out of list range, cannot delete field, which is not exist");
                                Delete(lib, objects);
                            }
                            break;

                        case 2:
                            lib.Clear();
                            break;

                        default:
                            Console.WriteLine("You can only use those numbers here: [1,2]");
                            Delete(lib, objects);
                            break;
                    }
                }
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Delete(lib, objects);
            }
        }

        private static void FDisplay(List<Library> lib, Library[] objects)
        {
            int check = 0;
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to write in file");
                    Menu(lib, objects);
                }
                else
                {
                    StreamWriter file = new StreamWriter("E:\\BrSTU\\CourseWork\\csCourseWork\\Display.txt");
                    for (int j = 0; j < lib.Count; j++)
                    {
                        file.WriteLine($"-------------{j + 1}-------------");
                        file.WriteLine(lib[j].ToString());
                    }
                    file.Close();
                    check = 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                FDisplay(lib, objects);
            }
            finally
            {
                if(check == 1)
                {
                    Console.WriteLine("Written succesfully!");
                }
                Menu(lib, objects);
            }
        }

        private static void Search(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to search");
                }
                else
                {
                    Console.WriteLine("------------------------------");
                    Console.Write("The keyfield is [inventory number]\nInput inventory number to find object:");
                    int search;
                    int size = 0;
                    search = int.Parse(Console.ReadLine());
                    for (int j = 0; j < lib.Count; j++)
                    {
                        if (search == lib[j].Number)
                        {
                            Console.WriteLine(lib[j].ToString());
                        }
                        else
                        {
                            size++;
                        }
                    }
                    if (size == lib.Count)
                    {
                        Console.WriteLine("object with such inventory number not exist");
                    }
                }
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Search(lib, objects);
            }
        }

        public static void Sort(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to sort");
                    Menu(lib, objects);
                }
                else
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Using which field do you want to sort objects?");
                    Console.WriteLine("1-Inventory number");
                    Console.WriteLine("2-Author of book");
                    Console.WriteLine("3-Book name");
                    Console.WriteLine("4-Amount of copies");
                    Console.WriteLine("5-Price of book");
                    int choice;
                    choice = int.Parse(Console.ReadLine());
                    while (choice > 5 || choice < 1)
                    {
                        Console.WriteLine("Please use only given numbers[1-5]");
                        choice = int.Parse(Console.ReadLine());
                    }
                    switch (choice)
                    {
                        case 1:
                            var sorted = lib.OrderBy(x => x.Number).ToList();
                            string path = @"E:\BrSTU\CourseWork\csCourseWork\sorted.dat";
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                                foreach (var x in sorted)
                                {
                                    writer.Write("---------------------");
                                    writer.Write(x.BinaryToString());
                                    writer.Write("\r\n");
                                }
                            break;
                        case 2:
                            sorted = lib.OrderBy(x => x.Author).ToList();
                            path = @"E:\BrSTU\CourseWork\csCourseWork\sorted.dat";
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                                foreach (var x in sorted)
                                {
                                    writer.Write("---------------------");
                                    writer.Write(x.BinaryToString());
                                    writer.Write("\r\n");
                                }
                            break;
                        case 3:
                            sorted = lib.OrderBy(x => x.Book).ToList();
                            path = @"E:\BrSTU\CourseWork\csCourseWork\sorted.dat";
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                                foreach (var x in sorted)
                                {
                                    writer.Write("---------------------");
                                    writer.Write(x.BinaryToString());
                                    writer.Write("\r\n");
                                }
                            break;
                        case 4:
                            sorted = lib.OrderBy(x => x.Copies).ToList();
                            path = @"E:\BrSTU\CourseWork\csCourseWork\sorted.dat";
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                                foreach (var x in sorted)
                                {
                                    writer.Write("---------------------");
                                    writer.Write(x.BinaryToString());
                                    writer.Write("\r\n");
                                }
                            break;
                        case 5:
                            sorted = lib.OrderBy(x => x.Price).ToList();
                            path = @"E:\BrSTU\CourseWork\csCourseWork\sorted.dat";
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                                foreach (var x in sorted)
                                {
                                    writer.Write("---------------------");
                                    writer.Write(x.BinaryToString());
                                    writer.Write("\r\n");
                                }
                            break;
                        default:
                            Console.WriteLine("Wrong numbers inputed");
                            Sort(lib, objects);
                            break;
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Sort failed");
                Console.WriteLine(e.Message);
                Sort(lib, objects);
            }
            finally
            {
                Console.WriteLine("Sorted sucsessfully");
                Menu(lib, objects);
            }
        }

        private static void Read(List<Library> lib, Library[] objects)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"E:\BrSTU\CourseWork\csCourseWork\display.txt", System.Text.Encoding.Default))
                {
                    string line;
                    int size = -1;
                    int iterator = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (size < objects.Length)
                        {
                            if (iterator == 0 || iterator % 6 == 0)
                            {
                                iterator = 0;
                                iterator++;
                                size++;
                                lib.Add(objects[size]);
                            }
                            else
                            {
                                line = line.Remove(0, line.LastIndexOf(":") + 2);
                                switch (iterator)
                                {
                                    case 1:
                                        objects[size].Number = int.Parse(line);
                                        break;
                                    case 2:
                                        objects[size].Author = line;
                                        break;
                                    case 3:
                                        objects[size].Book = line;
                                        break;
                                    case 4:
                                        objects[size].Copies = int.Parse(line);
                                        break;
                                    case 5:
                                        objects[size].Price = double.Parse(line);
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                                iterator++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Read(lib, objects);
            }
            finally
            {
                Console.WriteLine("Readen from file succesfull!");
                Menu(lib, objects);
            }
        }

        private static void InsertAt(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count < 1)
                {
                    Console.WriteLine("You need at least 1 object");
                    Add(lib, objects);
                }
                int index;
                Console.Write("After which object do you want to insert object?:");
                index = int.Parse(Console.ReadLine());
                if (index < lib.Count || index > 0)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"input {lib.Count + 1} field");

                    Console.WriteLine("Input inventory number");
                    objects[lib.Count].Number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input author of book");
                    objects[lib.Count].Author = Console.ReadLine();

                    Console.WriteLine("Input book name");
                    objects[lib.Count].Book = Console.ReadLine();

                    Console.WriteLine("Input amount of copies");
                    objects[lib.Count].Copies = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input price of book");
                    objects[lib.Count].Price = Double.Parse(Console.ReadLine());

                    Console.WriteLine("----------------------------");
                    lib.Insert(index, objects[lib.Count]);
                }
                else
                    Console.WriteLine($"You cant add objects anymore OR Wrong index[1-{lib.Count}]");
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                InsertAt(lib, objects);
            }
        }

        private static void ConditionalDelete(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to delete");
                }
                else
                {
                    int choice;
                    Console.Write("Which conditional do you want to use?\n1-priсe\n2-copies amount\n3-inventory number:");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            int flag;
                            int number;
                            Console.Write("which conditional do you want to use?\n0: < than number\n1 > than number\n?:");
                            flag = int.Parse(Console.ReadLine());
                            if (flag == 1)
                            {
                                Console.Write("input number:");
                                number = int.Parse(Console.ReadLine());
                                for (int j = 0; j < lib.Count; j++)
                                {
                                    if (lib[j].Price > number)
                                    {
                                        lib.RemoveAt(j);
                                        j--;
                                    }
                                }
                            }
                            else if (flag == 0)
                            {
                                Console.Write("input number:");
                                number = int.Parse(Console.ReadLine());
                                for (int j = 0; j < lib.Count; j++)
                                {
                                    if (lib[j].Price < number)
                                    {
                                        lib.RemoveAt(j);
                                        j--;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong flag[0-1] only");
                                ConditionalDelete(lib, objects);
                            }
                            break;
                        case 2:
                            Console.Write("which conditional do you want to use?\n0: < than number\n1 > than number\n?:");
                            flag = int.Parse(Console.ReadLine());
                            if (flag == 1)
                            {
                                Console.Write("input number:");
                                number = int.Parse(Console.ReadLine());
                                for (int j = 0; j < lib.Count; j++)
                                {
                                    if (lib[j].Copies > number)
                                    {
                                        lib.RemoveAt(j);
                                        j--;
                                    }
                                }
                            }
                            else if (flag == 0)
                            {
                                Console.Write("input number:");
                                number = int.Parse(Console.ReadLine());
                                for (int j = 0; j < lib.Count; j++)
                                {
                                    if (lib[j].Copies < number)
                                    {
                                        lib.RemoveAt(j);
                                        j--;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wron flag[0-1] only");
                                ConditionalDelete(lib, objects);
                            }
                            break;
                        case 3:
                            Console.Write("which conditional do you want to use?\n0: < than number\n1 > than number\n?:");
                            flag = int.Parse(Console.ReadLine());
                            if (flag == 1)
                            {
                                Console.Write("input number:");
                                number = int.Parse(Console.ReadLine());
                                for (int j = 0; j < lib.Count; j++)
                                {
                                    if (lib[j].Number > number)
                                    {
                                        lib.RemoveAt(j);
                                        j--;
                                    }
                                }
                            }
                            else if (flag == 0)
                            {
                                Console.Write("input number:");
                                number = int.Parse(Console.ReadLine());
                                for (int j = 0; j < lib.Count; j++)
                                {
                                    if (lib[j].Number < number)
                                    {
                                        lib.RemoveAt(j);
                                        j--;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wron flag[0-1] only");
                                ConditionalDelete(lib, objects);
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong number![1-3]only");
                            ConditionalDelete(lib, objects);
                            break;
                    }
                }
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ConditionalDelete(lib, objects);
            }
        }

        private static void MinMax(List<Library> lib, Library[] objects)
        {
            try
            {
                if (lib.Count == 0)
                {
                    Console.WriteLine("No objects to search");
                }
                else
                {
                    int choice;
                    int minDiap;
                    int maxDiap;
                    double max;
                    double min;
                    Console.Write("Which field do you want to use?\n1-priсe\n2-copies amount\n3-inventory number:");
                    choice = int.Parse(Console.ReadLine());
                    Console.Write("input minimal diapasone value:");
                    minDiap = int.Parse(Console.ReadLine());
                    Console.Write("input maximum diapasone value:");
                    maxDiap = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            max = 0;
                            min = Int32.MaxValue;
                            for (int j = 0; j < lib.Count; j++)
                            {
                                if (lib[j].Price >= minDiap && lib[j].Price <= maxDiap)
                                {
                                    if (max <= lib[j].Price)
                                    {
                                        max = lib[j].Price;
                                    }
                                    if (min >= lib[j].Price)
                                    {
                                        min = lib[j].Price;
                                    }
                                }
                            }
                            if (max == 0 || min == Int32.MaxValue)
                            {
                                Console.WriteLine("No numbers found in given diapasone");
                            }
                            else
                            {
                                Console.WriteLine($"minimal price is:{min}");
                                Console.WriteLine($"maximal price is:{max}");
                            }
                            break;
                        case 2:
                            max = 0;
                            min = Int32.MaxValue;
                            for (int j = 0; j < lib.Count; j++)
                            {
                                if (lib[j].Copies >= minDiap && lib[j].Copies <= maxDiap)
                                {
                                    if (max <= lib[j].Copies)
                                    {
                                        max = lib[j].Copies;
                                    }
                                    if (min >= lib[j].Copies)
                                    {
                                        min = lib[j].Copies;
                                    }
                                }
                            }
                            if (max == 0 || min == Int32.MaxValue)
                            {
                                Console.WriteLine("No numbers found in given diapasone");
                            }
                            else
                            {
                                Console.WriteLine($"minimal copies amount is:{min}");
                                Console.WriteLine($"maximal copies amount is:{max}");
                            }
                            break;
                        case 3:
                            max = 0;
                            min = Int32.MaxValue;
                            for (int j = 0; j < lib.Count; j++)
                            {
                                if (lib[j].Number >= minDiap && lib[j].Number <= maxDiap)
                                {
                                    if (max <= lib[j].Number)
                                    {
                                        max = lib[j].Number;
                                    }
                                    if (min >= lib[j].Number)
                                    {
                                        min = lib[j].Number;
                                    }
                                }
                            }
                            if (max == 0 || min == Int32.MaxValue)
                            {
                                Console.WriteLine("No numbers found in given diapasone");
                            }
                            else
                            {
                                Console.WriteLine($"minimal inventory number is:{min}");
                                Console.WriteLine($"maximal inventory number is:{max}");
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong number![1-3]only");
                            MinMax(lib, objects);
                            break;
                    }
                }
                Menu(lib, objects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MinMax(lib, objects);
            }
        }
    }
}