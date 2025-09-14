using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.GameSystems
{
    public static class EnemyFactory
    {
        public static Enemy CreateGoblin() =>
            new(
                name: "Гоблин",
                baseHealth: 5,
                strength: 1,
                agility: 1,
                endurance: 1,
                baseDamage: 2,
                lootWeapon: WeaponFactory.CreateDagger(),
                specialAbility: ""
                );
        
        public static Enemy CreateSkeleton() =>
            new(
                name: "Скелет",
                baseHealth: 10,
                strength: 2,
                agility: 2,
                endurance: 2,
                baseDamage: 2,
                lootWeapon: WeaponFactory.CreateClub(),
                specialAbility: "Получает вдвое больше урона от дробящего оружия"
                );
        
        public static Enemy CreateSlime() =>
            new(
                name: "Слайм",
                baseHealth: 8,
                strength: 3,
                agility: 1,
                endurance: 2,
                baseDamage: 1,
                lootWeapon: WeaponFactory.CreateSpear(),
                specialAbility: "Рубящее оружие не наносит урона"
                );
        
        public static Enemy CreateGhost() =>
            new(
                name: "Призрак",
                baseHealth: 6,
                strength: 1,
                agility: 3,
                endurance: 1,
                baseDamage: 3,
                lootWeapon: WeaponFactory.CreateSword(),
                specialAbility: "Скрытая атака"
                );
        
        public static Enemy CreateGolem() =>
            new(
                name: "Голем",
                baseHealth: 10,
                strength: 3,
                agility: 1,
                endurance: 3,
                baseDamage: 1,
                lootWeapon: WeaponFactory.CreateAxe(),
                specialAbility: "Каменная кожа"
                );
        
        public static Enemy CreateDragon() =>
            new(
                name: "Дракон",
                baseHealth: 20,
                strength: 3,
                agility: 3,
                endurance: 3,
                baseDamage: 4,
                lootWeapon: WeaponFactory.CreateAxe(),
                specialAbility: "Каждый 3-ий ход дышит огнём, нанося дополнительно 3 урона"
                );
    }
}