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
            barcodeScanner.BarcodeDetected();

            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaCorrect(object sender, EventArgs e)
        {
            // NOTE: we use the correct item weight here

            if(selfCheckout.GetCurrentProduct() != null)
            {
                baggingAreaScale.WeightChangeDetected(selfCheckout.GetCurrentProduct().GetWeight());
            }

            UpdateDisplay();

        }

        private void UserPutsProductInBaggingAreaIncorrect(object sender, EventArgs e)
        {
            // NOTE: We are pretending to put down an item with the wrong weight.
            // To simulate this we'll use a random number, here's one for you to use.

            int weight = new Random().Next(20, 100);

            if (selfCheckout.GetCurrentProduct() != null)
            {
                baggingAreaScale.WeightChangeDetected(weight);
                UpdateDisplay();
            }
        }

        private void AdminOverridesWeight(object sender, EventArgs e)
        {
            baggingAreaScale.OverrideWeight();
            UpdateDisplay();
        }

        private void UserChoosesToPay(object sender, EventArgs e)
        {
            if(baggingAreaScale.IsWeightOk())
            {
                selfCheckout.UserPaid();

                UpdateDisplay();
            }
        }

        void UpdateDisplay()
        {
            // TODO: use all the information we have to update the UI:
            //     - set whether buttons are enabled
            //     - set label texts
            //     - refresh the scanned products list box

            lblBaggingAreaCurrentWeight.Text = Convert.ToString(baggingAreaScale.GetCurrentWeight());
            lblBaggingAreaExpectedWeight.Text = Convert.ToString(baggingAreaScale.GetExpectedWeight());

            lblTotalPrice.Text = "£" + Convert.ToString((float)scannedProducts.CalculatePrice() / 100);

            lblScreen.Text = selfCheckout.GetPromptForUser();

            lbBasket.Items.Clear();
            foreach (var item in scannedProducts.GetProducts())
            {
                lbBasket.Items.Add(item.GetName());
            }
        }
    }
}