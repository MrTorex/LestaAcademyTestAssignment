using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class AgilityBuffEffect : StatusEffect
    {
        private readonly int _agilityBonus;
        
        public AgilityBuffEffect(int agilityBonus, int bonusDuration)
        {
            _agilityBonus = agilityBonus;
            duration = bonusDuration;
        }

        public override void OnApply(Entity target) =>
            target.agility += _agilityBonus;
        
        public override void OnRemove(Entity target) =>
            target.agility -= _agilityBonus;
    }
}