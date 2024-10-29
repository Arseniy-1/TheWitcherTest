using System;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] private Button _answerButton;
    [SerializeField] private Sprite _pressedSprite;

    public int _ID;

    private Image _spriteRenderer;

    public event Action<Answer> OnButtonClicked;

    private void Awake()
    {
        _spriteRenderer = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _answerButton.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _answerButton.onClick.RemoveListener(OnClicked);
    }

    public void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private void OnClicked()
    {
        _spriteRenderer.sprite = _pressedSprite;
        OnButtonClicked?.Invoke(this);
        _answerButton.interactable = false;
    }
}