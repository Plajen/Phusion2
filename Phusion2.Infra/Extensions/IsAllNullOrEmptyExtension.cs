using System.Linq;

namespace Phusion2.Infra.Extensions
{
    public static class IsAllNullOrEmptyExtension
    {
        public static bool IsAllNullOrEmpty(this object source)
        {
            return source.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(source))
                .All(value => string.IsNullOrEmpty(value));
        }
    }
}
