using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Data.Services
{
    public interface IEaterPostService
    {
        IEnumerable<EaterPost> GetAllDeliverPost();
        EaterPost GetEaterPostById(int id);
        void CreateEaterPost(EaterPost post);
        void UpdateEaterPost(EaterPost post);
        void DeleteEaterPostById(int id);
    }
}
