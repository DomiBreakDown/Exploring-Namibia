using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTItemDragHandler : MonoBehaviour
{
    public Transform leftPanelTransform;
    
    public Transform rightPanelTransform;

    private PanelPlacement panelPlacementLeft, panelPlacementRight;

    private Vector2 initialPosition;
    private Vector2 mousePosition;

    private float deltaX, deltaY;
    private int slot;

    private static int leftAttributes;
    private static int rightAttributes;
    private static int allAttributes;

    private string leftName = "Left-Attributes";
    private string rightName = "Right-Attributes";

    private bool left;
    private bool mid;
    private bool right;

    //Initialization
    void Start()
    {
        initialPosition = transform.position;
        panelPlacementLeft = leftPanelTransform.gameObject.GetComponent<PanelPlacement>();
        panelPlacementRight = rightPanelTransform.gameObject.GetComponent<PanelPlacement>();
        left = false;
        mid = true;
        right = false;
        leftAttributes = 0;
        rightAttributes = 0;
        allAttributes = 0;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("leftAttributes", leftAttributes);
        PlayerPrefs.SetInt("rightAttributes", rightAttributes);
        PlayerPrefs.SetInt("allAttributes", allAttributes);
    }

    //When left mouse button gets clicked
    private void OnMouseDown()
    {
        if(this.transform.position.x < -1)
        {
            panelPlacementLeft.FreeSlot(slot);
        }
        else if(this.transform.position.x > 1)
        {
            panelPlacementRight.FreeSlot(slot);
        }
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;

        //Calculate the deltas for smoother drag
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    //When left mouse button is down and object gets dragged
    private void OnMouseDrag()
    {
        //Get mouse position
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Set GameObject position to mouse position and subtract deltas for smoothness
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    //When left mouse button is released
    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - leftPanelTransform.position.x) <= 3.0f &&
           Mathf.Abs(transform.position.y - leftPanelTransform.position.y) <= 4.0f)
        {
            if (!left)
            {
                if (!panelPlacementLeft.AllSlotsFull())
                {
                    if (gameObject.transform.parent.name == rightName && right)
                    {
                        rightAttributes--;
                    }
                    if (mid)
                    {
                        allAttributes++;
                    }
                    if (gameObject.transform.parent.name == leftName)
                    {
                        leftAttributes++;
                    }

                    left = true;
                    mid = false;
                    right = false;
                } else
                {
                    left = false;
                    mid = true;
                    right = false;
                }
            }

            transform.position = panelPlacementLeft.GetPlacementPos(initialPosition);
            slot = panelPlacementLeft.GetSlotPos();
        }
        else if (Mathf.Abs(transform.position.x - rightPanelTransform.position.x) <= 3.0f &&
         Mathf.Abs(transform.position.y - rightPanelTransform.position.y) <= 4.0f)
        {
            

            if (!right)
            {
                if (!panelPlacementRight.AllSlotsFull())
                {
                    if (gameObject.transform.parent.name == leftName && left)
                    {
                        leftAttributes--;
                    }
                    if (mid)
                    {
                        allAttributes++;
                    }
                    if (gameObject.transform.parent.name == rightName)
                    {
                        rightAttributes++;
                    }
                    left = false;
                    mid = false;
                    right = true;
                } else
                {
                    left = false;
                    mid = true;
                    right = false;
                }
            }

            transform.position = panelPlacementRight.GetPlacementPos(initialPosition);
            slot = panelPlacementRight.GetSlotPos();
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);

            if(!mid)
            {
                allAttributes--;
                if(left && gameObject.transform.parent.name == leftName)
                {
                    leftAttributes--;
                }
                if (gameObject.transform.parent.name == rightName && right)
                {
                    rightAttributes--;
                }
            }

            left = false;
            mid = true;
            right = false;
        }
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}
