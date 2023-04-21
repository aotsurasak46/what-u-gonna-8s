using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what_u_gonna_eat.Models
{
	public class Depositor
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("DeliverPost")]
		public int postId { get; set; }

		[ForeignKey("Account")]
		public int UserId { get; set; }

		[Required]
		public string FoodName { get; set; }

        public virtual DeliverPost DeliverPost { get; set; }
    }
}
