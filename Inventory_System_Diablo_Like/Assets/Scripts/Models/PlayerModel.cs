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

        #endregion

        #region Editor

        [SerializeField]
        private int _health;

        [SerializeField]
        private int _mana;

        [SerializeField]
        private int _armour;

        //[SerializeField]
        //private InventoryItemModel[] _inventoryItems;

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

        #endregion

        #region Properties

        public int GetHealth => _health;
        public int GetMana => _mana;

        #endregion
    }
}
