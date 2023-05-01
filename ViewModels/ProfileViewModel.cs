using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.ViewModels
{
    public class ProfileViewModel
    {
        public Account account {  get; set; }

        public List<DeliverPost> deliverposts { get; set; }
        public List<EaterPost> eaterposts { get; set; }
        public List<EaterPostAccount> eaterpostaccounts { get; set; }
        public List<Order> orders { get; set; }
    }
}
