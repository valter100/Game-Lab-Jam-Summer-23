using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;
    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
    }

    public Vector3 GetMovementVector()
    {
        return playerControls.PlayerCharacter.Movement.ReadValue<Vector3>();
    }

    public Vector2 CameraMovement()
    {
        return playerControls.PlayerCharacter.CameraMovement.ReadValue<Vector2>();
    }

    public bool Smash()
    {
        return playerControls.PlayerCharacter.Smash.triggered;
    }

    public bool Grab()
    {
        return playerControls.PlayerCharacter.Grab.triggered;
    }
}
