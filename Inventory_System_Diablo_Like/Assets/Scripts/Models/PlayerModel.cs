using Assets.Scripts.Models;
using System;
using UnityEngine;

namespace Assets.Models
{
    [CreateAssetMenu(menuName = "Inventory/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<int> HealthChanged;
        public event Action<int> ManaChanged;
        public event Action<InventoryItemModel> HelmetEquiped;
        public event Action<InventoryItemModel> ArmourEquiped;
        public event Action<InventoryItemModel> WeaponLeftEquiped;
        public event Action<InventoryItemModel> WeaponRightEquiped;
        public event Action<InventoryItemModel> BootsEquiped;
        public event Action<InventoryItemModel> BeltEquiped;
        public event Action<InventoryItemModel> GlovesEquiped;
        public event Action<InventoryItemModel> AmuletOneEquiped;
        public event Action<InventoryItemModel> AmuletTwoEquiped;

        #endregion

        #region Editor

        [SerializeField]
        private int _health;

        [SerializeField]
        private int _mana;

        [SerializeField]
        private int _armour;

        [SerializeField]
        private InventoryItemModel[] _inventoryItems;

        [SerializeField]
        private InventoryItemModel _equipedRightWeapon;

        [SerializeField]
        private InventoryItemModel _equipedLeftWeapon;

        [SerializeField]
        private InventoryItemModel _equipedArmour;

        [SerializeField]
        private InventoryItemModel _equipedHelmet;

        [SerializeField]
        private InventoryItemModel _equipedGloves;

        [SerializeField]
        private InventoryItemModel _equipedBoots;

        [SerializeField]
        private InventoryItemModel _equipedBelt;

        [SerializeField]
        private InventoryItemModel _equipedAmuletOne;

        [SerializeField]
        private InventoryItemModel _equipedAmuletTwo;

        #endregion

        #region Methods

        public void IncreaseHealth(int health)
        {
            _health += health;
            HealthChanged?.Invoke(_health);
        }

        public void DecreaseHealth(int health)
        {
            if (health <= _health)
            {
                _health = Mathf.Max(0, _health - health);
                ManaChanged?.Invoke(_health);
            }
        }

        public void IncreaseMana(int mana)
        {
            _mana += mana;
            ManaChanged?.Invoke(_mana);
        }

        public void DecreaseMana(int mana)
        {
            if (mana <= _mana)
            {
                _mana = Mathf.Max(0, _mana - mana);
                ManaChanged?.Invoke(_mana);
            }
            else
            {
                Debug.Log("Not Enough Mana!");
            }          
        }

        public void EquipRandomItemFromStash()
        {
            for (int i = 0; i < 9; i++)
            {
                System.Random random = new System.Random();
                var randomItem = random.Next(_inventoryItems.Length);

                switch (_inventoryItems[randomItem].Type)
                {
                    case ItemType.Weapon:
                        if (_equipedLeftWeapon == null)
                        {
                            _equipedLeftWeapon = _inventoryItems[randomItem];
                            WeaponLeftEquiped?.Invoke(_equipedLeftWeapon);
                            return;
                        }
                        else if (_equipedRightWeapon == null)
                        {
                            _equipedRightWeapon = _inventoryItems[randomItem];
                            WeaponRightEquiped?.Invoke(_equipedRightWeapon);
                        }
                        break;
                    case ItemType.Armour:
                        if (_equipedArmour == null)
                        {
                            _equipedArmour = _inventoryItems[randomItem];
                            ArmourEquiped?.Invoke(_equipedArmour);
                        }
                        break;
                    case ItemType.Helmet:
                        if (_equipedHelmet == null)
                        {
                            _equipedHelmet = _inventoryItems[randomItem];
                            HelmetEquiped?.Invoke(_equipedHelmet);
                        }
                        break;
                    case ItemType.Boots:
                        if (_equipedBoots == null)
                        {
                            _equipedBoots = _inventoryItems[randomItem];
                            BootsEquiped?.Invoke(_equipedBoots);
                        }
                        break;
                    case ItemType.Belt:
                        if (_equipedBelt == null)
                        {
                            _equipedBelt = _inventoryItems[randomItem];
                            BeltEquiped?.Invoke(_equipedBelt);
                        }
                        break;
                    case ItemType.Gloves:
                        if (_equipedGloves == null)
                        {
                            _equipedGloves = _inventoryItems[randomItem];
                            GlovesEquiped?.Invoke(_equipedGloves);
                        }
                        break;
                    case ItemType.Jewelry:
                        if (_equipedAmuletOne == null)
                        {
                            _equipedAmuletOne = _inventoryItems[randomItem];
                            AmuletOneEquiped?.Invoke(_equipedAmuletOne);
                            return;
                        }
                        else if (_equipedAmuletTwo == null)
                        {
                            _equipedAmuletTwo = _inventoryItems[randomItem];
                            AmuletTwoEquiped?.Invoke(_equipedAmuletTwo);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Properties

        public int GetHealth => _health;
        public int GetMana => _mana;
        public InventoryItemModel[] InventoryItems => _inventoryItems;

        #endregion
    }
}
