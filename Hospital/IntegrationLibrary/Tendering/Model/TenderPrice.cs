using IntegrationLibrary.Pharmacies.Model;
using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class TenderPrice : ValueObject
    {
        public double Price { get; set; }
        public Currency Currency { get; set; }


        public TenderPrice() { }
        public TenderPrice(double price, Currency currency)
        {
            if(price< 0 || currency.ToString().IsNullOrEmpty()) throw new ArgumentException("You must set price and currency!");
            Price = price;
            Currency = currency;
        }

        public TenderPrice ChangePrice(double price)
        {
            if(price < 0) throw new ArgumentException("You must set  price!");
            return new TenderPrice(price, this.Currency);
        }
        public TenderPrice ChangeCurrency(Currency currency)
        {
            if (currency.ToString().IsNullOrEmpty()) throw new ArgumentException("You must set currency!");
            return new TenderPrice(this.Price, currency);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Price;
            yield return Currency;
        }
    }
}
