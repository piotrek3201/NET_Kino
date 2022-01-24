using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class GetShowingByIdUseCase : IGetShowingByIdUseCase
    {
        private readonly IShowingRepository showingRepository;

        public GetShowingByIdUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }
        public Showing Execute(int showingId)
        {
            return showingRepository.GetShowingById(showingId);
        }
    }
}
