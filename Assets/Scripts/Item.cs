using System;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private Button _interactButton;
    [SerializeField] private Test _test;
    [SerializeField] private QuestionData _questionData;

    private void OnEnable()
    {
        _interactButton.onClick.AddListener(Interact);
    }

    private void OnDisable()
    {
        _interactButton.onClick.RemoveListener(Interact);
    }

    public void Interact()
    {
        _test.Initialize(_questionData);
        _test.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _interactButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _interactButton.gameObject.SetActive(false);
        }
    }
}