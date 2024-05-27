using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
   //This method is called when the mouse is clicked and dragged, it's a super easy unity function 
     void OnMouseDrag()
 {
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = mousePos;
 }
}
// I found this code in the first comment by @topBagon under this youtube video: https://www.youtube.com/watch?v=We1ab6yHrwI&list=PLBIb_auVtBwCK_dyk-Wzxvk5I5z441lZd&index=6