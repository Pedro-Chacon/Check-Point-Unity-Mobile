using UnityEngine;

public class AddBullet : MonoBehaviour
{
    Rigidbody rb;
    SpawnBulletRandom SpawnBulletRandom;
    ShootBullet ShootBullet;
    void Start()
    {
        ShootBullet = FindAnyObjectByType<ShootBullet>();
        SpawnBulletRandom = FindAnyObjectByType<SpawnBulletRandom>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(SpawnBulletRandom.addBulletSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ShootBullet.municao++;
            Destroy(gameObject);
        }
    }
}
