using System;
using System.Collections.Generic;
using Benito.Model;
namespace Benito.Datos.Dto
{
    public class ProductoDto : BenitoBaseEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Nombre del Producto, es el nombre que se muestra en la tienda
        /// </summary>
        public string? Nombre{ get; set; }
        
        
        /// <summary>
        /// Breve reseña del producto, es el texto que aparece como subtitulo del nombre del producto.
        /// </summary>
        public string? Resena { get; set; }
        
        /// <summary>
        /// Código del tipo de producto
        /// </summary>
        public Guid? CodTipo { get; set; } 
        /// <summary>
        /// Código de la Categoría del producto
        /// </summary>
        public Guid? Categoría { get; set; }
        
        /// <summary>
        /// Indicador de si el producto está en estado de borrador, los productos en borrador no se muestran en la tienda
        /// </summary>
        public bool McaBorrador  { get; set; }
        
        /// <summary>
        /// Precio de venta Actual del Producto
        /// </summary>
        public decimal? Precio  { get; set; }
        /// <summary>
        /// Porcentaje de descuento vigente del producto
        /// </summary>
        public decimal? Descuento  { get; set; }

        /// <summary>
        /// Indicador de si el producto tiene descuento vigente
        /// </summary>
        public bool? McaDescuento { get; set; }
        
        /// <summary>
        /// Descrición del producto, es el texto que se muestra en la página de detalle del producto
        /// </summary>
        public string? Descripcion { get; set; }
        
        /// <summary>
        /// Meta descripción del producto, es el texto que se muestra como tooltip en la imagen del producto
        /// </summary>
        public string? MetaTitulo { get; set;} 
        
        
        /// <summary>
        /// Json con el listado de puntos destacados del producto [{"codigo":"string", "valor":"string"}]
        /// </summary>
        public string? PuntosDestacadosJson  { get; set; }

        public string? CodigoBarra  { get; set; }

        // listado de caracteristicas del producto [{"codigo":"string", "valor":"string"}]
        public string? CaracteristicasJson  { get; set; }
        public string? Imagen  { get; set; }
    }
}