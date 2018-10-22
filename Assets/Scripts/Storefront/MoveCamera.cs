// Script: MoveCamera
// Author: Alex + internet sources (below)
// Description: Allows user to click/touch and drag to move camera along the y-axis
// Sources...
//      Name: damien_oconnell
//      Website: https://forum.unity.com/threads/click-drag-camera-movement.39513/
//      Note: This is the source for the base of this script
//
//      Name: N0ught
//      Site: https://www.youtube.com/watch?v=qbl38iPitVY
//      Note: Sited for reference of phone related functions

using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float dragSpeed; // controls how fast camera is moved
    private Vector3 dragOrigin; // where mouse cursor or finger is originally placed

    void Update()
    {
        // Detect if a mouse-click/touch has occured.
        // Then set dragOrigin and return from function
        // (Will only happen once in a single drag instance)
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        // Exit function if mouse/finger is no longer being held down
        if (!Input.GetMouseButton(0))
            return;

        // Calculate new camera position
        Vector3 position = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

        // Caculate the move (the same as position, but accounts for where the screen is actually going)
        // (pos.y is negative to make the camera move opposite to the drag direction)
        Vector3 move = new Vector3(0, -position.y * dragSpeed, 0);

        // Check to see if the camera position AFTER the move is not within the bounds of the game world
        // (constant values used are hardcoded based on the highest and lowest positions the canvas can be at)
        bool isOutOfBounds = transform.position.y + move.y <= -1.91 && position.y > 0 || transform.position.y + move.y >= 0 && position.y < 0;

        // Check to see if mouse has stopped dragging
        bool hasMouseStopped = Input.GetAxis("Mouse Y") == 0;

        // Check to see if finger is touching screen
        // Then check to see if finger has stopped moving
        // (This is needed because Input.GetAxis() is not compatible with touch screen)
        bool isTouch = false;
        if (Input.touchCount > 0)
            isTouch = true;
        bool hasFingerStopped = isTouch && Input.GetTouch(0).phase == TouchPhase.Stationary;

        // If any are true, then reset the dragOrigin and exit the function
        // The check for mosue/finger movement is important because the camera won't stop moving without it
        if (hasMouseStopped || hasFingerStopped || isOutOfBounds)
        {
            dragOrigin = Input.mousePosition; // if dragOrigin is not reset, the drag will be wacky
            return;
        }

        // Actually move the camera to the new position (if the function ever made it here)
        transform.Translate(move);
    }
}
