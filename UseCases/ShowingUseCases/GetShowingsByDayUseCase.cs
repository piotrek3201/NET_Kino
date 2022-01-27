using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class GetShowingsByDayUseCase : IGetShowingsByDayUseCase
    {
        private readonly IShowingRepository showingRepository;

        public GetShowingsByDayUseCase(IShowingRepository showingRepository)
        {
            this.showingRepository = showingRepository;
        }

        public IEnumerable<Showing> Execute(DateTime day)
        {
            return showingRepository.GetShowingsByDay(day);
        }
    }
}
