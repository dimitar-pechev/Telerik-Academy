using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class TicTacToe : Page
    {
        private static int[,] board;
        private static bool isFinished;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                board = new int[3, 3];
                isFinished = false;
            }
        }

        protected void PlayAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicTacToe.aspx");
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            if (isFinished)
            {
                return;
            }

            switch (e.CommandName)
            {
                case "CellAt1":
                    if (IsCellEmpty(this.CellAt1))
                    {
                        board[0, 0] = 1;
                    }

                    MarkWithCross(this.CellAt1);
                    break;
                case "CellAt2":
                    if (IsCellEmpty(this.CellAt2))
                    {
                        board[0, 1] = 1;
                    }

                    MarkWithCross(this.CellAt2);
                    break;
                case "CellAt3":
                    if (IsCellEmpty(this.CellAt3))
                    {
                        board[0, 2] = 1;
                    }

                    MarkWithCross(this.CellAt3);
                    break;
                case "CellAt4":
                    if (IsCellEmpty(this.CellAt4))
                    {
                        board[1, 0] = 1;
                    }

                    MarkWithCross(this.CellAt4);
                    break;
                case "CellAt5":
                    if (IsCellEmpty(this.CellAt5))
                    {
                        board[1, 1] = 1;
                    }

                    MarkWithCross(this.CellAt5);
                    break;
                case "CellAt6":
                    if (IsCellEmpty(this.CellAt6))
                    {
                        board[1, 2] = 1;
                    }

                    MarkWithCross(this.CellAt6);
                    break;
                case "CellAt7":
                    if (IsCellEmpty(this.CellAt7))
                    {
                        board[2, 0] = 1;
                    }

                    MarkWithCross(this.CellAt7);
                    break;
                case "CellAt8":
                    if (IsCellEmpty(this.CellAt8))
                    {
                        board[2, 1] = 1;
                    }

                    MarkWithCross(this.CellAt8);
                    break;
                case "CellAt9":
                    if (IsCellEmpty(this.CellAt9))
                    {
                        board[2, 2] = 1;
                    }

                    MarkWithCross(this.CellAt9);
                    break;
                default:
                    break;
            }

            var player = 1;
            if (PlayerWins(player))
            {
                isFinished = true;
            }

            if (isFinished)
            {
                this.ExitMessage.InnerHtml = "You win!";
                this.ExitPanel.Visible = true;
                return;
            }

            ComputerMove();

            var computer = 2;
            if (PlayerWins(computer))
            {
                isFinished = true;
            }

            if (isFinished)
            {
                this.ExitMessage.InnerHtml = "The computer destroyed you!";
                this.ExitPanel.Visible = true;
                return;
            }

            if (IsDraw())
            {
                this.ExitMessage.InnerHtml = "Draw!";
                this.ExitPanel.Visible = true;
            }
        }

        private void ComputerMove()
        {
            var computer = 2;
            var computerWinningMove = HasWinningMove(computer);
            if (!string.IsNullOrEmpty(computerWinningMove))
            {
                if (computerWinningMove.IndexOf("row") >= 0)
                {
                    var row = int.Parse(computerWinningMove[computerWinningMove.Length - 1].ToString());
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            board[row, col] = 2;
                            MarkWithCircle(row, col);
                            return;
                        }
                    }
                }
                else if (computerWinningMove.IndexOf("col") >= 0)
                {
                    var col = int.Parse(computerWinningMove[computerWinningMove.Length - 1].ToString());
                    for (int row = 0; row < 3; row++)
                    {
                        if (board[row, col] == 0)
                        {
                            board[row, col] = 2;
                            MarkWithCircle(row, col);
                            return;
                        }
                    }
                }
            }

            var player = 1;
            var playerHasWinningMove = HasWinningMove(player);
            if (!string.IsNullOrEmpty(playerHasWinningMove))
            {
                if (playerHasWinningMove.IndexOf("row") >= 0)
                {
                    var row = int.Parse(playerHasWinningMove[playerHasWinningMove.Length - 1].ToString());
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            board[row, col] = 2;
                            MarkWithCircle(row, col);
                            return;
                        }
                    }
                }
                else if (playerHasWinningMove.IndexOf("col") >= 0)
                {
                    var col = int.Parse(playerHasWinningMove[playerHasWinningMove.Length - 1].ToString());
                    for (int row = 0; row < 3; row++)
                    {
                        if (board[row, col] == 0)
                        {
                            board[row, col] = 2;
                            MarkWithCircle(row, col);
                            return;
                        }
                    }
                }
            }

            if (board[1, 1] == 0)
            {
                board[1, 1] = 2;
                MarkWithCircle(1, 1);
                return;
            }
            else if (board[0, 0] == 0)
            {
                board[0, 0] = 2;
                MarkWithCircle(0, 0);
                return;
            }
            else if (board[0, 2] == 0)
            {
                board[0, 2] = 2;
                MarkWithCircle(0, 2);
                return;
            }
            else if (board[2, 0] == 0)
            {
                board[2, 0] = 2;
                MarkWithCircle(2, 0);
                return;
            }
            else if (board[2, 2] == 0)
            {
                board[2, 2] = 2;
                MarkWithCircle(2, 2);
                return;
            }
            else
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            board[row, col] = 2;
                            MarkWithCircle(row, col);
                            return;
                        }                        
                    }
                }
            }
        }

        // 0 -> empty field, 1 -> player(o anthropos), 2 -> computer
        private bool PlayerWins(int player)
        {
            if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player)
            {
                return true;
            }
            else if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player)
            {
                return true;
            }
            else if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            else if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player)
            {
                return true;
            }
            else if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player)
            {
                return true;
            }
            else if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player)
            {
                return true;
            }
            else if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            else if (board[2, 0] == player && board[1, 1] == player && board[0, 2] == player)
            {
                return true;
            }

            return false;
        }

        private bool IsDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string HasWinningMove(int player)
        {
            var counter = 0;
            // rows check
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == player)
                    {
                        counter++;
                    }
                    if (board[row, col] != player && board[row, col] != 0)
                    {
                        counter--;
                    }
                }

                if (counter == 2)
                {
                    return $"row {row}";
                }

                counter = 0;
            }

            // winning move in cols
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (board[row, col] == player)
                    {
                        counter++;
                    }
                    if (board[row, col] != player && board[row, col] != 0)
                    {
                        counter--;
                    }
                }

                if (counter == 2)
                {
                    return $"col {col}";
                }

                counter = 0;
            }

            // winning move in diagonal from left
            if (board[0, 0] == player)
            {
                counter++;
            }

            if (board[1, 1] == player)
            {
                counter++;
            }

            if (board[2, 2] == player)
            {
                counter++;
            }

            if (board[0, 0] != player && board[0, 0] != 0)
            {
                counter--;
            }

            if (board[1, 1] != player && board[1, 1] != 0)
            {
                counter--;
            }

            if (board[2, 2] != player && board[2, 2] != 0)
            {
                counter--;
            }

            if (counter == 2)
            {
                return "diagonal left";
            }

            counter = 0;

            //winning move in diagonal from right
            if (board[0, 2] == player)
            {
                counter++;
            }

            if (board[1, 1] == player)
            {
                counter++;
            }

            if (board[2, 0] == player)
            {
                counter++;
            }

            if (board[0, 2] != player && board[0, 2] != 0)
            {
                counter--;
            }

            if (board[1, 1] != player && board[1, 1] != 0)
            {
                counter--;
            }

            if (board[2, 0] != player && board[2, 0] != 0)
            {
                counter--;
            }

            if (counter == 2)
            {
                return "diagonal right";
            }

            return null;
        }

        private void MarkWithCircle(int row, int col)
        {
            switch (row)
            {
                case 0:
                    if (col == 0)
                    {
                        this.CellAt1.Enabled = false;
                        this.CellAt1.ImageUrl = "../Images/circle.png";
                    }
                    else if (col == 1)
                    {
                        this.CellAt2.Enabled = false;
                        this.CellAt2.ImageUrl = "../Images/circle.png";
                    }
                    else if (col == 2)
                    {
                        this.CellAt3.Enabled = false;
                        this.CellAt3.ImageUrl = "../Images/circle.png";
                    }
                    break;
                case 1:
                    if (col == 0)
                    {
                        this.CellAt4.Enabled = false;
                        this.CellAt4.ImageUrl = "../Images/circle.png";
                    }
                    else if (col == 1)
                    {
                        this.CellAt5.Enabled = false;
                        this.CellAt5.ImageUrl = "../Images/circle.png";
                    }
                    else if (col == 2)
                    {
                        this.CellAt6.Enabled = false;
                        this.CellAt6.ImageUrl = "../Images/circle.png";
                    }
                    break;
                case 2:
                    if (col == 0)
                    {
                        this.CellAt7.Enabled = false;
                        this.CellAt7.ImageUrl = "../Images/circle.png";
                    }
                    else if (col == 1)
                    {
                        this.CellAt8.Enabled = false;
                        this.CellAt8.ImageUrl = "../Images/circle.png";
                    }
                    else if (col == 2)
                    {
                        this.CellAt9.Enabled = false;
                        this.CellAt9.ImageUrl = "../Images/circle.png";
                    }
                    break;
                default:
                    break;
            }
        }

        private bool IsCellEmpty(ImageButton CellAt)
        {
            return CellAt.ImageUrl == "../Images/tranBg.png";
        }

        private void MarkWithCross(ImageButton CellAt)
        {
            if (CellAt.ImageUrl == "../Images/tranBg.png")
            {
                CellAt.Enabled = false;
                CellAt.ImageUrl = "../Images/cross.png";
            }
        }
    }
}