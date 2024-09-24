using System.Dynamic;
using System.Formats.Tar;
using System.Security.Cryptography;

namespace kamennuzkypapir;

    public class GameManager(){
        Random _rng = new Random();

        public RoundResult PlayRound(){
            Choice p1;
            do{
                Console.Write("Enter choice: (R)ock, (P)aper or (S)cissors");
                string input = Console.ReadLine().ToUpper();
                if (input == "R"){
                    p1 = Choice.Rock;
                    break;
                }
                else if (input == "P"){
                    p1 = Choice.Paper;
                    break;
                }
                else if (input == "S"){
                    p1 = Choice.Scissors;
                    break;
                }
                else{
                    System.Console.WriteLine("Invalid choice, try again.");
                }
            } while (true);
            Choice p2 = (Choice)_rng.Next(0,3);
            System.Console.WriteLine($"Player 2 picked {p2.ToString()}");

            if(p1 == p2){
                return RoundResult.Draw;
            }

            if (p1 == Choice.Rock && p2 == Choice.Scissors ||
                p1 == Choice.Paper && p2 == Choice.Rock ||
                p1 == Choice.Scissors && p2 == Choice.Paper)
                {
                    return RoundResult.Player1Win;
                }
            return RoundResult.Player2Win;
        }

        public enum Choice{
            Rock,
            Paper,
            Scissors
        }

        public enum RoundResult{
            Player1Win,
            Player2Win,
            Draw
        }
    }




