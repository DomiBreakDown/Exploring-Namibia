using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPlacement : MonoBehaviour
{
    private bool freeSlot1, freeSlot2, freeSlot3, freeSlot4, freeSlot5, freeSlot6, freeSlot7;
    private int lastSlotPos;

    private void Start()
    {
        freeSlot1 = freeSlot2 = freeSlot3 = freeSlot4 = freeSlot5 = freeSlot6 = freeSlot7 = true;
    }

    public Vector2 GetPlacementPos(Vector2 initialPosition)
    {
        if(freeSlot1)
        {
            freeSlot1 = false;
            lastSlotPos = 1;
            return new Vector3(this.transform.position.x, this.transform.position.y + 3);
        }
        else if(freeSlot2)
        {
            freeSlot2 = false;
            lastSlotPos = 2;
            return new Vector3(this.transform.position.x, this.transform.position.y + 2);
        }
        else if (freeSlot3)
        {
            freeSlot3 = false;
            lastSlotPos = 3;
            return new Vector3(this.transform.position.x, this.transform.position.y + 1);
        }
        else if (freeSlot4)
        {
            freeSlot4 = false;
            lastSlotPos = 4;
            return new Vector3(this.transform.position.x, this.transform.position.y);
        }
        else if (freeSlot5)
        {
            freeSlot5 = false;
            lastSlotPos = 5;
            return new Vector3(this.transform.position.x, this.transform.position.y - 1);
        }
        else if (freeSlot6)
        {
            freeSlot6 = false;
            lastSlotPos = 6;
            return new Vector3(this.transform.position.x, this.transform.position.y - 2);
        }
        else if (freeSlot7)
        {
            freeSlot7 = false;
            lastSlotPos = 7;
            return new Vector3(this.transform.position.x, this.transform.position.y - 3);
        }

        return initialPosition;
    }

    public int GetSlotPos()
    {
        return lastSlotPos;
    }

    public bool AllSlotsFull()
    {
        return !freeSlot1 && !freeSlot2 && !freeSlot3 && !freeSlot4 && !freeSlot5 && !freeSlot6 && !freeSlot7;
    }

    public void FreeSlot(int i)
    {
        switch(i)
        {
            case 1:
                freeSlot1 = true;
                break;
            case 2:
                freeSlot2 = true;
                break;
            case 3:
                freeSlot3 = true;
                break;
            case 4:
                freeSlot4 = true;
                break;
            case 5:
                freeSlot5 = true;
                break;
            case 6:
                freeSlot6 = true;
                break;
            case 7:
                freeSlot7 = true;
                break;
        }
    }
}
