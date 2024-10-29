using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField] private List<Answer> _answers = new List<Answer>();
    [SerializeField] private int _currentAnswerID;
    [SerializeField] private GameObject _test;

    private Color _wrongColor = Color.red;
    private Color _rightColor = Color.green;

    public event Action WrongAnswer;
    public event Action RightAnswer;

    private void OnEnable()
    {
        foreach (var answer in _answers)
        {
            answer.OnButtonClicked += GetAnswer;
        }
    }

    private void OnDisable()
    {
        foreach (var answer in _answers)
        {
            answer.OnButtonClicked -= GetAnswer;
        }
    }

    private void GetAnswer(Answer answer)
    {
        if (answer._ID == _currentAnswerID)
        {
            answer.ChangeColor(_rightColor);
            RightAnswer?.Invoke();
            StartCoroutine(DelayedHide());
        }
        else
        {
            WrongAnswer?.Invoke();
            answer.ChangeColor(_wrongColor);
        }
    }

    private IEnumerator DelayedHide()
    {
        yield return new WaitForSeconds(1f);
        _test.SetActive(false);
    }
}
