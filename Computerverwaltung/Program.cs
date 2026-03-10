using System;
using System.Collections.Generic;
using System.Text;

namespace Computerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var verwaltung = new ITVerwaltung();

            var server1 = new Server("Server01", "192.168.0.1", 2, 3, 16, 2, 1024, "FileServer", "1Gbps");
            verwaltung.AddComputer(server1);
            verwaltung.AddComputer(new Server("Server02", "192.168.0.2", 4, 3, 32, 4, 2048, "DatabaseServer", "10Gbps"));
            verwaltung.AddComputer(new OfficeWorkstation("Office01", "192.168.0.10", 2, 8, 512));
            verwaltung.AddComputer(new OfficeWorkstation("Office02", "192.168.0.10", 2, 8, 512));
            verwaltung.AddComputer(new OfficeWorkstation("Office03", "192.168.0.10", 2, 8, 512));
            verwaltung.AddComputer(new OfficeWorkstation("Office04", "192.168.0.10", 2, 8, 512));
            verwaltung.AddComputer(new OfficeWorkstation("Office05", "192.168.0.10", 2, 8, 512));
            verwaltung.AddComputer(new GraphicWorkstation("Graphic01", "192.168.0.11", 4, 16, 1000, "NVIDIA GTX", 27));
            verwaltung.AddComputer(new GraphicWorkstation("Graphic02", "192.168.0.11", 4, 16, 1000, "NVIDIA GTX", 27));
            verwaltung.AddComputer(new GraphicWorkstation("Graphic03", "192.168.0.11", 4, 16, 1000, "NVIDIA GTX", 27));
            verwaltung.AddComputer(new GraphicWorkstation("Graphic04", "192.168.0.11", 4, 16, 1000, "NVIDIA GTX", 27));
            verwaltung.AddComputer(new Terminal("Terminal01", "192.168.0.20", server1, "Room A"));
            verwaltung.AddComputer(new Terminal("Terminal02", "192.168.0.64", server1, "Room B"));
            verwaltung.AddComputer(new Terminal("Terminal03", "192.168.0.87", server1, "Room C"));

            var menu = new Menu(verwaltung);
            menu.Start();
        }
    }

    internal class Computer
    {
        public string Name { get; set; }
        public string IP { get; set; }

        public Computer(string name, string IP)
        {
            this.Name = name;
            this.IP = IP;
        }
        public override string ToString()
        {
            return $"Computer Name:\t{Name}\nIP:\t\t{IP}\n";
        }
    }
    internal class Terminal : Computer
    {
        public Server ConnectedServer { get; set; }
        public string Location { get; set; }

        public Terminal(string name, string ip, Server ConnectedServer, string Location) : base(name, ip)
        {
            this.ConnectedServer = ConnectedServer;
            this.Location = Location;
        }
        public override string ToString()
        {
            return base.ToString() + $"Connected Server:\t{ConnectedServer.Name}\nLocation:\t{Location}\n";
        }
    }

    internal class Server : Computer
    {
        public int CpuAmount { get; set; }
        public int CpuPower { get; set; }
        public int RamSize { get; set; }
        public int HarddriveAmount { get; set; }
        public int HarddriveSize { get; set; }
        public string Servertype { get; set; }
        public string NetworkSpeed { get; set; }

        public Server(string name, string ip, int cpuAmount, int cpuPower, int ramSize, int harddriveAmount, int harddriveSize, string servertype, string networkSpeed) : base(name, ip)
        {
            this.CpuAmount = cpuAmount;
            this.CpuPower = cpuPower;
            this.RamSize = ramSize;
            this.HarddriveAmount = harddriveAmount;
            this.HarddriveSize = harddriveSize;
            this.Servertype = servertype;
            this.NetworkSpeed = networkSpeed;
        }
        public override string ToString()
        {
            return base.ToString() + $"CPU Amount:\t{CpuAmount}\nCPU Power:\t{CpuPower} GHz\nRAM Size:\t{RamSize} GB\nHarddrive Amount:\t{HarddriveAmount}\nHarddrive Size:\t{HarddriveSize} GB\nServertype:\t{Servertype}\nNetwork Speed:\t{NetworkSpeed}\n";
        }
    }
}
