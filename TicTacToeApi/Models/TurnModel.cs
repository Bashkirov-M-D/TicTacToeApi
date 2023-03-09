using ProtoBuf;

namespace TicTacToeApi.Models {

    [ProtoContract]
    public class TurnModel {
        /// <summary>
        /// form 0 to 2
        /// </summary>
        [ProtoMember(1)]
        public int PosX { get; set; } = -1;
        /// <summary>
        /// from 0 to 2
        /// </summary>
        [ProtoMember(2)]
        public int PosY { get; set; } = -1;
    }
}
