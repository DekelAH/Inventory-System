using Assets.Models;
using Assets.Scripts.Providers;
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

        #endregion

        #region Consts

        private const string ADD_HEALTH_KEY = "=";
        private const string DECREASE_HEALTH_KEY = "-";
        private const string ADD_MANA_KEY = "[";
        private const string DECREASE_MANA_KEY = "]";

        #endregion

        #region Metods

        private void Update()
        {
            HealthHandler();
            ManaHandler();
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            return playerModel;
        }

        public void HealthHandler()
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

        public void ManaHandler()
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

        #endregion
    }
}
