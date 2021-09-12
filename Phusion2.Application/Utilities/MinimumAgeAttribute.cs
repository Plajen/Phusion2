using System;
using System.ComponentModel.DataAnnotations;

namespace Phusion2.Application.Utilities
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;

            if (value != null)
            {
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    return date.AddYears(_minimumAge) < DateTime.Now;
                }
            }

            return false;
        }
    }
}
