using System;
using LT_Game.Core.Data;
using NUnit.Framework;
using LT_Game.Core.GameSystems;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;
using UnityEngine;

namespace LT_Game.Tests.EditMode.Core.GameSystems
{
    public class CombatServiceTests
    {
        private readonly Weapon _playerWeapon = new("Sword", 3, DamageType.Slashing);
        private readonly Weapon _enemyWeapon = new("Dagger", 2, DamageType.Piercing);
        
        [Test]
        public void CheckHit_Probability_ShouldBeCorrect()
        {
            var player = new Player(
                baseHealth: 10, 
                strength: 5,
                agility: 5,
                endurance: 5, 
                weapon: _playerWeapon
                );
            
            var enemy = new Enemy(
                name: "Test", 
                baseHealth: 10, 
                strength: 5,
                agility: 5,
                endurance: 5,
                baseDamage: 3,
                lootWeapon: _enemyWeapon,
                specialAbility: ""
                );
    
            var hits = 0;
            const int attempts = 10000;
    
            for (var i = 0; i < attempts; i++)
                if (CombatService.CheckHit(player, enemy))
                    hits++;
    
            var hitChance = (double)hits / attempts;
            Assert.That(hitChance, Is.EqualTo(0.5).Within(0.02));
        }
        
        [Test]
        public void CheckHit_PlayerWithHigherAgility_AlwaysHitsEnemy()
        {
            var player = new Player(
                baseHealth: 5, 
                strength: 5,
                agility: 10000,
                endurance: 5, 
                weapon: _playerWeapon
                );
            
            var enemy = new Enemy(
                name: "Test", 
                baseHealth: 5, 
                strength: 1,
                agility: 1,
                endurance: 1,
                baseDamage: 2,
                lootWeapon: _enemyWeapon,
                specialAbility: ""
                );
    
            Assert.IsTrue(CombatService.CheckHit(player, enemy));
        }

        [Test] 
        public void CheckHit_EnemyWithLowerAgility_AlwaysMissesPlayer()
        {
            var player = new Player(
                baseHealth: 10, 
                strength: 5,
                agility: 10000,
                endurance: 5, 
                weapon: _playerWeapon
                );
    
            var enemy = new Enemy(
                name: "Test", 
                baseHealth: 5, 
                strength: 1,
                agility: 1,
                endurance: 1,
                baseDamage: 2,
                lootWeapon: _enemyWeapon,
                specialAbility: ""
                );

            Assert.IsFalse(CombatService.CheckHit(enemy, player));
        }
        
        [Test]
        public void SimulateBattle_PlayerVSGoblin()
        {
            var player = new Player(
                baseHealth: 4,
                strength: 2, 
                agility: 2, 
                endurance: 2, 
                weapon: _playerWeapon
                );
    
            var goblin = new Enemy(
                name: "Goblin",
                baseHealth: 5,
                strength: 1,
                agility: 1,
                endurance: 1,
                baseDamage: 2,
                lootWeapon: _enemyWeapon,
                specialAbility: ""
            );
    
            var result = CombatService.SimulateBattle(player, goblin);
    
            foreach (var log in result.logs)
                Debug.Log(log);

            if (result.winner == player)
            {
                Assert.IsTrue(player.IsAlive, "Player should be alive.");
                Assert.IsFalse(goblin.IsAlive, "Goblin should be dead.");
                
            }
            else if (result.winner == goblin)
            {
                Assert.IsTrue(goblin.IsAlive, "Goblin should be alive.");
                Assert.IsFalse(player.IsAlive, "Player should be dead.");
            }
            else
                throw new Exception("Winner should be player or goblin.");
            
            Assert.Greater(result.logs.Count, 0, "There should be battle logs.");
        }
    }
}