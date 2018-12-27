using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Story
{
    public enum StoryCardType
    {
        Undefined = -1,

        City,
        Road,

        Max
    }

    public enum StoryConditionParameter
    {
        Undefined = -1,

        Reputation,
        Prosperity,
        GoldCollective,
        GoldEach,
        Class,

        Max
    }

    public enum StoryConditionComparitor
    {
        Undefined = -1,
        
        GreaterThan,
        GreaterThanOrEqualTo,
        EqualTo,
        NotEqualTo,
        LessThanOrEqualTo,
        LessThan,
        
        ContainsAll,
        ContainsAny,

        Max
    }

    public enum StoryRewardParameter
    {
        Undefined = -1,

        Reputation,
        Prosperity,
        GoldCollective,
        GoldEach,
        ExperienceCollective,
        ExperienceEach,
        Checks,
        RoadEvent,
        CityEvent,
        ItemRandom,
        ItemSpecific,
        Bless,
        Curse,
        Achievement,
        Location,

        Max
    }
}
