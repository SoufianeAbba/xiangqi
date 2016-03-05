using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Pawns.Behaviour
{
    public class SoldierBehaviour : IPawnBehaviour
    {
        private delegate bool compare(int i, int j);
        private delegate int compare2(int k);
        private delegate bool compare3(int i);


        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();
            bool passedRiver = false;

            if (currentSide == PlayerSide.BLACK)
            {
                passedRiver = fromX < 5 ? false : true; 

                // Check down.
                if((fromX + 1) < 10)
                {
                    if ((fromX + 1) == toX && fromY == toY)
                    {
                        return true;
                    }
                }

                if(passedRiver)
                {
                    // Check right.
                    if ((fromY + 1) < 9)
                    {
                        if (fromX == toX && (fromY + 1) == toY)
                        {
                            return true;
                        }
                    }

                    // Check left.
                    if ((fromY - 1) > -1)
                    {
                        if (fromX == toX && (fromY - 1) == toY)
                        {
                            return true;
                        }
                    }
                }
            }

            if (currentSide == PlayerSide.RED)
            {
                passedRiver = fromX > 4 ? false : true;

                // Check up.
                if ((fromX - 1) > -1)
                {
                    if ((fromX - 1) == toX && fromY == toY)
                    {
                        return true;
                    }
                }

                if (passedRiver)
                {
                    // Check right.
                    if ((fromY + 1) < 9)
                    {
                        if (fromX == toX && (fromY + 1) == toY)
                        {
                            return true;
                        }
                    }

                    // Check left.
                    if ((fromY - 1) > -1)
                    {
                        if (fromX == toX && (fromY - 1) == toY)
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

            int riverRow = currentSide == PlayerSide.BLACK ? 4 : 5;

            compare myDelegate = null;
            compare2 myDelegate2 = null;
            compare3 myDelegate3 = null;

            if (currentSide == PlayerSide.BLACK)
            {
                myDelegate = (i, j) => i > j;
                myDelegate2 = (k) => k + 1;
                myDelegate3 = (i) => i < 10;
            }
            else if (currentSide == PlayerSide.RED)
            {
                myDelegate = (i, j) => i < j;
                myDelegate2 = (k) => k - 1;
                myDelegate3 = (i) => i > -1;
            }

            bool passedRiver = myDelegate(fromX, riverRow);

            // Check down or up.
            if (myDelegate3(myDelegate2(fromX)))
            {
                possiblePositionsOnGameBoard[myDelegate2(fromX), fromY] = true;
            }

            if (passedRiver)
            {
                // Check right.
                if ((fromY + 1) < 9)
                {
                    possiblePositionsOnGameBoard[fromX, (fromY + 1)] = true;
                }

                // Check left.
                if ((fromY - 1) > -1)
                {
                    possiblePositionsOnGameBoard[fromX, (fromY - 1)] = true;
                }
            }

            return possiblePositionsOnGameBoard;
        }

        //public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        //{
        //    PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();

        //    int riverRow = currentSide == PlayerSide.BLACK ? 4 : 5;

        //    compare myDelegate = null;
        //    compare2 myDelegate2 = null;
        //    compare3 myDelegate3 = null;

        //    if (currentSide == PlayerSide.BLACK)
        //    {
        //        myDelegate = (i, j) => i > j;
        //        myDelegate2 = (k) => k + 1;
        //        myDelegate3 = (i) => i < 10;
        //    }
        //    else if (currentSide == PlayerSide.RED)
        //    {
        //        myDelegate = (i, j) => i < j;
        //        myDelegate2 = (k) => k - 1;
        //        myDelegate3 = (i) => i > -1;
        //    }

        //    bool passedRiver = myDelegate(fromX, riverRow);

        //    // Check down or up.
        //    if (myDelegate3(myDelegate2(fromX)))
        //    {
        //        if (myDelegate2(fromX) == toX && fromY == toY)
        //        {
        //            return true;
        //        }
        //    }

        //    if (passedRiver)
        //    {
        //        // Check right.
        //        if ((fromY + 1) < 9)
        //        {
        //            if (fromX == toX && (fromY + 1) == toY)
        //            {
        //                return true;
        //            }
        //        }

        //        // Check left.
        //        if ((fromY - 1) > -1)
        //        {
        //            if (fromX == toX && (fromY - 1) == toY)
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    
    }
}
