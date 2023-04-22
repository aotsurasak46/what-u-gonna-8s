
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what_u_gonna_eat.Models
{
    public class EaterPost
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Account")]
        public int UserId { get; set; }

        [Required] public string Restaurant { get; set; } = "Prathep Restaurant";

        [Required] public bool isClosed { get; set; } = false;

        public string BenefactorId { get; set; } 
        
        public DateTime Date { get; set;} = DateTime.Now;

        [Required(ErrorMessage = "Time Period is required.")]
        [DisplayName("Time period")]
        public int TimeOut { get; set; }

        [Required(ErrorMessage = "Menu is required.")]
        public string Menu { get; set; }

        public virtual Account account { get; set; }
    }

}
