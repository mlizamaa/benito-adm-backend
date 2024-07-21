using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benito.Model.Entities.Despensa
{
    
    [Table("ItemDespensa")]
    public class ItemDespensa : BenitoBaseEntity {
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public bool EnStock { get; set; }
        public int Cantidad { get; set; }    
    }

}