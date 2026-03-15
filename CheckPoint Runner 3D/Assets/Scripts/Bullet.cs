using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    ShootBullet ShootBullet;

    void Start()
    {
        ShootBullet = FindAnyObjectByType<ShootBullet>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(-1f * ShootBullet.shootSpeed, rb.linearVelocity.y, rb.linearVelocity.z);


    }
}
