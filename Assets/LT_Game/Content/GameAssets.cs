using System;
using UnityEngine;

namespace LT_Game.Content
{
    [CreateAssetMenu]
    public class GameAssets : ScriptableObject
    {
        [Header("Sprites")]
        
        [Header("Enemies")]
        public Sprite goblinSprite;
        public Sprite skeletonSprite;
        public Sprite slimeSprite;
        public Sprite ghostSprite;
        public Sprite golemSprite;
        public Sprite dragonSprite;
        
        [Header("Weapons")]
        public Sprite swordSprite;
        public Sprite clubSprite;
        public Sprite daggerSprite;
        public Sprite axeSprite;
        public Sprite spearSprite;
        public Sprite legendarySwordSprite;
    
        [Header("Audio")]
        [Header("Music")]
        public AudioClip battleMusic;
        [Header("Sounds")]
        public AudioClip attackSound;
        public AudioClip victorySound;
        public AudioClip levelUpSound;
        
        public Sprite GetWeaponSprite(string weaponName) => 
            weaponName switch
            {
                "Sword" => swordSprite,
                "Club" => clubSprite,
                "Dagger" => daggerSprite,
                "Axe" => axeSprite,
                "Spear" => spearSprite,
                "Legendary Sword" => legendarySwordSprite,
                _ => throw new Exception($"No weapon sprite for: {weaponName}!")
            };
        
        public Sprite GetEnemySprite(string enemyName) => 
            enemyName switch
            {
                "Goblin" => goblinSprite,
                "Skeleton" => skeletonSprite,
                "Slime" => slimeSprite,
                "Ghost" => ghostSprite,
                "Golem" => golemSprite ,
                "Dragon" => dragonSprite,
                _ => throw new Exception($"No enemy sprite for: {enemyName}!")
            };
    }
}