using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalInput, _verticalInput;
    [SerializeField] private float _speed = 1f; 


    // Start is called before the first frame update
    void Start()
    {
        _rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput= Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() 
    {
        Vector3 playerMovement = new Vector3(_horizontalInput , 0 , _verticalInput);
        playerMovement *= _speed;
        _rb.AddForce(playerMovement,ForceMode.Acceleration);
    }
}
