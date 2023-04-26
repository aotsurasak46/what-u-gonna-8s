using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace what_u_gonna_eat.Models
{
    public class EaterPostAccount
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EaterPost")]
        public int EaterPostId { get; set; }
        public virtual EaterPost EaterPost { get; set; }

        [ForeignKey("Account")]
        public int BuyerId { get; set; }
        public virtual Account Buyer { get; set; }
    }
}
