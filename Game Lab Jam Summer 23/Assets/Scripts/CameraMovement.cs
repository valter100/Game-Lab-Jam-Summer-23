using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] Transform camTransform;
    [SerializeField] Transform body;
    [SerializeField] float rotateSpeed;

    void Update()
    {
        Vector3 eulerRotation = new Vector3(
            transform.eulerAngles.x + controller.CameraMovement().y * -1,
            body.transform.eulerAngles.y,
            body.transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);

        transform.position = camTransform.position;
    }
}
