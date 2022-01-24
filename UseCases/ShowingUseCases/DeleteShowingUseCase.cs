using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class DeleteShowingUseCase : IDeleteShowingUseCase
    {
        private readonly IShowingRepository showingRepository;

        public DeleteShowingUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }
        public void Delete(int showingId)
        {
            showingRepository.DeleteShowing(showingId);
        }
    }
}
