using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz/Question Data")]
public class QuestionData : ScriptableObject
{
    [field: SerializeField] public string Question { get; private set; }

    [field: SerializeField] public List<string> Answers { get; private set; }

    [field: SerializeField, Range(1, 4)] public int CorrectAnswerID { get; private set; }
}