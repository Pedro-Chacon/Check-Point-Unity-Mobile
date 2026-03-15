using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] public float enemySpeed;

    AlertSystem alertSystem;

    void Start()
    {
        alertSystem = FindAnyObjectByType<AlertSystem>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        enemySpeed = alertSystem.enemySpeed;

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(1f * enemySpeed, rb.linearVelocity.y, rb.linearVelocity.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
