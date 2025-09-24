using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class RogueStealthAttackEffect : StatusEffect
    {
        private const int DamageBonus = 1;
        
        public RogueStealthAttackEffect() =>
            duration = -1;

        public override int OnAttack(Entity owner, Entity defender, int damage) =>
            owner.agility > defender.agility
            ?  damage + DamageBonus
            : damage;
    }
}