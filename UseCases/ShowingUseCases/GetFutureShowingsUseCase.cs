using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class GetFutureShowingsUseCase : IGetFutureShowingsUseCase
    {
        private readonly IShowingRepository showingRepository;

        public GetFutureShowingsUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }

        public IEnumerable<Showing> Execute()
        {
            return showingRepository.GetFutureShowings();
        }
    }
}
