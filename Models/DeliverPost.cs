using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what_u_gonna_eat.Models
{
	public class DeliverPost
	{
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Restaurant is required.")]
        public string? Restaurant { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        public int? OpenAmount { get; set; } = 5;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        private bool _status;

        public bool Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (OpenAmount == 0)
                {
                    _status = false;
                }
                else
                {
                    _status = true;
                }
            }
        }

        // model relationship properties
        [ForeignKey("Account")]
        public int? PosterId { get; set; }
        public virtual Account? Poster { get; set; }

        public virtual ICollection<Order> Orderers { get; set; }


    }
}
