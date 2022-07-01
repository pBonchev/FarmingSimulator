using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private SpriteRenderer sr;

    private int state;

    private int cropIdx;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void NextState()
    {
        if (cropIdx == -1) return;

        if (state < CropManager.instance.crops[cropIdx].pattern.Length - 1)
        {
            state++;
            sr.sprite = CropManager.instance.crops[cropIdx].pattern[state];
        }
    }

    public void ChangeCrop(int idx)
    {
        cropIdx = idx;
        state = 0;

        sr.sprite = CropManager.instance.crops[idx].pattern[0];
    }

    public void Click()
    {
        OptionsCrop.instance.Open(this);
    }
}
