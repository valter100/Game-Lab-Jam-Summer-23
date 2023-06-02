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
}
