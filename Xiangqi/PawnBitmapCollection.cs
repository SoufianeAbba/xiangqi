using System.Drawing;

namespace Xiangqi
{
    public class PawnBitmapCollection
    {
        public readonly static int WIDTH = 52;
        public readonly static int HEIGHT = 52;

        // Black western pawns. imageType = 1
        public readonly static Bitmap cannonWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_cannon);
        public readonly static Bitmap generalWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_general);
        public readonly static Bitmap advisorWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_advisor);
        public readonly static Bitmap rookWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_rook);
        public readonly static Bitmap elephantWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_elephant);
        public readonly static Bitmap knightWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_knight);
        public readonly static Bitmap soldierWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_soldier);

        // Black chinese pawns. imageType = 0
        public readonly static Bitmap cannonChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_cannon);
        public readonly static Bitmap generalChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_general);
        public readonly static Bitmap advisorChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_advisor);
        public readonly static Bitmap rookChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_rook);
        public readonly static Bitmap elephantChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_elephant);
        public readonly static Bitmap knightChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_knight);
        public readonly static Bitmap soldierChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_soldier);

        // Red western pawns. imageType = 1
        public readonly static Bitmap cannonWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_cannon);
        public readonly static Bitmap generalWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_general);
        public readonly static Bitmap advisorWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_advisor);
        public readonly static Bitmap rookWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_rook);
        public readonly static Bitmap elephantWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_elephant);
        public readonly static Bitmap knightWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_knight);
        public readonly static Bitmap soldierWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_soldier);

        // Red chinese pawns. imageType = 0
        public readonly static Bitmap cannonChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_cannon);
        public readonly static Bitmap generalChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_general);
        public readonly static Bitmap advisorChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_advisor);
        public readonly static Bitmap rookChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_rook);
        public readonly static Bitmap elephantChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_elephant);
        public readonly static Bitmap knightChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_knight);
        public readonly static Bitmap soldierChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_soldier);

        // Pawn marker.
        public readonly static Bitmap pawnMarker = new Bitmap(Xiangqi.Properties.Resources.pawn_marker);

        // Pawn empty.
        public readonly static Bitmap pawnEmpty = new Bitmap(Xiangqi.Properties.Resources.pawn_empty);

        // General checked.
        public readonly static Bitmap generalChecked = new Bitmap(Xiangqi.Properties.Resources.check);

        // Possible movement pawn marker.
        public readonly static Bitmap possibleMovementMarker = new Bitmap(Xiangqi.Properties.Resources.possiblemovement);

        // Threatening pawn marker.
        public readonly static Bitmap threateningPawnMarker = new Bitmap(Xiangqi.Properties.Resources.threateningpawn);
    }
}
