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
        public override string ToString()
        {
            return base.ToString() + $"CPU Power:\t{CpuPower} GHz\nRAM Size:\t{RamSize} GB\nHarddrive Size:\t{HarddriveSize} GB\n";
        }
    }

    internal class GraphicWorkstation : OfficeWorkstation
            {
        public string GpuName { get; set; }
        public double MonitorSize { get; set; }

        public GraphicWorkstation(string name, string IP, int cpuPower, int ramSize, int harddriveSize, string gpuName, double monitorSize) : base(name, IP, cpuPower, ramSize, harddriveSize)
        {
            this.GpuName = gpuName;
            this.MonitorSize = monitorSize;
        }
        public override string ToString()
        {
            return base.ToString() + $"GPU Name:\t{GpuName}\nMonitor Size:\t{MonitorSize} inch\n";
        }
    }
}
