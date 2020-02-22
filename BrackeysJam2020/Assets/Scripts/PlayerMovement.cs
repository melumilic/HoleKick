using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _jumpPower = 5f;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float _dashCooldown = 3f;
    [SerializeField]
    private float _dashDistance = 2f;
    private float _prevTime = 0;
    private Vector2 dir = Vector2.zero;
    [Header("Cooldowns")]
    [SerializeField]
    private Image _dashFill;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dashFillAmount = 1-(Mathf.Clamp((Time.time - _prevTime),0,_dashCooldown) / _dashCooldown);
        Debug.Log(dashFillAmount);
        dashFillAmount = Mathf.Clamp(dashFillAmount, 0, 1);
        _dashFill.fillAmount = dashFillAmount;
    }
    private void FixedUpdate()
    {
        PlayerMove();
        PlayerDash();
        PlayerJump();
    }
    void PlayerMove()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            rb.AddForce(dir * _speed);
        }
    }
    void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&Time.time-_prevTime>_dashCooldown)
        {
            _prevTime = Time.time;
            if (dir.magnitude > 0)
            {
                rb.AddForce(dir * _dashDistance,ForceMode2D.Impulse);
            }
        }
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
                rb.AddForce(Vector2.up*_jumpPower, ForceMode2D.Impulse);
        }
    }
}
