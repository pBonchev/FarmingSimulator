using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    public static CropManager instance;

    public FieldSpriteSO[] crops;

    private void Awake()
    {
        instance = this;
    }
}
