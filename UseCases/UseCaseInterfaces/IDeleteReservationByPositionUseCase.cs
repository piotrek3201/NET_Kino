namespace UseCases
{
    public interface IDeleteReservationByPositionUseCase
    {
        void Execute(int showingId, int seatRow, int seatColumn);
    }
}
