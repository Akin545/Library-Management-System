using Library.Management.System.Core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Models
{
    public class EntityIdentity : IEntityIdentity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as IEntityIdentity;

            if (item == null)
                return false;

            return Id.Equals(item.Id);
        }
    }
}