using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Pawns.Behaviour
{
    public class ElephantBehaviour : IPawnBehaviour
    {
        private delegate bool compare(int i, int j);

        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();
            int riverRow = currentSide == PlayerSide.BLACK ? 5 : 4;

            compare myDelegate = null;

            if (currentSide == PlayerSide.BLACK)
            {
                myDelegate = (i, j) => i < j;
            }
            else if (currentSide == PlayerSide.RED)
            {
                myDelegate = (i, j) => i > j;
            }

            if(myDelegate(toX, riverRow)) // Check if movement on row is not over the river.
            {
                // Check top right.
                int posX = fromX - 1;
                int posY = fromY + 1;
                if(posX > -1 && posY < 9)
                {
                    if(gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                    {
                        if((posX - 1) == toX && (posY + 1) == toY)
                        {
                            return true;
                        }
                    }
                }

                // Check top left.
                posX = fromX - 1;
                posY = fromY - 1;
                if (posX > -1 && posY > -1)
                {
                    if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                    {
                        if ((posX - 1) == toX && (posY - 1) == toY)
                        {
                            return true;
                        }
                    }
                }

                // Check bottom right.
                posX = fromX + 1;
                posY = fromY + 1;
                if (posX < 10 && posY < 9)
                {
                    if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                    {
                        if ((posX + 1) == toX && (posY + 1) == toY)
                        {
                            return true;
                        }
                    }
                }

                // Check bottom left.
                posX = fromX + 1;
                posY = fromY - 1;
                if (posX < 10 && posY > -1)
                {
                    if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                    {
                        if ((posX + 1) == toX && (posY - 1) == toY)
                        {
                            return true;
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
            int riverRow = currentSide == PlayerSide.BLACK ? 5 : 4;

            compare myDelegate = null;

            if(currentSide == PlayerSide.BLACK)
            {
                myDelegate = (i, j) => i < j;
            }
            else if(currentSide == PlayerSide.RED)
            {
                myDelegate = (i, j) => i > j;
            }

            // Check top right.
            int posX = fromX - 1;
            int posY = fromY + 1;
                    
            if (posX > -1 && posY < 9)
            {
                if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    if (gameBoardPositions[(posX - 1), (posY + 1)].GetPlayerSide() != currentSide && myDelegate((posX - 1), riverRow)) 
                    {
                        possiblePositionsOnGameBoard[(posX - 1), (posY + 1)] = true;
                    }
                }
            }

            // Check top left.
            posX = fromX - 1;
            posY = fromY - 1;
            if (posX > -1 && posY > -1)
            {
                if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    if (gameBoardPositions[(posX - 1), (posY - 1)].GetPlayerSide() != currentSide && myDelegate((posX - 1), riverRow))
                    {
                        possiblePositionsOnGameBoard[(posX - 1), (posY - 1)] = true;
                    }
                }
            }

            // Check bottom right.
            posX = fromX + 1;
            posY = fromY + 1;
            if (posX < 10 && posY < 9)
            {
                if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY)
                {
                    if (gameBoardPositions[(posX + 1), (posY + 1)].GetPlayerSide() != currentSide && myDelegate((posX + 1), riverRow))
                    {
                        possiblePositionsOnGameBoard[(posX + 1), (posY + 1)] = true;
                    }
                }
            }

            // Check bottom left. 
            posX = fromX + 1;
            posY = fromY - 1;
            if (posX < 10 && posY > -1) 
            {
                if (gameBoardPositions[posX, posY].GetPlayerSide() == PlayerSide.EMPTY )
                {
                    if (gameBoardPositions[(posX + 1), (posY - 1)].GetPlayerSide() != currentSide && myDelegate((posX + 1), riverRow))
                    {
                        possiblePositionsOnGameBoard[(posX + 1), (posY - 1)] = true;
                    }
                }
            }

            return possiblePositionsOnGameBoard;
        }
    }
}
