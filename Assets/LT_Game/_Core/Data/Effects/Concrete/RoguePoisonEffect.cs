using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class RoguePoisonEffect : StatusEffect
    {
        private int _moveCounter;

        public RoguePoisonEffect()
        {
            description = "Poison: damage increases each turn (+1, +2, +3...)";
            duration = -1;
        }

        public override DamageResult OnAttack(Entity owner, Entity target, DamageResult damage)
        {
            var result = damage.Clone();
            _moveCounter++;
            result.Add(DamageType.Poisoning, _moveCounter - 1);
            return result;
        }
    }
}