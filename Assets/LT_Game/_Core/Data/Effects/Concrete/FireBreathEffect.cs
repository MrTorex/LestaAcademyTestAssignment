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

        public override void OnTurnStart(Entity owner) => 
            _moveCounter++;
        
        public override DamageResult OnAttack(Entity owner, Entity target, DamageResult damage)
        {
            var result = damage.Clone();
            if (_moveCounter % 3 == 0)
                result.Add(DamageType.Fire, FireDamageBonus);
            return result;
        }
    }
}