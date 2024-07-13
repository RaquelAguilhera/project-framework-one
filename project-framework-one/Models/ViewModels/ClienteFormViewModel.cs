namespace project_framework_one.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente cliente { get; set; }
        public List<Pagamento> pagamentos { get; set; } = new List<Pagamento>();
    }
}
