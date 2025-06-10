using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnswerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _answerText;
    
    private Button _button;
    private Image _buttonImage; 
    
    public int ButtonID { get; private set; }
    
    public event Action<AnswerButton> OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleClick);
        Reset();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleClick);
    }

    public void Initialize(string answerText, int buttonID)
    {
        _answerText.text = answerText;
        ButtonID = buttonID;
    }

    public void Wrong()
    {
        _button.interactable = false;
        _buttonImage.color = Color.red; // Красим в красный
    }

    public void Correct()
    {
        _button.interactable = false;
        _buttonImage.color = Color.green; // Красим в зелёный
    }

    public void Reset()
    {
        _button.interactable = true;
        _buttonImage.color = Color.white; // Сбрасываем на белый
    }

    
    private void HandleClick()
    {
        OnClick?.Invoke(this);
    }
}