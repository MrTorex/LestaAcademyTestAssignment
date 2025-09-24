using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class BarbarianRageEffect : StatusEffect
    {
        private const int DamageBonus = 2;

        private const int DamagePenalty = 1;
        
        private int _bonusMoveCounter = 3;

        public BarbarianRageEffect() => 
            duration = -1;

        public override int OnAttack(Entity owner, Entity defender, int damage)
        {
            if (_bonusMoveCounter <= 0) return damage - DamagePenalty;
            
            _bonusMoveCounter--;
            return damage + DamageBonus;
        }
    }
}