using UnityEngine;

public struct M_Answer
{
    public M_Answer(bool isCorrect)
    {
        IsCorrect = isCorrect;
    }
    
    public bool IsCorrect { get; private set; }
}