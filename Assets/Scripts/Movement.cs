using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float jumpStrenght;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode attack;
    [SerializeField] KeyCode jump;
    bool isGrounded;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }


    void Update()
    {
        Vector3 velocity = GetInputVector();
        Move(velocity);
        
    }

    void OnCollisionStay()
    {
        isGrounded = true; 
    }

    Vector3 GetInputVector()
    {
        bool jumpp = Input.GetKeyDown(jump);
        bool leftt = Input.GetKey(left);
        bool rightt = Input.GetKey(right);
        float z = ToAxis(rightt, leftt);
        float y = yAxis(jumpp);
        


        Vector3 velocity = new Vector3(0, y, z);
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
        return value*speed;
    }
    float yAxis(bool positive)
    {
        float value;
        if (positive)
        {
            value = 1;
        }
        else
            value = 0;
        return value*jumpStrenght;
                
    }
    void Move(Vector3 velocity)
    {
        //rb.velocity = speed * velocity.normalized;
        
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(velocity, ForceMode.VelocityChange);

        }
    }
}
