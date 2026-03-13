using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float enemySpeed = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(1f * enemySpeed, rb.linearVelocity.y, rb.linearVelocity.z);


    }
}
