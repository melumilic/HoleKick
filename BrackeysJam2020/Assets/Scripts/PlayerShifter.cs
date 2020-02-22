using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShifter : MonoBehaviour
{
    [SerializeField]
    private float _smoothing = .5f;
    [SerializeField]
    private Transform[] lanes = new Transform[5];
    [SerializeField]
    private int _curLane = 2;
    [SerializeField]
    private float _rotationSmoothing = .2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_curLane < 5)
            {
                //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, 0, -20),.2f);
                _curLane++;
                _curLane = Mathf.Clamp(_curLane, 0, 4);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_curLane > 0)
            {
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 20), Input.GetAxis("Horizontal"));
                _curLane--;
                _curLane = Mathf.Clamp(_curLane, 0, 4);
            }
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -30), _rotationSmoothing);
        }else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 30), _rotationSmoothing);

        }


        UpdatePlayer();
        ResetRotation();
    }
    void UpdatePlayer()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(lanes[_curLane].position.x, transform.position.y,0),_smoothing);
    }
    void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), _rotationSmoothing);
    }
}
