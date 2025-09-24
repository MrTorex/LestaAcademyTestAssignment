using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class RogueStealthAttackEffect : StatusEffect
    {
        private const int DamageBonus = 1;

        public RogueStealthAttackEffect()
        {
            description = "Stealth Attack: +1 damage if agility higher than target";
            duration = -1;
        }

        public override DamageResult OnAttack(Entity owner, Entity defender, DamageResult damage)
        {
            var result = damage.Clone();
            if (owner.agility > defender.agility)
                result.damageByType[DamageType.Physical] += DamageBonus;
            return result;
        }
    }
}