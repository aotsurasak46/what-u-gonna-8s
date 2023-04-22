using Microsoft.EntityFrameworkCore;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Data.Services
{
    public class DeliverPostService : IDeliverPostService 
    {
        private readonly ApplicationDbContext _db;
        public DeliverPostService(ApplicationDbContext db) {
            _db = db;
        }

        public IEnumerable<DeliverPost> GetAllDeliverPost()
        {
            throw new NotImplementedException();
        }

        public DeliverPost GetDeliverPostById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateDeliverPost(DeliverPost post)
        {
            throw new NotImplementedException();
        }

        public void UpdateDeliverPost(DeliverPost post)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeliverPostById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
