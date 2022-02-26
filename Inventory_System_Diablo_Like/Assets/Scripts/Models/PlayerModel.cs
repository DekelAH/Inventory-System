using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models
{
    [CreateAssetMenu(menuName = "Inventory/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<int> HealthChanged;
        public event Action<int> ManaChanged;
        public event Action<int> ArmourChanged;

        public event Action<InventoryItemModel> HelmetEquiped;
        public event Action<InventoryItemModel> ArmourEquiped;
        public event Action<InventoryItemModel> WeaponLeftEquiped;
        public event Action<InventoryItemModel> WeaponRightEquiped;
        public event Action<InventoryItemModel> BootsEquiped;
        public event Action<InventoryItemModel> BeltEquiped;
        public event Action<InventoryItemModel> GlovesEquiped;
        public event Action<InventoryItemModel> AmuletOneEquiped;
        public event Action<InventoryItemModel> AmuletTwoEquiped;

        public event Action<InventoryItemModel> ConsumableItemOneEquiped;
        public event Action<InventoryItemModel> ConsumableItemTwoEquiped;
        public event Action<InventoryItemModel> ConsumableItemThreeEquiped;
        public event Action<InventoryItemModel> ConsumableItemFourEquiped;

        #endregion

        #region Editor

        [SerializeField]
        private int _health;

        [SerializeField]
        private int _mana;

        [SerializeField]
        private int _armour;


        [SerializeField]
        private List<InventoryItemModel> _stashItems;


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


        [SerializeField]
        private InventoryItemModel _cosumableItemOne;

        [SerializeField]
        private InventoryItemModel _cosumableItemTwo;

        [SerializeField]
        private InventoryItemModel _cosumableItemThree;

        [SerializeField]
        private InventoryItemModel _cosumableItemFour;

        #endregion

        #region Fields

        private List<InventoryItemModel> _consumableItems;

        #endregion

        #region Methods

        public void RestartEquipedItems()
        {
            _equipedRightWeapon = null;
            _equipedLeftWeapon = null;
            _equipedArmour = null;
            _equipedHelmet = null;
            _equipedGloves = null;
            _equipedBoots = null;
            _equipedBelt = null;
            _equipedAmuletOne = null;
            _equipedAmuletTwo = null;
            _cosumableItemOne = null;
            _cosumableItemTwo = null;
            _cosumableItemThree = null;
            _cosumableItemFour = null;
        }

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
                var randomItemIndex = random.Next(_stashItems.Count);

                switch (_stashItems[randomItemIndex].Type)
                {
                    case ItemType.Weapon:
                        if (_equipedLeftWeapon == null)
                        {
                            _equipedLeftWeapon = _stashItems[randomItemIndex];
                            WeaponLeftEquiped?.Invoke(_equipedLeftWeapon);
                            return;
                        }
                        else if (_equipedRightWeapon == null)
                        {
                            _equipedRightWeapon = _stashItems[randomItemIndex];
                            WeaponRightEquiped?.Invoke(_equipedRightWeapon);
                        }
                        break;
                    case ItemType.Armour:
                        if (_equipedArmour == null)
                        {
                            _equipedArmour = _stashItems[randomItemIndex];
                            ArmourEquiped?.Invoke(_equipedArmour);
                            ArmourChanged?.Invoke(_armour += _equipedArmour.Parameter);
                        }
                        break;
                    case ItemType.Helmet:
                        if (_equipedHelmet == null)
                        {
                            _equipedHelmet = _stashItems[randomItemIndex];
                            HelmetEquiped?.Invoke(_equipedHelmet);
                            ArmourChanged?.Invoke(_armour += _equipedHelmet.Parameter);
                        }
                        break;
                    case ItemType.Boots:
                        if (_equipedBoots == null)
                        {
                            _equipedBoots = _stashItems[randomItemIndex];
                            BootsEquiped?.Invoke(_equipedBoots);
                            ArmourChanged?.Invoke(_armour += _equipedBoots.Parameter);
                        }
                        break;
                    case ItemType.Belt:
                        if (_equipedBelt == null)
                        {
                            _equipedBelt = _stashItems[randomItemIndex];
                            BeltEquiped?.Invoke(_equipedBelt);
                            ArmourChanged?.Invoke(_armour += _equipedBelt.Parameter);
                        }
                        break;
                    case ItemType.Gloves:
                        if (_equipedGloves == null)
                        {
                            _equipedGloves = _stashItems[randomItemIndex];
                            GlovesEquiped?.Invoke(_equipedGloves);
                            ArmourChanged?.Invoke(_armour += _equipedGloves.Parameter);
                        }
                        break;
                    case ItemType.Jewelry:
                        if (_equipedAmuletOne == null)
                        {
                            _equipedAmuletOne = _stashItems[randomItemIndex];
                            AmuletOneEquiped?.Invoke(_equipedAmuletOne);
                            return;
                        }
                        else if (_equipedAmuletTwo == null)
                        {
                            _equipedAmuletTwo = _stashItems[randomItemIndex];
                            AmuletTwoEquiped?.Invoke(_equipedAmuletTwo);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetConsumableItemsList()
        {
            foreach (var item in _stashItems)
            {
                switch (item.Type)
                {
                    case ItemType.Consumable:
                        _consumableItems.Add(item);
                        break;
                }
            }
        }

        public void EquipQuickAccessSlotOne()
        {
            var randomConsumableItemIndex = ReturnRandomConsumableItemIndex();

            if (_cosumableItemOne == null)
            {
                _cosumableItemOne = _consumableItems[randomConsumableItemIndex];
                if (_cosumableItemOne.Name == "Mana")
                {
                    _mana += _cosumableItemOne.Parameter;
                }
                else if (_cosumableItemOne.Name == "Hp")
                {
                    _health += _cosumableItemOne.Parameter;
                }

                ConsumableItemOneEquiped?.Invoke(_cosumableItemOne);
            }
            else
            {
                return;
            }
        }

        public void EquipQuickAccessSlotTwo()
        {
            var randomConsumableItemIndex = ReturnRandomConsumableItemIndex();

            if (_cosumableItemTwo == null)
            {
                _cosumableItemTwo = _consumableItems[randomConsumableItemIndex];
                if (_cosumableItemTwo.Name == "Mana")
                {
                    _mana += _cosumableItemTwo.Parameter;
                }
                else if (_cosumableItemTwo.Name == "Hp")
                {
                    _health += _cosumableItemTwo.Parameter;
                }

                ConsumableItemTwoEquiped?.Invoke(_cosumableItemTwo);
            }
            else
            {
                return;
            }
        }

        public void EquipQuickAccessSlotThree()
        {
            var randomConsumableItemIndex = ReturnRandomConsumableItemIndex();

            if (_cosumableItemThree == null)
            {
                _cosumableItemThree = _consumableItems[randomConsumableItemIndex];
                if (_cosumableItemThree.Name == "Mana")
                {
                    _mana += _cosumableItemThree.Parameter;
                }
                else if (_cosumableItemThree.Name == "Hp")
                {
                    _health += _cosumableItemThree.Parameter;
                }

                ConsumableItemThreeEquiped?.Invoke(_cosumableItemThree);
            }
            else
            {
                return;
            }
        }

        public void EquipQuickAccessSlotFour()
        {
            var randomConsumableItemIndex = ReturnRandomConsumableItemIndex();

            if (_cosumableItemFour == null)
            {
                _cosumableItemFour = _consumableItems[randomConsumableItemIndex];
                if (_cosumableItemFour.Name == "Mana")
                {
                    _mana += _cosumableItemFour.Parameter;
                }
                else if (_cosumableItemFour.Name == "Hp")
                {
                    _health += _cosumableItemFour.Parameter;
                }

                ConsumableItemFourEquiped?.Invoke(_cosumableItemFour);
            }
            else
            {
                return;
            }
        }

        private int ReturnRandomConsumableItemIndex()
        {
            System.Random random = new System.Random();
            var randomConsumableItemIndex = random.Next(_consumableItems.Count);

            return randomConsumableItemIndex;
        }

        #endregion

        #region Properties

        public int GetHealth => _health;
        public int GetMana => _mana;
        public int GetArmour => _armour;
        public List<InventoryItemModel> StashItems => _stashItems;
        public InventoryItemModel EquipedRightWeapon => _equipedRightWeapon;
        public InventoryItemModel EquipedLeftWeapon => _equipedLeftWeapon;
        public InventoryItemModel EquipedArmour => _equipedArmour;
        public InventoryItemModel EquipedHelmet => _equipedHelmet;
        public InventoryItemModel EquipedGloves => _equipedGloves;
        public InventoryItemModel EquipedBoots => _equipedBoots;
        public InventoryItemModel EquipedBelt => _equipedBelt;
        public InventoryItemModel EquipedAmuletOne => _equipedAmuletOne;
        public InventoryItemModel EquipedAmuletTwo => _equipedAmuletTwo;

        #endregion
    }
}
