using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Scenario
{
    public class ElementBoardEntry
    {
        public ElementBoardEntry() { Strength = ElementStrength.Inert; }
        
        protected ElementStrength Strength { get; set; }

        public bool IsUseable { get { return IsWaning || IsStrong; } }

        public bool IsInert { get { return Strength == ElementStrength.Inert; } }
        public bool IsWaning { get { return Strength == ElementStrength.Waning; } }
        public bool IsStrong { get { return Strength == ElementStrength.Strong; } }

        public void GenerateElement() { Strength = ElementStrength.Strong; }
        public void UseElement() { Strength = ElementStrength.Inert; }
        public void WeakenElement() { if (IsUseable) Strength--; }
    }
}
