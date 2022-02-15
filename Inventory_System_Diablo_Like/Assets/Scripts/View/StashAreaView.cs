﻿using UnityEngine;
using Assets.Models;
using Assets.Scripts.Buttons;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.View
{
    public class StashAreaView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private InventoryItemBtn _consumableItemBtnPrefabRef;

        [SerializeField]
        private InventoryItemBtn _jewelryItemBtnPrefabRef;

        [SerializeField]
        private InventoryItemBtn _armourItemBtnPrefabRef;  

        [SerializeField]
        private InventoryItemBtn _weaponItemBtnPrefabRef;

        [SerializeField]
        private RectTransform _parentRectTranform;

        [SerializeField]
        private PlayerModel _playerModel;

        #endregion

        #region Fields

        private InventoryItemBtn _currentSelectedBtn;

        private InventoryItemModel _currentSelectedItem;

        private List<InventoryItemBtn> _createdBtns = new List<InventoryItemBtn>();

        #endregion

        #region Methods

        private void Start()
        {
            CreatedItemsList();
        }

        private void OnDestroy()
        {
            foreach (var button in _createdBtns)
            {
                button.BtnClicked -= OnInventorybtnClicked;
            }
        }

        private void CreatedItemsList()
        {
            foreach (var inventoryItemModel in _playerModel.InventoryItems)
            {
                var buttonPrefabRef = (InventoryItemBtn)GetButtonPrefabByItemType(inventoryItemModel.Type);
                var inventoryButton = Instantiate(buttonPrefabRef, _parentRectTranform);
                inventoryButton.SetUpItemBtn(inventoryItemModel);
                inventoryButton.BtnClicked += OnInventorybtnClicked;
                        }
        }

        private void OnInventorybtnClicked(InventoryItemBtn btnSended, InventoryItemModel inventoryItemModel)
        {
            if (_currentSelectedBtn != null)
            {
                _currentSelectedBtn.DeselectItemBtn();
            }

            _currentSelectedBtn = btnSended;
            _currentSelectedBtn.SelectItemBtn();
        }

        private object GetButtonPrefabByItemType(ItemType type)
        {
            switch (type)
            {
                case ItemType.Consumable:
                    return _consumableItemBtnPrefabRef;
                case ItemType.Weapon:
                    return _weaponItemBtnPrefabRef;
                case ItemType.Armour:
                    return _armourItemBtnPrefabRef;
                case ItemType.Jewelry:
                    return _jewelryItemBtnPrefabRef;
                default:
                    throw new ArgumentException($"Item type {type} is not supported");
            }
        }

        #endregion
    }
}