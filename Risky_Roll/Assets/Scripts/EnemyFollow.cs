using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float _speed =1;
    private Rigidbody _rb;
    private bool _isPlayerRange=false;

    //gameobject to hold a reference of the player.
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb= GetComponent<Rigidbody>();
        _player =GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerRange=true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerRange=false;
        }
    }

    private void FixedUpdate() 
    {
        if(_isPlayerRange)
        {
            // calculate a vector to determine the dash direction
            // by substracting the player position from the enemy position
            Vector3 targetDirection = _player.transform.position - transform.position;


            //add a force to our enemy Rigidbody, multiplied by speed and fixedDeltaTime for smoothness
            //the force mode is going to be VelocityChange which means this force will change our velocity (by ingoring the enemy's mass)
            _rb.AddForce(targetDirection *_speed * Time.fixedDeltaTime , ForceMode.VelocityChange);

            // store our velocity in a temporary variable to change it later
            Vector3 newVelocity = _rb.velocity;

            //remove any velocity on Y-Axis 
            newVelocity.y=0;

            // set the new velocity yo our Rigidbody 
            _rb.velocity =newVelocity;



        }
    }
}
