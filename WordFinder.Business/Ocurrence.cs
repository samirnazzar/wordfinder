using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Business
{
    public class Ocurrence
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        LeftToRight,
        TopToBottom
    }
}
