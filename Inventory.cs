using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Strumplådan3
{
    internal class Inventory
    {
        List<Sock> socks = new List<Sock>();
         
        public void GetSavedSocks()
        {
            try
            {
                string getSavedSocks = File.ReadAllText("inventarie");
                socks = JsonSerializer.Deserialize<List<Sock>>(getSavedSocks) ?? new List<Sock>();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ingen befinlig fil funnen, ny inventarie startas.");
                socks = new List<Sock>();
            }
            catch (Exception)
            {
                Console.WriteLine("Ett fel har inträffat, ny inventarie startas.");
                socks = new List<Sock>();
            }
            
        }

        public void MainMenu()
        {
            Console.WriteLine("Välkommen till inventariehjälpen, hur kan jag assistera dig idag?");
            Console.WriteLine("1. Lägg till ett sockpar");
            Console.WriteLine("2. Visa alla tillgängliga sockar i inventarielistan");
            Console.WriteLine("3. Spara och avsluta");
            HandleMenuChoice();
        }

        public void HandleMenuChoice()
        {
            int menuChoice;
            bool validChoice = int.TryParse(Console.ReadLine(), out menuChoice);

            if (validChoice == false)
            {
                Console.WriteLine("Ange ditt val med giltig siffra");
            }
            else
            {
                switch (menuChoice)
                {
                    case 1:
                        AddSock();
                        break;
                    case 2:
                        ShowAllSocks();
                        break;
                    case 3:
                        SaveSockFile();
                        Console.WriteLine("Programmet avslutas");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, ange någon av de tillgängliga siffrorna");
                        break;
                }
            }
        }

        public void AddSock()
        {
            Sock sock = new Sock();
            Console.WriteLine("Ange storlek:");
            sock.Size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ange färg:");
            sock.Color = Console.ReadLine();
            Console.WriteLine("Ange betyg mellan 0-5");
            sock.Grade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            socks.Add(sock);
            MainMenu();

        }

        public void ShowAllSocks()
        {
            foreach (var s in socks)
            {
                Console.WriteLine($"Storlek: {s.Size}. Färg: {s.Color}. Betyg: {s.Grade}");
            }
            Console.WriteLine();
            MainMenu();
        }

        public void SaveSockFile()
        {
            string saveSocks = JsonSerializer.Serialize(socks);
            File.WriteAllText("inventarie", saveSocks);
        }


    }
}
