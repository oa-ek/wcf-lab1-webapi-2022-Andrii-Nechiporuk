using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Core
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? KeyId { get; set; }

        public double? Price { get; set; }

        public virtual Key? Key { get; set; }

        public virtual Order? Order { get; set; }
    }
}