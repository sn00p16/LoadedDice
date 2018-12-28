using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.World
{
    public enum LocationState
    {
        Undefined = -1,

        Hidden,
        Revealed,
        Blocked,
        Completed,

        Max
    }

    public enum Race
    {
        Undefined = -1,

        Human,
        Inox,
        Quatryl,
        Vermling,

        Max
    }

    public enum GlobalAchievement
    {
        Undefined = -1,

        TheDrakeSlain,
        TheDrakeAided,
        TheVoiceSilenced,
        TheVoiceFreed,
        CityRuleMilitaristic,
        CityRuleEconomic,
        CityRuleDemonic,
        ArtifactRecovered,
        ArtifactCleansed,
        ArtifactLost,
        ArtifactFound,
        TheMerchantFlees,
        TheDeadInvade,
        ThePowerOfEnhancement,
        WaterBreathing,
        TheRiftNeutralized,
        TheEdgeOfDarkness,
        EndOfTheInvasion,
        EndOfCorruption,
        EndOfGloom,
        AncientTechnology,
        TheAnnihilationOfTheOrder,

        Max
    }
}
