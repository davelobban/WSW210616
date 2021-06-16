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
        private List<FuelLine> _lines = new ();
        public void Add(FuelLine value)
        {
            _lines.Add(value);
        }

        public decimal GetTotal(DateTime dateTime)=>_lines.Sum(l => l.Litres) * 1.25m * (dateTime.Hour >= 23 || dateTime.Hour < 7 ? 0.95m : 1m);
    }
    public record FuelLine(decimal Litres);

}
