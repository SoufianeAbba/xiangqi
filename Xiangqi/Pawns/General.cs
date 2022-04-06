using System.Drawing;
using Xiangqi.Pawns.Behaviour;

namespace Xiangqi.Pawns
{
    class General : IPawn
    {
        private PlayerSide playerSide;
        private Rectangle pawnLocation;
        private IPawnBehaviour behaviour;

        public General(PlayerSide playerSide)
        {
            this.playerSide = playerSide;
            pawnLocation = new Rectangle(0, 0, PawnBitmapCollection.WIDTH, PawnBitmapCollection.HEIGHT);
            behaviour = new GeneralBehaviour();
        }

        public General(General r)
        {
            this.playerSide = r.GetPlayerSide();
            this.pawnLocation = r.GetRec();
            this.behaviour = r.GetBehaviour();
        }

        public void Paint(Graphics g, int x, int y, int imageType)
        {
            pawnLocation.X = x;
            pawnLocation.Y = y;

            switch (imageType)
            {
                case 0:
                    g.DrawImage(playerSide == PlayerSide.BLACK ? PawnBitmapCollection.generalChineseBlack : PawnBitmapCollection.generalChineseRed, pawnLocation);
                    break;
                case 1:
                    g.DrawImage(playerSide == PlayerSide.BLACK ? PawnBitmapCollection.generalWesternBlack : PawnBitmapCollection.generalWesternRed, pawnLocation);
                    break;
            }
        }

        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            return behaviour.CheckMovement(fromX, fromY, toX, toY, gameBoardPositions);
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions)
        {
            return behaviour.GetPossibleMovements(fromX, fromY, gameBoardPositions);
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
            return this.behaviour;
        }

        public IPawn Duplicate()
        {
            return new General(this);
        }
    }
}
