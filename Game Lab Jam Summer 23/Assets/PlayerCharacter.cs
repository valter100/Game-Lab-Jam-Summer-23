using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        if (playerController.GetMovementVector() != Vector2.zero)
        {
            transform.position += new Vector3(playerController.GetMovementVector().x, 0, playerController.GetMovementVector().y) * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(playerController.GetMovementVector().x, 0, playerController.GetMovementVector().y)), 0.05f);
        }

    }
}
