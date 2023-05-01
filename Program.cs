using System;

namespace UUIDBuilder{
    class UUIDBuilder{
        public static void Main(string[] args) {
            Menu();
        }

        public static void Menu() {

            // =================
            //   Apresentation
            // =================
            Console.Clear();
            Console.WriteLine("┏┳┓┏┳┓┏━━┓┏━━┓  ┏━━┓┏┳┓┏━━┓┏┓░┏━━┓┏━┓┏━┓");
            Console.WriteLine("┃┃┃┃┃┃┗┃┃┛┗┓┓┃  ┃┏┓┃┃┃┃┗┃┃┛┃┃░┗┓┓┃┃┳┛┃╋┃");
            Console.WriteLine("┃┃┃┃┃┃┏┃┃┓┏┻┛┃  ┃┏┓┃┃┃┃┏┃┃┓┃┗┓┏┻┛┃┃┻┓┃┓┫");
            Console.WriteLine("┗━┛┗━┛┗━━┛┗━━┛  ┗━━┛┗━┛┗━━┛┗━┛┗━━┛┗━┛┗┻┛");
            Console.WriteLine("created by Salutx.");
            Console.WriteLine();
            Console.WriteLine("Choose a option:");
            Console.WriteLine("1 - Create a UUID's list");
            Console.WriteLine("2 - Read a UUID's list");
            Console.WriteLine("3 - Exit");
            var choose = short.Parse(Console.ReadLine()!);
           
            // =================
            //     Chooser
            // =================

            switch (choose) {
                case 1: CreateUUIDList(); break;
                case 2: ReadUUIDList(); break;
                case 3: Exit(); break;
                default: Menu(); break;
            }
        }

       public static void CreateUUIDList() {
            Console.Clear();

            Console.Write("Enter the number of UUIDs to generate: ");
            int uuidCount;
            while (!int.TryParse(Console.ReadLine(), out uuidCount)) {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            Console.WriteLine();

            var uuids = new List<Guid>();
            for (int i = 0; i < uuidCount; i++) {
                uuids.Add(Guid.NewGuid());
            }
            var uuidListText = string.Join(Environment.NewLine, uuids);

            Console.WriteLine(uuidListText);
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("Do you want to save this file?");
            Console.WriteLine("1 - Save file as");
            Console.WriteLine("2 - Exit");

            int saveOption;
            while (!int.TryParse(Console.ReadLine(), out saveOption) || saveOption < 1 || saveOption > 3) {
                Console.WriteLine("Invalid option. Please enter a valid number.");
            }

            switch (saveOption) {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("====================================");
                    Console.WriteLine("Enter the path to save the file");
                    Console.WriteLine(@"Example: C:\dev\");
                    Console.Write("Path: ");

                    var path = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(path)) {
                        Console.WriteLine("Invalid path! Please try again.");
                        Console.ReadLine();
                        Menu();
                        return;
                    }
                    try {
                        SaveUUIDList(uuidListText, path);
                        Console.ReadLine();
                        Menu();
                    } catch (Exception ex) {
                        Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
                        Console.ReadLine();
                        Menu();
                    }
                    break;
                case 2: Exit(); break;
            }
        }

        public static void SaveUUIDList(string textValue, string pathfile) {
            Console.Clear();

            var dateTimeNow = DateTime.Now;
            var uuidListFilePath = $"{pathfile}uuidlist-{dateTimeNow:yyyy-MM-dd-HH-mm-ss}.txt";

            Console.WriteLine("[1/3 Step] - Loading...");
            Thread.Sleep(1000);

            Console.WriteLine("[2/3 Step] - Writing...");
            Thread.Sleep(1000);

            Console.WriteLine("[3/3 Step] - Finishing...");
            Thread.Sleep(1000);

            Console.WriteLine("");

            try {
                using(var file = new StreamWriter(uuidListFilePath)) {
                    file.Write(textValue);
                }
                Console.WriteLine("UUIDs saved successfully!");
            } catch (System.Exception) {
                Console.WriteLine("An error occurred while trying to save the file.");
                throw;
            }

            Console.WriteLine("Press any key to go back.");
        }

        public static void Exit() {
            Console.Clear();
            Console.WriteLine("UUIDBuilder - Thanks for visit.");
            System.Environment.Exit(0);
        }
    }   
}
