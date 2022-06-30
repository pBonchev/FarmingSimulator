using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance;

    [SerializeField]
    private GameObject block;

    public int widgth = 10;
    public int heigth = 10;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        for (int i = 0; i < widgth; i++)
        {
            for (int j = 0; j < heigth; j++)
            {
                Block bl = Instantiate(block, new Vector3(i, j, 0f), Quaternion.identity, this.transform).GetComponent<Block>();
                bl.ChangeCrop(0);
            }
        }
    }
}
