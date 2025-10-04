using LT_Game.Gameplay.UI.Animators;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class ClassTypeSelector : MonoBehaviour
    {
        [SerializeField] private Button classTypeRogueButton;
        public Button ClassTypeRogueButton => classTypeRogueButton;
        [SerializeField] private Button classTypeWarriorButton;
        public Button ClassTypeWarriorButton => classTypeWarriorButton;
        [SerializeField] private Button classTypeBarbarianButton;
        public Button ClassTypeBarbarianButton => classTypeBarbarianButton;
        
        public ClassTypeSelectorAnimator animator {get; private set;}

        private void Start()
        {
            animator = GetComponent<ClassTypeSelectorAnimator>();
        }

        public void Enable() => 
            gameObject.SetActive(true);
        
        public void Disable() =>
            gameObject.SetActive(false);
    }
}