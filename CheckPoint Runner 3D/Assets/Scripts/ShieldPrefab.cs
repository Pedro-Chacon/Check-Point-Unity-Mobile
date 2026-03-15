using UnityEngine;

public class ShieldPrefab : MonoBehaviour
{
    ShieldManager shieldManager;
    Rigidbody rb;
    void Start()
    {
        shieldManager = FindAnyObjectByType<ShieldManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector3(shieldManager.shieldSpeed, 0f, 0f);
    }

}
