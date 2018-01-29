using System;

namespace Hexa.Business.Models.Shared
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
