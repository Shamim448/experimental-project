using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class PaymentDetaile
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string CardHolderName { get; set; } = "";
        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; } = "";
        [Column(TypeName = "nvarchar(7)")]
        public string ExpirationDate { get; set; } = "";
        [Column(TypeName = "nvarchar(6)")]
        public string SecurityCode { get; set; } = "";         
    }
}
