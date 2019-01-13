using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class CurseModifier : AttackModifier
    {
        public CurseModifier() : base() { }
        public CurseModifier(int curses) : base(AttackModifierType.Curse, curses) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
