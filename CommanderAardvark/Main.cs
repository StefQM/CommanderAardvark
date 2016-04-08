using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

//using System.IO;
using TotalPhase;

namespace CommanderAardvark
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();

            aardVarkWrapper aardVarkObject = new aardVarkWrapper();

            i2cCommandLine[] i2cCommandLines = new i2cCommandLine[5];

            for (int i = 0; i < i2cCommandLines.Length; i++)
            {
                i2cCommandLines[i] = new i2cCommandLine(aardVarkObject);
                this.tabI2c.Controls.Add(i2cCommandLines[i].pnlI2cCommand);
            }

        }

    }


    public partial class i2cCommandLine
    {
        private static int _i2cCommandLineCount = 0;
        private static aardVarkWrapper _aardVarkObject;
        //static aardVarkWrapper aardVarkObject = new aardVarkWrapper();

        public i2cCommandLine(aardVarkWrapper aardVarkObject)
        {
            _i2cCommandLineCount++;
            this.InitializeComponent();
            _aardVarkObject = aardVarkObject;
        }

        //TODO: make addr byte[] iso byte (both read/write functions)
        private void btnI2cWrite_Click(object sender, EventArgs e)
        {
            byte device = typeConversion.StringToByteArray(txtI2cDevice.Text)[0];
            device = (byte)(device & 0xFE);

            byte addr = typeConversion.StringToByteArray(txtI2cAddr.Text)[0];

            byte[] data = new byte[typeConversion.StringToByteArray(txtI2cData.Text).Length];
            data = typeConversion.StringToByteArray(txtI2cData.Text);

            _writeI2c(_aardVarkObject.handle, device, addr, data, false);
            Console.WriteLine("I2C W - " + device.ToString("X2") + " "
                + addr.ToString("X2") + " "
                + BitConverter.ToString(data).Replace("-", " "));
        }

        private void btnI2cRead_Click(object sender, EventArgs e)
        {
            byte device = typeConversion.StringToByteArray(txtI2cDevice.Text)[0];
            device = (byte)(device | 0x01);

            byte addr = typeConversion.StringToByteArray(txtI2cAddr.Text)[0];

            byte[] data = new byte[typeConversion.StringToByteArray(txtI2cData.Text).Length];
            data = typeConversion.StringToByteArray(txtI2cData.Text);

            _readI2c(_aardVarkObject.handle, device, addr, data, false);

            Console.WriteLine("I2C R - " + device.ToString("X2") + " "
                + addr.ToString("X2") + " "
                + BitConverter.ToString(data).Replace("-", " "));

            txtI2cData.Text = typeConversion.ByteArrayToString(data);
        }

        private static void _writeI2c(int handle, byte device, byte addr, byte[] data, bool zero)
        {
            //if (data == null)

            // combi address and data
            byte[] addrData = new byte[data.Length + 1];
            data.CopyTo(addrData, 1);
            addrData[0] = addr;

            // write i2c to the device
            AardvarkApi.aa_i2c_write(handle, (ushort)(device / 2),
                                        AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                        (ushort)addrData.Length, addrData);
            AardvarkApi.aa_sleep_ms(10);

        }

        private static void _readI2c(int handle, byte device, byte addr, byte[] data, bool zero)
        {
            int count = 0;
            //if (data == null)

            byte[] address = { addr };
            //byte[] dataRx = new byte[data.Length];

            // write i2c address to the device
            AardvarkApi.aa_i2c_write(handle, (ushort)(device / 2),
                                        AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                        (ushort)address.Length, address);

            // read i2c data from the device
            count = AardvarkApi.aa_i2c_read(handle, (ushort)(device / 2),
                                AardvarkI2cFlags.AA_I2C_NO_FLAGS,
                                (ushort)data.Length, data);

            if (count < 0)
            {
                Console.WriteLine("error: {0}\n", AardvarkApi.aa_status_string(count));
                return;
            }

            if (count == 0)
            {
                Console.WriteLine("error: no bytes read");
                Console.WriteLine("       are you sure you have the right slave address?");
                return;
            }
            else if (count != data.Length)
            {
                Console.WriteLine("error: read {0} bytes (expected {1})",
                                  count, data.Length);
            }
            //    AardvarkApi.aa_sleep_ms(10);

        }

    }

    public class aardVarkWrapper
    {
        /*=====================================================================
        | CONSTANTS
        ====================================================================*/
        public const int PAGE_SIZE = 8;
        public const int BUS_TIMEOUT = 150;  // ms

        private int _handle;
        private int port = 0;
        private int bitrate = 100;
        private int bus_timeout;

        public int handle
        {
            get { return _handle; }
        }

        public aardVarkWrapper()
        {
            Console.WriteLine("Starting...");
            AADetect.aarvarkDetect();

            // Open the device
            _handle = AardvarkApi.aa_open(port);
            if (_handle <= 0)
            {
                Console.WriteLine("Unable to open Aardvark device on port {0}",
                                  port);
                Console.WriteLine("error: {0}",
                                  AardvarkApi.aa_status_string(_handle));
                return;
            }

            // Ensure that the I2C subsystem is enabled
            AardvarkApi.aa_configure(_handle, AardvarkConfig.AA_CONFIG_SPI_I2C);

            // Enable the I2C bus pullup resistors (2.2k resistors).
            // This command is only effective on v2.0 hardware or greater.
            // The pullup resistors on the v1.02 hardware are enabled by default.
            AardvarkApi.aa_i2c_pullup(_handle, AardvarkApi.AA_I2C_PULLUP_BOTH);

            // Power the EEPROM using the Aardvark adapter's power supply.
            // This command is only effective on v2.0 hardware or greater.
            // The power pins on the v1.02 hardware are not enabled by default.
            AardvarkApi.aa_target_power(_handle,
                                         AardvarkApi.AA_TARGET_POWER_BOTH);

            // Set the bitrate
            bitrate = AardvarkApi.aa_i2c_bitrate(_handle, bitrate);
            Console.WriteLine("Bitrate set to {0} kHz", bitrate);

            // Set the bus lock timeout
            bus_timeout = AardvarkApi.aa_i2c_bus_timeout(_handle, BUS_TIMEOUT);
            Console.WriteLine("Bus lock timeout set to {0} ms", bus_timeout);
        }
    }

    public static class typeConversion
    {
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }

}
