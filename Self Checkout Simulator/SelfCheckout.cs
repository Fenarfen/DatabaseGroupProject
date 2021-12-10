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
            if (currentProduct == null)
            {
                currentProduct = ProductsDAO.SearchUsingBarcode(barcode);

                currentScannedProducts.Add(currentProduct);

                baggingAreaScale.SetExpectedWeight(currentScannedProducts.CalculateWeight());
            }
        }

        public void BaggingAreaWeightChanged()
        {
            currentProduct = null;
        }

        public void UserPaid()
        {
            currentScannedProducts.Reset();
            baggingAreaScale.Reset();
            currentProduct = null;
        }

        public string GetPromptForUser()
        {
            if (currentProduct == null && currentScannedProducts.HasItems() == false)
            {
                return "Scan an item to begin";
            }
            else if (currentProduct == null && baggingAreaScale.IsWeightOk())
            {
                return "Scan an item";
            }
            else if (currentProduct != null)
            {
                return "Place item on scale";
            }
            else if (!baggingAreaScale.IsWeightOk())
            {
                return "ERROR: INCORRECT WEIGHT DETECTED";
            }
            else
            {
                return "ERROR: UNKNOWN STATE";
            }
        }

        public Product GetCurrentProduct()
        {
            return currentProduct;
        }
    }
}