using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class Product
    {
        // Attributes
        protected int barcode;
        protected string name;
        protected int weightInGrams;

        // Operations
        public string GetName()
        {
            return name;
        }

        public int GetBarcode()
        {
            return barcode;
        }

        public int GetWeight()
        {
            return weightInGrams;
        }

        // TODO: Use the class diagram for details of other operations
        public void SetWeight(int newWeight)
        {
            weightInGrams = newWeight;
        }

        //public int CalculatePrice()
        //{
            //TODO??? don't see why we need another considering there's only packaged products being sold
        //}
    }

    class PackagedProduct : Product
    {
        // Attributes
        private int priceInPence;

        // Constructor
        public PackagedProduct(int newBarcode, string newName, int newPriceInPence, int newWeightInGrams)
        {
            barcode = newBarcode;
            name = newName;
            priceInPence = newPriceInPence;
            weightInGrams = newWeightInGrams;
        }

        //Operations
        public int CalculatePrice()
        {
           return priceInPence;
        }
    }
}