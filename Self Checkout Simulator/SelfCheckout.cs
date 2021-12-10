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
            currentProduct = ProductsDAO.SearchUsingBarcode(barcode);
            currentScannedProducts.Add(currentProduct);
            baggingAreaScale.SetExpectedWeight(baggingAreaScale.GetCurrentWeight() + currentProduct.GetWeight());
        }

        public void BaggingAreaWeightChanged()
        {
            currentProduct = null;
        }

        public void UserPaid()
        {
            currentScannedProducts.Reset();
            baggingAreaScale.Reset();
        }

        public string GetPromptForUser()
        {
            if (currentProduct == null && currentScannedProducts.HasItems() == false)
            {
                return "Scan an item.";
            }
            else if (currentProduct == null && baggingAreaScale.IsWeightOk())
            {
                return "Scan an item or pay.";
            }
            else if (currentProduct != null)
            {
                return "Place the item in the bagging area.";
            }
            else if (!baggingAreaScale.IsWeightOk() && baggingAreaScale.GetCurrentWeight() > (baggingAreaScale.GetExpectedWeight() - (currentScannedProducts.GetProducts()[currentScannedProducts.GetProducts().Count - 1]).GetWeight()))
            {
                return "Please wait, assistant is on the way";
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