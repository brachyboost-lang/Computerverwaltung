using System;
using System.Collections.Generic;
using System.Text;

namespace Computerverwaltung
{
    internal class ITVerwaltung
    {
        public List<Computer> ComputerList { get; set; }

        public ITVerwaltung()
        {
            ComputerList = new List<Computer>();
        }
    }
}
