using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    public partial class UserInterface : Form
    {
        // Attributes
        SelfCheckout selfCheckout;
        BarcodeScanner barcodeScanner;
        BaggingAreaScale baggingAreaScale;
        ScannedProducts scannedProducts;

        // Constructor
        public UserInterface()
        {
            InitializeComponent();

            // NOTE: This is where we set up all the objects,
            // and create the various relationships between them.

            baggingAreaScale = new BaggingAreaScale();
            scannedProducts = new ScannedProducts();
            barcodeScanner = new BarcodeScanner();
            selfCheckout = new SelfCheckout(baggingAreaScale, scannedProducts);
            barcodeScanner.LinkToSelfCheckout(selfCheckout);
            baggingAreaScale.LinkToSelfCheckout(selfCheckout);

            UpdateDisplay();
        }

        // Operations
        private void UserScansProduct(object sender, EventArgs e)
        {
            // TO DO

            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaCorrect(object sender, EventArgs e)
        {
            // NOTE: we use the correct item weight here

            // TO DO

            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaIncorrect(object sender, EventArgs e)
        {
            // NOTE: We are pretending to put down an item with the wrong weight.
            // To simulate this we'll use a random number, here's one for you to use.

            int weight = new Random().Next(20, 100);

            // TODO

            UpdateDisplay();
        }

        private void AdminOverridesWeight(object sender, EventArgs e)
        {
        
            // TO DO

            UpdateDisplay();
        }

        private void UserChoosesToPay(object sender, EventArgs e)
        {
            // TO DO

            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            // TODO: use all the information we have to update the UI:
            //     - set whether buttons are enabled
            //     - set label texts
            //     - refresh the scanned products list box
        }
    }
}