using CoreBusiness;

namespace UseCases
{
    public interface IGetTicketsByMailUseCase
    {
        IEnumerable<Ticket> Execute(string clientMail);
    }
}