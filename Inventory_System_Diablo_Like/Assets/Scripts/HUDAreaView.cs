using Assets.Models;
using Assets.Scripts.Inputs;
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

    //[SerializeField]
    //private quick access array something

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
    }

    private void UpdateView()
    {
        var playerModel = SetPlayerModel();
        _healthBar.value = playerModel.GetHealth;
        _manaBar.value = playerModel.GetMana;
    }

    private void OnManaChanged(int manaParam)
    {
        UpdateView();
    }

    private void OnHealthChanged(int healthParam)
    {
        UpdateView();
    }

    #endregion

}
