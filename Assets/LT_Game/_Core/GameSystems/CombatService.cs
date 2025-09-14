using System;
using System.Collections.Generic;
using System.Linq;
using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.GameSystems
{
    public static class CombatService
    {
        private static readonly Random Randomizer = new();
        public class CombatResult
        {
            public Entity winner { get; set; }
            public List<string> logs { get; } = new();
        }

        public static CombatResult SimulateBattle(Player player, Enemy enemy)
        {
            var result = new CombatResult();
            
            var battlers = new List<Entity> { player, enemy }.OrderByDescending(entity => entity.agility).ToList();
            if (player.agility == enemy.agility)
                battlers = new List<Entity> { player, enemy };
            
            var first = battlers.First();
            var second = battlers.Last();
            
            result.logs.Add($"{GetEntityName(first)} is first, {GetEntityName(second)} is second.");
            
            while (player.IsAlive && enemy.IsAlive)
            {
                ProcessAttack(first, second, result);
                if (!second.IsAlive) break;
                
                ProcessAttack(second, first, result);
                if (!first.IsAlive) break;
            }
            
            result.winner = player.IsAlive ? player : enemy;
            Entity loser = player.IsAlive ? enemy : player;
            
            result.logs.Add($"{GetEntityName(result.winner)} killed {GetEntityName(loser)}. " +
                            $"{GetEntityName(result.winner)} HP: {result.winner.health}");

            return result;
        }

        private static void ProcessAttack(Entity attacker, Entity defender, CombatResult result)
        {
            if (CheckHit(attacker, defender))
            {
                var damage = attacker.CalculateDamage();
                defender.TakeDamage(damage);
                
                result.logs.Add($"{GetEntityName(attacker)} damaged {GetEntityName(defender)}: {damage}. " +
                                $"{GetEntityName(defender)} HP: {defender.health}");
            }
            else
                result.logs.Add($"{GetEntityName(attacker)} missed by {GetEntityName(defender)}.");
        }

        public static bool CheckHit(Entity attacker, Entity defender) => 
            Randomizer.Next(1, attacker.agility + defender.agility + 1) > defender.agility;
        
        private static string GetEntityName(Entity entity) =>
            entity switch
            {
                Player => "Player",
                Enemy enemy => enemy.name,
                _ => "Unknown" 
            };
    }
}