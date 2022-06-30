using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsCrop : MonoBehaviour
{
    public static OptionsCrop instance;

    private Block host;

    private void Awake()
    {
        instance = this;
        Close();
    }

    public void Open(Block from)
    {
        host = from;

        transform.position = from.transform.position;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        host = null;
        gameObject.SetActive(false);
    }
}
