namespace TicTacToe.Tests {
    public class GameManagerTests {
        [Theory]
        [InlineData(GameStatus.PlayerOneTurn, 2, 1, true, GameStatus.PlayerTwoTurn)]
        [InlineData(GameStatus.PlayerTwoTurn, 1, 0, true, GameStatus.PlayerOneTurn)]
        [InlineData(GameStatus.PlayerOneTurn, 0, 1, true, GameStatus.PlayerTwoTurn)]
        public void NewTurn_CorrectTurns_ReturnsTrueAndCorrectStatus
            (string gameStatus, int pX, int pY, bool result1, string result2) {
            char[][] field = new char[][] {
                new char[] { 'X', ' ', '0'},
                new char[] { ' ', 'X', '0'},
                new char[] { '0', ' ', ' '}
            };

            var expected = (result1, result2);
            var actual = GameManager.NewTurn(field, gameStatus, pX, pY);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NewTurn_FilledCell_ReturnsFalse() {
            char[][] field = new char[][] {
                new char[] { 'X', ' ', '0'},
                new char[] { ' ', 'X', '0'},
                new char[] { '0', ' ', ' '}
            };
            bool expected = false;

            bool actual = GameManager.NewTurn(field, GameStatus.PlayerOneTurn, 0, 0).Item1;
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(GameStatus.PlayerOneTurn, 2, 2, true, GameStatus.PlayerOneWon)]
        [InlineData(GameStatus.PlayerTwoTurn, 2, 2, true, GameStatus.PlayerTwoWon)]
        public void NewTurn_VictoryTurns_ReturnsTrueAndVictoryStatus
            (string gameStatus, int pX, int pY, bool result1, string result2) {
            char[][] field = new char[][] {
                new char[] { 'X', ' ', '0'},
                new char[] { ' ', 'X', '0'},
                new char[] { '0', ' ', ' '}
            };

            var expected = (result1, result2);
            var actual = GameManager.NewTurn(field, gameStatus, pX, pY);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NewTurn_DrawTurn_ReturnsDraw() {
            char[][] field = new char[][] {
                new char[] { '0', '0', '0'},
                new char[] { '0', '0', '0'},
                new char[] { '0', '0', ' '}
            };

            var expected = (true, GameStatus.Draw);
            var actual = GameManager.NewTurn(field, GameStatus.PlayerOneTurn, 2, 2);

            Assert.Equal(expected, actual);
        }
    }
}