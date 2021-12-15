using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    public class QRCode
    {

        private static List<QRcode> QRcodes = new List<QRcode>
            {

            new QR(1025497, "Wes", "Atkinson", 100),
            new QR(1232467, "Jamie", "Hufford", 1050),
            new QR(1239467, "Ethan", "Micheal", 4375),
            new QR(2075545, "Kate", "McGinn", 1400),
            
        };
   

        public static QRcode SearchUsingBarcode(int barcode)
        {
            return QRcodes.Find(p => p.GetQRcode() == barcode);
        }

        public static int GetRandomQRcode()
        {
            // filter the products to get only packaged items
            var qrcodes = QRcodes.ToList();

            // return a random one
            return qrcodes[new Random().Next(qrcodes.Count)].GetQRcode();
        }
    }
}