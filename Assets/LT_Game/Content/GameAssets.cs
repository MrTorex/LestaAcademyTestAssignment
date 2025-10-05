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
        
        [Header("EndScreens")]
        public Sprite winScreenSprite;
        public Sprite deathScreenSprite;
        
        [Header("Audio")]
        [Header("Music")]
        public AudioClip mainMenu;
        public AudioClip battle1;
        public AudioClip battle2;
        public AudioClip battle3;
        public AudioClip victory;
        public AudioClip death;
        
        [Header("SFXs")]
        public AudioClip playButton;
        
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