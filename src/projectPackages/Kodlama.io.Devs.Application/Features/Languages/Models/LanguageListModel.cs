using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;

namespace Kodlama.io.Devs.Application.Features.Languages.Models
{
    public class LanguageListModel : BasePageableModel
    {
        public IList<LanguageListDto> Items { get; set; }
    }
}
