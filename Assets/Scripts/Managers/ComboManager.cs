using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public GameObject[] combosArray;
    public int TotalCombosInLevel;

    public static ComboManager _i;

    public static ComboManager i()
    {
        return _i;
    }
    void Awake()
    {
        _i = this;
        TotalCombosInLevel = combosArray.Length;
    }
}
