using System;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class WarriorShieldEffect : StatusEffect
    {
        private const int DamageReduction = 3;

        public WarriorShieldEffect()
        {
            description = "Shield: -3 damage if strength higher than attacker";
            duration = -1;
        }

        public override DamageResult OnDefend(Entity owner, Entity attacker, DamageResult damage)
        {
            var result = damage.Clone();
            if (owner.strength > attacker.strength)
                result.Add(DamageType.Shield, damage.ResultDamage - owner.endurance >= 0 
                    ? -DamageReduction 
                    : -result.ResultDamage);
            return result;
        }
    }
}