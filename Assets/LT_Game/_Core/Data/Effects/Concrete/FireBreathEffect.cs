using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class FireBreathEffect : StatusEffect
    {
        private const int FireDamageBonus = 3;
        private int _moveCounter;
        
        public FireBreathEffect()
        {
            description = $"Fire Breath: Every 3rd turn, {FireDamageBonus} fire damage";
            duration = -1;
        }
        
        public override DamageResult OnAttack(Entity owner, Entity target, DamageResult damage)
        {
            _moveCounter++;
            if (_moveCounter % 3 == 0)
                damage.Add(DamageType.Fire, FireDamageBonus);
            return damage;
        }
    }
}