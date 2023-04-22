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
        [Required]
		public int? DurationInMinutes { get; set; }
		[Required]
		public string Description { get; set; }
        public List<Account> Participants { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive
        {
            get
            {
                return Participants.Count < 5 && DateCreated.AddMinutes(DurationInMinutes ?? 0) > DateTime.Now;
            }
        }

    }
}
