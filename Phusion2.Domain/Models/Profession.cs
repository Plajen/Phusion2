using Phusion2.Domain.Core.Models;

namespace Phusion2.Domain.Models
{
    public class Profession : Entity
    {
        public string Description { get; private set; }

        protected Profession() { } // Empty constructor for EF

        public Profession(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
