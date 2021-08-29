using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prog1LabPC1.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]        
        public int Id { get; set; }
        public string name {get;set;}
        public string categoria {get;set;}       
        public decimal precio {get;set;}
        public decimal descuento {get;set;}
        
    }
}