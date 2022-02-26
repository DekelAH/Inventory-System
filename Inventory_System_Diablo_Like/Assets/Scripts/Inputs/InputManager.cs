using Assets.Models;
using Assets.Scripts.Providers;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Inputs
{
    public class InputManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private int _manaToTake;

        [SerializeField]
        private int _manaToAdd;

        [SerializeField]
        private int _healthToTake;

        [SerializeField]
        private int _healthToAdd;

        [SerializeField]
        private InventoryWindow _inventoryWindow;

        #endregion

        #region Consts

        private const KeyCode RESTART_EQUIPED_ITEMS = KeyCode.R;
        private const KeyCode OPEN_INVENTORY = KeyCode.I;
        private const KeyCode ADD_RANDOM_ITEM = KeyCode.Space;

        private const string ADD_HEALTH_KEY = "=";
        private const string DECREASE_HEALTH_KEY = "-";
        private const string ADD_MANA_KEY = "[";
        private const string DECREASE_MANA_KEY = "]";
        private const string QUICK_ACCESS_SLOT_ONE = "1";
        private const string QUICK_ACCESS_SLOT_TWO = "2";
        private const string QUICK_ACCESS_SLOT_THREE = "3";
        private const string QUICK_ACCESS_SLOT_FOUR = "4";

        #endregion

        #region Metods

        private void Start()
        {
            var playerModel = SetPlayerModel();
            playerModel.SetConsumableItemsList();
        }

        private void Update()
        {
            HealthHandler();
            ManaHandler();
            InventoryAreaHandler();
            EquipRandomItemToInventoryArea();
            AssignToQuickAccessSlots();
            RestartEquipedItems();
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            return playerModel;
        }

        private void HealthHandler()
        {
            if (Input.GetKeyDown(ADD_HEALTH_KEY))
            {
                var playerModel = SetPlayerModel();
                playerModel.IncreaseHealth(_healthToAdd);
            }
            else if (Input.GetKeyDown(DECREASE_HEALTH_KEY))
            {
                var playerModel = SetPlayerModel();
                playerModel.DecreaseHealth(_healthToTake);
            }
        }

        private void ManaHandler()
        {
            if (Input.GetKeyDown(ADD_MANA_KEY))
            {
                var playerModel = SetPlayerModel();
                playerModel.IncreaseMana(_manaToAdd);
            }
            else if (Input.GetKeyDown(DECREASE_MANA_KEY))
            {
                var playerModel = SetPlayerModel();
                playerModel.DecreaseMana(_manaToTake);
            }
        }

        private void InventoryAreaHandler()
        {
            if (Input.GetKeyDown(OPEN_INVENTORY))
            {
                _inventoryWindow.gameObject.SetActive(!_inventoryWindow.gameObject.activeSelf);
            }
        }

        private void EquipRandomItemToInventoryArea()
        {
            if (Input.GetKeyDown(ADD_RANDOM_ITEM))
            {
                var playerModel = SetPlayerModel();
                playerModel.EquipRandomItemFromStash();
            }
        }

        private void AssignToQuickAccessSlots()
        {
            var playerModel = SetPlayerModel();

            if (Input.GetKeyDown(QUICK_ACCESS_SLOT_ONE))
            {
                playerModel.EquipQuickAccessSlotOne();
            }
            else if (Input.GetKeyDown(QUICK_ACCESS_SLOT_TWO))
            {
                playerModel.EquipQuickAccessSlotTwo();
            }
            else if (Input.GetKeyDown(QUICK_ACCESS_SLOT_THREE))
            {
                playerModel.EquipQuickAccessSlotThree();
            }
            else if (Input.GetKeyDown(QUICK_ACCESS_SLOT_FOUR))
            {
                playerModel.EquipQuickAccessSlotFour();
            }
        }

        private void RestartEquipedItems()
        {
            var playerModel = SetPlayerModel();

            if (Input.GetKeyDown(RESTART_EQUIPED_ITEMS))
            {
                playerModel.RestartEquipedItems();
            }
        }

        #endregion
    }
}
