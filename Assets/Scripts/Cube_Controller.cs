using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private Vector3 direction = Vector3.up;
    [SerializeField] private float charge =0f;
    [SerializeField] private float jumpForce =100f;
    private bool _isGround = false;
    private bool _isHolding = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !_isHolding && _isGround)
        {
            charge += 0.01f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isHolding = true;
        }

        if (!_isGround)
        {
            charge = 0f;
        }

        charge = Mathf.Clamp(charge, 0, 5f);
    }

    private void FixedUpdate()
    {
        if (_isHolding)
        {
            rb.AddForce(direction* charge * jumpForce);
            _isHolding = false;
            _isGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }
}
