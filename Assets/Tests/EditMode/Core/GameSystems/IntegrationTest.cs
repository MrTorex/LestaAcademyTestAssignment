using System.Collections.Generic;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.GameSystems;
using NUnit.Framework;
using UnityEngine;

namespace LT_Game.Tests.EditMode.Core.GameSystems
{
    public class IntegrationTest
    {
        [Test]
        public void FullCombatFlow_PlayerVsAllEnemies()
        {
            var player = new Player(
                baseHealth: 10, 
                strength: 2,
                agility: 2, 
                endurance: 2,
                weapon: WeaponFactory.CreateSword()
            );

            var allEnemies = new List<Enemy>
            {
                EnemyFactory.CreateGoblin(),
                EnemyFactory.CreateSkeleton(),
                EnemyFactory.CreateSlime(),
                EnemyFactory.CreateGhost(),
                EnemyFactory.CreateGolem(),
                EnemyFactory.CreateDragon()
            };

            foreach (var enemy in allEnemies)
            {
                Debug.Log($"\n=== Battle with {enemy.Name} ===");
        
                var result = CombatService.SimulateBattle(player, enemy);
        
                foreach (var log in result.Logs)
                    Debug.Log(log);

                Debug.Log("===============================\n");
                
                player.HealToFull();
            }
        }
    }
}