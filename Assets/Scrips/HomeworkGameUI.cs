using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeworkGameUI : MonoBehaviour
{
    private const int PLAYER_LIFE = 5;
    
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _damageHealthBarButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private Image _healthBar;
    
    private string _playerName;
    private int _currentPlayerLife = PLAYER_LIFE;

    private void Start()
    {
        _menu.SetActive(false);
    }

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(OnMenuClick);
        _continueButton.onClick.AddListener(OnContinueClick);
        _damageHealthBarButton.onClick.AddListener(OnDamageHealthBarClick);
        _nameInputField.onValueChanged.AddListener(OnInputFieldChanged);
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(OnMenuClick);
        _continueButton.onClick.RemoveListener(OnContinueClick);
        _damageHealthBarButton.onClick.RemoveListener(OnDamageHealthBarClick);
        _nameInputField.onValueChanged.RemoveListener(OnInputFieldChanged);
    }

    private void OnMenuClick()
    {
        _menu.SetActive(!_menu.activeSelf);
    }
    
    private void OnInputFieldChanged(string text)
    {
        _playerName = text.ToUpper();
    }
    
    private void OnContinueClick()
    {
        _menu.SetActive(false);
    }
    
    private void OnDamageHealthBarClick()
    {
        if (_currentPlayerLife > 0)
        {
            _currentPlayerLife--;
            float healthBarFillAmount = (float)_currentPlayerLife / PLAYER_LIFE;
            _healthBar.fillAmount = healthBarFillAmount;
            
            Debug.Log($"Player {_playerName} has taken damage, {_currentPlayerLife} life left");
        }
    }
}