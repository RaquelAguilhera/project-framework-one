namespace project_framework_one.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int PratoId { get; set; }
        public Prato Prato { get; set; }
        public int EntregadorId { get; set; }
        public Entregador Entregador { get; set; }
    }
}
