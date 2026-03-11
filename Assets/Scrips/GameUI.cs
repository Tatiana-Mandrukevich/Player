using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _image;

    private void Start()
    {
        _menu.SetActive(false);
        _toggle.isOn = false;
    }

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(OnMenuClick);
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _inputField.onValueChanged.AddListener(OnInputFieldChanged);
        _toggle.onValueChanged.AddListener(OnToggleChange);
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(OnMenuClick);
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        _inputField.onValueChanged.RemoveListener(OnInputFieldChanged);
        _toggle.onValueChanged.RemoveListener(OnToggleChange);
    }

    private void OnMenuClick()
    {
        _menu.SetActive(!_menu.activeSelf);
    }
    
    private void OnVolumeChanged(float value)
    {
        Debug.Log($"Volume changed to {value}");
    }
    
    private void OnInputFieldChanged(string text)
    {
        Debug.Log($"Input field changed to {text}");
    }
    
    private void OnToggleChange(bool value)
    {
        Debug.Log($"Toggle changed to {value}");
    }
}