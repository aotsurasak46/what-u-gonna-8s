using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.ViewModels
{
    public class EaterPostView
    {
        public Account account { get; set; }
        public EaterPost eaterPost { get; set; }
        public IEnumerable<EaterPost> eaterPosts { get; set; }
    }
}
