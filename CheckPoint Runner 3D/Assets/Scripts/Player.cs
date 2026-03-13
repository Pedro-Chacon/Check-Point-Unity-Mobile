using UnityEngine;


public class Player : MonoBehaviour
{
 

    [SerializeField] public float jumpForce = 20f;
    [SerializeField] public float Dash = 20f;
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

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                jumpCount++;
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            }

            if (touch.phase == TouchPhase.Moved)
            {

            }



            
        }
    

    }




}



