using System;
using LT_Game.Core.Data.Effects.Concrete;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.GameSystems
{
    public static class ClassBonusService
    {
        public static void ApplyLevelBonus(ClassType classType, int level, Player player)
        {
            switch (classType)
            {
                case ClassType.Rogue:
                    ApplyRogueBonus(level, player);
                    break;
                case ClassType.Warrior:
                    ApplyWarriorBonus(level, player);
                    break;
                case ClassType.Barbarian:
                    ApplyBarbarianBonus(level, player);
                    break;
                default:
                    throw new ArgumentException("Unknown class type", nameof(classType));
            }
        }
        
        private static void ApplyRogueBonus(int level, Player player)
        {
            player.IncreaseMaxHealth(4);
            
            switch (level)
            {
                case 1:
                    player.effectManager.Add(new RogueStealthAttackEffect());
                    break;
                case 2:
                    player.effectManager.Add(new AgilityBuffEffect(1, -1));
                    break;
                case 3: 
                    player.effectManager.Add(new RoguePoisonEffect());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
        
        private static void ApplyWarriorBonus(int level, Player player)
        {
            player.IncreaseMaxHealth(5);
            
            switch (level)
            {
                case 1:
                    player.effectManager.Add(new WarriorFirstStrikeEffect());
                    break;
                case 2:
                    player.effectManager.Add(new WarriorShieldEffect());
                    break;
                case 3:
                    player.effectManager.Add(new StrengthBuffEffect(1, -1));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        private static void ApplyBarbarianBonus(int level, Player player)
        {
            player.IncreaseMaxHealth(6);
            
            switch (level)
            {
                case 1: 
                    player.effectManager.Add(new BarbarianRageEffect());
                    break;
                case 2: 
                    player.effectManager.Add(new BarbarianStoneSkinEffect());
                    break;
                case 3:
                    player.effectManager.Add(new EnduranceBuffEffect(1, -1));
                    player.IncreaseMaxHealth(1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        public static string GetRogueBonusDescription(int level) =>
            level switch
            {
                1 => new RogueStealthAttackEffect().description,
                2 => new AgilityBuffEffect(1, -1).description,
                3 => new RoguePoisonEffect().description,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };

        public static string GetWarriorBonusDescription(int level) =>
            level switch
            {
                1 => new WarriorFirstStrikeEffect().description,
                2 => new WarriorShieldEffect().description,
                3 => new StrengthBuffEffect(1, -1).description,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };

        public static string GetBarbarianBonusDescription(int level) =>
            level switch
            {
                1 => new BarbarianRageEffect().description,
                2 => new BarbarianStoneSkinEffect().description,
                3 => new EnduranceBuffEffect(1, -1).description,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
    }
}