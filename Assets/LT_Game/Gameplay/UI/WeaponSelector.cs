using LT_Game.Gameplay.UI.Animators;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private Button weaponOldButton;
        public Button WeaponOldButton => weaponOldButton;
        [SerializeField] private Button weaponNewButton;
        public Button WeaponNewButton => weaponNewButton;
        
        public WeaponSelectorAnimator animator {get; private set;}

        private void Start()
        {
            animator = GetComponent<WeaponSelectorAnimator>();
        }

        public void Enable() => 
            gameObject.SetActive(true);
        
        public void Disable() =>
            gameObject.SetActive(false);
    }
}