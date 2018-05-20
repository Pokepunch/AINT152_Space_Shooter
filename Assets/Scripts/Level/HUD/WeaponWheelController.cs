using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponWheelController : MonoBehaviour
{
    // Array of Images. These are the Weapon Wheel slots.
    private Image[] slot;

    // Array of Vector3 positions. These are the original positions of the above slots. Used when moving the slots upon changing weapon.
    private Vector3[] slotPos;

    // Subscribe to WeaponSwitch event and collect information from children.
	void Start ()
    {
        WeaponController.OnWeaponSwitch += WeaponWheelSwitch;
        slot = new Image[transform.childCount];
        slotPos = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            slot[i] = transform.Find("Slot " + i).GetComponent<Image>();
            slotPos[i] = slot[i].rectTransform.localPosition;
        }
	}

    private void OnDisable()
    {
        WeaponController.OnWeaponSwitch -= WeaponWheelSwitch;
    }

    // Called by WeaponSwitch delegate event. Sets up each slot for the weapon switch.
    private void WeaponWheelSwitch(bool changeUp, int weapIndex, int numbWeaps)
    {
        // The index is used to assign the picture the slot should use after its finished moving. There is one exception to this.
        int weapIndexNext = weapIndex + 1;
        int weapIndexPrev = weapIndex - 1;
        if (weapIndexNext > numbWeaps)
        {
            weapIndexNext = 0;
        }
        if (weapIndex == 0)
        {
            weapIndexPrev = numbWeaps;
        }

        int target = 2;
        if (changeUp)
        {
            target = 1;
        }
        MoveSlot(0, target, weapIndex);

        target = 0;
        if (changeUp)
        {
            target = 3;
        }
        MoveSlot(1, target, weapIndexPrev);

        target = 3;
        if (changeUp)
        {
            target = 0;
        }
        MoveSlot(2, target, weapIndexNext);

        target = 1;
        int i = weapIndexPrev;
        if (changeUp)
        {
            target = 2;
            i = weapIndexNext;
        }
        MoveSlot(3, target, i);
    }

    private void MoveSlot(int slotNo, int target, int index)
    {
        slot[slotNo].gameObject.GetComponent<WeaponWheelSlot>().SetProperties(slotPos[target], index);
    }
}
