using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Kata
{
    public interface IBrettBeurteiler
    {
        void VerarbeiteFigur(IFigur figur, List<Position> zielpositionen);
    }
}
