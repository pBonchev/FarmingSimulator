using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static GameTime instance;

    private List<Block> blocks = new List<Block>();

    private void Awake()
    {
        instance = this;
    }

    public void GetBlockInfo(List<Block> bl)
    {
        blocks = bl;
    }

    public void ChangeTime()
    {
        for (int i = 0; i < blocks.Count; i++)
            blocks[i].NextState();
    }
}
