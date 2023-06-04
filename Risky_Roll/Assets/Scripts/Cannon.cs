using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _cannonHead;
    [SerializeField] private Transform _cannonTip;
    [SerializeField] private float _shootingCoolDown =3f;
    [SerializeField] private float _laserPower = 100f;

    private bool _isPlayerInRange =false;
    private GameObject _player;
    private float _timeLeftToShoot =0;
    private LineRenderer _cannonLaser;


    // Start is called before the first frame update
    void Start()
    {
        _cannonLaser= GetComponent<LineRenderer>();
        _cannonLaser.sharedMaterial.color= Color.green;
        _cannonLaser.enabled=false;
        _player= GameObject.FindGameObjectWithTag("Player");
        _timeLeftToShoot= _shootingCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isPlayerInRange)
        {
            _cannonHead.transform.LookAt(_player.transform);

            // set the first point of the laser to be the cannon tip 
            _cannonLaser.SetPosition(0 , _cannonTip.transform.position);

            // set the second point of the laser to be the player position
            _cannonLaser.SetPosition(1, _player.transform.position);

            // as long as the player is in range substract the time from -  time left to shoot
            _timeLeftToShoot -=Time.deltaTime;
        }

        //check the time left to shoot 
        if(_timeLeftToShoot <= _shootingCoolDown*0.5)
        {
            _cannonLaser.sharedMaterial.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerInRange=true;
            _cannonLaser.enabled=true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _isPlayerInRange=false;
            _cannonLaser.enabled=false;

            _timeLeftToShoot = _shootingCoolDown;

            _cannonLaser.sharedMaterial.color = Color.green;


        }
    }
}
