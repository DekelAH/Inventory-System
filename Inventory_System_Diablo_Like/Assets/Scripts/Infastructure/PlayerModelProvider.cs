using Assets.Models;
using UnityEngine;

namespace Assets.Scripts.Providers
{
    public class PlayerModelProvider
    {
        #region Fields

        private static PlayerModelProvider _instance;

        private static PlayerModel _playerModel;

        private const string PLAYER_MODEL_NAME = "Player Model";

        #endregion

        #region Constructors

        private PlayerModelProvider(string playerModel)
        {
            _playerModel = Resources.Load<PlayerModel>(playerModel);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider(PLAYER_MODEL_NAME);
                }

                return _instance;
            }
        }

        public PlayerModel GetPlayerModel => _playerModel;

        #endregion
    }
}
