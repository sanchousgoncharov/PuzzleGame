using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleSelect_ : MonoBehaviour
{
    public GameObject startPanel;
    public void setPuzzlesPic(Image pic)
    {
        for (int i = 0; i < 36; i++)
        {
            GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = pic.sprite;
        }
        startPanel.SetActive(false);
    }
}
