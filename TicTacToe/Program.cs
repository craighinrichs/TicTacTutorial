using System;

namespace TicTacToe {


	class MainClass {

		public static void Main(string[] args) {

			string[] boards = new string[9];
			for (int i = 0; i < 9; i++) {
				boards[i] = " ";
			}


			string playerTurn = "O";
			string winMessage = "";

			bool gameOver = false;

			while (!gameOver) {
				Console.Clear();

				Console.WriteLine(" --- TicTacToe ---");
				Console.WriteLine("   1   2   3  ");
				Console.WriteLine("A  {0} | {1} | {2} ", boards[0], boards[1], boards[2]);
				Console.WriteLine("  -----------");
				Console.WriteLine("B  {0} | {1} | {2} ", boards[3], boards[4], boards[5]);
				Console.WriteLine("  -----------");
				Console.WriteLine("C  {0} | {1} | {2} ", boards[6], boards[7], boards[8]);

				if (winMessage.Length > 0) {
					Console.WriteLine(winMessage);
					gameOver = true;
					continue;
				}

				bool emptySpotFound = false;
				for (int i = 0; i < 9; i++) {
					if (string.IsNullOrWhiteSpace(boards[i])) {
						emptySpotFound = true;
					}
				}

				if (emptySpotFound == false) {
					Console.WriteLine("It's a DRAW!");
					gameOver = true;
					continue;
				}

				playerTurn = SwitchPlayers(playerTurn);

				Console.WriteLine("Player {0}: It's your turn.", playerTurn);
				Console.WriteLine("Please enter a LETTER then a NUMBER: Example A2 ");
				Console.Write("-->:");
				string answer = Console.ReadLine();

				string upperCase = answer.ToUpper();

				char[] charArray = upperCase.ToCharArray(0, 2);


				bool spotTakenError = false;

				if (charArray[0] == 'A') {
					if (charArray[1] == '1') {
						boards[0] = playerTurn;
					} else if (charArray[1] == '2') {
						boards[1] = playerTurn;
					} else if (charArray[1] == '3') {
						boards[2] = playerTurn;
					} else {
						spotTakenError = true;
					}
				} else if (charArray[0] == 'B') {
					if (charArray[1] == '1') {
						boards[3] = playerTurn;
					} else if (charArray[1] == '2') {
						boards[4] = playerTurn;
					} else if (charArray[1] == '3') {
						boards[5] = playerTurn;
					} else {
						spotTakenError = true;
					}
				} else if (charArray[0] == 'C') {
					if (charArray[1] == '1') {
						boards[6] = playerTurn;
					} else if (charArray[1] == '2') {
						boards[7] = playerTurn;
					} else if (charArray[1] == '3') {
						boards[8] = playerTurn;
					} else {
						spotTakenError = true;
					}
				} else {
					spotTakenError = true;
				}

				if (spotTakenError == true) {
					Console.Clear();
					Console.WriteLine("You entered {0} as an invalid input. please try again.\n", answer);
					playerTurn = SwitchPlayers(playerTurn);
					Console.WriteLine("Press Any Key to Continue:");
					Console.ReadLine();
				}

				// Check the win state. 
				bool topRowWin = boards[0] == playerTurn && boards[1] == playerTurn && boards[2] == playerTurn;
				bool midRowWin = boards[3] == playerTurn && boards[4] == playerTurn && boards[5] == playerTurn;
				bool botpRowWin = boards[6] == playerTurn && boards[7] == playerTurn && boards[8] == playerTurn;
				bool colOneWin = boards[0] == playerTurn && boards[3] == playerTurn && boards[6] == playerTurn;
				bool colTwoWin = boards[1] == playerTurn && boards[4] == playerTurn && boards[7] == playerTurn;
				bool colThreeWin = boards[2] == playerTurn && boards[5] == playerTurn && boards[8] == playerTurn;
				bool leftRightWin = boards[0] == playerTurn && boards[4] == playerTurn && boards[8] == playerTurn;
				bool rightLeftWin = boards[2] == playerTurn && boards[4] == playerTurn && boards[6] == playerTurn;

				if (topRowWin || midRowWin || botpRowWin || colOneWin || colTwoWin || colThreeWin || leftRightWin || rightLeftWin) {
					winMessage = string.Format("{0} wins!", playerTurn);
				}
			}

			Console.WriteLine("Thanks for playing!");
		}

		private static string SwitchPlayers(string playerTurn) {
			if (playerTurn.Equals("X")) {
				playerTurn = "O";
			} else if (playerTurn.Equals("O")) {
				playerTurn = "X";
			}

			return playerTurn;
		}
	}

}
