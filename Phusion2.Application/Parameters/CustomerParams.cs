using LinqKit;
using Phusion2.Application.Extensions;
using Phusion2.Domain.Models;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace Phusion2.Application.Parameters
{
    public class CustomerParams : BaseParams<Customer>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public int? ProfessionId { get; set; }

        public int Page { get; set; } = 1;
        public int TotalPages { get; private set; }

        public override Expression<Func<Customer, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Customer>();

            if (Id != null)
            {
                predicate = predicate.And(x => x.Id == Id);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                var inner = PredicateBuilder.New<Customer>();

                inner = inner.Or(x => x.FirstName.ToLower().Contains(Name.ToLower()));
                inner = inner.Or(x => x.LastName.ToLower().Contains(Name.ToLower()));

                predicate = predicate.And(inner);
            }

            if (!string.IsNullOrEmpty(CPF))
            {
                predicate = predicate.And(x => x.CPF == CPF.ToCleanCPF());
            }

            if (DateOfBirth != null && DateOfBirth != new DateTime())
            {
                predicate = predicate
                    .And(x => x.DateOfBirth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) == DateOfBirth.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }

            if (Age != null)
            {
                predicate = predicate.And(x => x.Age == Age);
            }

            if (ProfessionId != null)
            {
                predicate = predicate.And(x => x.ProfessionId == ProfessionId);
            }

            return predicate;
        }

        public void CountPages(int take, int total)
        {
            TotalPages = decimal.ToInt32(Math.Ceiling(Convert.ToDecimal(total) / Convert.ToDecimal(take)));
        }

        public CustomerParams() { }
    }
}
