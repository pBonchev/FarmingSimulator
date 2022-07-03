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
        {
            if (blocks[i].ploughed && !blocks[i].watered)
            {
                blocks[i].ChangeCrop(0);
                blocks[i].ploughed = false;
                continue;
            }

            if (blocks[i].watered && !blocks[i].planted)
            {
                blocks[i].ChangeCrop(1);
                blocks[i].watered = false;
                continue;
            }

            blocks[i].NextState();
        }
    }
}
