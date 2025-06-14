using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessSymbolGame : MonoBehaviour
{
    public List<SymbolData> symbols;
    public Image symbolDisplay;
    public Text feedbackText;

    private SymbolData currentSymbol;

    void Start()
    {
        ShowRandomSymbol();
    }

    public void ShowRandomSymbol()
    {
        feedbackText.text = "";
        int index = Random.Range(0, symbols.Count);
        currentSymbol = symbols[index];
        symbolDisplay.sprite = currentSymbol.image;
    }

    public void GuessSymbol(int typeIndex)
    {
        SymbolType guessedType = (SymbolType)typeIndex;
        if (guessedType == currentSymbol.type)
        {
            feedbackText.text = "✅ Верно!";
        }
        else
        {
            feedbackText.text = "❌ Неверно. Это был: " + currentSymbol.type.ToString();
        }
    }
}
