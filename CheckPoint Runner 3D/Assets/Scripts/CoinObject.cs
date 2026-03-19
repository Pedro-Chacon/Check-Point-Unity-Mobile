using System.Collections;
using UnityEngine;


public class CoinObject : MonoBehaviour
{
    [Header("Configurações Moeda")]
    public float coinSpeedRotation = 8f;
    public float coinSpeed;



    [Header("Rotacionar Moeda")]
    public Vector3 angulosRotacao = new Vector3(90f, 0, 0f);

    Rigidbody rb;

    HudManager hudManager;
    CoinManager coinManager;


    public void Initialize(HudManager hud, CoinManager coinMgr)
    {
        hudManager = hud;
        coinManager = coinMgr;

        coinSpeed = coinManager.coinSpeed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.Rotate(angulosRotacao * coinSpeedRotation * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(coinSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hudManager.coinCount++;
            Destroy(gameObject);
        }
    }
}
