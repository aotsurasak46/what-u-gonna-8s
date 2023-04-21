using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what_u_gonna_eat.Models
{
	public class DeliverPost
	{
		[Key] public int Id { get; set; }

		[ForeignKey("Account")]
		public int UserId { get; set; }

		public string Restaurant { get; set; }

		public bool IsClosed { get; set; }

        public virtual ICollection<Depositor> Depositors { get; set; }

        [Required]
		public TimeSpan Duration { get; set; }

		[Required]
		public string Description { get; set; }

	}
}
