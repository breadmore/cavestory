using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float speed = 10.0f;
    public Transform cameraTarget;

    private Camera thisCamera;
    private Vector3 worldDefaultForward;

    [SerializeField]
    private float MaxDis = 60.0f;
    [SerializeField]
    private float MinDis = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        worldDefaultForward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

        if (thisCamera.fieldOfView <= MinDis && scroll < 0)
        {
            thisCamera.fieldOfView = MinDis;
        }

        else if (thisCamera.fieldOfView >= MaxDis && scroll > 0)
        {
            thisCamera.fieldOfView = MaxDis;
        }

        else
        {
            thisCamera.fieldOfView += scroll;
        }

        if(cameraTarget && thisCamera.fieldOfView <= 35.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(cameraTarget.position - transform.position),
                 0.15f);
        }

        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation
                , Quaternion.LookRotation(worldDefaultForward),
                0.15f);
        }
    }
}
