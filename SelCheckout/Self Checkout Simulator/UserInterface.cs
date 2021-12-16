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

            baggingAreaScale.WeightChangeDetected(selfCheckout.GetCurrentProduct().GetWeight());

            UpdateDisplay();

        }

        private void UserPutsProductInBaggingAreaIncorrect(object sender, EventArgs e)
        {
            // NOTE: We are pretending to put down an item with the wrong weight.
            // To simulate this we'll use a random number, here's one for you to use.

            int weight = new Random().Next(20, 100);

            baggingAreaScale.WeightChangeDetected(weight);
            UpdateDisplay();
        }

        private void AdminOverridesWeight(object sender, EventArgs e)
        {
            baggingAreaScale.OverrideWeight();
            UpdateDisplay();
        }

        private void UserChoosesToPay(object sender, EventArgs e)
        {
            selfCheckout.UserPaid();

            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            //if user has not scanned anything yet
            if (selfCheckout.GetCurrentProduct() == null && scannedProducts.GetProducts().Count == 0)
            {
                btnUserPutsProductInBaggingAreaCorrect.Enabled = false;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = false;
                btnAdminOverridesWeight.Enabled = false;
                btnUserChooseToPay.Enabled = false;
                btnUserScansBarcodeProduct.Enabled = true;
            }
            //if user has scanned but not placed
            else if (selfCheckout.GetCurrentProduct() != null)
            {
                btnUserPutsProductInBaggingAreaCorrect.Enabled = true;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = true;
                btnAdminOverridesWeight.Enabled = false;
                btnUserChooseToPay.Enabled = false;
                btnUserScansBarcodeProduct.Enabled = false;
            }
            //if the user has placed their item correctly
            else if (selfCheckout.GetCurrentProduct() == null && baggingAreaScale.IsWeightOk())
            {
                btnUserPutsProductInBaggingAreaCorrect.Enabled = false;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = false;
                btnAdminOverridesWeight.Enabled = false;
                btnUserChooseToPay.Enabled = true;
                btnUserScansBarcodeProduct.Enabled = true;
            }
            //if the user has placed their item incorrectly
            else if (!baggingAreaScale.IsWeightOk() && baggingAreaScale.GetCurrentWeight() > (baggingAreaScale.GetExpectedWeight() - (scannedProducts.GetProducts()[scannedProducts.GetProducts().Count - 1]).GetWeight()))
            {
                btnUserPutsProductInBaggingAreaCorrect.Enabled = false;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = false;
                btnAdminOverridesWeight.Enabled = true;
                btnUserChooseToPay.Enabled = false;
                btnUserScansBarcodeProduct.Enabled = false;
            }

            //system labels labels
            lblBaggingAreaCurrentWeight.Text = baggingAreaScale.GetCurrentWeight().ToString("N0");
            lblBaggingAreaExpectedWeight.Text = baggingAreaScale.GetExpectedWeight().ToString("N0");
            lblTotalPrice.Text = "£" + ((float)scannedProducts.CalculatePrice() / 100f).ToString();

            //set customer facing screen
            lblScreen.Text = selfCheckout.GetPromptForUser();

            //set scanned items listbox contents
            lbBasket.Items.Clear();
            foreach (var product in scannedProducts.GetProducts())
            {
                string price = (product.CalculatePrice() / 100f).ToString();
                lbBasket.Items.Add("£" + price + " " + product.GetName());
            }
        }
    }
}