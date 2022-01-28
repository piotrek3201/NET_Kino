using CoreBusiness;

namespace UseCases
{
    public interface IAddTicketUseCase
    {
        void Execute(Ticket ticket);
    }
}