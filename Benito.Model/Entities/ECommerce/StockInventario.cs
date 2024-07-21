namespace Benito.Model.Entities.ECommerce {
    public class InventarioBodega : BenitoBaseEntity
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public int ModificarCantidad(int cantidad){
            return 0;
        }
    }

}


