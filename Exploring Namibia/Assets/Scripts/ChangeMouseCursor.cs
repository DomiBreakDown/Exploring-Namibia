using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouseCursor : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D handCursor;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, curMode);
    }

    //For Hand Cursor on Objects with a tag (just add another if with the new tag and cursor)
    public void OnMouseEnter()
    {
        if(gameObject.tag == "hand")
        {
            Cursor.SetCursor(handCursor, hotSpot, curMode);
        }
    }


    //For Default Cursor when leaving a Object that changed the Cursor
    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, curMode);
    }

    //For Hand Cursor on Objects without a tag
    public void OnMouseOver()
    {
        Cursor.SetCursor(handCursor, hotSpot, curMode);
    }
}
