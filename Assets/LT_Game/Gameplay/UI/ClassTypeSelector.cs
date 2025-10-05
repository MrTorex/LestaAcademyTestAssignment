using System.Collections.Generic;
using LT_Game._Core.Utilities;
using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;
using LT_Game.Gameplay.UI.Animators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class ClassTypeSelector : MonoBehaviour
    {
        [SerializeField] private Button classTypeRogueButton;
        public Button ClassTypeRogueButton => classTypeRogueButton;
        [SerializeField] private TMP_Text classTypeRogueButtonText;
        
        [SerializeField] private Button classTypeWarriorButton;
        public Button ClassTypeWarriorButton => classTypeWarriorButton;
        [SerializeField] private TMP_Text classTypeWarriorButtonText;
        
        [SerializeField] private Button classTypeBarbarianButton;
        public Button ClassTypeBarbarianButton => classTypeBarbarianButton;
        [SerializeField] private TMP_Text classTypeBarbarianButtonText;
        
        public ClassTypeSelectorAnimator animator {get; private set;}

        private void Start()
        {
            animator = GetComponent<ClassTypeSelectorAnimator>();
        }

        public void Enable() => 
            gameObject.SetActive(true);
        
        public void Disable() =>
            gameObject.SetActive(false);
        
        public void Initialize(Player player)
        {
            var rogueLevel = player.ClassLevels.GetValueOrDefault(ClassType.Rogue, 0);
            classTypeRogueButtonText.text = $"Rogue (Level {(rogueLevel + 1).ToRoman()})\n" +
                                            ClassBonusService.GetRogueBonusDescription(rogueLevel + 1);
            
            var warriorLevel = player.ClassLevels.GetValueOrDefault(ClassType.Warrior, 0);
            classTypeWarriorButtonText.text = $"Warrior (Level {(warriorLevel + 1).ToRoman()})\n" +
                                            ClassBonusService.GetWarriorBonusDescription(warriorLevel + 1);
            
            var barbarianLevel = player.ClassLevels.GetValueOrDefault(ClassType.Barbarian, 0);
            classTypeBarbarianButtonText.text = $"Barbarian (Level {(barbarianLevel + 1).ToRoman()})\n" +
                                            ClassBonusService.GetBarbarianBonusDescription(barbarianLevel + 1);
        }
        
        public void InitializeFirstTime()
        {
            classTypeRogueButtonText.text = $"Rogue (Level {1.ToRoman()})\n" +
                                            ClassBonusService.GetRogueBonusDescription(1);
            
            classTypeWarriorButtonText.text = $"Warrior (Level {1.ToRoman()})\n" +
                                              ClassBonusService.GetWarriorBonusDescription(1);
            
            classTypeBarbarianButtonText.text = $"Barbarian (Level {1.ToRoman()})\n" +
                                                ClassBonusService.GetBarbarianBonusDescription(1);
        }
    }
}