namespace Quoridors.Models.Services
{
    public interface IBoardFactory
    {
        BoardCellStatus[][] CreateBoard();
    }
}