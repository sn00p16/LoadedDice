using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Class
{
    public enum PlayerClassType
    {
        Undefined = -1,

        Brute,
        Tinkerer,
        Spellweaver,
        Scoundrel,
        Cragheart,
        Mindthief,

        Sunkeeper,
        Quartermaster,
        Circles,
        Eclipse,
        Cthulhu,
        LightningBolt,
        MusicNote,
        Doomstalker,
        Saw,
        Elementalist,
        BeastTamer,

        Max,

        Sun = Sunkeeper,
        ThreeArrows = Quartermaster,
        SpikyHead = Doomstalker,
        Triangles = Elementalist,
        TwoMini = BeastTamer,
    }

    public enum PlayerClassState
    {
        Undefined = -1,

        Locked,
        Unlocked,
        InPlay,

        Max
    }
}
