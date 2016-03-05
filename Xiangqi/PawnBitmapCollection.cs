using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi
{
    public class PawnBitmapCollection
    {
        public static int WIDTH = 52;
        public static int HEIGHT = 52;

        // Black western pawns. imageType = 1
        public static Bitmap cannonWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_cannon);
        public static Bitmap generalWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_general);
        public static Bitmap advisorWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_advisor);
        public static Bitmap rookWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_rook);
        public static Bitmap elephantWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_elephant);
        public static Bitmap knightWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_knight);
        public static Bitmap soldierWesternBlack = new Bitmap(Xiangqi.Properties.Resources.we_b_soldier);

        // Black chinese pawns. imageType = 0
        public static Bitmap cannonChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_cannon);
        public static Bitmap generalChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_general);
        public static Bitmap advisorChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_advisor);
        public static Bitmap rookChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_rook);
        public static Bitmap elephantChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_elephant);
        public static Bitmap knightChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_knight);
        public static Bitmap soldierChineseBlack = new Bitmap(Xiangqi.Properties.Resources.ch_b_soldier);

        // Red western pawns. imageType = 1
        public static Bitmap cannonWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_cannon);
        public static Bitmap generalWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_general);
        public static Bitmap advisorWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_advisor);
        public static Bitmap rookWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_rook);
        public static Bitmap elephantWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_elephant);
        public static Bitmap knightWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_knight);
        public static Bitmap soldierWesternRed = new Bitmap(Xiangqi.Properties.Resources.we_r_soldier);

        // Red chinese pawns. imageType = 0
        public static Bitmap cannonChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_cannon);
        public static Bitmap generalChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_general);
        public static Bitmap advisorChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_advisor);
        public static Bitmap rookChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_rook);
        public static Bitmap elephantChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_elephant);
        public static Bitmap knightChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_knight);
        public static Bitmap soldierChineseRed = new Bitmap(Xiangqi.Properties.Resources.ch_r_soldier);

        // Pawn marker.
        public static Bitmap pawnMarker = new Bitmap(Xiangqi.Properties.Resources.pawn_marker);

        // Pawn empty.
        public static Bitmap pawnEmpty = new Bitmap(Xiangqi.Properties.Resources.pawn_empty);

        // General checked.
        public static Bitmap generalChecked = new Bitmap(Xiangqi.Properties.Resources.check);

        // Possible movement pawn marker.
        public static Bitmap possibleMovementMarker = new Bitmap(Xiangqi.Properties.Resources.possiblemovement);

        // Threatening pawn marker.
        public static Bitmap threateningPawnMarker = new Bitmap(Xiangqi.Properties.Resources.threateningpawn);
    }
}
