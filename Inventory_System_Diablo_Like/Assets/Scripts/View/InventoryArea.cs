using Assets.Models;
using Assets.Scripts.Models;
using Assets.Scripts.Providers;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class InventoryArea : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Image _helmetImage;

        [SerializeField]
        private Image _armourImage;

        [SerializeField]
        private Image _bootsImage;

        [SerializeField]
        private Image _beltImage;

        [SerializeField]
        private Image _glovesImage;

        [SerializeField]
        private Image _rightWeaponImage;

        [SerializeField]
        private Image _leftWeaponImage;

        [SerializeField]
        private Image _amuletOneImage;

        [SerializeField]
        private Image _amuletTwoImage;

        #endregion

        #region Methods

        private void Start()
        {
            InitializeView();
        }

        private void Update()
        {
            UpdateInventoryArea();
        }

        private void OnDestroy()
        {
            var playerModel = SetPlayerModel();
            playerModel.HelmetEquiped -= OnHelmetEquiped;
        }

        private void InitializeView() 
        { 

        }

        private void UpdateInventoryArea()
        {
            var playerModel = SetPlayerModel();
            playerModel.HelmetEquiped += OnHelmetEquiped;
            playerModel.ArmourEquiped += OnArmourEquiped;
            playerModel.BootsEquiped += OnBootsEquiped;
            playerModel.BeltEquiped += OnBeltEquiped;
            playerModel.GlovesEquiped += OnGlovesEquiped;
            playerModel.WeaponLeftEquiped += OnWeaponLeftEquiped;
            playerModel.WeaponRightEquiped += OnWeaponRightEquiped;
            playerModel.AmuletOneEquiped += OnAmuletOneEquiped;
            playerModel.AmuletTwoEquiped += OnAmuletTwoEquiped;
        }

        private void OnAmuletTwoEquiped(InventoryItemModel amuletTwo)
        {
            _amuletTwoImage.sprite = amuletTwo.Preview;
        }

        private void OnAmuletOneEquiped(InventoryItemModel amulet)
        {
            _amuletOneImage.sprite = amulet.Preview;
        }

        private void OnWeaponRightEquiped(InventoryItemModel rightWeapon)
        {
            _rightWeaponImage.sprite = rightWeapon.Preview;
        }

        private void OnWeaponLeftEquiped(InventoryItemModel leftWeapon)
        {
            _leftWeaponImage.sprite = leftWeapon.Preview;
        }

        private void OnGlovesEquiped(InventoryItemModel gloves)
        {
            _glovesImage.sprite = gloves.Preview;
        }

        private void OnBeltEquiped(InventoryItemModel belt)
        {
            _beltImage.sprite = belt.Preview;
        }

        private void OnBootsEquiped(InventoryItemModel boots)
        {
            _bootsImage.sprite = boots.Preview;
        }

        private void OnArmourEquiped(InventoryItemModel armour)
        {
            _armourImage.sprite = armour.Preview;
        }

        private void OnHelmetEquiped(InventoryItemModel helmet)
        {
            _helmetImage.sprite = helmet.Preview;
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            return playerModel;
        }

        #endregion
    }
}
