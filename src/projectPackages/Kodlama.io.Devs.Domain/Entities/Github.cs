using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class GithubProfile : Entity
    {
        public string Url { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public GithubProfile()
        {
        }

        public GithubProfile(int id, string url, int userId) : this()
        {
            Id = id;
            Url = url;
            UserId = userId;
        }

    }
}

