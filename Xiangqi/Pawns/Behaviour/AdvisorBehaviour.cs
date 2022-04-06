namespace Xiangqi.Pawns.Behaviour
{
    public class AdvisorBehaviour : IPawnBehaviour
    {
        public bool CheckMovement(int fromX, int fromY, int toX, int toY, IPawn[,] gameBoardPositions)
        {
            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();
            int rowMin = currentSide == PlayerSide.BLACK ? 0 : 7;
            int rowMax = currentSide == PlayerSide.BLACK ? 2 : 9;

            //Check if movement is inside palace.
            if (toY <= 5 && toY >= 3 && toX >= rowMin && toX <= rowMax)
            {
                // Check top right.
                if ((fromX - 1) == toX && (fromY + 1) == toY)
                {
                    return true;
                } 

                // Check top left.
                if ((fromX - 1) == toX && (fromY - 1) == toY)
                {
                    return true;
                }

                // Check bottom right.
                if ((fromX + 1) == toX && (fromY + 1) == toY)
                {
                    return true;
                }

                // Check bottom left.
                if ((fromX + 1) == toX && (fromY - 1) == toY)
                {
                    return true;
                }
            }

            return false;
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, IPawn[,] gameBoardPositions)
        {
            PlayerSide currentSide = gameBoardPositions[fromX, fromY].GetPlayerSide();
            int rowMin = currentSide == PlayerSide.BLACK ? 0 : 7;
            int rowMax = currentSide == PlayerSide.BLACK ? 2 : 9;

            bool[,] possiblePositionsOnGameBoard = new bool[10, 9];

            int possibleX;
            int possibleY;

            // Check top right.
            possibleX = (fromX - 1);
            possibleY = (fromY + 1);

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (gameBoardPositions[possibleX, possibleY].GetPlayerSide() == PlayerSide.EMPTY || gameBoardPositions[possibleX, possibleY].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[possibleX, possibleY] = true;
                }               
            }

            // Check top left.
            possibleX = (fromX - 1);
            possibleY = (fromY - 1);

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (gameBoardPositions[possibleX, possibleY].GetPlayerSide() == PlayerSide.EMPTY || gameBoardPositions[possibleX, possibleY].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[possibleX, possibleY] = true;
                }
            }

            // Check bottom right.
            possibleX = (fromX + 1);
            possibleY = (fromY + 1);

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (gameBoardPositions[possibleX, possibleY].GetPlayerSide() == PlayerSide.EMPTY || gameBoardPositions[possibleX, possibleY].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[possibleX, possibleY] = true;
                }
            }

            // Check bottom left.
            possibleX = (fromX + 1);
            possibleY = (fromY - 1);

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (gameBoardPositions[possibleX, possibleY].GetPlayerSide() == PlayerSide.EMPTY || gameBoardPositions[possibleX, possibleY].GetPlayerSide() != currentSide)
                {
                    possiblePositionsOnGameBoard[possibleX, possibleY] = true;
                }
            }

            return possiblePositionsOnGameBoard;
        }
    }
}
