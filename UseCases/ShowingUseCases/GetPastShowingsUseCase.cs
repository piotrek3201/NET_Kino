using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class GetPastShowingsUseCase : IGetPastShowingsUseCase
    {
        private readonly IShowingRepository showingRepository;

        public GetPastShowingsUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }
        public IEnumerable<Showing> Execute()
        {
            return showingRepository.GetPastShowings();
        }
    }
}
