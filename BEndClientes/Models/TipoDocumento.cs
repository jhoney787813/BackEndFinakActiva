using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BEndClientes.Models
{
    [Table("TipoDocumentos")]
    public class TipoDocumento
    {
        [Key]
        [MaxLength(3)]
        [Required]
        [Column("idtipodoc", TypeName = "varchar(3)")]
        public string idtipodoc { get; set; }
        [Required]
        [Column("Descripcion", TypeName = "varchar(100)")]
        public string descripcion { get; set; }


        public ICollection<Cliente> Clientes { get; set; }
    }
}
