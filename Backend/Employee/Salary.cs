using BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Employee
{
    [ComplexType]
    public class Salary : ValueObject
    {
        public decimal Amount { get; private set; }
        public Salary() { }
        private Salary(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            this.Amount = amount;
        }

        public static Salary Of(decimal value) => new Salary(value);    

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }

        public static bool operator <(Salary one, Salary two)
        {
            return one.Amount <= two.Amount;
        }
        public static bool operator >(Salary one, Salary two)
        {
            return one.Amount >= two.Amount;
        }
        public static bool operator <(Salary one, decimal two)
        {
            return one < new Salary(two);
        }
        public static bool operator >(Salary one, decimal two)
        {
            return one > new Salary(two);
        }
    }
}
