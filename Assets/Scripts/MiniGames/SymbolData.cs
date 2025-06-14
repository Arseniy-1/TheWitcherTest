using UnityEngine;

[System.Serializable]
public class SymbolData
{
    public string symbolName;
    public Sprite image;
    public SymbolType type;
}

public enum SymbolType
{
    CoatOfArms,
    Flag,
    Anthem
}
