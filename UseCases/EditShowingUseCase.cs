using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class EditShowingUseCase : IEditShowingUseCase
    {
        private readonly IShowingRepository showingRepository;

        public EditShowingUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }
        public void Execute(Showing showing)
        {
            showingRepository.UpdateShowing(showing);
        }
    }
}
