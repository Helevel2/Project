using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode attack;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponentInChildren<Rigidbody>();
        }
    }


    void Update()
    {
        
        Vector3 velocity = GetInputVector();
        Move(velocity);
    }

    Vector3 GetInputVector()
    {
        bool leftt = Input.GetKey(left);
        bool rightt = Input.GetKey(right);
        float z = ToAxis(rightt, leftt);

        Vector3 velocity = new Vector3(0, 0, z);
        return velocity;
    }
    float ToAxis(bool positive, bool negative)
    {
        float value;
        if (positive)
        {
            value = 1;
        }
        else if (negative)
        {
            value = -1;
        }
        else
            value = 0;
        return value;
    }

    void Move(Vector3 velocity)
    {
        rb.velocity = velocity.normalized * speed;
    }
}