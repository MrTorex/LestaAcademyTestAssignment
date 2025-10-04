using System;
using System.Collections.Generic;
using System.Linq;
using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.GameSystems
{
    public static class CombatService
    {
        private static readonly Random Randomizer = new();
        public class BattleState
        {
            public Player Player;
            public Enemy Enemy;
            public List<Entity> TurnOrder;
            public int CurrentTurnIndex;
            public readonly List<string> Logs = new();
        }
        
        public static BattleState CreateBattle(Player player, Enemy enemy)
        {
            var state = new BattleState
            {
                Player = player, Enemy = enemy,
                TurnOrder = new List<Entity> { player, enemy }
                    .OrderByDescending(e => e.agility).ToList()
            };

            if (player.agility == enemy.agility)
                state.TurnOrder = new List<Entity> { player, enemy };
            
            state.Logs.Add($"First: {GetEntityName(state.TurnOrder[0])}, Second: {GetEntityName(state.TurnOrder[1])}");
        
            return state;
        }
        
        public static bool ExecuteNextTurn(BattleState state)
        {
            if (!state.Player.IsAlive || !state.Enemy.IsAlive)
                return false;

            var attacker = state.TurnOrder[state.CurrentTurnIndex];
            var defender = state.TurnOrder[1 - state.CurrentTurnIndex];
            
            state.Player.effectManager.ProcessTurnStart();
            state.Enemy.effectManager.ProcessTurnStart();
        
            ProcessAttack(attacker, defender, state);
            
            state.CurrentTurnIndex = 1 - state.CurrentTurnIndex;
        
            return true;
        }

        private static void ProcessAttack(Entity attacker, Entity defender, BattleState state)
        {
            var damage = attacker.CalculateDamage();
            damage = attacker.effectManager.ModifyAttackDamage(defender, damage);
            damage = defender.effectManager.ModifyDefenseDamage(attacker, damage);
            if (CheckHit(attacker, defender))
            {
                defender.TakeDamage(damage.ResultDamage);
                
                state.Logs.Add($"{GetEntityName(attacker)} damaged {GetEntityName(defender)}: {damage}. " +
                                $"{GetEntityName(defender)} HP: {defender.health}");
            }
            else
                state.Logs.Add($"{GetEntityName(attacker)} missed by {GetEntityName(defender)}.");
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