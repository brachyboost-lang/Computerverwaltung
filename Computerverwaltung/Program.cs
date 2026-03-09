using System;

namespace Computerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mal gucken ob es schlau war so viele strings zu nutzen?");
            Console.WriteLine("Hab doch wieder in int umgewandelt in Buero.cs");
        }
    }

    public class Computer
    {
        public string Name { get; set; }
        public string IP { get; set; }
        
        public Computer(string name, string IP) 
        {
            this.Name = name;
            this.IP = IP;
        }
    }
    public class Terminal
    {
        string ConnectedServer { get; set; }
        string Location { get; set; }
    }
    public class Server
    {
        int CpuAmount { get; set; }
        int RamSize { get; set; }
        int HarddriveAmount { get; set; }
        int HarddriveSize { get; set; }
        string Servertype { get; set; }
        string NetworkSpeed { get; set; }
    }
}