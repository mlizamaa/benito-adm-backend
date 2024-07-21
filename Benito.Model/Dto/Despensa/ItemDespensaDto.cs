using System;
using Benito.Model.Entities.Despensa;
namespace Benito.Model.Dto.Despensa
{
    
    // DTO para la vista de la despensa, automapeado con AutoMapper con la clase Item

    
    public class ItemDespensaDto
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public bool? EnStock { get; set; }
        public int? Cantidad { get; set; }    
    }
}