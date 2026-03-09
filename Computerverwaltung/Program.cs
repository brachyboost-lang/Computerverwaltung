using System;

namespace Computerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
    }
    internal class Terminal : Computer
    {
        public object ConnectedServer { get; set; }
        public string Location { get; set; }

        public Terminal(string name, string ip, object ConnectedServer, string Location) : base(name, ip)
        {
            this.ConnectedServer = ConnectedServer;
            this.Location = Location;
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
    }
}