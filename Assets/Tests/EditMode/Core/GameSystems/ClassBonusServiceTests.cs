using LT_Game.Core.Data;
using NUnit.Framework;
using LT_Game.Core.GameSystems;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Tests.EditMode.Core.GameSystems
{
    public class ClassBonusServiceTests
    {
        [Test]
        public void ApplyLevelBonus_WarriorLevel3_IncreasesStrengthBy1()
        {
            var player = new Player(baseHealth: 10, strength: 5, agility: 5, endurance: 5, 
                weapon: new Weapon("Sword", 3, DamageType.Slashing));
            
            ClassBonusService.ApplyLevelBonus(ClassType.Warrior, 3, player);
            
            Assert.AreEqual(6, player.Strength);
        }
    }
}