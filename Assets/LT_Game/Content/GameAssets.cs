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
        
        public AudioClip rogue;
        public AudioClip warrior;
        public AudioClip barbarian;
        
        public AudioClip playerAttack;
        public AudioClip playerDefend;
        public AudioClip playerDeath;
        
        public AudioClip goblinAttack;
        public AudioClip goblinDefend;
        public AudioClip goblinDeath;
        
        public AudioClip skeletonAttack;
        public AudioClip skeletonDefend;
        public AudioClip skeletonDeath;
        
        public AudioClip slimeAttack;
        public AudioClip slimeDefend;
        public AudioClip slimeDeath;
        
        public AudioClip ghostAttack;
        public AudioClip ghostDefend;
        public AudioClip ghostDeath;
        
        public AudioClip golemAttack;
        public AudioClip golemDefend;
        public AudioClip golemDeath;
        
        public AudioClip dragonAttack;
        public AudioClip dragonDefend;
        public AudioClip dragonDeath;
        
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

        public AudioClip GetEnemyAudioClip(string enemyName, string state)
        {
            return (enemyName, state) switch
            {
                ("Goblin", "Attack") => goblinAttack,
                ("Goblin", "Defend") => goblinDefend,
                ("Goblin", "Death") => goblinDeath,
        
                ("Skeleton", "Attack") => skeletonAttack,
                ("Skeleton", "Defend") => skeletonDefend,
                ("Skeleton", "Death") => skeletonDeath,
        
                ("Slime", "Attack") => slimeAttack,
                ("Slime","Defend") => slimeDefend,
                ("Slime","Death") => slimeDeath,
                
                ("Ghost", "Attack") => ghostAttack,
                ("Ghost","Defend") => ghostDefend,
                ("Ghost","Death") => ghostDeath,
                
                ("Golem", "Attack") => golemAttack,
                ("Golem","Defend") => golemDefend,
                ("Golem","Death") => golemDeath,
                
                ("Dragon", "Attack") => dragonAttack,
                ("Dragon","Defend") => dragonDefend,
                ("Dragon","Death") => dragonDeath,
        
                _ => throw new Exception($"No AudioClip {state} for {enemyName}!")
            };
        }
    }
}