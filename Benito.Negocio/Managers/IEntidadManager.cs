namespace Benito.Negocio
{
    public interface IEntidadManager<T>
    {
        T Crear(T entidad);
        List<T> Listar();
        T Obtener(int id);
        void Eliminar(int id);
        T Actualizar(T entidad);
    }
}