using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class RoguePoisonEffect : StatusEffect
    {
        private int _moveCounter;

        public RoguePoisonEffect() => 
            duration = -1;

        public override DamageResult OnAttack(Entity owner, Entity target, DamageResult damage)
        {
            _moveCounter++;
            damage.Add(DamageType.Poisoning, _moveCounter - 1);
            return damage;
        }
    }
}