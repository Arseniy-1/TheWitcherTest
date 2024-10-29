using TMPro;
using UnityEngine;

public class ResultView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ShowResult(int value)
    {
        _text.text = value.ToString() + "/10";
    }
}
