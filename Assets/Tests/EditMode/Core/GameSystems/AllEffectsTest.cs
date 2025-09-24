using LT_Game.Core.Data;
using LT_Game.Core.Data.Effects.Concrete;
using NUnit.Framework;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;

namespace LT_Game.Tests
{
    [TestFixture]
    public class AllEffectsTest
    {
        [Test]
        public void TestSkeletonTakesDoubleBludgeoningDamage()
        {
            var skeleton = EnemyFactory.CreateSkeleton();
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateClub());
            
            var damage = player.CalculateDamage();
            var result = skeleton.effectManager.ModifyDefenseDamage(player, damage);
            
            Assert.Greater(result.ResultDamage, damage.ResultDamage, "Skeleton should take extra damage from bludgeoning weapons");
        }

        [Test]
        public void TestSlimeImmuneToSlashing()
        {
            var slime = EnemyFactory.CreateSlime();
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateSword());
            
            var damage = player.CalculateDamage();
            var result = slime.effectManager.ModifyDefenseDamage(player, damage);
            
            Assert.AreEqual(5, result.ResultDamage, "Slime should be completely immune to slashing damage");
        }

        [Test]
        public void TestGhostHasStealthAttack()
        {
            var ghost = EnemyFactory.CreateGhost();
            var player = new Player(10, 1, 1, 1, WeaponFactory.CreateDagger());
            
            var damage = ghost.CalculateDamage();
            var result = ghost.effectManager.ModifyAttackDamage(player, damage);
            
            Assert.Greater(result.ResultDamage, damage.ResultDamage, "Ghost should have stealth attack bonus against lower agility targets");
        }

        [Test]
        public void TestGolemHasStoneSkin()
        {
            var golem = EnemyFactory.CreateGolem();
            var player = new Player(20, 10, 5, 5, WeaponFactory.CreateAxe());
            
            var damage = player.CalculateDamage();
            var result = golem.effectManager.ModifyDefenseDamage(player, damage);
            
            Assert.Less(result.ResultDamage, damage.ResultDamage, "Golem should reduce damage with stone skin effect");
        }

        [Test]
        public void TestDragonFireBreath()
        {
            var dragon = EnemyFactory.CreateDragon();
            var player = new Player(30, 5, 5, 5, WeaponFactory.CreateSpear());
            
            for (var i = 0; i < 3; i++)
                dragon.effectManager.ProcessTurnStart();
            
            var damage = dragon.CalculateDamage();
            var result = dragon.effectManager.ModifyAttackDamage(player, damage);
            
            Assert.Greater(result.ResultDamage, damage.ResultDamage, "Dragon should have fire breath damage every 3rd turn");
        }
        
        [Test]
        public void TestBarbarianRageFirstTurns()
        {
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateAxe());
            var rage = new BarbarianRageEffect();
            player.effectManager.Add(rage);
            
            var baseDamage = player.CalculateDamage();
            var rageDamage = rage.OnAttack(player, null, baseDamage);
            
            Assert.Greater(rageDamage.ResultDamage, baseDamage.ResultDamage, "Rage should increase damage in first turns");
        }

        [Test]
        public void TestWarriorFirstStrike()
        {
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateSword());
            var firstStrike = new WarriorFirstStrikeEffect();
            player.effectManager.Add(firstStrike);
            
            var baseDamage = player.CalculateDamage();
            var firstStrikeDamage = firstStrike.OnAttack(player, null, baseDamage);
            
            Assert.Greater(firstStrikeDamage.ResultDamage, baseDamage.ResultDamage, "First strike should double weapon damage on first turn");
        }

        [Test]
        public void TestWarriorShieldAgainstWeakerEnemy()
        {
            var player = new Player(20, 10, 5, 5, WeaponFactory.CreateSword());
            var shield = new WarriorShieldEffect();
            player.effectManager.Add(shield);
            
            var weakEnemy = new Enemy("Test", 10, 5, 5, 5, 5, WeaponFactory.CreateDagger());
            var incomingDamage = new DamageResult();
            incomingDamage.Add(DamageType.Physical, 10);
            
            var shieldedDamage = shield.OnDefend(player, weakEnemy, incomingDamage);
            
            Assert.Less(shieldedDamage.ResultDamage, incomingDamage.ResultDamage, "Shield should reduce damage when player strength is higher");
        }

        [Test]
        public void TestRogueStealthAttackAgainstLowerAgility()
        {
            var player = new Player(20, 5, 10, 5, WeaponFactory.CreateDagger());
            var stealth = new RogueStealthAttackEffect();
            player.effectManager.Add(stealth);
            
            var lowAgilityEnemy = new Enemy("Test", 10, 5, 3, 5, 5, WeaponFactory.CreateClub());
            var baseDamage = player.CalculateDamage();
            var stealthDamage = stealth.OnAttack(player, lowAgilityEnemy, baseDamage);
            
            Assert.Greater(stealthDamage.ResultDamage, baseDamage.ResultDamage, "Stealth attack should bonus damage against lower agility");
        }

        [Test]
        public void TestRoguePoisonStacking()
        {
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateDagger());
            var poison = new RoguePoisonEffect();
            player.effectManager.Add(poison);
            
            var enemy = new Enemy("Test", 20, 5, 5, 5, 5, WeaponFactory.CreateClub());
            
            var turn1Damage = poison.OnAttack(player, enemy, new DamageResult());
            poison.OnTurnStart(player);
            
            var turn2Damage = poison.OnAttack(player, enemy, new DamageResult());
            poison.OnTurnStart(player);
            
            var turn3Damage = poison.OnAttack(player, enemy, new DamageResult());
            
            Assert.Greater(turn2Damage.ResultDamage, turn1Damage.ResultDamage, "Poison damage should increase each turn");
            Assert.Greater(turn3Damage.ResultDamage, turn2Damage.ResultDamage, "Poison damage should stack over time");
        }

        [Test]
        public void TestStrengthBuffEffect()
        {
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateSword());
            var strengthBuff = new StrengthBuffEffect(3, 1);
            player.effectManager.Add(strengthBuff);
            
            Assert.AreEqual(8, player.strength, "Strength buff should increase player strength");
        }

        [Test]
        public void TestAgilityBuffEffect()
        {
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateDagger());
            var agilityBuff = new AgilityBuffEffect(2, 1);
            player.effectManager.Add(agilityBuff);
            
            Assert.AreEqual(7, player.agility, "Agility buff should increase player agility");
        }

        [Test]
        public void TestEnduranceBuffEffect()
        {
            var player = new Player(20, 5, 5, 5, WeaponFactory.CreateClub());
            var enduranceBuff = new EnduranceBuffEffect(4, 1);
            player.effectManager.Add(enduranceBuff);
            
            Assert.AreEqual(9, player.endurance, "Endurance buff should increase player endurance");
        }
    }
}