namespace TicTacToe {
	public interface View {
		void DisplayBoard(Model model);
		void DisplayMessage(string message);
		void DisplayWinMessage(Model model);
		void DrawMessage();
		string GetInput(Model model);
		string GetInput();
		void PressAnyKey();
	}
}