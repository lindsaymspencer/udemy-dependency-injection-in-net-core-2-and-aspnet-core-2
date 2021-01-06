using System;
using System.Collections.Generic;
using System.Text;
using ConditionalResolve;

namespace ConditionalResolve
{
    class Purchase
    {
        private readonly Func<UserLocations, ITaxCalculator> _accessor;
        public Purchase(Func<UserLocations, ITaxCalculator> accessor)
        {
            _accessor = accessor;
        }

        public int Checkout(UserLocations location)
        {
            var tax = _accessor(UserLocations.Australia);
            var total = tax.Calculate() + 100;
            return total;
        }
    }
}
