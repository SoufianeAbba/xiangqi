using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Pawns.Behaviour
{
    public class RookBehaviour : IPawnBehaviour
    {
        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            // Movement is on the same column.
            if(fromY == toY)
            {
                //Check vertical up.
                for (int row = (fromX - 1); row >-1; row--)
                {
                    if(row == toX)
                    {
                        return true;
                    }
                    else
                    {
                        if(gameBoardPositions[row, toY].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            break;
                        }
                    }
                }

                //Check vertical down.
                for (int row = (fromX + 1); row < 10; row++)
                {
                    if (row == toX)
                    {
                        return true;
                    }
                    else
                    {
                        if (gameBoardPositions[row, toY].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            break;
                        }
                    }
                }
            }

            // Movement is on the same row.
            if (fromX == toX)
            {
                //Check horizontal right.
                for (int col = (fromY + 1); col < 9; col++)
                {
                    if (col == toY)
                    {
                        return true;
                    }
                    else
                    {
                        if (gameBoardPositions[toX, col].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            break;
                        }
                    }
                }

                //Check horizontal left.
                for (int col = (fromY - 1); col > -1; col--)
                {
                    if (col == toY)
                    {
                        return true;
                    }
                    else
                    {
                        if (gameBoardPositions[toX, col].GetPlayerSide() != PlayerSide.EMPTY)
                        {
                            break;
                        }
                    }
                }
            }

            return false;
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions)
        {
            bool[,] possiblePositionsOnGameBoard = new bool[10, 9];
            bool pawnPassed = false;

            /* Movement is on the same column. */
            //Check vertical up.
            for (int row = (fromX - 1); row > -1; row--)
            {
                if(pawnPassed)
                {
                    pawnPassed = false;
                    break;
                }

                possiblePositionsOnGameBoard[row, fromY] = true;

                if (gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    // Same pawn color.
                    if(gameBoardPositions[row, fromY].GetPlayerSide() == gameBoardPositions[fromX, fromY].GetPlayerSide())
                    {
                        possiblePositionsOnGameBoard[row, fromY] = false;
                    }
                    pawnPassed = true;
                }            
            }

            pawnPassed = false;

            //Check vertical down.
            for (int row = (fromX + 1); row < 10; row++)
            {
                if (pawnPassed)
                {
                    pawnPassed = false;
                    break;
                }

                possiblePositionsOnGameBoard[row, fromY] = true;

                if (gameBoardPositions[row, fromY].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    // Same pawn color.
                    if (gameBoardPositions[row, fromY].GetPlayerSide() == gameBoardPositions[fromX, fromY].GetPlayerSide())
                    {
                        possiblePositionsOnGameBoard[row, fromY] = false;
                    }

                    pawnPassed = true;
                }              
            }

            pawnPassed = false;

            /* Movement is on the same row. */
            //Check horizontal right.
            for (int col = (fromY + 1); col < 9; col++)
            {
                if (pawnPassed)
                {
                    pawnPassed = false;
                    break;
                }

                possiblePositionsOnGameBoard[fromX, col] = true;

                if (gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    // Same pawn color.
                    if (gameBoardPositions[fromX, col].GetPlayerSide() == gameBoardPositions[fromX, fromY].GetPlayerSide())
                    {
                        possiblePositionsOnGameBoard[fromX, col] = false;
                    }

                    pawnPassed = true;
                }             
            }

            pawnPassed = false;

            //Check horizontal left.
            for (int col = (fromY - 1); col > -1; col--)
            {
                if (pawnPassed)
                {
                    pawnPassed = false;
                    break;
                }

                possiblePositionsOnGameBoard[fromX, col] = true;

                if (gameBoardPositions[fromX, col].GetPlayerSide() != PlayerSide.EMPTY)
                {
                    // Same pawn color.
                    if (gameBoardPositions[fromX, col].GetPlayerSide() == gameBoardPositions[fromX, fromY].GetPlayerSide())
                    {
                        possiblePositionsOnGameBoard[fromX, col] = false;
                    }
                    pawnPassed = true;
                }
            }

            return possiblePositionsOnGameBoard;
        }

    }
}
