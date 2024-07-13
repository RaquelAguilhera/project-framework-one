namespace project_framework_one.Models
{
    public class Prato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Qtde { get; set; }
        public int Peso { get; set; }
        public float Preco { get; set; }
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
