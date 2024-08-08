using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatAt = DateTime.Now;
            IsDeleted = false;
        }

        public int  Id { get; private set; }
        public DateTime CreatAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}