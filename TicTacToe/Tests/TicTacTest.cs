using System;
using System.IO;
using NUnit.Framework;

namespace TicTacToe.Tests {
	[TestFixture]
	public class TicTacTest {

		[Test]
		public void IntegrationTest1() {

			var example = @"--- TicTacToe ---
   1   2   3  
A    |   |   
  -----------
B    |   |   
  -----------
C    |   |   
 --- TicTacToe ---
   1   2   3  
A  X |   |   
  -----------
B    |   |   
  -----------
C    |   |   
 --- TicTacToe ---
   1   2   3  
A  X |   |   
  -----------
B  O |   |   
  -----------
C    |   |   
 --- TicTacToe ---
   1   2   3  
A  X | X |   
  -----------
B  O |   |   
  -----------
C    |   |   
 --- TicTacToe ---
   1   2   3  
A  X | X |   
  -----------
B  O | O |   
  -----------
C    |   |   
 --- TicTacToe ---
   1   2   3  
A  X | X | X 
  -----------
B  O | O |   
  -----------
C    |   |   
X wins!
Thanks for playing!";


			using (var sw = new StringWriter()) {
				MainView.testView = true;
				Console.SetOut(sw);

				TicTacToe.MainClass.Main(null);

				var result = sw.ToString().Trim();
				Assert.AreEqual(example, result);
			}
		}
	}
}

