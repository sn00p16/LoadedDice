using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryStepDestroyCard : IStoryStep
    {
        public void EnterNode()
        {
            // Destroy it
        }
    }

    public class StoryStepReturnCardToDeck : IStoryStep
    {
        public void EnterNode()
        {
            // Put it to the bottom of the deck
        }
    }

    public class StoryStepShuffleCardIntoDeck :IStoryStep
    {
        public void EnterNode()
        {
            // Put it in the deck and then shuffle
        }
    }
}
