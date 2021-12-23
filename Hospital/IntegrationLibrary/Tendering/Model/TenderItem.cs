using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class TenderItem : Entity 
    {
        private string tenderItemName;
        private int tenderItemQuantity;
        private double tenderItemPrice;

        public string TenderItemName { get => tenderItemName; set => tenderItemName = value; }
        public int TenderItemQuantity { get => tenderItemQuantity; set => tenderItemQuantity = value; }
        public double TenderItemPrice { get => tenderItemPrice; set => tenderItemPrice = value; }

        public TenderItem() : base(-1) { }
    }
}
