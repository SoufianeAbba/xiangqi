using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xiangqi.Pawns;

namespace Xiangqi
{
    public enum PlayerSide { BLACK, RED, EMPTY}
    public enum GameState { PLAYING, CHECKMATED, BREAK}

    public class GameBoard
    {
        private Bitmap gameBoardImg;
        private IPawn[,] gameBoardPositions;
        private GameState gameState;

        private int screenWidthMiddle;
        private int screenHeightMiddle;

        private int pawnSizeWidth;
        private int pawnSizeHeight;

        private int spaceBetweenPawnsX;
        private int spaceBetweenPawnsY;

        private int imageType;

        private Rectangle selectedPawn;
        private int selectedCol;
        private int selectedRow;
        private PlayerSide previousPlayer;
        private bool[,] selectedPawnPossibleMovements;

        private IPawn blackGeneral;
        private int colBlackGeneral;
        private int rowBlackGeneral;
        private bool blackGeneralChecked;

        private IPawn redGeneral;
        private int colRedGeneral;
        private int rowRedGeneral;
        private bool redGeneralChecked;

        private IPawn threateningPawn;
        private int colThreateningPawn;
        private int rowThreateningPawn;

        public GameBoard()
        {
            gameBoardImg = new Bitmap(Xiangqi.Properties.Resources.smboard);
            gameBoardPositions = new IPawn[10, 9];

            pawnSizeWidth = PawnBitmapCollection.WIDTH;
            pawnSizeHeight = PawnBitmapCollection.HEIGHT;

            spaceBetweenPawnsX = 12;
            spaceBetweenPawnsY = 12;

            imageType = 1;

            selectedPawn = Rectangle.Empty;
            previousPlayer = PlayerSide.BLACK;

            PlacePawns();
            
            screenWidthMiddle = GameScreen.width / 2;
            int gameBoardWidthMiddle = gameBoardImg.Width / 2;
            screenWidthMiddle = screenWidthMiddle - gameBoardWidthMiddle;

            screenHeightMiddle = GameScreen.height / 2;
            int gameBoardHeighMiddle = gameBoardImg.Height / 2;
            screenHeightMiddle = screenHeightMiddle - gameBoardHeighMiddle;
        }

        public void Paint(PaintEventArgs e, Label l)
        {
            string currentSide = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK.ToString() : PlayerSide.RED.ToString();
            l.Text = "Current side on set: " + currentSide;
            PaintBoardImg(e);
            PaintPawns(e);
        }

        private void PaintBoardImg(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(gameBoardImg, new Rectangle(screenWidthMiddle, screenHeightMiddle, gameBoardImg.Width, gameBoardImg.Height));
        }

        private void PaintPawns(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int locX = screenWidthMiddle - (pawnSizeWidth / 2);
            int locY = screenHeightMiddle - (pawnSizeHeight / 2);


            int marginX = pawnSizeWidth + spaceBetweenPawnsX;
            int marginY = pawnSizeHeight + spaceBetweenPawnsY;

            // If black general is checked.
            if (GeneralIsChecked(blackGeneral))
            {
                g.DrawImage(PawnBitmapCollection.generalChecked, blackGeneral.GetRec());
                blackGeneralChecked = true;

                if (GeneralIsCheckMated(blackGeneral))
                {
                    gameState = GameState.CHECKMATED;
                    g.DrawString("Checkmate, RED has won!!!\n\nStart a new game!", new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular),
                    new SolidBrush(Color.Black), 0, 60);
                }
            }
            
            // If red general is checked.
            if (GeneralIsChecked(redGeneral))
            {
                g.DrawImage(PawnBitmapCollection.generalChecked, redGeneral.GetRec());
                redGeneralChecked = true;

                if (GeneralIsCheckMated(redGeneral))
                {
                    gameState = GameState.CHECKMATED;
                    g.DrawString("Checkmate. BLACK has won!!!\n\nStart a new game!", new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular),
                    new SolidBrush(Color.Black), 0, 50);
                }
            }
            
            // Draw every pawn on the board and updating its X and Y.
            for(int row = 0; row < 10; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    if (gameBoardPositions[row, col] != null)
                    {
                        gameBoardPositions[row, col].Paint(g, (marginX * col) + locX, (marginY * row) + locY, imageType);
                    }
                }
            }
       
            // Marking the selected pawn.
            if(!selectedPawn.IsEmpty)
            {
                g.DrawImage(PawnBitmapCollection.pawnMarker, selectedPawn);
            }

            // Marking the pawn that threatens the general if checked.
            if (threateningPawn != null)
            {
                g.DrawImage(PawnBitmapCollection.threateningPawnMarker, threateningPawn.GetRec());
            }

            // Marking the possible positions the pawn can move to.
            if (selectedPawnPossibleMovements != null)
            {
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (selectedPawnPossibleMovements[row, col])
                        {
                            g.DrawImage(PawnBitmapCollection.possibleMovementMarker, gameBoardPositions[row, col].GetRec());
                        }
                    }
                }
            }
        }

        private void ResetBoard()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    gameBoardPositions[row, col] = null;
                }
            }

            PlacePawns();
        }

        private void PlacePawns()
        {
            gameState = GameState.PLAYING;

            blackGeneral = new General(PlayerSide.BLACK);
            redGeneral = new General(PlayerSide.RED);

            colBlackGeneral = 4;
            rowBlackGeneral = 0;

            colRedGeneral = 4;
            rowRedGeneral = 9;

            blackGeneralChecked = false;
            redGeneralChecked = false;

            threateningPawn = null;
            rowThreateningPawn = -1;
            colThreateningPawn = -1;

            selectedPawn = Rectangle.Empty;
            selectedCol = -1;
            selectedRow = -1;
            selectedPawnPossibleMovements = null;

            // Black side.
            gameBoardPositions[0, 0] = new Rook(PlayerSide.BLACK);
            gameBoardPositions[0, 1] = new Knight(PlayerSide.BLACK);
            gameBoardPositions[0, 2] = new Elephant(PlayerSide.BLACK);
            gameBoardPositions[0, 3] = new Advisor(PlayerSide.BLACK);
            gameBoardPositions[0, 4] = blackGeneral;
            gameBoardPositions[0, 5] = new Advisor(PlayerSide.BLACK);
            gameBoardPositions[0, 6] = new Elephant(PlayerSide.BLACK);
            gameBoardPositions[0, 7] = new Knight(PlayerSide.BLACK);
            gameBoardPositions[0, 8] = new Rook(PlayerSide.BLACK);

            gameBoardPositions[2, 1] = new Cannon(PlayerSide.BLACK);
            gameBoardPositions[2, 7] = new Cannon(PlayerSide.BLACK);

            gameBoardPositions[3, 0] = new Soldier(PlayerSide.BLACK);
            gameBoardPositions[3, 2] = new Soldier(PlayerSide.BLACK);
            gameBoardPositions[3, 4] = new Soldier(PlayerSide.BLACK);
            gameBoardPositions[3, 6] = new Soldier(PlayerSide.BLACK);
            gameBoardPositions[3, 8] = new Soldier(PlayerSide.BLACK);

            // Red side.
            gameBoardPositions[9, 0] = new Rook(PlayerSide.RED);
            gameBoardPositions[9, 1] = new Knight(PlayerSide.RED);
            gameBoardPositions[9, 2] = new Elephant(PlayerSide.RED);
            gameBoardPositions[9, 3] = new Advisor(PlayerSide.RED);
            gameBoardPositions[9, 4] = redGeneral;
            gameBoardPositions[9, 5] = new Advisor(PlayerSide.RED);
            gameBoardPositions[9, 6] = new Elephant(PlayerSide.RED);
            gameBoardPositions[9, 7] = new Knight(PlayerSide.RED);
            gameBoardPositions[9, 8] = new Rook(PlayerSide.RED);

            gameBoardPositions[7, 1] = new Cannon(PlayerSide.RED);
            gameBoardPositions[7, 7] = new Cannon(PlayerSide.RED);

            gameBoardPositions[6, 0] = new Soldier(PlayerSide.RED);
            gameBoardPositions[6, 2] = new Soldier(PlayerSide.RED);
            gameBoardPositions[6, 4] = new Soldier(PlayerSide.RED);
            gameBoardPositions[6, 6] = new Soldier(PlayerSide.RED);
            gameBoardPositions[6, 8] = new Soldier(PlayerSide.RED);
            
            // Fill null cells with empty pawns.
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (gameBoardPositions[row, col] == null)
                    {
                        gameBoardPositions[row, col] = new EmptyPawn();
                    }
                }
            }
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            if (gameState == GameState.PLAYING)
            {
                if (e.Button == MouseButtons.Left)
                {
                    LeftMouseClicked(e);
                }

                if (e.Button == MouseButtons.Right)
                {
                    RightMouseClicked();
                }
            }          
        }

        private void LeftMouseClicked(MouseEventArgs e)
        {          
            if (!selectedPawn.IsEmpty) // Pawn already selected. Check if pawn can be moved.
            {
                bool pawnFound = false;

                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        // Check which cell is clicked by user and if the cell has an empty pawn or a pawn of the opposite player.
                        if (gameBoardPositions[col, row].GetRec().Contains(e.Location) && (gameBoardPositions[col, row].GetPlayerSide() == previousPlayer || gameBoardPositions[col, row].GetPlayerSide() == PlayerSide.EMPTY))
                        {
                            // Check if the selected cell is the same pawn that the user wants to move.
                            if(col == selectedCol && row == selectedRow)
                            {
                                pawnFound = true;
                                break;
                            }
                            else
                            {
                                //Let the pawn check if it is allowed to move to the new location.
                                if (gameBoardPositions[selectedCol, selectedRow].CheckMovement(selectedCol, selectedRow, col, row, gameBoardPositions))
                                {
                                    // Get true back if pawn can move to selected cell.
                                    previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                    IPawn tempPawnStart = gameBoardPositions[selectedCol, selectedRow];
                                    IPawn tempPawnEnd = gameBoardPositions[col, row];

                                    if (gameBoardPositions[selectedCol, selectedRow].Equals(blackGeneral))
                                    {
                                        gameBoardPositions[col, row] = gameBoardPositions[selectedCol, selectedRow].Duplicate();
                                        blackGeneral = gameBoardPositions[col, row];
                                        colBlackGeneral = row;
                                        rowBlackGeneral = col;
                                        gameBoardPositions[selectedCol, selectedRow] = new EmptyPawn();

                                        // Check if generals do not face each other. If they face each other reset move.
                                        if (!CheckLineOfSightIsBlockedGenerals())
                                        {
                                            gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                            gameBoardPositions[col, row] = tempPawnEnd;

                                            blackGeneral = tempPawnStart;
                                            colBlackGeneral = selectedRow;
                                            rowBlackGeneral = selectedCol;

                                            previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                            pawnFound = true;
                                            break;
                                        }

                                        if (GeneralIsChecked(blackGeneral))
                                        {
                                            gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                            gameBoardPositions[col, row] = tempPawnEnd;

                                            blackGeneral = tempPawnStart;
                                            colBlackGeneral = selectedRow;
                                            rowBlackGeneral = selectedCol;

                                            previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                            pawnFound = true;
                                            break;
                                        }
                                        else
                                        {
                                            threateningPawn = null;
                                            rowThreateningPawn = -1;
                                            colThreateningPawn = -1;

                                            blackGeneralChecked = false;
                                        }
                                    }
                                    else if (gameBoardPositions[selectedCol, selectedRow].Equals(redGeneral))
                                    {
                                        gameBoardPositions[col, row] = gameBoardPositions[selectedCol, selectedRow].Duplicate();
                                        redGeneral = gameBoardPositions[col, row];
                                        colRedGeneral = row;
                                        rowRedGeneral = col;
                                        gameBoardPositions[selectedCol, selectedRow] = new EmptyPawn();

                                        // Check if generals do not face each other. If they face each other reset move.
                                        if (!CheckLineOfSightIsBlockedGenerals())
                                        {
                                            gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                            gameBoardPositions[col, row] = tempPawnEnd;

                                            redGeneral = tempPawnStart;
                                            colRedGeneral = selectedRow;
                                            rowRedGeneral = selectedCol;

                                            previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                            pawnFound = true;
                                            break;
                                        }

                                        if (GeneralIsChecked(redGeneral))
                                        {
                                            gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                            gameBoardPositions[col, row] = tempPawnEnd;

                                            redGeneral = tempPawnStart;
                                            colRedGeneral = selectedRow;
                                            rowRedGeneral = selectedCol;

                                            previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                            pawnFound = true;
                                            break;
                                        }
                                        else
                                        {
                                            threateningPawn = null;
                                            rowThreateningPawn = -1;
                                            colThreateningPawn = -1;

                                            redGeneralChecked = false;
                                        }
                                    }
                                    else
                                    {
                                        gameBoardPositions[col, row] = gameBoardPositions[selectedCol, selectedRow].Duplicate();
                                        gameBoardPositions[selectedCol, selectedRow] = new EmptyPawn();

                                        // Check if generals do not face each other. If they face each other reset move.
                                        if (!CheckLineOfSightIsBlockedGenerals())
                                        {
                                            gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                            gameBoardPositions[col, row] = tempPawnEnd;

                                            previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                            pawnFound = true;
                                            break;
                                        }

                                        if (previousPlayer == PlayerSide.BLACK)
                                        {
                                            if (GeneralIsChecked(blackGeneral))
                                            {
                                                gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                                gameBoardPositions[col, row] = tempPawnEnd;

                                                previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                                pawnFound = true;
                                                break;
                                            }
                                            else
                                            {
                                                blackGeneralChecked = false;
                                            }

                                            // Check if by moving this black pawn, it threatens the red general.
                                            if(GeneralIsChecked(redGeneral))
                                            {
                                                threateningPawn = gameBoardPositions[col, row];
                                                rowThreateningPawn = col;
                                                colThreateningPawn = row;
                                            }
                                            else
                                            {
                                                threateningPawn = null;
                                                rowThreateningPawn = -1;
                                                colThreateningPawn = -1;
                                            }
                                        }

                                        if (previousPlayer == PlayerSide.RED)
                                        {
                                            if (GeneralIsChecked(redGeneral))
                                            {
                                                gameBoardPositions[selectedCol, selectedRow] = tempPawnStart;
                                                gameBoardPositions[col, row] = tempPawnEnd;

                                                previousPlayer = previousPlayer == PlayerSide.RED ? PlayerSide.BLACK : PlayerSide.RED;
                                                pawnFound = true;
                                                break;
                                            }
                                            else
                                            {
                                                redGeneralChecked = false;
                                            }

                                            // Check if by moving this red pawn, it threatens the black general.
                                            if (GeneralIsChecked(blackGeneral))
                                            {
                                                threateningPawn = gameBoardPositions[col, row];
                                                rowThreateningPawn = col;
                                                colThreateningPawn = row;
                                            }
                                            else
                                            {
                                                threateningPawn = null;
                                                rowThreateningPawn = -1;
                                                colThreateningPawn = -1;
                                            }
                                        }
                                    }

                                    // Deselects current pawn so that the next player can select a pawn.
                                    selectedPawn = Rectangle.Empty;
                                    selectedCol = -1;
                                    selectedRow = -1;
                                    selectedPawnPossibleMovements = null;

                                    pawnFound = true;
                                    break;

                                }
                                else
                                {
                                    // Pawn is not allowed to move to the new location. Current pawn is still selected.
                                    pawnFound = true;
                                    break;
                                }                        
                            }
                        }
                    }

                    if (pawnFound)
                    {
                        break;
                    }
                }
            }
            else if (selectedPawn.IsEmpty) // No pawn selected, check if pawn can be selected.
            {
                bool pawnFound = false;

                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (gameBoardPositions[row, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, col].GetPlayerSide() != previousPlayer && gameBoardPositions[row, col].GetRec().Contains(e.Location))
                        {
                            pawnFound = true;
                            selectedPawn = gameBoardPositions[row, col].GetRec();
                            selectedCol = row;
                            selectedRow = col;
                            selectedPawnPossibleMovements = gameBoardPositions[row, col].GetPossibleMovements(row, col, gameBoardPositions);

                            break;
                        }
                    }

                    if (pawnFound)
                    {
                        break;
                    }
                }
            } 
        }

        private bool GeneralIsChecked(IPawn General)
        {
            PlayerSide player = General.GetPlayerSide();
            int rowGeneral = player == PlayerSide.BLACK ? rowBlackGeneral : rowRedGeneral;
            int colGeneral = player == PlayerSide.BLACK ? colBlackGeneral : colRedGeneral;

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (gameBoardPositions[row, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, col].GetPlayerSide() != player)
                    {
                        if (gameBoardPositions[row, col].CheckMovement(row, col, rowGeneral, colGeneral, gameBoardPositions))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool GeneralIsCheckMated(IPawn General)
        {
            PlayerSide player = General.GetPlayerSide();
            int rowGeneral = player == PlayerSide.BLACK ? rowBlackGeneral : rowRedGeneral;
            int colGeneral = player == PlayerSide.BLACK ? colBlackGeneral : colRedGeneral;

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (gameBoardPositions[row, col].GetPlayerSide() != PlayerSide.EMPTY && gameBoardPositions[row, col].GetPlayerSide() == player)
                    {
                        if (gameBoardPositions[row, col].CheckMovement(row, col, rowThreateningPawn, colThreateningPawn, gameBoardPositions))
                        {
                            return false;
                        }
                    }
                }
            }

            IPawn tempPawnStart;
            IPawn tempPawnEnd;
            bool generalCanEscape = false;

            // Move general up;
            if (General.CheckMovement(rowGeneral, colGeneral, (rowGeneral - 1), colGeneral, gameBoardPositions))
            {
                tempPawnStart = gameBoardPositions[rowGeneral, colGeneral];
                tempPawnEnd = gameBoardPositions[(rowGeneral - 1), colGeneral];

                gameBoardPositions[(rowGeneral - 1), colGeneral] = gameBoardPositions[rowGeneral, colGeneral].Duplicate();
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = gameBoardPositions[(rowGeneral - 1), colGeneral];
                    colBlackGeneral = colGeneral;
                    rowBlackGeneral = (rowGeneral - 1);
                }
                else
                {
                    redGeneral = gameBoardPositions[(rowGeneral - 1), colGeneral];
                    colRedGeneral = colGeneral;
                    rowRedGeneral = (rowGeneral - 1);
                }
           
                gameBoardPositions[rowGeneral, colGeneral] = new EmptyPawn();

                if (CheckLineOfSightIsBlockedGenerals() && !GeneralIsChecked(General))
                {
                    generalCanEscape = true;
                }

                gameBoardPositions[rowGeneral, colGeneral] = tempPawnStart;
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = tempPawnStart;
                    colBlackGeneral = colGeneral;
                    rowBlackGeneral = rowGeneral;
                }
                else
                {
                    redGeneral = tempPawnStart;
                    colRedGeneral = colGeneral;
                    rowRedGeneral = rowGeneral;
                }

                gameBoardPositions[(rowGeneral - 1), colGeneral] = tempPawnEnd;
            }

            // Move general down;
            if (General.CheckMovement(rowGeneral, colGeneral, (rowGeneral + 1), colGeneral, gameBoardPositions))
            {
                tempPawnStart = gameBoardPositions[rowGeneral, colGeneral];
                tempPawnEnd = gameBoardPositions[(rowGeneral + 1), colGeneral];

                gameBoardPositions[(rowGeneral + 1), colGeneral] = gameBoardPositions[rowGeneral, colGeneral].Duplicate();
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = gameBoardPositions[(rowGeneral + 1), colGeneral];
                    colBlackGeneral = colGeneral;
                    rowBlackGeneral = (rowGeneral + 1);
                }
                else
                {
                    redGeneral = gameBoardPositions[(rowGeneral + 1), colGeneral];
                    colRedGeneral = colGeneral;
                    rowRedGeneral = (rowGeneral + 1);
                }

                gameBoardPositions[rowGeneral, colGeneral] = new EmptyPawn();

                if (CheckLineOfSightIsBlockedGenerals() && !GeneralIsChecked(General))
                {
                    generalCanEscape = true;
                }

                gameBoardPositions[rowGeneral, colGeneral] = tempPawnStart;
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = tempPawnStart;
                    colBlackGeneral = colGeneral;
                    rowBlackGeneral = rowGeneral;
                }
                else
                {
                    redGeneral = tempPawnStart;
                    colRedGeneral = colGeneral;
                    rowRedGeneral = rowGeneral;
                }

                gameBoardPositions[(rowGeneral + 1), colGeneral] = tempPawnEnd;
            }

            // Move general right;
            if (General.CheckMovement(rowGeneral, colGeneral, rowGeneral, (colGeneral + 1), gameBoardPositions))
            {
                tempPawnStart = gameBoardPositions[rowGeneral, colGeneral];
                tempPawnEnd = gameBoardPositions[rowGeneral, (colGeneral + 1)];

                gameBoardPositions[rowGeneral, (colGeneral + 1)] = gameBoardPositions[rowGeneral, colGeneral].Duplicate();
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = gameBoardPositions[rowGeneral, (colGeneral + 1)];
                    colBlackGeneral = (colGeneral + 1);
                    rowBlackGeneral = rowGeneral;
                }
                else
                {
                    redGeneral = gameBoardPositions[rowGeneral, (colGeneral + 1)];
                    colRedGeneral = (colGeneral + 1);
                    rowRedGeneral = rowGeneral;
                }

                gameBoardPositions[rowGeneral, colGeneral] = new EmptyPawn();

                if (CheckLineOfSightIsBlockedGenerals() && !GeneralIsChecked(General))
                {
                    generalCanEscape = true;
                }

                gameBoardPositions[rowGeneral, colGeneral] = tempPawnStart;
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = tempPawnStart;
                    colBlackGeneral = colGeneral;
                    rowBlackGeneral = rowGeneral;
                }
                else
                {
                    redGeneral = tempPawnStart;
                    colRedGeneral = colGeneral;
                    rowRedGeneral = rowGeneral;
                }

                gameBoardPositions[rowGeneral, (colGeneral + 1)] = tempPawnEnd;
            }

            // Move general left;
            if (General.CheckMovement(rowGeneral, colGeneral, rowGeneral, (colGeneral - 1), gameBoardPositions))
            {
                tempPawnStart = gameBoardPositions[rowGeneral, colGeneral];
                tempPawnEnd = gameBoardPositions[rowGeneral, (colGeneral - 1)];

                gameBoardPositions[rowGeneral, (colGeneral - 1)] = gameBoardPositions[rowGeneral, colGeneral].Duplicate();
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = gameBoardPositions[rowGeneral, (colGeneral - 1)];
                    colBlackGeneral = (colGeneral - 1);
                    rowBlackGeneral = rowGeneral;
                }
                else
                {
                    redGeneral = gameBoardPositions[rowGeneral, (colGeneral - 1)];
                    colRedGeneral = (colGeneral - 1);
                    rowRedGeneral = rowGeneral;
                }

                gameBoardPositions[rowGeneral, colGeneral] = new EmptyPawn();

                if (CheckLineOfSightIsBlockedGenerals() && !GeneralIsChecked(General))
                {
                    generalCanEscape = true;
                }

                gameBoardPositions[rowGeneral, colGeneral] = tempPawnStart;
                if (player == PlayerSide.BLACK)
                {
                    blackGeneral = tempPawnStart;
                    colBlackGeneral = colGeneral;
                    rowBlackGeneral = rowGeneral;
                }
                else
                {
                    redGeneral = tempPawnStart;
                    colRedGeneral = colGeneral;
                    rowRedGeneral = rowGeneral;
                }

                gameBoardPositions[rowGeneral, (colGeneral - 1)] = tempPawnEnd;
            }

            if (generalCanEscape)
            {
                return false;
            }

            return true;
        }

        private bool CheckLineOfSightIsBlockedGenerals()
        {
            if(colBlackGeneral == colRedGeneral)
            {
                bool pawnPassed = false;
                for(int row = rowBlackGeneral + 1; row < rowRedGeneral; row++)
                {
                    if(gameBoardPositions[row, colBlackGeneral].GetPlayerSide() != PlayerSide.EMPTY)
                    {
                        pawnPassed = true;
                        break;
                    }
                }

                if(pawnPassed)
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        private void RightMouseClicked()
        {
            selectedPawn = Rectangle.Empty;
            selectedCol = -1;
            selectedRow = -1;
            selectedPawnPossibleMovements = null;
        }

        public void NewGame()
        {
            ResetBoard();
            selectedPawn = Rectangle.Empty;
            selectedCol = -1;
            selectedRow = -1;
            previousPlayer = PlayerSide.BLACK;
        }

        public void ChangePawnType(int i)
        {
            imageType = i;
        }
    }
}
