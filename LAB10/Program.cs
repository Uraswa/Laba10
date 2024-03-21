using LAB10Classes;
using Lab9;
using Laba10;

namespace LAB10
{
    public class Program
    {
        static Game[] FormArrayFromHierarchy(int itemsCount = 20)
        {
            Random rnd = Helpers.Helpers.GetOrCreateRandom();

            Game[] arr = new Game[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                Game game;
                int object2Create = rnd.Next(0, 4);
                if (object2Create == 0)
                {
                    game = new Game();
                }
                else if (object2Create == 1)
                {
                    game = new TableGame();
                }
                else if (object2Create == 2)
                {
                    game = new VideoGame();
                }
                else
                {
                    game = new VRGame();
                }

                game.RandomInit();
                arr[i] = game;
            }

            return arr;
        }

        public static void Main(string[] args)
        {
            Random rnd = Helpers.Helpers.GetOrCreateRandom();

            int itemsCount = 20;

            Game[] arr = FormArrayFromHierarchy(itemsCount);

            uint menuAnswer = 99;

            while (menuAnswer != 0)
            {
                menuAnswer = Helpers.Helpers.EnterUInt("Выберите задание или 0, чтобы выйти", 0, 3);
                switch (menuAnswer)
                {
                    case 0:
                        return;
                    case 1:
                        for (int i = 0; i < itemsCount; i++)
                        {
                            Console.WriteLine($"-----------Игра #{i + 1}-------------");
                            Game game = arr[i];

                            //виртуальный метод
                            Console.WriteLine("Virtual: ");
                            game.ShowVirtual();
                            Console.WriteLine("\n");

                            //обычный
                            Console.WriteLine("Обычный: ");
                            game.Show();
                            Console.WriteLine("\n");
                        }

                        Console.WriteLine("Нажмите для продолжения...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Task2(arr);
                        break;
                    case 3:
                        Task3();
                        break;
                }
            }
        }


        static void Task2(Game[] arr)
        {
            Task2Req1(arr);
            Task2Req2(arr);
            Task2Req3(arr);
        }

        static IEnumerable<Game> Req1(Game[] arr, uint minGreaterOrEqual)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Game game = arr[i];
                if (game.MinimumPlayers >= minGreaterOrEqual && minGreaterOrEqual <= game.MaximumPlayers)
                {
                    yield return game;
                }
            }
        }

        static void Task2Req1(Game[] arr)
        {
            uint minGreaterOrEqual = Helpers.Helpers.EnterUInt("Минимальное количество игроков", 1, uint.MaxValue);

            Console.WriteLine($"Игры, минмальное количество игроков >= {minGreaterOrEqual.ToString()}");
            foreach (Game game in Req1(arr, minGreaterOrEqual))
            {
                game.ShowVirtual();
                Console.WriteLine("-----------------------");
            }
        }

        static IEnumerable<Game> Req2(Game[] arr, Device device)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Game game = arr[i];
                if (game is VideoGame videoGame && videoGame.Device == device)
                {
                    yield return game;
                }
            }
        }

        static void Task2Req2(Game[] arr)
        {
            Console.WriteLine();
            uint deviceType = Helpers.Helpers.EnterUInt("тип устройства: 1 - телефон, 2 - пк, 3 - игровая консоль", 1, 3);
            Device device = Device.Mobile;

            if (deviceType == 1)
            {
                device = Device.Mobile;
            }
            else if (deviceType == 2)
            {
                device = Device.Pc;
            }
            else if (deviceType == 3)
            {
                device = Device.Console;
            }

            Console.WriteLine($"\nИгры, в которые можно играть на {device}");
            foreach (Game game in Req2(arr, device))
            {
                Console.WriteLine(game.Name);
            }
        }

        static IEnumerable<Game> Req3(Game[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Game game = arr[i];
                if (game is VRGame vr && vr.AreVRGlassesRequired)
                {
                    yield return game;
                }
            }
        }

        static void Task2Req3(Game[] arr)
        {
            Console.WriteLine($"\nИгры, в которые можно играть в vr очках");
            foreach (Game game in Req3(arr))
            {
                Console.WriteLine(game.Name);
            }
        }

        static void Task3()
        {
            
            while (true)
            {
                uint menu = Helpers.Helpers.EnterUInt("Пукнт сабменю 3 задания " +
                    "\n0 - выйти" +
                    "\n1 - Сформировать в демонстрационной программе массив, содержащий объекты из иерархии классов и лабораторной работы №9. \r\n Вывести объект на печать, подсчитать количество объектов каждого типа. " +
                    "\n2 - Сформировать в демонстрационной программе массив из объектов разных классов из созданной иерархии. Реализовать сортировку элементов массива, используя стандартный интерфейс IComparable  и метод Sort класса Array.\r\n  Реализовать бинарный поиск с помощью метода Array.BinarySearch() в отсортированном массиве." +
                    "\n3 - Реализовать сортировку (по другому критерию), используя стандартный интерфейс ICompare  и метод Sort класса Array.\r\n  Реализовать бинарный поиск с помощью метода Array.BinarySearch() в отсортированном массиве." +
                    "\n4 - демонстрация клонирования", 0, 4);
                switch (menu)
                {
                    case 0:
                        return;
                    case 1:
                        int itemsCount = 20;
                        IInit[] arr = new IInit[itemsCount];
                        Random rnd = Helpers.Helpers.GetOrCreateRandom();

                        for (int i = 0; i < itemsCount; i++)
                        {
                            IInit init;
                            int object2Create = rnd.Next(0, 5);
                            if (object2Create == 0)
                            {
                                init = new Game();
                            }
                            else if (object2Create == 1)
                            {
                                init = new TableGame();
                            }
                            else if (object2Create == 2)
                            {
                                init = new VideoGame();
                            }
                            else if (object2Create == 3)
                            {
                                init = new VRGame();
                            }
                            else
                            {
                                init = new Mark();
                            }

                            init.RandomInit();
                            arr[i] = init;
                        }

                        int gameType = 0;
                        int tableGameType = 0;
                        int videoGameType = 0;
                        int vrGameType = 0;
                        int markType = 0;

                        for (int i = 0; i < arr.Length; i++)
                        {
                            IInit item = arr[i];

                            if (item is Mark mark)
                            {
                                markType++;
                                mark.Print();
                            }
                            else if (item is VRGame vr)
                            {
                                vrGameType++;
                                vr.ShowVirtual();
                            }
                            else if (item is VideoGame videoGame)
                            {
                                videoGameType++;
                                videoGame.ShowVirtual();
                            }
                            else if (item is TableGame tableGame)
                            {
                                tableGameType++;
                                tableGame.ShowVirtual();
                            }
                            else if (item is Game game)
                            {
                                gameType++;
                                game.ShowVirtual();
                            }
                        }

                        Console.WriteLine($"Количество Mark: {markType}");
                        Console.WriteLine($"Количество VRGame: {vrGameType}");
                        Console.WriteLine($"Количество VideoGame: {videoGameType}");
                        Console.WriteLine($"Количество TableGame: {tableGameType}");
                        Console.WriteLine($"Количество Game: {gameType}");
                        break;
                    case 2:
                        //пункт 6. Формируем массив и сортируем IComparablы
                        Game[] hierarchyArr = FormArrayFromHierarchy(20);
                        Array.Sort(hierarchyArr);

                        //бинарный поиск
                        int index1 = Array.BinarySearch(hierarchyArr, new Game("Игра 3", 1, 10, new Game.IdNumber()));
                        Console.WriteLine("Найденный индекс " + index1);

                        if (index1 >= 0)
                        {
                            Console.WriteLine("Найденный элемент");
                            hierarchyArr[index1].ShowVirtual();
                        }
                        break;
                    case 3:
                        //бинарным поиск с компаратором

                        Game[] hierarchyArr2 = FormArrayFromHierarchy(20);
                        Array.Sort(hierarchyArr2, new MaximumPlayersComparer());


                        int index2 = Array.BinarySearch(hierarchyArr2, new Game("Игра 3", 1, 10, new Game.IdNumber()),
                            new MaximumPlayersComparer());
                        Console.WriteLine("Найденный индекс " + index2);

                        if (index2 >= 0)
                        {
                            Console.WriteLine("Найденный элемент");
                            hierarchyArr2[index2].ShowVirtual();
                        }

                        break;
                    case 4:
                        Game toClone = new Game("test", 1, 2, new Game.IdNumber(3));

                        Console.WriteLine("----Демонстрация Глубокого копирования----");

                        Console.WriteLine("Глубокое копирование");
                        Game deepCloned = (Game)toClone.Clone();

                        Console.WriteLine("Совпадают ли объекты Id у toClone & deepCloned ?" + (ReferenceEquals(toClone.Id, deepCloned.Id) ? "Да" : "Нет"));

                        Console.WriteLine("----Демонстрация Memberwise clone----");

                        Game memberwiseCloned = (Game)toClone.ShallowCopy();
                        Console.WriteLine("Совпадают ли объекты Id у toClone & memberwiseCloned ?" + (ReferenceEquals(toClone.Id, memberwiseCloned.Id) ? "Да" : "Нет"));

                        break;

                    
                }
                Console.WriteLine("Нажмите для продолжения...");
                Console.ReadKey();
            }
        }
    }
}