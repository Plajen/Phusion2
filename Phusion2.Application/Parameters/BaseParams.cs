using Phusion2.Application.Interfaces;
using System;
using System.Linq.Expressions;

namespace Phusion2.Application.Parameters
{
    public abstract class BaseParams<TEntity> : IBaseParams
    {
        public int? Id { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string OrderBy { get; set; }
        public string Include { get; set; }
        public abstract Expression<Func<TEntity, bool>> Filter();

        protected BaseParams() { }
    }
}
