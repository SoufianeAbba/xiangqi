using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Pawns.Behaviour
{
    public class KnightBehaviour : IPawnBehaviour
    {
        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            // Check horizontal left.
            if ((fromY - 2) > -1 && gameBoardPositions[fromX, (fromY - 1)].GetPlayerSide() == PlayerSide.EMPTY )
            {
                int posY = fromY - 2;
                if(posY == toY)
                {
                    int pos1X = fromX - 1;
                    int pos2X = fromX + 1;

                    if(pos1X == toX)
                    {
                        return true;
                    }

                    if (pos2X == toX)
                    {
                        return true;
                    }
                }
                
            }

            // Check horizontal right.
            if ((fromY + 2) < 9 && gameBoardPositions[fromX, (fromY + 1)].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posY = fromY + 2;
                if (posY == toY)
                {
                    int pos1X = fromX - 1;
                    int pos2X = fromX + 1;

                    if (pos1X == toX)
                    {
                        return true;
                    }

                    if (pos2X == toX)
                    {
                        return true;
                    }
                }

            }

            // Check vertical up.
            if ((fromX - 2) > -1 && gameBoardPositions[(fromX - 1), fromY].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posX = fromX - 2;
                if (posX == toX)
                {
                    int pos1Y = fromY - 1;
                    int pos2Y = fromY + 1;

                    if (pos1Y == toY)
                    {
                        return true;
                    }

                    if (pos2Y == toY)
                    {
                        return true;
                    }
                }
            }

            // Check vertical down.
            if ((fromX + 2) < 10 && gameBoardPositions[(fromX + 1), fromY].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posX = fromX + 2;
                if (posX == toX)
                {
                    int pos1Y = fromY - 1;
                    int pos2Y = fromY + 1;

                    if (pos1Y == toY)
                    {
                        return true;
                    }

                    if (pos2Y == toY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions)
        {
            bool[,] possiblePositionsOnGameBoard = new bool[10, 9];
            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();

            // Check horizontal left.
            if ((fromY - 2) > -1 && gameBoardPositions[fromX, (fromY - 1)].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posY = fromY - 2;

                int pos1X = fromX - 1;
                int pos2X = fromX + 1;

                if (pos1X > -1 && pos1X < 10)
                {
                    if (gameBoardPositions[pos1X, posY].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[pos1X, posY] = true;
                    }
                }

                if (pos2X > -1 && pos2X < 10)
                {
                    if (gameBoardPositions[pos2X, posY].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[pos2X, posY] = true;
                    }
                }
            }

            // Check horizontal right.
            if ((fromY + 2) < 9 && gameBoardPositions[fromX, (fromY + 1)].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posY = fromY + 2;

                int pos1X = fromX - 1;
                int pos2X = fromX + 1;

                if (pos1X > -1 && pos1X < 10)
                {
                    if (gameBoardPositions[pos1X, posY].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[pos1X, posY] = true;
                    }
                }

                if (pos2X > -1 && pos2X < 10)
                {
                    if (gameBoardPositions[pos2X, posY].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[pos2X, posY] = true;
                    }
                }
            }

            // Check vertical up.
            if ((fromX - 2) > -1 && gameBoardPositions[(fromX - 1), fromY].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posX = fromX - 2;

                int pos1Y = fromY - 1;
                int pos2Y = fromY + 1;

                if (pos1Y > -1 && pos1Y < 9)
                {
                    if (gameBoardPositions[posX, pos1Y].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[posX, pos1Y] = true;
                    }
                }

                if (pos2Y > -1 && pos2Y < 9)
                {
                    if (gameBoardPositions[posX, pos2Y].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[posX, pos2Y] = true;
                    }
                }
            
            }

            // Check vertical down.
            if ((fromX + 2) < 10 && gameBoardPositions[(fromX + 1), fromY].GetPlayerSide() == PlayerSide.EMPTY)
            {
                int posX = fromX + 2;

                int pos1Y = fromY - 1;
                int pos2Y = fromY + 1;

                if (pos1Y > -1 && pos1Y < 9)
                {
                    if (gameBoardPositions[posX, pos1Y].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[posX, pos1Y] = true;
                    }
                }

                if (pos2Y > -1 && pos1Y < 9)
                {
                    if (gameBoardPositions[posX, pos2Y].GetPlayerSide() != currentSide)
                    {
                        possiblePositionsOnGameBoard[posX, pos2Y] = true;
                    }
                }              
            }

            return possiblePositionsOnGameBoard;
        }
    }
}
