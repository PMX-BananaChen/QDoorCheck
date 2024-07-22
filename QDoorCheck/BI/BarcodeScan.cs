using System;
using System.Collections.Generic;
using System.Text;

namespace QDoorCheck.BI
{
    public class BarcodeScanEventArgs:EventArgs
    {
        private string _barcodeNo;

        public string BarcodeNo
        {
            get { return _barcodeNo; }
            protected set { _barcodeNo = value; }
        }

        public BarcodeScanEventArgs(string barcodeNo)
            :base()
        {
            this.BarcodeNo = barcodeNo;
        }
    }

    public delegate void BarcodeScannedHandler(object sender,BarcodeScanEventArgs e);


    public class BarcodeScan
    {
        public event BarcodeScannedHandler BarcodeScanned;

        private bool inRunning = false;
        private object _obj = new object();
        System.Threading.Thread listenThread = null;

        /// <summary>
        /// Throw barcode scan event.
        /// </summary>
        /// <param name="barcodeNo"></param>
        protected virtual void OnBarcodeScanned(string barcodeNo)
        {
            if (null!=BarcodeScanned)
            {
                BarcodeScanned(this, new BarcodeScanEventArgs(barcodeNo));
            }
        }

        public void Start()
        {
            lock (_obj)
            {
                if (inRunning)
                {
                    throw new Exception("Barcode scan is already in running!");
                }

                this.inRunning = true;

                listenThread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
                listenThread.Start();
            }          
        }

        public void Stop()
        {
            lock (_obj)
            {
                if (!inRunning)
                {
                    throw new Exception("Barcode scan has already stopped!");
                }                             

                this.inRunning = false;
            }
        }

        private void Listen()
        {
            while (inRunning)
            {
                //TODO: get a barcode from machine.
                string barcodeNo = GetScannedBarcode();
                if (!string.IsNullOrEmpty(barcodeNo))
                {
                    OnBarcodeScanned(barcodeNo);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        private string GetScannedBarcode()
        {
//#if DEBUG
//            List<string> strs = new List<string>();
//            strs.Add("987654321");
//            strs.Add("123456789");
//            strs.Add("2134adsf23");

//            Random rnd = new Random();
//            return strs[rnd.Next(0, strs.Count)];
//#else  
            List<string> strs = new List<string>();
            strs.Add("987654321");
            strs.Add("123456789");
            strs.Add("2134adsf23");
            strs.Add("543216789");

            Random rnd = new Random();
            return strs[rnd.Next(0, strs.Count)];
//#endif
        }
    }
}
