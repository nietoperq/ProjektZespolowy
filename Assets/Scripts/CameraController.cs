using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float rotationSpeedHorizontal;
    public float rotationSpeedVertical;

    public float moveSpeedHorizontal;

    private float rotationHorizontal = 0.0f;
    private float rotationVertical = 0.0f;

    private float cameraZ;

    public bool follow = false;


    void Start()
    {
        cameraZ = transform.position.z;
        Cursor.visible = false;
        offset = target.position - transform.position;
    }

    void Update()
    {
        rotationHorizontal += rotationSpeedHorizontal * Input.GetAxis("Mouse X");
        rotationVertical += rotationSpeedVertical * Input.GetAxis("Mouse Y");

        if (rotationVertical > 5f) rotationVertical = 5f;
        else if (rotationVertical < -15f) rotationVertical = -15f;

        if (rotationHorizontal > 2f) rotationHorizontal = 2f;
        else if (rotationHorizontal < -2f) rotationHorizontal = -2f;

        if (offset.x > 3f) offset.x = 3f;
        else if (offset.x < -3f) offset.x = -3f;
        transform.eulerAngles = new Vector3(-rotationVertical, rotationHorizontal, 0.0f);
        offset.x -= moveSpeedHorizontal * Input.GetAxis("Mouse X");

        Vector3 cameraPos = target.position - offset;
        if (!follow)
        {
            cameraPos.z = cameraZ;
        }
        transform.position = cameraPos;



    }
}
