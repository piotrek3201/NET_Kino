namespace UseCases
{
    public interface IDeleteExpiredReservationsByShowingIdUseCase
    {
        void Execute(int showingId);
    }
}
