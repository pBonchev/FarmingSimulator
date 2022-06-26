using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "product", menuName = "SO/crop")]
public class FieldSpriteSO : ScriptableObject
{
    public Sprite[] pattern;
    public int readyStateIdx;
}
