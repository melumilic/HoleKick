using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _turningSpeed = 20f;
    [SerializeField]
    private float _driftTurn = 20f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private bool _goingStraight = true;
    [SerializeField]
    private float gravity = 10f;
    [SerializeField]
    private float scaler = .01f;
    [SerializeField]
    private bool _accelerating;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        transform.position = rb.transform.position - new Vector3(0, 0.4f, 0);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            _accelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            _accelerating = false;
        }
        if (_accelerating)
        {
            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.mass = 300;
        if (_goingStraight)
        {
            moveChar();
        }
        else
        {
            turnMove();
            rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
        //rb.inertiaTensorRotation = new Quaternion(0.01f, 0.01f, 0.01f, 1f);
        //rb.AddTorque(-rb.angularVelocity * scaler);
    }
    void moveChar()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }
    void turnMove()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            Vector3 moveDirection = (transform.forward * Input.GetAxis("Vertical")).normalized;
            rb.AddForce(moveDirection * _speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 moveDirection = (transform.forward * 1).normalized;
            rb.AddForce(moveDirection * _speed * .5f, ForceMode.Acceleration);
            transform.Rotate(0, (_driftTurn + _turningSpeed) * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, (_turningSpeed) * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        }
    }
}
