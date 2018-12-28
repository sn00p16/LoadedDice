using boardgamelogic.BaseComponents;
using System;
using System.Collections.Generic;
using System.Text;
using gloomhavenlogic.Story;
using System.Xml.Linq;
using System.Diagnostics;
using gloomhavenlogic.Class;
using gloomhavenlogic.World;
using gloomhavenlogic.Party;

namespace gloomhavenlogic.Story
{
    public class StoryCardController
    {
        public StoryCardController()
        {
            Name = "";
            Cards = new List<StoryCard>();
            Party = PartyController.Instance;
        }
        public StoryCardController(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<StoryCard> Cards { get; set; }
        protected PartyController Party { get; set; }

        public void GenerateCards(string data_folder)
        {
            var xml = XDocument.Load(data_folder + Name + "Cards.xml");
            var cardNode = (xml.FirstNode as XElement).Element("Card");

            while (cardNode != null)
                cardNode = CreateCard(cardNode);
        }

        protected XElement CreateCard(XElement node)
        {
            if (node.Name.ToString() != "Card")
                return null;

            var index = int.Parse(node.FirstAttribute.Value);
            Cards.Add(new StoryCard(index, CreatePathNode(node.FirstNode as XElement)));

            return node.NextNode as XElement;
        }

        protected IStoryStep CreatePathNode(XElement node)
        {
            if (node == null)
            {
                Debug.Assert(node != null, "Whoopsy! There's a null condition in here!");
                return null;
            }

            switch(node.Name.ToString())
            {
                case "CardTreatment":
                    return CreateCardTreatmentNode(node);
                case "Choice":
                    return CreateChoiceNode(node);
                case "Condition":
                    return CreateConditionNode(node);
                case "Reward":
                    return CreateRewardNode(node);
                case "Story":
                    return CreateTextNode(node);
            }

            return null;
        }

        protected IStoryStep CreateCardTreatmentNode(XElement node)
        {
            var treatment = node.FirstAttribute.Value;

            switch(treatment)
            {
                case "ReturnToDeck":
                    return new StoryStepReturnCardToDeck();
                case "Destroy":
                    return new StoryStepDestroyCard();
                case "ShuffleIntoDeck":
                    return new StoryStepShuffleCardIntoDeck();
                default:
                    return null;
            }
        }

        protected IStoryStep CreateChoiceNode(XElement node)
        {
            var nextSteps = new List<IStoryStep>();
            var optionTexts = new List<string>();
            var optionCount = int.Parse(node.FirstAttribute.Value);
            var nodeToPath = node.FirstNode;

            while(nodeToPath != null)
            {
                nextSteps.Add(CreatePathNode((nodeToPath as XElement).FirstNode as XElement));
                optionTexts.Add(Name.ToUpper() + (nodeToPath as XElement).FirstAttribute.Value);
                nodeToPath = nodeToPath.NextNode;
            }

            return new StoryStepChoice(optionTexts, nextSteps);
        }

        protected IStoryStep CreateConditionNode(XElement node)
        {
            if (node.Attribute("param").Value == "Class")
                return CreateClassConditionNode(node);

            var param = GetConditionEnum(node.Attribute("param").Value);
            var comp = GetComparitorEnum(node.Attribute("comp").Value);
            var value = int.Parse(node.Attribute("value").Value);

            var success = CreatePathNode((node.FirstNode as XElement).FirstNode as XElement);
            var failure = CreatePathNode((node.LastNode as XElement).FirstNode as XElement);

            return new StoryStepCondition(param, comp, value, success, failure);
        }

        protected IStoryStep CreateClassConditionNode(XElement node)
        {
            var comp = GetComparitorEnum(node.Attribute("comp").Value);
            var list = GetClassList(node.Attribute("value").Value);

            var success = CreatePathNode((node.FirstNode as XElement).FirstNode as XElement);
            var failure = CreatePathNode((node.LastNode as XElement).FirstNode as XElement);

            return new StoryStepCondition(list, comp, success, failure);
        }

        protected IStoryStep CreateRewardNode(XElement node)
        {
            var param = GetRewardEnum(node.Attribute("param").Value);
            var value_string = node.Attribute("value").Value;

            var nextStep = CreatePathNode(node.NextNode as XElement);

            if (param == StoryRewardParameter.Achievement)
            {
                var glob_achievement = GetGlobalAchievementEnum(value_string);
                var party_achievement = GetPartyAchievementEnum(value_string);

                if (glob_achievement != GlobalAchievement.Undefined)
                    return new StoryStepReward(new StoryReward(glob_achievement), nextStep);
                else
                    return new StoryStepReward(new StoryReward(party_achievement), nextStep);
            }
            else
            {
                var value = int.Parse(value_string);
                return new StoryStepReward(new StoryReward(param, value), nextStep);
            }
        }

        protected IStoryStep CreateTextNode(XElement node)
        {
            var story = Name.ToUpper() + node.FirstAttribute.Value;

            var nextStep = CreatePathNode(node.NextNode as XElement);
            return new StoryStepText(story, nextStep);
        }

        protected StoryRewardParameter GetRewardEnum(string reward)
        {
            switch(reward)
            {
                case "Reputation":
                    return StoryRewardParameter.Reputation;
                case "Prosperity":
                    return StoryRewardParameter.Prosperity;
                case "GoldCollective":
                    return StoryRewardParameter.GoldCollective;
                case "GoldEach":
                    return StoryRewardParameter.GoldEach;
                case "ExperienceCollective":
                    return StoryRewardParameter.ExperienceCollective;
                case "ExperienceEach":
                    return StoryRewardParameter.ExperienceEach;
                case "Checks":
                    return StoryRewardParameter.Checks;
                case "RoadEvent":
                    return StoryRewardParameter.RoadEvent;
                case "CityEvent":
                    return StoryRewardParameter.CityEvent;
                case "ItemRandom":
                    return StoryRewardParameter.ItemRandom;
                case "ItemSpecific":
                    return StoryRewardParameter.ItemSpecific;
                case "Bless":
                    return StoryRewardParameter.Bless;
                case "Curse":
                    return StoryRewardParameter.Curse;
                case "Achievement":
                    return StoryRewardParameter.Achievement;
                case "Location":
                    return StoryRewardParameter.Location;
                default:
                    Debug.Fail("Unexpected Reward");
                    return StoryRewardParameter.Undefined;
            }
        }

        protected StoryConditionParameter GetConditionEnum(string reward)
        {
            switch (reward)
            {
                case "Reputation":
                    return StoryConditionParameter.Reputation;
                case "Prosperity":
                    return StoryConditionParameter.Prosperity;
                case "GoldCollective":
                    return StoryConditionParameter.GoldCollective;
                case "GoldEach":
                    return StoryConditionParameter.GoldEach;
                case "Class":
                    return StoryConditionParameter.Class;
                default:
                    Debug.Fail("Unexpected Condition Parameter");
                    return StoryConditionParameter.Undefined;
            }
        }

        protected StoryConditionComparitor GetComparitorEnum(string comp)
        {
            switch(comp)
            {
                case "GREATER_THAN":
                    return StoryConditionComparitor.GreaterThan;
                case "GREATER_THAN_OR_EQUAL_TO":
                    return StoryConditionComparitor.GreaterThanOrEqualTo;
                case "EQUAL_TO":
                    return StoryConditionComparitor.EqualTo;
                case "NOT_EQUAL_TO":
                    return StoryConditionComparitor.NotEqualTo;
                case "LESS_THAN_OR_EQUAL_TO":
                    return StoryConditionComparitor.LessThanOrEqualTo;
                case "LESS_THAN":
                    return StoryConditionComparitor.LessThan;
                case "ContainsAny":
                    return StoryConditionComparitor.ContainsAny;
                case "ContainsAll":
                    return StoryConditionComparitor.ContainsAll;
                default:
                    Debug.Fail("Unexpected Comparitor");
                    return StoryConditionComparitor.Undefined;
            }
        }

        protected List<PlayerClassType> GetClassList(string value)
        {
            var list = new List<PlayerClassType>();
            var strings = value.Split(',');
            
            foreach(var text in strings)
            {
                switch(text)
                {
                    case "Brute":
                        list.Add(PlayerClassType.Brute); break;
                    case "Tinkerer":
                        list.Add(PlayerClassType.Tinkerer); break;
                    case "Spellweaver":
                        list.Add(PlayerClassType.Spellweaver); break;
                    case "Scoundrel":
                        list.Add(PlayerClassType.Scoundrel); break;
                    case "Cragheart":
                        list.Add(PlayerClassType.Cragheart); break;
                    case "Mindthief":
                        list.Add(PlayerClassType.Mindthief); break;
                    case "Sun":
                    case "Sunkeeper":
                        list.Add(PlayerClassType.Sunkeeper); break;
                    case "ThreeArrows":
                    case "Quartermaster":
                        list.Add(PlayerClassType.Quartermaster); break;
                    case "Circles":
                        list.Add(PlayerClassType.Circles); break;
                    case "Eclipse":
                        list.Add(PlayerClassType.Eclipse); break;
                    case "Cthulhu":
                        list.Add(PlayerClassType.Cthulhu); break;
                    case "LightningBolt":
                        list.Add(PlayerClassType.LightningBolt); break;
                    case "MusicNote":
                        list.Add(PlayerClassType.MusicNote); break;
                    case "SpikyHead":
                    case "Doomstalker":
                        list.Add(PlayerClassType.Doomstalker); break;
                    case "Saw":
                        list.Add(PlayerClassType.Saw); break;
                    case "Triangles":
                    case "Elementalist":
                        list.Add(PlayerClassType.Elementalist); break;
                    case "TwoMini":
                    case "BeastTamer":
                        list.Add(PlayerClassType.BeastTamer); break;
                    default:
                        Debug.Fail("Unexpected Class Name");
                        break;
                }
            }

            return list;
        }

        protected GlobalAchievement GetGlobalAchievementEnum(string label)
        {
            switch(label)
            {
                case "The Drake Slain":
                    return GlobalAchievement.TheDrakeSlain;
                case "The Drake Aided":
                    return GlobalAchievement.TheDrakeAided;
                case "The Voice Silenced":
                    return GlobalAchievement.TheVoiceSilenced;
                case "The Voice Freed":
                    return GlobalAchievement.TheVoiceFreed;
                case "City Rule Militaristic":
                    return GlobalAchievement.CityRuleMilitaristic;
                case "City Rule Economic":
                    return GlobalAchievement.CityRuleEconomic;
                case "City Rule Demonic":
                    return GlobalAchievement.CityRuleDemonic;
                case "Artifact Found":
                    return GlobalAchievement.ArtifactFound;
                case "Artifact Recovered":
                    return GlobalAchievement.ArtifactRecovered;
                case "Artifact Cleansed":
                    return GlobalAchievement.ArtifactCleansed;
                case "Artifact Lost":
                    return GlobalAchievement.ArtifactLost;
                case "The Merchant Flees":
                    return GlobalAchievement.TheMerchantFlees;
                case "The Dead Invade":
                    return GlobalAchievement.TheDeadInvade;
                case "The Power Of Enhancement":
                    return GlobalAchievement.ThePowerOfEnhancement;
                case "Water Breathing":
                    return GlobalAchievement.WaterBreathing;
                case "The Rift Neutralized":
                    return GlobalAchievement.TheRiftNeutralized;
                case "The Edge Of Darkness":
                    return GlobalAchievement.TheEdgeOfDarkness;
                case "End Of The Invasion":
                    return GlobalAchievement.EndOfTheInvasion;
                case "End Of Corruption":
                    return GlobalAchievement.EndOfCorruption;
                case "End Of Gloom":
                    return GlobalAchievement.EndOfGloom;
                case "Ancient Technology":
                    return GlobalAchievement.AncientTechnology;
                case "The Annihilation Of The Order":
                    return GlobalAchievement.TheAnnihilationOfTheOrder;
                default:
                    Debug.Fail("Unexpected Achievement");
                    return GlobalAchievement.Undefined;
            }
        }

        protected PartyAchievement GetPartyAchievementEnum(string label)
        {
            switch (label)
            {
                case "A Map To Treasure":
                    return PartyAchievement.AMapToTreasure;
                case "Bad Business":
                    return PartyAchievement.BadBusiness;
                default:
                    Debug.Fail("Unexpected Achievement");
                    return PartyAchievement.Undefined;
            }
        }
    }
}
