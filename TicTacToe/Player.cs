namespace TicTacToe {
	public class Player {
		public int board;
		private string name;
		public Player(string name) {
			this.name = name;
			board = 0b000_000_000;
		}
		public override string ToString() {
			return name;
		}
	}
}
