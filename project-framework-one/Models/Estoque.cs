namespace project_framework_one.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
