using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private SpriteRenderer sr;

    private int state;

    public int cropIdx;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            NextState();
    }
}
