namespace Benito.Datos.Repositorio{

    public interface IRepositorioCrud<T>
    {
        T Crear(T entidad);
        List<T> Listar();
        T Obtener(int id);
        T Obtener(Guid id);
        void Eliminar(int id);
        void Eliminar(Guid id);
        T Actualizar(T entidad);
    }

}