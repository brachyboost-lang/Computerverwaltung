using System;
using System.Collections.Generic;
using System.Text;

namespace Computerverwaltung
{
    internal class OfficeWorkstation : Computer
    {
        int CpuPower { get; set; }
        int RamSize { get; set; }
        int HarddriveSize { get; set; }

        public OfficeWorkstation(string name, string IP, int cpuPower, int ramSize, int harddriveSize) : base(name, IP)
        {
            this.CpuPower = cpuPower;
            this.RamSize = ramSize;
            this.HarddriveSize = harddriveSize;
        }
    }

    internal class GraphicWorkstation : OfficeWorkstation
            {
        string GpuName { get; set; }
        int MonitorSize { get; set; }

        public GraphicWorkstation(string name, string IP, int cpuPower, int ramSize, int harddriveSize, string gpuName, int monitorSize) : base(name, IP, cpuPower, ramSize, harddriveSize)
        {
            this.GpuName = gpuName;
            this.MonitorSize = monitorSize;
        }
    }
}
