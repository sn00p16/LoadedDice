using gloomhavenlogic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryReward
    {
        public StoryReward() { }
        public StoryReward(StoryRewardParameter reward, int value) : this()
        {
            Parameter = reward;
            Value = value;
        }
        public StoryReward(Achievement achievement) : this()
        {
            Achievement = achievement;
        }

        protected StoryRewardParameter Parameter { get; set; }
        protected Achievement Achievement { get; set; }
        protected int Value { get; set; }

        public void Award()
        {

        }
    }
}
