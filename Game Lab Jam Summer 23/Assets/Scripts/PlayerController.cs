using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;
    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetMovementVector()
    {
        return playerControls.PlayerCharacter.Movement.ReadValue<Vector2>();
    }

    public Vector2 CameraMovement()
    {
        return playerControls.PlayerCharacter.CameraMovement.ReadValue<Vector2>();
    }

    public bool Smash()
    {
        return playerControls.PlayerCharacter.Smash.triggered;
    }

    public bool GrabLeft()
    {
        return playerControls.PlayerCharacter.GrabLeft.triggered;
    }

    public bool GrabRight()
    {
        return playerControls.PlayerCharacter.GrabRight.triggered;
    }

    public bool Combine()
    {
        return playerControls.PlayerCharacter.Combine.triggered;
    }
}
