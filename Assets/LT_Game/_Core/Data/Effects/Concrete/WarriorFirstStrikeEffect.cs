using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class WarriorFirstStrikeEffect : StatusEffect
    {
        private bool _firstTurn = true;

        public WarriorFirstStrikeEffect() =>
            duration = -1;

        public override DamageResult OnAttack(Entity owner, Entity target, DamageResult damage)
        {
            if (!_firstTurn || owner is not Player player) return damage;
            
            _firstTurn = false;
            damage.Add(DamageType.Critical, player.CurrentWeapon.damage);
            return damage;
        }
    }
}