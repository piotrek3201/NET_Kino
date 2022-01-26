using CoreBusiness;

namespace UseCases
{
    public interface IGetShowingsByDayUseCase
    {
        IEnumerable<Showing> Execute(DateTime day);
    }
}