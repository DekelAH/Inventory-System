using Assets.Scripts.Models;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Buttons
{
    [RequireComponent(typeof(Button))]
    public class InventoryItemBtn : MonoBehaviour
    {
        #region Events

        public event Action<InventoryItemBtn, InventoryItemModel> BtnClicked;

        #endregion

        #region Editor

        [SerializeField]
        private Image _itemPreviewImage;

        [SerializeField]
        private Image _btnImage;

        [SerializeField]
        private Sprite _selectedSprite;

        [SerializeField]
        private Sprite _notSelectedSprite;

        #endregion

        #region Fields

        private InventoryItemModel _modelData;

        #endregion

        #region Methods

        public void OnBtnClicked()
        {
            BtnClicked?.Invoke(this, _modelData);
        }

        public void SetUpItemBtn(InventoryItemModel modelData)
        {
            _modelData = modelData;
            _itemPreviewImage.sprite = modelData.Preview;
        }

        public void SelectItemBtn()
        {
            _btnImage.sprite = _selectedSprite;
        }

        public void DeselectItemBtn()
        {
            _btnImage.sprite = _notSelectedSprite;
        }

        #endregion
    }
}
