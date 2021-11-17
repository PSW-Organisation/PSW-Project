using System;

namespace IntegrationLibrary.Model
{
    public class Inventory
    {
        private string name;
        private bool isStatic;
        private DateTime dateOfPurchase;
        private InventoryStatus status;

        public Inventory()
        {
        }

        public Inventory(string n, bool b, DateTime d, InventoryStatus i)
        {
            name = n;
            isStatic = b;
            dateOfPurchase = d;
            status = i;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                }
            }
        }

        public bool IsStatic
        {
            get { return isStatic; }
            set
            {
                if (value != isStatic)
                {
                    isStatic = value;
                }
            }
        }

        public DateTime DateOfPurchase
        {
            get { return dateOfPurchase; }
            set
            {
                if (value != dateOfPurchase)
                {
                    dateOfPurchase = value;
                }
            }
        }

        public InventoryStatus Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                }
            }
        }
        public string StatusString
        {
            get
            {   if(status.ToString() != null) { 
                return status.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}