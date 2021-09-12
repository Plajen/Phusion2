using LinqKit;
using Phusion2.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Phusion2.Application.Parameters
{
    public class ProfessionParams : BaseParams<Profession>
    {
        public string Description { get; set; }

        public override Expression<Func<Profession, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Profession>();

            if (Id != null)
                predicate = predicate.And(x => x.Id == Id);

            if (!string.IsNullOrEmpty(Description))
                predicate = predicate.And(x => x.Description.ToLower().Contains(Description.ToLower()));

            return predicate;
        }
    }
}
