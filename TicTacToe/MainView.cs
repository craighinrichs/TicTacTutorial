using System;

namespace TicTacToe {

	public class MainView : View {

		public static bool testView = false;
		public static View GetView() {
			return (testView) ? new TestMainViewWrapper() : new MainView();
		}

		public virtual string GetInput(Model model) {
			Console.WriteLine("Player {0}: It's your turn.", model.PlayerTurn);
			Console.WriteLine("Please enter a LETTER then a NUMBER: Example A2 ");
			Console.Write("-->:");
			string answer = GetInput();
			return answer.ToUpper();
		}

		public void DisplayBoard(Model model) {
			Console.Clear();

			Console.WriteLine(" --- TicTacToe ---");
			Console.WriteLine("   1   2   3  ");
			Console.WriteLine($"A  {model.GetOwner("A1")} | {model.GetOwner("A2")} | {model.GetOwner("A3")} ");
			Console.WriteLine("  -----------");
			Console.WriteLine($"B  {model.GetOwner("B1")} | {model.GetOwner("B2")} | {model.GetOwner("B3")} ");
			Console.WriteLine("  -----------");
			Console.WriteLine($"C  {model.GetOwner("C1")} | {model.GetOwner("C2")} | {model.GetOwner("C3")} ");

		}

		public void PressAnyKey() {
			DisplayMessage("Press Any Key to Continue:");
			GetInput();
		}

		public string GetInput() {
			return Console.ReadLine();
		}

		public void DisplayMessage(string message) {
			Console.WriteLine(message);
		}

		public void DisplayWinMessage(Model model) {
			Console.WriteLine(model.WinMessage);
		}
		public void DrawMessage() {
			DisplayMessage("It's a DRAW!");
		}
	}
}
