using System;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class WarriorShieldEffect : StatusEffect
    {
        private const int DamageReduction = 3;
        
        public WarriorShieldEffect() => 
            duration = -1;

        public override DamageResult OnDefend(Entity owner, Entity attacker, DamageResult damage)
        {
            if (owner.strength > attacker.strength)
                damage.Add(DamageType.Shield, damage.ResultDamage - owner.endurance >= 0 
                    ? -DamageReduction 
                    : -damage.ResultDamage);
            return damage;
        }
    }
}