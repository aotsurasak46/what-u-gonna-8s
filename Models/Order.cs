using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what_u_gonna_eat.Models
{
    public class Order
    {
        //self properties
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Menu is Requied")]
        public string? Menu { get; set; }

        [Required(ErrorMessage = "Description is Requied")]
        public string? Description { get; set; }


        // model relationship properties
        [ForeignKey("DeliverPost")]
        public int? DeliverPostId { get; set; }
        public virtual DeliverPost? DeliverPost { get; set; }

        [ForeignKey("Account")]
        public int? OrdererId { get; set; }
        public virtual Account? Orderer { get; set; }

    }
}
