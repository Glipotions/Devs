using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class LanguageRepository : EfRepositoryBase<Language, BaseDbContext>, ILanguageRepository
    {
        public LanguageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
