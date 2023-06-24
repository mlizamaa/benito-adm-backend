
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.Modelo;
using Benito.Datos.Repositorio;
using AutoMapper;
namespace Benito.Negocio {

    public class ProductoManager : IProductoManager
    {
        private readonly IRepository<Producto> _productoRepository;
        // Clase de lógica de negocio para el módulo de productos
        public ProductoManager(IRepository<Producto> productoRepository){
            _productoRepository = productoRepository;
        }
        public ProductoDTO RegistrarProducto(string nombre, decimal precio)
        {
            // Lógica para registrar un producto en la base de datos
            // ...
            var entidad =  _productoRepository.Agregar(new Producto {
                Nombre = nombre,
                Precio = precio
            });
            // Retornar DTO del producto registrado
            var productoDTO = new ProductoDTO
            {
                Id = entidad.Id, // Id asignado al producto registrado
                Nombre = entidad.Nombre,
                Precio = entidad.Precio
            };

            return productoDTO;
        }

        public List<ProductoDTO> ObtenerProductos()
        {
           var config = new MapperConfiguration(cfg => cfg.CreateMap<Producto, ProductoDTO>());
           var mapper = config.CreateMapper();
           var productosBd = _productoRepository.Listar();
           var productos = mapper.Map<List<ProductoDTO>>(productosBd);
           return productos;
        }


    }

}