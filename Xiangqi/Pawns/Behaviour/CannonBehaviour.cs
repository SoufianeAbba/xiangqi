using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Pawns.Behaviour
{
    public class CannonBehaviour : IPawnBehaviour
    {
        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();
            bool hasPassedPawn = false;


            // Movement is on the same column.
            if (fromY == toY)
            {
                //Check vertical up.
                for (int row = (fromX - 1); row > -1; row--)
                {
                    if (row == toX)
                    {
                        if (hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, fromY].GetPlayerSide() != currentSide)
                        {
                            return true;
                        }
                        else if (!hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() == PlayerSide.EMPTY)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (gameBoardPositions[row, toY].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            if (!hasPassedPawn)
                            {
                                hasPassedPawn = true;
                            }
                            else
                            {
                                break;
                            }                           
                        }
                    }
                }

                hasPassedPawn = false;

                //Check vertical down.
                for (int row = (fromX + 1); row < 10; row++)
                {
                    if (row == toX)
                    {
                        if (hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, fromY].GetPlayerSide() != currentSide)
                        {
                            return true;
                        }
                        else if (!hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() == PlayerSide.EMPTY)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (gameBoardPositions[row, toY].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            if (!hasPassedPawn)
                            {
                                hasPassedPawn = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            hasPassedPawn = false;

            // Movement is on the same row.
            if (fromX == toX)
            {
                //Check horizontal right.
                for (int col = (fromY + 1); col < 9; col++)
                {
                    if (col == toY)
                    {
                        if (hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[fromX, col].GetPlayerSide() != currentSide)
                        {
                            return true;
                        }
                        else if (!hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() == PlayerSide.EMPTY)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (gameBoardPositions[toX, col].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            if (!hasPassedPawn)
                            {
                                hasPassedPawn = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                hasPassedPawn = false;

                //Check horizontal left.
                for (int col = (fromY - 1); col > -1; col--)
                {
                    if (col == toY)
                    {
                        if (hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[fromX, col].GetPlayerSide() != currentSide)
                        {
                            return true;
                        }
                        else if (!hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() == PlayerSide.EMPTY)
                        {
                            return true;
                        }                  
                    }
                    else
                    {
                        if (gameBoardPositions[toX, col].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            if (!hasPassedPawn)
                            {
                                hasPassedPawn = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions)
        {
            bool[,] possiblePositionsOnGameBoard = new bool[10, 9];

            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();
            bool hasPassedPawn = false;

            //Check vertical up.
            for (int row = (fromX - 1); row > -1; row--)
            {
                if (hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, fromY].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[row, fromY] = true;
                    break;
                }
                else if (!hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    possiblePositionsOnGameBoard[row, fromY] = true;
                }

                if (gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    if (!hasPassedPawn)
                    {
                        hasPassedPawn = true;
                    }
                }
            }

            hasPassedPawn = false;

            //Check vertical down.
            for (int row = (fromX + 1); row < 10; row++)
            {
                if (hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, fromY].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[row, fromY] = true;
                    break;
                }
                else if (!hasPassedPawn && gameBoardPositions[row, fromY].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    possiblePositionsOnGameBoard[row, fromY] = true;
                }

                if (gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    if (!hasPassedPawn)
                    {
                        hasPassedPawn = true;
                    }
                }
            }

            hasPassedPawn = false;


            //Check horizontal right.
            for (int col = (fromY + 1); col < 9; col++)
            {
                if (hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[fromX, col].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[fromX, col] = true;
                    break;
                }
                else if (!hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    possiblePositionsOnGameBoard[fromX, col] = true;
                }

                if (gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    if (!hasPassedPawn)
                    {
                        hasPassedPawn = true;
                    }
                }
            }

            hasPassedPawn = false;

            //Check horizontal left.
            for (int col = (fromY - 1); col > -1; col--)
            {
                if (hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[fromX, col].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[fromX, col] = true;
                    break;
                }
                else if (!hasPassedPawn && gameBoardPositions[fromX, col].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    possiblePositionsOnGameBoard[fromX, col] = true;
                }

                if (gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    if (!hasPassedPawn)
                    {
                        hasPassedPawn = true;
                    }
                }
            }

            return possiblePositionsOnGameBoard;
        }
    }
}
