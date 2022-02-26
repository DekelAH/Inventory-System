using Assets.Models;
using Assets.Scripts.Inputs;
using Assets.Scripts.Models;
using Assets.Scripts.Providers;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDAreaView : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Slider _healthBar;

    [SerializeField]
    private Slider _armourBar;

    [SerializeField]
    private Slider _manaBar;

    [SerializeField]
    private Image _quickAccessSlotOne;

    [SerializeField]
    private Image _quickAccessSlotTwo;

    [SerializeField]
    private Image _quickAccessSlotThree;

    [SerializeField]
    private Image _quickAccessSlotFour;

    #endregion

    #region Methods

    private void Start()
    {
        SubscribeToEvents();
        UpdateView();
    }

    private void OnDestroy()
    {
        var playerModel = SetPlayerModel();
        playerModel.HealthChanged -= OnHealthChanged;
        playerModel.ManaChanged -= OnManaChanged;
    }


    private PlayerModel SetPlayerModel()
    {
        var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
        return playerModel;
    }

    private void SubscribeToEvents()
    {
        var playerModel = SetPlayerModel();
        playerModel.HealthChanged += OnHealthChanged;
        playerModel.ManaChanged += OnManaChanged;
        playerModel.ArmourChanged += OnArmourChanged;

        playerModel.ConsumableItemOneEquiped += OnConsumableItemSlotOneEquiped;
        playerModel.ConsumableItemTwoEquiped += OnConsumableItemSlotTwoEquiped;
        playerModel.ConsumableItemThreeEquiped += OnConsumableItemSlotThreeEquiped;
        playerModel.ConsumableItemFourEquiped += OnConsumableItemSlotFourEquiped;
    }

    private void OnConsumableItemSlotFourEquiped(InventoryItemModel consumableItemFour)
    {
        _quickAccessSlotFour.sprite = consumableItemFour.Preview;
        UpdateView();
    }

    private void OnConsumableItemSlotThreeEquiped(InventoryItemModel consumableItemThree)
    {
        _quickAccessSlotThree.sprite = consumableItemThree.Preview;
        UpdateView();
    }

    private void OnConsumableItemSlotTwoEquiped(InventoryItemModel consumableItemTwo)
    {
        _quickAccessSlotTwo.sprite = consumableItemTwo.Preview;
        UpdateView();
    }

    private void OnConsumableItemSlotOneEquiped(InventoryItemModel consumableItemOne)
    {
        _quickAccessSlotOne.sprite = consumableItemOne.Preview;
        UpdateView();
    }

    private void UpdateView()
    {
        var playerModel = SetPlayerModel();

        _healthBar.value = playerModel.GetHealth;
        _manaBar.value = playerModel.GetMana;
        _armourBar.value = playerModel.GetArmour;
    }

    private void OnManaChanged(int manaParam)
    {
        UpdateView();
    }

    private void OnHealthChanged(int healthParam)
    {
        UpdateView();
    }

    private void OnArmourChanged(int armourParam)
    {
        UpdateView();
    }

    #endregion

}
