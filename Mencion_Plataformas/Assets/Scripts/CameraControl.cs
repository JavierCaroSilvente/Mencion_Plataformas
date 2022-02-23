using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float Speed = 8;
    public GameObject Target;
    private Vector3 FinalPos;

    public float camOffSetX = 0;
    public float camOffSetY = 0;
    public float camOffSetZ = 0;

    void Update()
    {
        if (Target.transform.parent != null)
            FinalPos = new Vector3(Target.transform.position.x + camOffSetX, Target.transform.position.y + camOffSetY, camOffSetZ); 
        transform.position = Vector3.Lerp(transform.position, FinalPos, Speed * Time.deltaTime);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -1.9f)
        {
            transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        }
        if (transform.position.y > 16f)
        {
            transform.position = new Vector3(transform.position.x, 16, transform.position.z);
        }
    }
    void FixedUpdate()
    {
        if (Target.transform.parent == null)
            FinalPos = new Vector3(Target.transform.position.x + camOffSetX, Target.transform.position.y + camOffSetY, camOffSetZ);
        transform.position = Vector3.Lerp(transform.position, FinalPos, Speed * Time.deltaTime);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -1.9f)
        {
            transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        }
    }
}
