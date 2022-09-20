using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float jumpStrenght;
    [SerializeField] int airJumpCount = 1;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode attack;
    [SerializeField] KeyCode jump;
    
    int jumpCount;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }


    void Update()
    {
        Move();
        Turning();
    }

    void OnCollisionEnter(Collision collision)
    { 
        jumpCount = 0;
    }

    Vector3 GetInputVector()
    { 
        bool leftt = Input.GetKey(left);
        bool rightt = Input.GetKey(right);
        float x = ToAxis(rightt, leftt);

        Vector3 velocity = new Vector3(x, 0, 0);
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
        return value * speed;
    }

    
    void Move()
    {
        Vector3 velocity = GetInputVector();
        rb.AddForce(velocity, ForceMode.Acceleration);
        
        if (Input.GetKeyDown(jump) && jumpCount <= airJumpCount)
        {
            jumpCount++;
            
            // rb.AddForce(jumpStrenght * Vector3.up, ForceMode.VelocityChange);
            
            Vector3 vel = rb.velocity;
            vel.y = jumpStrenght;
            rb.velocity = vel;
        }
    }

    void Turning()
    {
        if (Input.GetKeyDown(left))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (Input.GetKeyDown(right))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }


    }


}