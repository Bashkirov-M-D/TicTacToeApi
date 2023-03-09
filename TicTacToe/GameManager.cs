using System.Net.Sockets;

namespace TicTacToe {
    public class GameManager {
        public static (bool, string) NewTurn(char[][] field, string gameStatus, int turnPosX, int turnPosY) {
            int[] coords = new int[] { -1, 0, 1 };
            char targetSymbol;

            if (turnPosX > 3 || turnPosX < 0 || turnPosY > 3 || turnPosY < 0)
                return (false, gameStatus);

            if (field[turnPosX][turnPosY] != ' ')
                return (false, gameStatus);

            if (gameStatus == GameStatus.PlayerOneTurn)
                targetSymbol = 'X';
            else if (gameStatus == GameStatus.PlayerTwoTurn)
                targetSymbol = '0';
            else return (false, gameStatus);

            for (int i = 0; i < coords.Length; i++) {
                for (int j = 0; j < coords.Length; j++) {
                    if (i == 1 && j == 1)
                        continue;

                    if (CheckCell(field, targetSymbol, turnPosX + coords[i], turnPosY + coords[j]))
                        if (CheckOtherCells(field, targetSymbol, turnPosX, turnPosY, coords[i], coords[j]))
                            return (true, GameStatus.VictoryOfCurrentPlayer(gameStatus));
                }
            }

            if (CheckDraw(field))
                return (true, GameStatus.Draw);

            return (true, GameStatus.NextTurn(gameStatus));
        }

        private static bool CheckOtherCells(char[][] field, char targetSymbol,
            int targetPosX, int targetPosY, int posXChange, int posYChange) {
            if (CheckCell(field, targetSymbol, targetPosX + posXChange * 2, targetPosY + posYChange * 2) ||
                CheckCell(field, targetSymbol, targetPosX - posXChange, targetPosY - posYChange))
                return true;
            return false;
        }

        private static bool CheckCell(char[][] field, char targetSymbol, int pX, int pY) {
            if (pX >= 0 && pX <= 2 && pY >= 0 && pY <= 2)
                if (field[pX][pY] == targetSymbol)
                    return true;
            return false;
        }

        private static bool CheckDraw(char[][] field) {
            int count = 0;
            foreach (char[] chars in field)
                foreach (char c in chars)
                    if(c == ' ')
                        count++;
            return count < 2;
        }
    }
}