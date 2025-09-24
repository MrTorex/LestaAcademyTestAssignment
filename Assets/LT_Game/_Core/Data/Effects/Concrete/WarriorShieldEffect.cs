using System;
using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class WarriorShieldEffect : StatusEffect
    {
        private const int DamageReduction = 3;
        
        public WarriorShieldEffect() => 
            duration = -1;

        public override int OnDefend(Entity owner, Entity attacker, int damage) =>
            owner.strength > attacker.strength 
                ? Math.Max(0, damage - DamageReduction) 
                : damage;
    }
}