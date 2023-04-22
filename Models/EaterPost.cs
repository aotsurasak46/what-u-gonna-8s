
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
         
        [Required] public bool isClosed { get; set; }

        public string BenefactorId { get; set; } 
        
        public DateTime Date { get; set;} = DateTime.Now;

        [Required]
        public int TimeOut { get; set; }

        [Required]
        public string Menu { get; set; }

        public virtual Account account { get; set; }
    }

}
