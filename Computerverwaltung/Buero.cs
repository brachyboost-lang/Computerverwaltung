using System;
using System.Collections.Generic;
using System.Text;

namespace Computerverwaltung
{

    internal class OfficeWorkstation : Computer
    {
        public int CpuPower { get; set; }
        public int RamSize { get; set; }
        public int HarddriveSize { get; set; }

        public OfficeWorkstation(string name, string IP, int cpuPower, int ramSize, int harddriveSize) : base(name, IP)
        {
            this.CpuPower = cpuPower;
            this.RamSize = ramSize;
            this.HarddriveSize = harddriveSize;
        }
    }

    internal class GraphicWorkstation : OfficeWorkstation
            {
        public string GpuName { get; set; }
        public string MonitorSize { get; set; }

        public GraphicWorkstation(string name, string IP, int cpuPower, int ramSize, int harddriveSize, string gpuName, string monitorSize) : base(name, IP, cpuPower, ramSize, harddriveSize)
        {
            this.GpuName = gpuName;
            this.MonitorSize = monitorSize;
        }
    }
}
