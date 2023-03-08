using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    public class GameStatus {
        public const string PlayerOneTurn = "P1Turn";
        public const string PlayerTwoTurn = "P2Turn";
        public const string PlayerOneWon = "P1Won";
        public const string PlayerTwoWon = "P2Won";
        public const string Draw = "Draw";

        public static string NextTurn(string status) { 
            if(status == PlayerOneTurn) 
                return PlayerTwoTurn;
            if(status == PlayerTwoTurn)
                return PlayerOneTurn;
            return status;
        }

        public static string VictoryOfCurrentPlayer(string status) {
            if (status == PlayerOneTurn)
                return PlayerOneWon;
            if (status == PlayerTwoTurn)
                return PlayerTwoWon;
            return status;
        }
    }
}
