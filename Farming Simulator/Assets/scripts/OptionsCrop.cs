using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsCrop : MonoBehaviour
{
    public static OptionsCrop instance;

    [SerializeField]
    private GameObject seedsObject;

    [SerializeField]
    private GameObject toolsObject;

    [SerializeField]
    private SpriteRenderer water;
    [SerializeField]
    private SpriteRenderer plough;
    [SerializeField]
    private SpriteRenderer harvest;

    private Block host;

    private void Awake()
    {
        instance = this;
        Close();
    }

    public void Open(Block from)
    {
        host = from;

        transform.position = host.transform.position;

        gameObject.SetActive(true);

        UpdateOptions();
    }

    private void UpdateOptions()
    {
        if (!host.watered || host.planted)
        {
            ShowTools();

            if (!host.watered && host.ploughed) water.color = new Color(water.color.r, water.color.g, water.color.b, 1f);
            else water.color = new Color(water.color.r, water.color.g, water.color.b, .5f);

            if(!host.ploughed) plough.color = new Color(plough.color.r, plough.color.g, plough.color.b, 1f);
            else plough.color = new Color(plough.color.r, plough.color.g, plough.color.b, .5f);

            if (host.Ready() && host.planted) harvest.color = new Color(harvest.color.r, harvest.color.g, harvest.color.b, 1f);
            else harvest.color = new Color(harvest.color.r, harvest.color.g, harvest.color.b, .5f);
        }
        else ShowCrops();
    }

    public void Close()
    {
        host = null;
        gameObject.SetActive(false);
    }

    public void PlantSeed(int seedIdx)
    {
        if (host == null) 
        {
            Debug.LogError("no host");
            return;
        }

        if (seedIdx > 1) host.planted = true;
        host.ChangeCrop(seedIdx);

        Close();
    }

    public void Plogh()
    {
        if (host.ploughed) return;

        host.ploughed = true;
        host.ChangeCrop(1);

        UpdateOptions();
    }

    public void Water()
    {
        if (!host.ploughed || host.watered) return;

        host.watered = true;
        host.NextState();

        UpdateOptions();
    }

    public void Harvest()
    {
        if (!host.Ready() || !host.planted) return;

        if (host.watered) host.ChangeCrop(1);

        host.watered = false;
        host.ploughed = true;
        host.planted = false;

        UpdateOptions();
    }

    private void ShowCrops()
    {
        toolsObject.SetActive(false);
        seedsObject.SetActive(true);
    }

    private void ShowTools()
    {
        toolsObject.SetActive(true);
        seedsObject.SetActive(false);
    }
}
