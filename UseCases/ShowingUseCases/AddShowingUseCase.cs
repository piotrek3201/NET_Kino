using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class AddShowingUseCase : IAddShowingUseCase
    {
        private readonly IShowingRepository showingRepository;

        public AddShowingUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }
        public void Execute(Showing showing)
        {
            showingRepository.AddShowing(showing);
        }
    }
}
