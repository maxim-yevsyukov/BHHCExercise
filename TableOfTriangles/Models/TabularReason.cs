using System.Drawing;

namespace BHHCExercise.Models
{

    public class TabularReason
    {
        public TabularReason(string reason, Point v1, Point v2, Point v3, string row, int column)
        {
            Reason = reason;
            V1 = v1;
            V2 = v2;
            V3 = v3;
            Row = row;
            Column = column;
        }

        public string Reason { get; private set; }

        public Point V1 { get; private set; }
        public Point V2 { get; private set; }
        public Point V3 { get; private set; }
        public string Row { get; set; }
        public int Column { get; set; }
    }
}
