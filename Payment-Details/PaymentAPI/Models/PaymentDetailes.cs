namespace PaymentAPI.Models
{
    public class PaymentDetailes
    {
        public int Id { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }       
    }
}
