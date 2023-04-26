using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.ViewModels
{
    public class DeliverPostView
    {
        public DeliverPost deliverPost { get; set; }
        public IEnumerable<DeliverPost> deliverPosts { get; set; }
    }
}
