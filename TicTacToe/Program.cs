using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {


	class MainClass {

		public static void Main(string[] args) {

			string[] rows = new string[6] { "A", "B", "C", "1", "2", "3" };

			string playerTurn = "O";
			string winMessage = "";

			Dictionary<string, string> board = new Dictionary<string, string>();
			foreach (int index in Enumerable.Range(0, 3)) {
				foreach (int j in Enumerable.Range(0, 3)) {
					board.Add(rows[index] + rows[(j + 3)], " ");
				}
			}

			bool gameOver = false;

			while (!gameOver) {
				Console.Clear();

				Console.WriteLine(" --- TicTacToe ---");
				Console.WriteLine("   1   2   3  ");
				Console.WriteLine("A  {0} | {1} | {2} ", board["A1"], board["A2"], board["A3"]);
				Console.WriteLine("  -----------");
				Console.WriteLine("B  {0} | {1} | {2} ", board["B1"], board["B2"], board["B3"]);
				Console.WriteLine("  -----------");
				Console.WriteLine("C  {0} | {1} | {2} ", board["C1"], board["C2"], board["C3"]);

				if (winMessage.Length > 0) {
					Console.WriteLine(winMessage);
					gameOver = true;
					continue;
				}

				bool emptySpotFound = false;
				foreach (var entry in board.Values) {
					if (string.IsNullOrWhiteSpace(entry)) {
						emptySpotFound = true;
						break;
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

				if (board.ContainsKey(upperCase)) {
					board[upperCase] = playerTurn;
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
				bool playerWon = false;
				foreach (string letter in rows) {
					if (board.Where(l => l.Key.Contains(letter) && l.Value.Equals(playerTurn)).Count() == 3) {
						playerWon = true;
					}
				}

				bool leftRightWin = board["A1"] == playerTurn && board["B2"] == playerTurn && board["C3"] == playerTurn;
				bool rightLeftWin = board["A3"] == playerTurn && board["B2"] == playerTurn && board["C1"] == playerTurn;

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
