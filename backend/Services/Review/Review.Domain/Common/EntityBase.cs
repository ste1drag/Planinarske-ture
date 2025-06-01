using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewing.Domain.Common
{
    public abstract class EntityBase(int Id, DateTime CreateDate, DateTime UpdateDate)
    {
        public int Id { get; protected set; } = Id;
        public DateTime CreatedDate { get; protected set; } = CreateDate;
        public DateTime UpdatedDate { get; protected set; } = UpdateDate;
    }
}
