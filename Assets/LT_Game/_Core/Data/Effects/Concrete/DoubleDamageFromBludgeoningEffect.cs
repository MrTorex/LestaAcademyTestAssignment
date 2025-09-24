using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class DoubleDamageFromBludgeoningEffect : StatusEffect
    {
        public DoubleDamageFromBludgeoningEffect() =>
            description = "Takes double damage from bludgeoning damage";
        
        public override DamageResult OnDefend(Entity owner, Entity attacker, DamageResult damage)
        {
            damage.damageByTypeModifiers[DamageType.Bludgeoning] = 2;
            return damage;
        }
    }
}