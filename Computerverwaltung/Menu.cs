using System;
using System.Collections.Generic;
using System.Text;

namespace Computerverwaltung
{
    internal class Menu
    {
        private readonly ITVerwaltung it;

        public Menu(ITVerwaltung verwaltung)
        {
            it = verwaltung;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("1) Anzeige aller Rechner (mit Index)");
                Console.WriteLine("2) Anzeige aller Rechner einer speziellen Art");
                Console.WriteLine("3) Anlage eines neuen Rechners");
                Console.WriteLine("4) Löschung eines Rechners über den Index");
                Console.WriteLine("0) Beenden");
                Console.Write("Wahl: ");
                var input = Console.ReadLine();
                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        ShowAllWithIndices();
                        break;
                    case "2":
                        ShowByType();
                        break;
                    case "3":
                        CreateComputer();
                        break;
                    case "4":
                        RemoveByIndex();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        break;
                }
            }
        }

        private void ShowAllWithIndices()
        {
            var list = it.Computers;
            if (list.Count == 0)
            {
                Console.WriteLine("Keine Rechner vorhanden.");
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"[{i}] {list[i].Name}");
                Console.WriteLine(list[i].ToString());
            }
        }

        private void ShowByType()
        {
            Console.WriteLine("Wähle Typ:");
            Console.WriteLine("1) Server");
            Console.WriteLine("2) Terminal");
            Console.WriteLine("3) OfficeWorkstation");
            Console.WriteLine("4) GraphicWorkstation");
            Console.WriteLine("5) Alle anderen (Basis)");
            Console.Write("Wahl: ");
            var choice = Console.ReadLine();
            var list = it.Computers;
            bool any = false;
            for (int i = 0; i < list.Count; i++)
            {
                var c = list[i];
                bool match = choice switch
                {
                    "1" => c is Server,
                    "2" => c is Terminal,
                    "3" => c is OfficeWorkstation,
                    "4" => c is GraphicWorkstation,
                    "5" => c.GetType() == typeof(Computer),
                    _ => false
                };
                if (match)
                {
                    Console.WriteLine($"[{i}] {c.Name}");
                    Console.WriteLine(c.ToString());
                    any = true;
                }
            }
            if (!any) Console.WriteLine("Keine Rechner dieses Typs gefunden.");
        }

        private void CreateComputer()
        {
            Console.WriteLine("Wähle Typ zum Anlegen:");
            Console.WriteLine("1) Basis Computer");
            Console.WriteLine("2) Server");
            Console.WriteLine("3) Terminal");
            Console.WriteLine("4) OfficeWorkstation");
            Console.WriteLine("5) GraphicWorkstation");
            Console.Write("Wahl: ");
            var choice = Console.ReadLine();
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("IP: ");
            var ip = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    it.AddComputer(new Computer(name, ip));
                    Console.WriteLine("Basis-Computer angelegt.");
                    break;
                case "2":
                    int cpuAmount = GetUserInt("CPU Amount: ");
                    int cpuPower = GetUserInt("CPU Power (GHz): ");
                    int ramSize = GetUserInt("RAM Size (GB): ");
                    int hdAmount = GetUserInt("Harddrive Amount: ");
                    int hdSize = GetUserInt("Harddrive Size (GB): ");
                    string servertype = GetUserString("Servertype (e.g. Webserver, Datenbankserver): ");
                    string netspeed = GetUserString("Network Speed (e.g. 1Gbps): ");
                    it.AddComputer(new Server(name, ip, cpuAmount, cpuPower, ramSize, hdAmount, hdSize, servertype, netspeed));
                    Console.WriteLine("Server angelegt.");
                    break;
                case "3":
                    var servers = new List<(int idx, Server server)>();
                    var list = it.Computers;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is Server s) servers.Add((i, s));
                    }
                    if (servers.Count == 0)
                    {
                        Console.WriteLine("Keine Server vorhanden. Lege zuerst einen Server an.");
                        return;
                    }
                    Console.WriteLine("Verfügbare Server:");
                    foreach (var s in servers)
                        Console.WriteLine($"[{s.idx}] {s.server.Name}");
                    Console.Write("Index des verbundenen Servers: ");
                    if (!int.TryParse(Console.ReadLine(), out int serverIndex))
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        return;
                    }
                    if (serverIndex < 0 || serverIndex >= list.Count || !(list[serverIndex] is Server chosenServer))
                    {
                        Console.WriteLine("Ungültiger Server-Index"); return;
                    }
                    string location = GetUserString("Standort des Terminals: ");
                    it.AddComputer(new Terminal(name, ip, chosenServer, location));
                    Console.WriteLine("Terminal angelegt.");
                    break;
                case "4":
                    int cpuP = GetUserInt("CPU Power (GHz): ");
                    int ram = GetUserInt("Ram Size (GB): ");
                    int hd = GetUserInt("Harddrive Size (GB): ");
                    it.AddComputer(new OfficeWorkstation(name, ip, cpuP, ram, hd));
                    Console.WriteLine("OfficeWorkstation angelegt.");
                    break;
                case "5":
                    int cpuPg = GetUserInt("CPU Power (GHz): ");
                    int ramg = GetUserInt("RAM Size (GB): ");
                    int hdg = GetUserInt("Harddrive Size (GB): ");
                    string gpu = GetUserString("GPU Name: ");
                    double mon = GetUserDouble("Monitor Size (Zoll): ");
                    it.AddComputer(new GraphicWorkstation(name, ip, cpuPg, ramg, hdg, gpu, mon));
                    Console.WriteLine("GraphicWorkstation angelegt.");
                    break;
                default:
                    Console.WriteLine("Ungültige Wahl.");
                    break;
            }
        }

        private void RemoveByIndex()
        {
            Console.Write("Index des zu löschenden Rechners: ");
            if (!int.TryParse(Console.ReadLine(), out int idx))
            {
                Console.WriteLine("Ungültige Eingabe.");
                return;
            }
            var result = it.RemoveComputerAt(idx);
            Console.WriteLine(result);
        }
        public int GetUserInt(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl eingeben.");
                return GetUserInt(prompt);
            }
        }
        public string GetUserString(string prompt)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input != null)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte einen Text eingeben.");
                return GetUserString(prompt);
            }
        }
        public double GetUserDouble(string prompt)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl eingeben.");
                return GetUserDouble(prompt);
            }
        }
    }
}
