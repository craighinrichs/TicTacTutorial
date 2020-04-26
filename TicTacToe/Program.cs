using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {

	static class PlayerExtension {
		public static int Board(this MainClass.Players player) {
			return MainClass.storage[player];
		}
		public static void SetBoard(this MainClass.Players player, int addValue) {
			MainClass.storage[player] |= addValue;
		}
		public static string Name(this MainClass.Players player) {
			return player.ToString();
		}
		public static void Switch(this MainClass.Players player) {
			MainClass.playerTurn = (MainClass.Players)((((int)player) + 1) % Enum.GetNames(typeof(MainClass.Players)).Length);
		}
	}

	class MainClass {

		public static Dictionary<Players, int> storage = new Dictionary<Players, int>() {
			{Players.X,0 },
			{Players.O,0 }
		};
		public enum Players {
			X,
			O
		}

		public static string Owner(int location) {
			foreach (Players player in (Players[])Enum.GetValues(typeof(Players))) {
				if ((player.Board() & location) == location) {
					return player.Name();
				}
			}
			return " ";
		}
		public static Players playerTurn = Players.X;

		public static void Main(string[] args) {

			string winMessage = "";

			bool gameOver = false;

			while (!gameOver) {
				Console.Clear();

				Console.WriteLine(" --- TicTacToe ---");
				Console.WriteLine("   1   2   3  ");
				Console.WriteLine("A  {0} | {1} | {2} ", Owner(0b000000001), Owner(0b000000010), Owner(0b000000100));
				Console.WriteLine("  -----------");
				Console.WriteLine("B  {0} | {1} | {2} ", Owner(0b000001000), Owner(0b000010000), Owner(0b000100000));
				Console.WriteLine("  -----------");
				Console.WriteLine("C  {0} | {1} | {2} ", Owner(0b001000000), Owner(0b010000000), Owner(0b100000000));

				if (winMessage.Length > 0) {
					Console.WriteLine(winMessage);
					gameOver = true;
					continue;
				}

				if ((Players.X.Board() & Players.O.Board()) == 0b111111111) {
					Console.WriteLine("It's a DRAW!");
					gameOver = true;
					continue;
				}

				playerTurn.Switch();

				Console.WriteLine("Player {0}: It's your turn.", playerTurn);
				Console.WriteLine("Please enter a LETTER then a NUMBER: Example A2 ");
				Console.Write("-->:");
				string answer = Console.ReadLine();
				string upperCase = answer.ToUpper();

				bool invalidInputError = false;

				char[] charArray = upperCase.ToCharArray(0, 2);
				int row = Math.Abs('A' - charArray[0]);
				int col = Math.Abs('1' - charArray[1]);

				if (upperCase.Length == 2 && row >= 0 && row <= 2 && col >= 0 && col <= 2) {
					int selection = 1 << (row * 3);
					selection <<= col;
					playerTurn.SetBoard(selection);
				} else {
					invalidInputError = true;
				}

				if (invalidInputError) {
					Console.Clear();
					Console.WriteLine("You entered {0} as an invalid input. please try again.\n", answer);
					playerTurn.Switch();
					Console.WriteLine("Press Any Key to Continue:");
					Console.ReadLine();
				}
			}
			Console.WriteLine("Thanks for playing!");
		}
	}
}
