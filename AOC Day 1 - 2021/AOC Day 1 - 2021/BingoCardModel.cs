using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC___2021
{
    public class BingoCardModel
    {
        public int CardId { get; set; }

        public int Row { get; set; } 

        public int Column { get; set; }

        public BingoCardModel(int cardId, int row, int column)
        {
            this.CardId = cardId;
            this.Row = row;
            this.Column = column;
        }
    }
}
