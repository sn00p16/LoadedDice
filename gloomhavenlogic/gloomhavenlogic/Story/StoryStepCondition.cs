using gloomhavenlogic.Class;
using gloomhavenlogic.Party;
using gloomhavenlogic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Story
{
    public class StoryStepCondition : IStoryStep
    {
        public StoryStepCondition()
        {
            Parameter = StoryConditionParameter.Undefined;
            Comparitor = StoryConditionComparitor.Undefined;
            Classes = new List<PlayerClassType>();
            Value = 0;
            SuccessNext = null;
            FailureNext = null;
        }
        public StoryStepCondition(StoryConditionParameter param, StoryConditionComparitor comp, int value, IStoryStep success, IStoryStep fail) : this()
        {
            Parameter = param;
            Comparitor = comp;
            Value = value;
            SuccessNext = success;
            FailureNext = fail;
        }
        public StoryStepCondition(List<PlayerClassType> classes, StoryConditionComparitor comp, IStoryStep success, IStoryStep fail) : this()
        {
            Classes.AddRange(classes);
            Parameter = StoryConditionParameter.Class;
            Comparitor = comp;
            SuccessNext = success;
            FailureNext = fail;
        }

        protected StoryConditionParameter Parameter { get; set; }
        protected StoryConditionComparitor Comparitor { get; set; }
        protected List<PlayerClassType> Classes { get; set; }
        protected int Value { get; set; }
        protected IStoryStep SuccessNext { get; set; }
        protected IStoryStep FailureNext { get; set; }

        public void EnterNode()
        {
            var success = false;

            switch(Parameter)
            {
                case StoryConditionParameter.GoldCollective:
                    success = Compare(PartyController.Instance.GoldCollective);
                    break;

                case StoryConditionParameter.GoldEach:
                    success = Compare(PartyController.Instance.GoldMinimum);
                    break;

                case StoryConditionParameter.Prosperity:
                    success = Compare(GlobalController.Instance.ProsperityLevel);
                    break;

                case StoryConditionParameter.Reputation:
                    success = Compare(PartyController.Instance.Reputation);
                    break;

                case StoryConditionParameter.Class:
                    success = Compare(PartyController.Instance.Classes);
                    break;
            }

            if (success)
                SuccessNext.EnterNode();
            else
                FailureNext.EnterNode();
        }

        protected bool Compare(int value)
        {
            switch(Comparitor)
            {
                case StoryConditionComparitor.GreaterThan:
                    return value > Value;

                case StoryConditionComparitor.GreaterThanOrEqualTo:
                    return value >= Value;

                case StoryConditionComparitor.LessThanOrEqualTo:
                    return value <= Value;

                case StoryConditionComparitor.LessThan:
                    return value < Value;

                case StoryConditionComparitor.EqualTo:
                    return value == Value;

                case StoryConditionComparitor.NotEqualTo:
                    return value != Value;

                default:
                    return false;
            }
        }

        protected bool Compare(List<PlayerClassType> classes)
        {
            switch(Comparitor)
            {
                case StoryConditionComparitor.ContainsAll:
                    {
                        bool returnVal = true;
                        foreach (var pclass in Classes)
                            returnVal &= classes.Contains(pclass);

                        return returnVal;
                    }

                case StoryConditionComparitor.ContainsAny:
                    {
                        foreach(var pclass in Classes)
                            if (classes.Contains(pclass))
                                return true;

                        return false;
                    }

                default:
                    return false;
            }
        }
    }
}
