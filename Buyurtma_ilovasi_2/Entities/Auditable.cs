using Buyurtma_ilovasi_2.Halpers;
using System;

namespace Buyurtma_ilovasi_2.Entities
{
    public abstract class Auditable :BaseEntities
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Auditable()
        {
            CreatedAt=TimeHelper.GetDateTime();
            UpdatedAt=TimeHelper.GetDateTime();
        }

    }
}
