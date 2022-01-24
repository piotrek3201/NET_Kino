using CoreBusiness;

namespace UseCases
{
    public interface IGetShowingByIdUseCase
    {
        Showing Execute(int showingId);
    }
}