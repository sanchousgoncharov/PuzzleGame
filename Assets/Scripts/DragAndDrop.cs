using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectedPiece;
    float selectedPieceZ;
    int OIL = 1;
    Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //В hit мы занесем результат выполнения команды Raycast
            //там будет либо null, если raycast никого не задел, либо первый
            //объект, стоящий на пути мышки (какой объект будет первым
            //решает его положение Z в мировом пространстве)
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                //Debug.Log($"{hit.transform.gameObject.name} {hit.transform.localPosition.z}");
                if (!hit.transform.GetComponent<pieceScript>().inRightPosition)
                {
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<pieceScript>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                    offset = selectedPiece.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {
                selectedPiece.GetComponent<pieceScript>().selected = false;
                selectedPiece = null;
            }
        }

        if (selectedPiece != null)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            selectedPiece.transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }
}
