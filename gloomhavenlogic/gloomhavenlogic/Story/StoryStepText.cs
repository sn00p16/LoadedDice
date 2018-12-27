using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryStepText : IStoryStep
    {
        public StoryStepText()
        {
            Text = "";
            NextNode = null;
        }
        public StoryStepText(string text, IStoryStep next) : this()
        {
            Text = text;
            NextNode = next;
        }

        protected string Text { get; set; }
        protected IStoryStep NextNode { get; set; }

        public void EnterNode()
        {
            // Display Text
            Debug.Write(Text);

            // Move onto the next node
            if (NextNode != null)
                NextNode.EnterNode();
        }
    }
}
