using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class WarriorFirstStrikeEffect : StatusEffect
    {
        private bool _firstTurn = true;

        public WarriorFirstStrikeEffect() =>
            duration = -1;

        public override int OnAttack(Entity owner, Entity target, int damage)
        {
            if (!_firstTurn)
                return damage;
            
            _firstTurn = false;
            return damage * 2;
        }
    }
}