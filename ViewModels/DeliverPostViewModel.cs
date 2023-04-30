using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.ViewModels
{
    public class DeliverPostView
    {
        public Account account { get; set; }
        public List<Account> accounts { get; set; }
        public DeliverPost deliverPost { get; set; }
        public List<DeliverPost> deliverPosts { get; set; }
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }

    }
}
