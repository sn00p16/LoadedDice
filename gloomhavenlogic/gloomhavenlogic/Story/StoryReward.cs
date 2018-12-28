using gloomhavenlogic.Party;
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
            GlobalAchievement = GlobalAchievement.Undefined;
            PartyAchievement = PartyAchievement.Undefined;
        }
        public StoryReward(GlobalAchievement achievement) : this()
        {
            GlobalAchievement = achievement;
        }
        public StoryReward(PartyAchievement achievement) : this()
        {
            PartyAchievement = achievement;
        }

        protected StoryRewardParameter Parameter { get; set; }
        protected GlobalAchievement GlobalAchievement { get; set; }
        protected PartyAchievement PartyAchievement { get; set; }
        protected int Value { get; set; }

        public void Award()
        {

        }
    }
}
