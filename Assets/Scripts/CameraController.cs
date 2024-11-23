using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public float cameraSmoothingFactor = 1f;
    //public float lookUpMax = 60f;
    //public float lookUpMin = -60f;

    public Transform t_camera;

    private Quaternion camRotation;
    private RaycastHit hit;
    private Vector3 cameraOffset;

    void Start()
    {
        if (t_camera == null)
        {
            Debug.LogError("Camera transform (t_camera) is not assigned.");
            return;
        }
        camRotation = transform.localRotation;
        cameraOffset = t_camera.localPosition;
    }

    void Update()
    {
        //if (t_camera == null)
        //    return;

        //// Update camera rotation
        ////camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor * -1;
        ////camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor;

        //camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);

        // Adjust camera position
        AdjustCameraPosition();
    }

    private void AdjustCameraPosition()
    {
        Vector3 targetPosition = transform.position + transform.localRotation * cameraOffset;

        if (Physics.Linecast(transform.position, targetPosition, out hit))
        {
            t_camera.localPosition = new Vector3(0, 0, -Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            t_camera.localPosition = Vector3.Lerp(t_camera.localPosition, cameraOffset, Time.deltaTime * 5f); // Adjust smoothing factor here
        }
    }
}
