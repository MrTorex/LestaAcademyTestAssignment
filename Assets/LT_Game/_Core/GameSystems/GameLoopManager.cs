using System;
using System.Collections.Generic;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;
using UnityEngine;
using Random = System.Random;

namespace LT_Game.Core.GameSystems
{
    public static class GameLoopManager
    {
        public static void StartGameLoop()
        {
            var randomizer = new Random();
            var player = CreateInitialPlayer();
            var victories = 0;

            while (victories < 3 && player.IsAlive)
            {
                var enemy = GetRandomEnemy(randomizer);
                
                Debug.Log($"\n=== Battle with {enemy.name} ===");
                var result = CombatService.SimulateBattle(player, enemy);
        
                foreach (var log in result.logs)
                    Debug.Log(log);

                if (result.winner == player)
                {
                    player.HealToFull();
                    LevelUpPlayer(player, randomizer);
                    victories++;
                }
                else
                    Debug.Log("Game over!");
                
                Debug.Log("===============================\n");
            }
            
            Debug.Log(victories == 3 ? "You won!" : "You lost!");
        }

        private static Player CreateInitialPlayer() =>
            new (
                baseHealth: 4,
                strength: 2, 
                agility: 2, 
                endurance: 2, 
                weapon: WeaponFactory.CreateSword()
                );

        private static Enemy GetRandomEnemy(Random randomizer)
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

        private static ClassType GetRandomClassType(Random randomizer)
        {
            var classes = new List<ClassType>
            {
                ClassType.Rogue,
                ClassType.Warrior,
                ClassType.Barbarian
            };
            
            return classes[randomizer.Next(classes.Count)];
        }

        private static void LevelUpPlayer(Player player, Random randomizer) =>
            player.LevelUp(GetRandomClassType(randomizer));
    }
}