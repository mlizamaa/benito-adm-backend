using Benito.Datos.Repositorio;

namespace Benito.Negocio
{
    public class EntidadManager<T> : IEntidadManager<T>
    {
        private IRepositorioCrud<T> _entidadRepository ;
        public EntidadManager(IRepositorioCrud<T> entidadRepository){
            this._entidadRepository = entidadRepository;
        }
        public T Actualizar(T entidad)
        {
            return _entidadRepository.Actualizar(entidad);
        }

        public T Crear(T entidad)
        {
            return _entidadRepository.Crear(entidad);
        }

        public void Eliminar(int id)
        {
            _entidadRepository.Eliminar(id);
        }

        public List<T> Listar()
        {
            return _entidadRepository.Listar();
        }

        public T Obtener(int id)
        {
            return _entidadRepository.Obtener(id);
        }
    }
}