using TMPro;
using UnityEngine;

public sealed class UiManager : MonoBehaviour, IInitializable
{
    [SerializeField] private TMP_Text totalMoneyText;
    [SerializeField] private string totalFormatMoneyText;

    [SerializeField] private TMP_Text gameMoneyText;
    [SerializeField] private string gameFormatMoneyText;

    private GameManager _gameManager;


    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;

        _gameManager.MoneyRepository.onMoneyChanged += UpdateMoney;

        UpdateMoney();
    }

    private void UpdateMoney()
    {
        totalMoneyText.text = string.Format(totalFormatMoneyText, _gameManager.MoneyRepository.Money);
        gameMoneyText.text = string.Format(gameFormatMoneyText, _gameManager.MoneyRepository.MoneyForOnePlay);
    }
}