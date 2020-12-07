using System;


namespace newtik
{
    class Program
    {
        static void Main(string[] args)
        {
            char userinput;
            
           
            
            do 
            {
                
                int gameStatus = 0;
                int presentPlayer = -1;
                char [] gameMarker = {'1' , '2' , '3' , '4' , '5' , '6' , '7' , '8' , '9'};//array to make board dynamic

            
            
            do 
            {
                Console.Clear();//to clear the screen
                presentPlayer = Nextplayer(presentPlayer); //Asigns the turn to the player
                startingDisplay(presentPlayer);
                
                Drawboard(gameMarker);//calling the draw board method

                gameeng(gameMarker, presentPlayer);

                gameStatus = checkWiner(gameMarker);
                

            } while(gameStatus.Equals(0));


            if (gameStatus.Equals(1))
            {
                Console.Clear();
                startingDisplay(presentPlayer);
                Drawboard(gameMarker);
                Console.WriteLine($"Player{presentPlayer} is the Winner!! ");
            }
            if (gameStatus.Equals(2))
            {
                Console.Clear();
                startingDisplay(presentPlayer);
                Drawboard(gameMarker);
                Console.WriteLine("The game is draw !!");
            }
            
             userinput = promptForYorN();
            
            
        }while(userinput == 'y' );
            

        }
        private static char promptForYorN()
        {
            Console.WriteLine("Do you want to play again? y/n: ");
            string userinput = Console.ReadLine();
            if(userinput == "y")
            {
                return 'y';

            }
            else
            {
                return 'n';
            }
            
            
            
        }
        private static int checkWiner(char [] gameMarker)
        {
            if (isGameDraw(gameMarker))
            {
                return 2;
            }
            if (isGameWiner(gameMarker))
            {
                return 1;
            }
            return 0;
        }
        private static bool isGameDraw(char[] gameMarker)
        {
            //Here we are cheking the draw conditions
            return gameMarker[0] != '1' &&
                   gameMarker[1] != '2' &&
                   gameMarker[2] != '3' &&
                   gameMarker[3] != '4' &&
                   gameMarker[4] != '5' &&
                   gameMarker[5] != '6' &&
                   gameMarker[6] != '7' &&
                   gameMarker[7] != '8' &&
                   gameMarker[8] != '9';
        }
        private static bool isGameWiner(char[] gameMarker)
        { 
            //Here we are checking the evry winning possibilty
            if (isgaMemarkSame(gameMarker , 0 , 1 , 2)) //checking for first row winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 3 , 4 , 5)) //checking for second row winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 6 , 7 , 8)) //checking for third row winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 0 , 3 , 6)) //checking for first column winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 1 , 4 , 7)) //checking for second colmn winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 2 , 5 , 8)) // checking for third column winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 0 , 4 , 8)) //checking for diagonal line winner
            {
                return true;
            }
            if (isgaMemarkSame(gameMarker , 2 , 4 , 6)) // checking for diagonal line winner
            {
                return true;
            }
            return false;

        }
        //Checking the spots if it has same values 
        private static bool isgaMemarkSame(char [] testGameMark, int pos1, int pos2, int pos3)
        {
            return testGameMark[pos1].Equals(testGameMark[pos2]) && testGameMark[pos2].Equals(testGameMark[pos3]);
        }
        
        private static void gameeng(char [] gameMarker , int presentPlayer)
        {
            bool notValid = true;
            do
            {
             // update the board after user input and notify whose turn is this
             string userIn = Console.ReadLine();
             if(!string.IsNullOrEmpty(userIn) &&
                (userIn.Equals("1") ||
                userIn.Equals("2") ||
                userIn.Equals("3") ||
                userIn.Equals("4") ||
                userIn.Equals("5") ||
                userIn.Equals("6") ||
                userIn.Equals("7") ||
                userIn.Equals("8") ||
                userIn.Equals("9")))
              {
                  Console.Clear();
                  int.TryParse( userIn , out var gamePlacem);

                  char currentMark = gameMarker[gamePlacem - 1];

                  if (currentMark.Equals('X') || currentMark.Equals('O'))
                  {
                      Drawboard(gameMarker);
                      //Here we are not leting the user to put same value
                       Console.WriteLine("Please enter different value this spot is taken: ");
                         
                  }
                  else
                  {
                      gameMarker[gamePlacem - 1] = getPLayerMarker(presentPlayer);
                      notValid = false;
                  }
              }
              else 
              {
                  Console.WriteLine("Not valid value please pick from 1-9:");
              }
            } while(notValid);   

             

             

             
             
        }
        private static char getPLayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';

        }
         static void startingDisplay(int player)
        {
            //.Provide instruction
            //.Greetings
            Console.WriteLine("Welcome to the tic tac toe game");
            //Display player sign Player1 is x: Player2 is o
            Console.WriteLine("Player1: X");
            Console.WriteLine("Player2: Y");
            Console.WriteLine();


            //Instruct the user to enter the number between 1 and 9
            Console.WriteLine($"Player: {player} to move , please pick from 1 to 9" );
            Console.WriteLine();
        }
        static void Drawboard(char[] gameMarker)
        {


            //Draw the board
            Console.WriteLine($" {gameMarker[0]}  |  {gameMarker[1]}  |  {gameMarker[2]} ");
            Console.WriteLine("____|_____|____");
            Console.WriteLine($" {gameMarker[3]}  |  {gameMarker[4]}  |  {gameMarker[5]} ");
            Console.WriteLine("____|_____|____");
            Console.WriteLine("    |     |    ");
            Console.WriteLine($" {gameMarker[6]}  |  {gameMarker[7]}  |  {gameMarker[8]} ");
           
    
        }
        static int Nextplayer( int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            
            return 1;
            
        }
    }
}