using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCrosshair : MonoBehaviour
{
    public Texture2D crosshair;

    // Start is called before the first frame update
    void Start()
    {
        // Sets cursor to crosshair texture
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
    }

}
