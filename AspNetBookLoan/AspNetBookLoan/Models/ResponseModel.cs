namespace AspNetBookLoan.Models
{
    public class ResponseModel<T>
    {
        public string  Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        
    }
}
