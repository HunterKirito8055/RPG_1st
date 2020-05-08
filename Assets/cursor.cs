using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public Texture2D csr;
    void Start()
    {
        Vector2 loc = new Vector2(-12.5f,-0.6f);
        Cursor.SetCursor(csr, loc, CursorMode.ForceSoftware);
    }


   
}
