using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Scenario
{
    public enum Element
    {
        Undefined = -1,

        Fire,
        Ice,
        Earth,
        Wind,
        Light,
        Dark,

        Max,

        Any,
        All
    }

    public enum ElementStrength
    {
        Undefined = -1,

        Inert,
        Waning,
        Strong,

        Max
    }
}
