using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
