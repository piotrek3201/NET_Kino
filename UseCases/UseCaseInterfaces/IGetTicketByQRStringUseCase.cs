using CoreBusiness;

namespace UseCases
{
    public interface IGetTicketByQRStringUseCase
    {
        Ticket Execute(string pQRString);
    }
}