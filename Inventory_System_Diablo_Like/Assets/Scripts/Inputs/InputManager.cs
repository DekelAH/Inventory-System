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

        private const string ADD_HEALTH_KEY = "=";
        private const string DECREASE_HEALTH_KEY = "-";
        private const string ADD_MANA_KEY = "[";
        private const string DECREASE_MANA_KEY = "]";

        private const KeyCode OPEN_INVENTORY = KeyCode.I;
        private const KeyCode ADD_RANDOM_ITEMS = KeyCode.Space;
        private const string QUICK_ACCESS_SLOT_ONE = "1";
        private const string QUICK_ACCESS_SLOT_TWO = "2";
        private const string QUICK_ACCESS_SLOT_THREE = "3";
        private const string QUICK_ACCESS_SLOT_FOUR = "4";

        #endregion

        #region Metods

        private void Update()
        {
            HealthHandler();
            ManaHandler();
            InventoryAreaHandler();
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
        private void AddRandomItemToInventory()
        {
            if (Input.GetKeyDown(ADD_RANDOM_ITEMS))
            {

            }
        }

        private void InventoryAreaHandler()
        {
            if (Input.GetKeyDown(OPEN_INVENTORY))
            {
                _inventoryWindow.gameObject.SetActive(!_inventoryWindow.gameObject.activeSelf);
            }
        }

        private void AssignToQuickAccessSlots()
        {
            switch ("")
            {
                default:
                    break;
            }
        }

        #endregion
    }
}
