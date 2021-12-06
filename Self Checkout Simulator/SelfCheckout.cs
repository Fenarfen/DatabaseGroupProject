using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class SelfCheckout
    {
        // Attributes
        
        private Product currentProduct;

        // Constructor
        public SelfCheckout(BaggingAreaScale baggingArea, ScannedProducts scannedProducts)
        {
            // TO DO
        }

        // Operations

        public void BarcodeWasScanned(int barcode)
        {
            // TO DO
        }

        public void BaggingAreaWeightChanged()
        {
            // TO DO
        }

        public void UserPaid()
        {
            // TO DO
        }

        public string GetPromptForUser()
        {
            // TO DO: Use the information we have to produce the correct message
            //       e.g. "Scan an item.", "Place item on scale.", etc.

            return "ERROR: UNKNOWN STATE";
        }

        public Product GetCurrentProduct()
        {
            return currentProduct;
        }
    }
}