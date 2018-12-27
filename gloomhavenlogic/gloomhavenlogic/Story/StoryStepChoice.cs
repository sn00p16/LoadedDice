using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryChoice
    {
        public StoryChoice() { }
        public StoryChoice(string choice, IStoryStep next) :this()
        {
            Choice = choice;
            NextNode = next;
        }

        public string Choice { get; protected set; }
        public IStoryStep NextNode { get; protected set; }
    }

    public class StoryStepChoice : IStoryStep
    {
        public StoryStepChoice()
        {
            ChoiceTexts = new List<string>();
            NextNodes = new List<IStoryStep>();
        }
        public StoryStepChoice(List<string> choices, List<IStoryStep> nexts) : this()
        {
            ChoiceTexts = choices;
            NextNodes = nexts;
        }
        public StoryStepChoice(List<StoryChoice> choices) : this()
        {
            foreach(var choice in choices)
            {
                ChoiceTexts.Add(choice.Choice);
                NextNodes.Add(choice.NextNode);
            }
        }

        protected List<string> ChoiceTexts { get; set; }
        protected List<IStoryStep> NextNodes { get; set; }

        public void EnterNode()
        {
            // Display the choices
            Debug.Write(ChoiceTexts);

            // Choose one (for now, assume 0) - need to get from player module
            int choiceIndex = 0;

            // Proceed to the appropriate node
            NextNodes[choiceIndex].EnterNode();
        }
    }
}
