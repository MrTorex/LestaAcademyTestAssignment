using System;
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
            switch (level)
            {
                case 1:
                    Console.WriteLine("Скрытая атака");
                    break;
                case 2:
                    player.Agility++;
                    Console.WriteLine("Ловкость +1");
                    break;
                case 3:
                    Console.WriteLine("Яд");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
        
        private static void ApplyWarriorBonus(int level, Player player)
        {
            switch (level)
            {
                case 1:
                    Console.WriteLine("Порыв к действию");
                    break;
                case 2:
                    Console.WriteLine("Щит");
                    break;
                case 3:
                    player.Strength++;
                    Console.WriteLine("Сила +1");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        private static void ApplyBarbarianBonus(int level, Player player)
        {
            switch (level)
            {
                case 1:
                    Console.WriteLine("Ярость");
                    break;
                case 2:
                    Console.WriteLine("Каменная кожа");
                    break;
                case 3:
                    player.Endurance++;
                    Console.WriteLine("Выносливость +1");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
    }
}