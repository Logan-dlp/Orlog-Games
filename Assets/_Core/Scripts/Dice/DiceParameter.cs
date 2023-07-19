using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceParameterObject", menuName = "ScriptableObjects/DiceObject", order = 1)]
public class DiceParameter : ScriptableObject
{
    /// <summary>
    /// Order rotation: [0] axe, [1] arrow, [2] sheild, [3] axe, [4] hand, [5] helmet
    /// </summary>
    public Vector3[] DiceFaceRotation;
}
