using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Interface
{
    public interface IEntityIdentity
    {
        [Key]
        int Id { get; set; }
    }
}
