using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using TicTacToe;

namespace TicTacToeApi.Models {

    [ProtoContract]
    public class GameModel {
        [Key]
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoIgnore]
        [JsonIgnore]
        public string Field { get; set; } = " ; ; ; ; ; ; ; ; ";

        [ProtoMember(2)]
        public string Status { get; set; } = GameStatus.PlayerOneTurn;

        [ProtoMember(3)]
        [NotMapped]
        public char[][] FieldArray {
            get {
                char[] array = Array.ConvertAll(Field.Split(';'), Char.Parse);
                return new char[][] {
                    new char[] { array[0], array[1], array[2] },
                    new char[] { array[3], array[4], array[5] },
                    new char[] { array[6], array[7], array[8] }
                };
            }
            set {
                Field = String.Join(";", value.Select(p => String.Join(";", p)).ToArray());
            }
        }
    }
}

