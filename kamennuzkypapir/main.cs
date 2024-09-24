using kamennuzkypapir;
using static kamennuzkypapir.GameManager;
GameManager gm = new GameManager();
        
        do
        {
            RoundResult result = gm.PlayRound();
            if(result == RoundResult.Player1Win){
                System.Console.WriteLine("Player 1 Wins!");
            }
            else if(result == RoundResult.Player2Win){
                System.Console.WriteLine("Player 2 Wins!");
            }
            else{
                System.Console.WriteLine("It's a draw!");
            }

            System.Console.WriteLine("Play again? (Y/N)");

        } while (Console.ReadLine().ToUpper() == "Y");