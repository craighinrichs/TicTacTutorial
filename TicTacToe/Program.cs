using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
	class MainClass {

		public static void Main(string[] args) {

			string[] rows = new string[6] { "A", "B", "C", "1", "2", "3" };

			Dictionary<string, string> boards = new Dictionary<string, string>();

			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					boards.Add(rows[i] + rows[(j + 3)], " ");
				}
			}


			string playerTurn = "O";
			string winMessage = "";

			bool gameOver = false;

			while (!gameOver) {
				Console.Clear();

				Console.WriteLine(" --- TicTacToe ---");
				Console.WriteLine("   1   2   3  ");
				Console.WriteLine("A  {0} | {1} | {2} ", boards["A1"], boards["A2"], boards["A3"]);
				Console.WriteLine("  -----------");
				Console.WriteLine("B  {0} | {1} | {2} ", boards["B1"], boards["B2"], boards["B3"]);
				Console.WriteLine("  -----------");
				Console.WriteLine("C  {0} | {1} | {2} ", boards["C1"], boards["C2"], boards["C3"]);


				if (winMessage.Length > 0) {
					Console.WriteLine(winMessage);
					gameOver = true;
					continue;
				}

				bool emptySpotFound = false;
				foreach (string item in boards.Keys) {
					if (string.IsNullOrWhiteSpace(boards[item])) {
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

				bool spotTakenError = false;

				if (boards.ContainsKey(upperCase)) {
					if (boards[upperCase] == " ") {
						boards[upperCase] = playerTurn;
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

				bool playerWon = false;
				foreach (string letter in rows) {
					if (boards.Where(d => d.Key.Contains(letter) && d.Value.Equals(playerTurn)).Count() == 3) {
						playerWon = true;
					}
				}

				// Check the win state. 
				bool leftRightWin = boards["A1"] == playerTurn && boards["B2"] == playerTurn && boards["C3"] == playerTurn;
				bool rightLeftWin = boards["A3"] == playerTurn && boards["B2"] == playerTurn && boards["C1"] == playerTurn;

				if (playerWon || leftRightWin || rightLeftWin) {
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
