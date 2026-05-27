using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_2
{
    internal class Register
    {
        public const int size = 4;
        public Device[] devices = new Device[size];
        private int count;

        public Device[] Devices
        {
            get
            {
                Device[] avaibleDevices = new Device[count];
                for (int i = 0; i < count; i++)
                {
                    avaibleDevices[i] = devices[i];
                }
                return avaibleDevices;
            }
        }

        public void AddDevice(Device device)
        {
            if (count < size)
            {
                devices[count] = device;
                count++;
            }
            else
            {
                Console.WriteLine("Register is full. Cannot add more devices.");
            }
        }

        public override string ToString()
        {
            string devices = "";
            foreach (var device in Devices)
            {
                devices += device.ToString() + "\n";
            }
            return $"Current Devices:\n{devices}";
        }
    }
}  
