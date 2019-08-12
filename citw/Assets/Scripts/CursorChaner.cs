using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChaner : MonoBehaviour {

    public Texture2D cursorTexture;
    public Texture2D cursorClickTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorClickTexture, hotSpot, cursorMode);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
}
