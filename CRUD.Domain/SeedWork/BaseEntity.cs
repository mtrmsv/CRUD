using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.SeedWork
{
    public class BaseEntity
    {
        public BaseEntity() 
        {
            Id= System.Guid.NewGuid();
        }


        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]

        public System.Guid Id { get; private set; }
    }
}
