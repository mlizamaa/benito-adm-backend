
using Benito.Datos.Dto;
using Benito.Datos.Repositorio;
using Benito.Model.Entities.ECommerce;
using AutoMapper;
namespace Benito.Negocio.Managers.ECommerce {

    public class ProductoManager : IProductoManager
    {
        private readonly IRepositorioCrud<Producto> _productoRepository;
        // Clase de lógica de negocio para el módulo de productos
        public ProductoManager(IRepositorioCrud<Producto> productoRepository){
            _productoRepository = productoRepository;
        }

        public ProductoDto Actualizar(ProductoDto producto)
        {
           // Mapea el DTO a entidad con AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductoDTO, Producto>());
            var mapper = config.CreateMapper();
            var entidad = mapper.Map<Producto>(producto);
            // Actualiza el producto en la base de datos
            _productoRepository.Actualizar(entidad);
            // Retorna el DTO del producto actualizado
            return producto;

        }

        public ProductoDto Crear(ProductoDto producto)
        {
           // mapear DTO a entidad con AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductoDto, Producto>());
            var mapper = config.CreateMapper();
            var entidad = mapper.Map<Producto>(producto);
            // crear el producto en la base de datos
            entidad = _productoRepository.Crear(entidad);
            // transformar la entidad en dto mediante automapper
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Producto, ProductoDTO>());
            var mapper2 = config2.CreateMapper();
            producto = mapper2.Map<ProductoDto>(entidad);
            // retornar el DTO del producto
            return producto;
        }

        public void Eliminar(int id)
        {
            // eliimnar el producto de la base de datos
            _productoRepository.Eliminar(id);

        }

        public List<ProductoDto> Listar()
        {
           var config = new MapperConfiguration(cfg => cfg.CreateMap<Producto, ProductoDto>());
           var mapper = config.CreateMapper();
           var productosBd = _productoRepository.Listar();
           var productos = mapper.Map<List<ProductoDto>>(productosBd);
           return productos;
        }

        public ProductoDto Obtener(int id)
        {
            // obtener el producto de la base de datos
            var productoBd = _productoRepository.Obtener(id);
            // mapear entidad a DTO con AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Producto, ProductoDto>());
            var mapper = config.CreateMapper();
            var producto = mapper.Map<ProductoDto>(productoBd);
            // retornar el DTO del producto
            return producto;
        }
    }

}