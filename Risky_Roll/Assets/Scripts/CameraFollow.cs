using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     private Transform _cameraTarget;
     [SerializeField] private Vector3 _offset;
     [SerializeField] private float _smoothTime= 0.3f;

     // this value will change at runtime depending on target movement. Initialize with zero vector.
     private Vector3 _cameraVelocity= Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _offset= transform.position - _cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() 
    {
        Vector3 targetPosition = _cameraTarget.position + _offset;

        // smooth damp will gradually changes a vector towards a desired goal over time.
        transform.position =Vector3.SmoothDamp(transform.position , targetPosition,ref _cameraVelocity, _smoothTime);

        // make the camera's transform look at the player transform.
        transform.LookAt(_cameraTarget);
    }
}
