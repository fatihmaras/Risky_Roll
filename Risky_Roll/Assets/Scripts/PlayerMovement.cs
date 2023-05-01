using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalInput, _verticalInput;
    [SerializeField] private float _speed = 10f; 
    [SerializeField] private float _jumpForce=10;
    private bool _isJumpButtonPressed;
    private bool _isGrounded;


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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            
            _isJumpButtonPressed=true;

        }
    }

    private void FixedUpdate() 
    {
        Vector3 playerMovement = new Vector3(_horizontalInput , 0 , _verticalInput);
        playerMovement *= _speed;
        _rb.AddForce(playerMovement,ForceMode.Acceleration);

        Ray ray =new Ray(transform.position,Vector3.down);
        if(Physics.Raycast(ray, transform.localScale.x/2f+0.01f))
        {
            _isGrounded=true;
        }
        else
        {
            _isGrounded=false;
        }



        if(_isJumpButtonPressed && _isGrounded)
        {
            _rb.AddForce(Vector3.up* _jumpForce, ForceMode.Impulse);
            _isJumpButtonPressed = false;
        }
    }

    // private void OnCollisionEnter(Collision other) 
    // {
    //     _isGrounded=true;
    // }
    // private void OnCollisionExit(Collision other) 
    // {
    //     _isGrounded=false;
    // }
}
