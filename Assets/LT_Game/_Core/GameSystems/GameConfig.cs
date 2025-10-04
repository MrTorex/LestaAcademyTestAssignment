using System;
using LT_Game.Core.Data;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.GameSystems
{
    public static class GameConfig
    {
        public static Player CreateInitialPlayer(Random random, ClassType classType)
        {
            int baseHealth;
            Weapon startWeapon;

            switch (classType)
            {
                case ClassType.Rogue:
                    baseHealth = 4;
                    startWeapon = WeaponFactory.CreateDagger();
                    break;
                case ClassType.Warrior:
                    baseHealth = 5;
                    startWeapon = WeaponFactory.CreateSword();
                    break;
                case ClassType.Barbarian:
                    baseHealth = 6;
                    startWeapon = WeaponFactory.CreateClub();
                    break;
                default:
                    throw new ArgumentException("Unknown class type", nameof(classType));            }
            
            return new Player(
                baseHealth: baseHealth,
                strength: random.Next(1, 4), 
                agility: random.Next(1, 4), 
                endurance: random.Next(1, 4), 
                weapon: startWeapon
            );
        }    
        
            

        public static Enemy GetRandomEnemy(Random randomizer)
        {
            var enemies = new Func<Enemy>[]
            {
                EnemyFactory.CreateGoblin,
                EnemyFactory.CreateSkeleton,
                EnemyFactory.CreateSlime,
                EnemyFactory.CreateGhost,
                EnemyFactory.CreateGolem,
                EnemyFactory.CreateDragon
            };
    
            return enemies[randomizer.Next(enemies.Length)]();
        }
        
        public const int VictoriesToWin = 3;
    }
}