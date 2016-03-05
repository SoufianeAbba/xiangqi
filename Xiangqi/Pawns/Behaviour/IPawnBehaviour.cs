using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Pawns.Behaviour
{
    public interface IPawnBehaviour
    {
        bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions);

        bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions);
    }
}
