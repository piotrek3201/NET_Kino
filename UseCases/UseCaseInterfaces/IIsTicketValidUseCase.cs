using CoreBusiness;

namespace UseCases
{
    public interface IIsTicketValidUseCase
    {
        bool Execute(Ticket ticket);
    }
}