using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Data.Services
{
    public interface IDeliverPostService
    {
        IEnumerable<DeliverPost> GetAllDeliverPost();
        DeliverPost GetDeliverPostById(int id);
        void CreateDeliverPost(DeliverPost post);
        void UpdateDeliverPost(DeliverPost post);   
        void DeleteDeliverPostById(int id);
    }
}
