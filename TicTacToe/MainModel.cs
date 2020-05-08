using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToe {

	public class MainModel : Model {

		private readonly string[] rows = new string[6] { "A", "B", "C", "1", "2", "3" };

		private readonly Dictionary<string, int> board = new Dictionary<string, int>();

		public string WinMessage { get; private set; }

		public Player playerX = new Player("X");
		public Player playerO = new Player("O");

		public Player PlayerTurn { get; private set; }

		public bool PlayerWon => WinMessage.Length > 0;

		private int GetBoard() {
			return playerX.board | playerO.board;
		}

		private int[] winStates = new int[] {
			0b111_000_000,
			0b000_111_000,
			0b000_000_111,
			0b100_100_100,
			0b010_010_010,
			0b001_001_001,
			0b100_010_001,
			0b001_010_100
		};

		public MainModel() {
			WinMessage = "";
			int location = 0b100_000_000;
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					board.Add(rows[i] + rows[(j + 3)], location);
					location >>= 1;
				}
			}
		}

		public string GetOwner(string location) {
			string result = " ";
			if ((playerX.board & board[location]) == board[location]) {
				result = playerX.ToString();
			} else if ((playerO.board & board[location]) == board[location]) {
				result = playerO.ToString();
			}
			return result;
		}

		public void CheckForWinState() {
			bool playerWon = false;

			foreach (int state in winStates) {
				if ((PlayerTurn.board & state) == state) {
					playerWon = true;
					break;
				}
			}
			if (playerWon) {
				WinMessage = string.Format("{0} wins!", PlayerTurn);
			}
		}

		public (bool error, string answer) CheckForError(string answer) {
			bool spotTakenError = false;
			if (board.ContainsKey(answer)) {
				if ((GetBoard() & board[answer]) == 0) {
					PlayerTurn.board |= board[answer];
				} else {
					spotTakenError = true;
				}
			} else {
				spotTakenError = true;
			}
			return (spotTakenError, answer);
		}

		public void SwitchPlayers() {
			if (PlayerTurn == null || PlayerTurn == playerO) {
				PlayerTurn = playerX;
			} else if (PlayerTurn == playerX) {
				PlayerTurn = playerO;
			}
		}

		public bool CheckForDraw() {
			return (GetBoard() & 0b111_111_111) == 0b111_111_111;
		}
	}
}
