using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalPhase;

namespace testform
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            ushort[] ports = new ushort[16];
            int numElem = 16;

            numElem = AardvarkApi.AA_PORT_NOT_FREE;  //test
            numElem = 16;

            AardvarkApi.aa_find_devices(numElem, ports);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //label1.Text = AADetect.aardvarkDetect().ToString();
            label1.Text = AADetect.Main().ToString();
            AADetect.Main();
           
        }
    }
}
