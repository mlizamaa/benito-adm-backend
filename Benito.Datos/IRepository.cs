namespace Benito.Datos.Repositorio{

    public interface IRepository<T>
    {
        T Agregar(T entidad);
        List<T> Listar();
        T Obtener(int id);
        void Eliminar(int id);
        T Editar(T entidad);
    }

}