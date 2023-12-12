using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS.Serial
{
    public class sp_Master
    {
        static SerialPort serial;
        public static void Open(string PortName)
        {
            try
            {
                serial = new SerialPort();

                serial.PortName = PortName;
                serial.BaudRate = 38400;
                serial.Parity = Parity.None;
                serial.DataBits = 8;
                serial.StopBits = StopBits.One;
                serial.Handshake = Handshake.None;

                serial.DataReceived += Comport1_DataReceived;
                serial.Open();

                Model.isOpen_Master = true;
            }
            catch (Exception ex) { }
        }

        private static void Comport1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(serial.ReadExisting());
        }

        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);
        }
    }
}
