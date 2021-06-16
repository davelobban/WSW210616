using System;
using System.Collections.Generic;
using System.Linq;

namespace WSW210616
{
    public class PetrolStation
    {
        public Transaction NewTransaction() => new ();
    }

    public record Transaction
    {
        private List<TransactionLine> _lines = new ();
        public void Add(TransactionLine value)
        {
            _lines.Add(value);
        }
        public decimal GetTotal(DateTime dateTime)=>_lines.Where(l=>l is FuelLine).Select(l=>l as FuelLine).Sum(l => l.Litres) * 1.25m * 1.05m* (dateTime.Hour >= 23 || dateTime.Hour < 7 ? 0.95m : 1m)
        + _lines.Where(l => l is SnackLine).Select(l => l as SnackLine).Sum(l => l.ItemCount* l.ItemPrice) * (dateTime.Hour >= 23 || dateTime.Hour < 7 ? 0.95m : 1m);
    }
    public record FuelLine(decimal Litres):TransactionLine;

    public record SnackLine(decimal ItemPrice, int ItemCount) : TransactionLine;

    public record TransactionLine
    {
    }
}
