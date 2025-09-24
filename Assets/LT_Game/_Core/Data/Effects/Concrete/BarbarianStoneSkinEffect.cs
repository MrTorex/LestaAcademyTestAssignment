using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class BarbarianStoneSkinEffect : StatusEffect
    {
        public BarbarianStoneSkinEffect()
        {
            description = "Stone Skin: damage reduction equal to Endurance";
            duration = -1;
        }

        public override DamageResult OnDefend(Entity owner, Entity attacker, DamageResult damage)
        {
            damage.Add(DamageType.Shield, damage.ResultDamage - owner.endurance >= 0 
                ? -owner.endurance 
                :  -damage.ResultDamage);
            return damage;
        }
    }
}