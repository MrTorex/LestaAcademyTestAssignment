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
            if (_bonusMoveCounter <= 0)
            {
                damage.damageByType[DamageType.Physical] -= DamagePenalty;
                return damage;
            }
            
            _bonusMoveCounter--;
            damage.damageByType[DamageType.Physical] += DamageBonus;
            return damage;
        }
    }
}