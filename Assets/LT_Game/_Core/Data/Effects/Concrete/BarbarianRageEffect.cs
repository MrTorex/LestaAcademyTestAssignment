using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class BarbarianRageEffect : StatusEffect
    {
        private const int DamageBonus = 2;

        private const int DamagePenalty = 1;
        
        private int _bonusMoveCounter = 3;

        public BarbarianRageEffect()
        {
            description = "Barbarian Rage: +2 damage (first 3 turns), then -1";
            duration = -1;
        }

        public override DamageResult OnAttack(Entity owner, Entity defender, DamageResult damage)
        {
            var result = damage.Clone();
            if (_bonusMoveCounter <= 0)
            {
                result.damageByType[DamageType.Physical] -= DamagePenalty;
                return result;
            }
            
            _bonusMoveCounter--;
            result.damageByType[DamageType.Physical] += DamageBonus;
            return result;
        }
    }
}