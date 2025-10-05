using LT_Game.Content;
using LT_Game.Core.Data;
using LT_Game.Gameplay.UI.Animators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private GameAssets assets;
        
        [SerializeField] private Button weaponOldButton;
        public Button WeaponOldButton => weaponOldButton;
        [SerializeField] private TMP_Text weaponOldButtonText;
        [SerializeField] private Image weaponOldButtonImage;
        
        
        [SerializeField] private Button weaponNewButton;
        public Button WeaponNewButton => weaponNewButton;
        [SerializeField] private TMP_Text weaponNewButtonText;
        [SerializeField] private Image weaponNewButtonImage;
        
        public WeaponSelectorAnimator animator {get; private set;}

        private void Start()
        {
            animator = GetComponent<WeaponSelectorAnimator>();
        }

        public void Enable() => 
            gameObject.SetActive(true);
        
        public void Disable() =>
            gameObject.SetActive(false);

        public void Initialize(Weapon oldWeapon, Weapon newWeapon)
        {
            weaponOldButtonImage.sprite = assets.GetWeaponSprite(oldWeapon.name);
            weaponOldButtonText.text = "Old\n" +
                                       $"Name: {oldWeapon.name}\n" +
                                       $"Damage Type: {oldWeapon.weaponDamageType}\n" +
                                       $"Damage: {oldWeapon.damage}";
            
            weaponNewButtonImage.sprite = assets.GetWeaponSprite(newWeapon.name);
            weaponNewButtonText.text = "New\n" +
                                       $"Name: {newWeapon.name}\n" +
                                       $"Damage Type: {newWeapon.weaponDamageType}\n" +
                                       $"Damage: {newWeapon.damage}";
        }
    }
}