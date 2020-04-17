using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private static bool Mouselock;

    public static bool MouseLocked
    {
        get
        {
            return Mouselock;
        }
        set
        {
            Mouselock = value;
            if (Mouselock)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
