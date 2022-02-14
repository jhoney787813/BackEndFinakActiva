using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BEndClientes.Models
{

    [Table("Clientes")]
    public class Cliente
    {

        [Key]
        [Column("Identificacion", TypeName = "numeric(11,0)")]
        public int identificacion { get; set; }

        [Required]
        [Column("NombreCompleto", TypeName = "varchar(150)")]
        public string nombrecompleto { get; set; }

        [Required]
        [Column("RazonSocial", TypeName = "varchar(150)")]
        public string razonsocial { get; set; }
        [Required]
        [Column("Proveedores", TypeName = "integer")]
        public int proveedores { get; set; }
        [Required]
        [Column("Ventas", TypeName = "integer")]
        public int ventas { get; set; }


        [MaxLength(3)]
        [Column("idtipodoc", TypeName = "varchar(3)")]
        public string idtipodocref { get; set; }

        [ForeignKey("idtipodocref")]
        public  TipoDocumento Idtipodoc { get; set; }
        
    }
}
