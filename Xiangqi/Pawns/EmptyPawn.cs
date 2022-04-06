using System;
using System.Drawing;
using Xiangqi.Pawns.Behaviour;

namespace Xiangqi.Pawns
{
    public class EmptyPawn : IPawn
    {
        private PlayerSide playerSide;
        private Rectangle pawnLocation;

        public EmptyPawn()
        {
            playerSide = PlayerSide.EMPTY;
            pawnLocation = new Rectangle(0, 0, PawnBitmapCollection.WIDTH, PawnBitmapCollection.HEIGHT);
        }

        public EmptyPawn(EmptyPawn r)
        {
            this.playerSide = r.GetPlayerSide();
            this.pawnLocation = r.GetRec();
        }

        public void Paint(Graphics g, int x, int y, int imageType)
        {
            pawnLocation.X = x;
            pawnLocation.Y = y;

            g.DrawImage(PawnBitmapCollection.pawnEmpty, pawnLocation);
        }

        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            return false;
        }

        public Rectangle GetRec()
        {
            return this.pawnLocation;
        }

        public PlayerSide GetPlayerSide()
        {
            return this.playerSide;
        }

        public IPawnBehaviour GetBehaviour()
        {
            throw new NotImplementedException();
        }

        public IPawn Duplicate()
        {
            return new EmptyPawn(this);
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions)
        {
            return null;
        }
     
    }
}
