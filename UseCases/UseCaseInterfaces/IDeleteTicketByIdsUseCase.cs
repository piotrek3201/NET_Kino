using CoreBusiness;

namespace UseCases
{
    public interface IDeleteTicketByIdsUseCase
    {
        void Execute(string clientMail, int ticketId);
    }
}