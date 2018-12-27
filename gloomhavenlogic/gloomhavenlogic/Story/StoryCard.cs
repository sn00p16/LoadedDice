using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryCard
    {
        public StoryCard()
        {
            FirstStep = null;
        }
        public StoryCard(int index, IStoryStep first) : this()
        {
            Index = index;
            FirstStep = first;
        }

        protected int Index { get; set; }
        protected IStoryStep FirstStep { get; set; }
    }
}
