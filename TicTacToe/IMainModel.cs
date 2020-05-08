namespace TicTacToe {
	public interface Model {
		string WinMessage { get; }
		bool PlayerWon { get; }
		Player PlayerTurn { get; }
		bool CheckForDraw();
		(bool error, string answer) CheckForError(string answer);
		void CheckForWinState();
		string GetOwner(string location);
		void SwitchPlayers();
	}
}