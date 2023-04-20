using System.ComponentModel.DataAnnotations;

namespace what_u_gonna_eat.Models
{
    public class EaterPost
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int UserId { get; set; }

        [Required] public string Restaurant { get; set;}

        [Required] public bool isClosed { get; set; }

        public string BenefactorId { get; set; } 

        public DateTime Date { get; set;} = DateTime.Now;

        [Required]
        public int TimeOut { get; set; }

        [Required]
        public string Menu { get; set; }



    }

}
