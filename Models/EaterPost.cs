
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what_u_gonna_eat.Models
{
    public class EaterPost
    {

        //self properties
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Menu is required.")]
        public string? Menu { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? PosterId { get; set; }

        public virtual Account Poster { get; set; }

        public virtual ICollection<EaterPostAccount> EaterPostAccounts { get; set; }

        
    }

}   
