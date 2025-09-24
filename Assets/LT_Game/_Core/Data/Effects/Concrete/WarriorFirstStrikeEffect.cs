using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class WarriorFirstStrikeEffect : StatusEffect
    {
        private bool _firstTurn = true;

        public WarriorFirstStrikeEffect()
        {
            description = "First Strike: double weapon damage on first turn";
            duration = -1;
        }

        public override DamageResult OnAttack(Entity owner, Entity target, DamageResult damage)
        {
            var result = damage.Clone();
            if (!_firstTurn || owner is not Player player) return result;
            
            _firstTurn = false;
            result.Add(DamageType.Critical, player.CurrentWeapon.damage);
            return result;
        }
    }
}