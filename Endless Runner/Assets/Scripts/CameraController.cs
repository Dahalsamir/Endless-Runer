using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTarget.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + playerTarget.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 260 * Time.deltaTime);
        //transform.position = newPosition;
    }
}

