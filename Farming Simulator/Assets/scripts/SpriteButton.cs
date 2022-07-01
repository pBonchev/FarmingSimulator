using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour
{
    [SerializeField]
    private UnityEvent on_click;

    public void Click()
    {
        on_click.Invoke();
    }
}
