using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D[] hit = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

            Block block = null;
            SpriteButton button = null;

            for (int i = 0; i < hit.Length; i++) 
                if (hit[i].collider != null)
                {
                    if (block == null) block = hit[i].collider.GetComponent<Block>();
                    if (button == null) button = hit[i].collider.GetComponent<SpriteButton>();
                }

            if (button != null)
            {
                button.Click();
            }
            else if (block != null)
            {
                block.Click();
            }
        }
    }
}
