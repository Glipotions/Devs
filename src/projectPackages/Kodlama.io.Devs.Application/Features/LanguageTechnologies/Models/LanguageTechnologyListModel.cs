using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models
{
    public class LanguageTechnologyListModel : BasePageableModel
    {
        public IList<LanguageTechnologyListDto> Items { get; set; }
    }
}
