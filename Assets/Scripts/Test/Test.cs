using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.PlayerLoop;


public class Test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _question;

    [SerializeField] private List<AnswerButton> _answerButton;

    private List<string> _answers = new List<string>();
    private int _correntAnswerID;

    private void OnDestroy()
    {
        foreach (var answerButton in _answerButton)
        {
            answerButton.OnClick -= HandleAnswerButtonClicked;
        }
    }

    public void Initialize(QuestionData questionData)
    {
        _question.text = questionData.Question;
        _correntAnswerID = questionData.CorrectAnswerID;
        _answers = questionData.Answers;

        for (int i = 0; i < _answerButton.Count; i++)
        {
            _answerButton[i].Initialize(_answers[i], i + 1);
            _answerButton[i].OnClick += HandleAnswerButtonClicked;
        }
    }

    private void HandleAnswerButtonClicked(AnswerButton answerButton)
    {
        bool isCorrectAnswer = answerButton.ButtonID == _correntAnswerID;

        if (isCorrectAnswer)
        {
            answerButton.Correct();
            StartCoroutine(DisableObjectAfterTime());
        }
        else
        {
            answerButton.Wrong();
        }

        MessageBrokerHolder.GameActions.Publish(new M_Answer(isCorrectAnswer));
    }

    private IEnumerator DisableObjectAfterTime()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }
}