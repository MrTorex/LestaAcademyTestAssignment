using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class NoDamageFromSlashingEffect : StatusEffect
    {
        public NoDamageFromSlashingEffect() =>
            description = "Takes no damage from slashing damage";
        
        public override DamageResult OnDefend(Entity owner, Entity attacker, DamageResult damage)
        {
            var result = damage.Clone();
            result.damageByTypeModifiers[DamageType.Slashing] = 0;
            return result;
        }
    }
}