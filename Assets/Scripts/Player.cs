using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Application.targetFrameRate = 60;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private List<Question> _questions;
    [SerializeField] private ResultView _resultView;

    private IInteractable _currentIteract = null;

    private bool _hasKey = false;

    public int MoneyCount { get; private set; } = 0;

    private void OnEnable()
    {
        foreach (var question in _questions)
        {
            question.RightAnswer += AddCoin;
        }
    }

    private void OnDisable()
    {
        foreach (var question in _questions)
        {
            question.RightAnswer -= AddCoin;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentIteract != null)
            {
                if (_currentIteract is Door)
                {
                    if (_hasKey)
                    {
                        _currentIteract.Interact();
                    }
                }
                else if (_currentIteract is Exit)
                {
                    _resultView.gameObject.SetActive(true);
                    _resultView.ShowResult(MoneyCount);
                }
                else
                {
                    _currentIteract.Interact();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            _currentIteract = interactable;

            if (_currentIteract is Key)
            {
                _currentIteract.Interact();
                _hasKey = true;
            }
            else if (_currentIteract is Coin)
            {
                _currentIteract.Interact();
                AddCoin();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            _currentIteract = null;
        }
    }

    public void AddCoin()
    {
        MoneyCount++;
        _text.text = MoneyCount.ToString();
    }
}
