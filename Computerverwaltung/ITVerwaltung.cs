using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Computerverwaltung
{
    internal class ITVerwaltung
    {
        private readonly List<Computer> ComputerList;
        private int? computerAmount;

        public ITVerwaltung()
        {
            ComputerList = new List<Computer>();
            computerAmount = ComputerList.Count;
        }
        public string AddComputer(Computer computer)
        {
            ComputerList.Add(computer);
            computerAmount = ComputerList.Count;
            return $"Computer {computer.Name} added successfully.";
        }
        public string RemoveComputer(Computer computerName)
        {
            try
            {
                ComputerList.Remove(computerName);
                computerAmount = ComputerList.Count;
                return $"Computer {computerName.Name} removed successfully.";
            }
            catch (Exception ex)
            {
                return $"Computer {computerName.Name} could not be removed.\nError message: {ex.Message}";
            }
        }
        public void ShowAllComputers()
        {
            if (ComputerList.Count == 0)
            {
                Console.WriteLine("No computers in the list.");
            }
            else
            {
                foreach (var computer in ComputerList)
                {
                    Console.WriteLine(computer.ToString());
                }
            }
        }
    }
}
