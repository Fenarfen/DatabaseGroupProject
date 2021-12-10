using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class SelfCheckout
    {
        // Attributes
        private Product currentProduct;
        private ScannedProducts currentScannedProducts;
        private BarcodeScanner barcodeScanner;
        private BaggingAreaScale baggingAreaScale;

        // Constructor
        public SelfCheckout(BaggingAreaScale baggingArea, ScannedProducts scannedProducts)
        {
            baggingAreaScale = baggingArea;
            currentScannedProducts = scannedProducts;
        }

        // Operations

        public void BarcodeWasScanned(int barcode)
        {
            // TO DO
            currentProduct = ProductsDAO.SearchUsingBarcode(barcode);

            currentScannedProducts.Add(currentProduct);

            baggingAreaScale.SetExpectedWeight(currentScannedProducts.CalculateWeight());
        }

        public void BaggingAreaWeightChanged()
        {
            // TO DO

        }

        public void UserPaid()
        {
            currentScannedProducts.Reset();
            baggingAreaScale.Reset();
        }

        public string GetPromptForUser()
        {
            // TO DO: Use the information we have to produce the correct message
            //       e.g. "Scan an item.", "Place item on scale.", etc.

            if (currentProduct == null)
            {
                return "Scan an item";
            }
            else if (currentProduct != null)
            {
                return "Place item on scale";
            }
            
            return "ERROR: INCORRECT WEIGHT DETECTED";
            return "ERROR: UNKNOWN STATE";
        }

        public Product GetCurrentProduct()
        {
            return currentProduct;
        }
    }
}