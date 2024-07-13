namespace project_framework_one.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public int PedidoId { get; set; }
        public Pedido pedido { get; set; }
    }
}
