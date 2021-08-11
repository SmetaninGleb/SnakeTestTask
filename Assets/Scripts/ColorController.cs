using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorController : ScriptableObject
{
    [SerializeField]
    private DictionaryPart[] _colorDic;
    public DictionaryPart[] ColorDic => _colorDic;

    public enum Color
    {
        Green,
        Red,
        Purple,
        Blue,
        Orange,
        LightBlue,
        Pink,
        Yellow
    }

    public Color32 GetColorByEnum(ColorController.Color color)
    {
        foreach (DictionaryPart item in _colorDic)
        {
            if (item.ColorName == color)
            {
                return item.Color;
            }
        }
        return _colorDic[0].Color;
    }

}

[Serializable]
public struct DictionaryPart
{
    public ColorController.Color ColorName;
    public Color32 Color;
}
