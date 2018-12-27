using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryStepReward : IStoryStep
    {
        public StoryStepReward()
        {
            Rewards = new List<StoryReward>();
            NextNode = null;
        }
        public StoryStepReward(StoryReward reward, IStoryStep next) : this()
        {
            Rewards.Add(reward);
            NextNode = next;
        }
        public StoryStepReward(List<StoryReward> rewards, IStoryStep next) : this()
        {
            Rewards.AddRange(rewards);
            NextNode = next;
        }

        protected List<StoryReward> Rewards { get; set; }
        protected IStoryStep NextNode { get; set; }

        public void EnterNode()
        {
            // Award the rewards
            foreach (var reward in Rewards)
                reward.Award();

            // Move onto the next node
            if (NextNode != null)
                NextNode.EnterNode();
        }
    }
}
