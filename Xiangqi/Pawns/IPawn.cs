using System.Drawing;
using Xiangqi.Pawns.Behaviour;

namespace Xiangqi.Pawns
{
    public interface IPawn
    {
        void Paint(Graphics g, int x, int y, int imageType);

        bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions);

        bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions);

        Rectangle GetRec();

        PlayerSide GetPlayerSide();

        IPawnBehaviour GetBehaviour();

        IPawn Duplicate();
    }
}
