using System;


namespace TicTacToe {

	// Controller
	public class MainClass {

		public static void Main(string[] args) {

			Model model = new MainModel();
			View view = MainView.GetView();

			bool gameOver = false;

			while (!gameOver) {

				view.DisplayBoard(model);

				if (model.PlayerWon) {
					view.DisplayWinMessage(model);
					gameOver = true;
					continue;
				}

				if (model.CheckForDraw()) {
					view.DrawMessage();
					gameOver = true;
					continue;
				}

				model.SwitchPlayers();

				var (error, answer) = model.CheckForError(view.GetInput(model));
				if (error) {
					view.DisplayMessage(string.Format("You entered {0} as an invalid input. please try again.\n", answer));
					model.SwitchPlayers();
					view.PressAnyKey();
				}

				model.CheckForWinState();
			}

			view.DisplayMessage("Thanks for playing!");
		}
	}
}
