using System;
namespace TicTacToe {

	public class TestMainViewWrapper : MainView {

		string[] testData1 = new string[] { "A1", "B1", "A2", "B2", "A3" };

		int index = 0;
		public TestMainViewWrapper() {

		}

		public override string GetInput(MainModel model) {
			return testData1[index++];
		}
	}
}
