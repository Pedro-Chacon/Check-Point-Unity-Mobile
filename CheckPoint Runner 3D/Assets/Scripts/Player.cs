using UnityEngine;

public class Player : MonoBehaviour
{
 

    [SerializeField] public float jumpForce = 20f;
    [SerializeField] public bool OnFloor;
    [SerializeField] public int jumpCount;
    Rigidbody rb;


    void Start()
    {
        jumpCount = 0;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            jumpCount++;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            
        }
    

    }




}



