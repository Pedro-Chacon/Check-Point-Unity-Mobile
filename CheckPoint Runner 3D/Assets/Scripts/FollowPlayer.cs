using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Alert Object")]
    [SerializeField] public float spawnAlertSpeed = 35f;

    Player player;
    Rigidbody rb;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        Vector3 direcao = player.transform.position - transform.position;
        direcao = direcao.normalized;
        rb.linearVelocity = new Vector3(0f, direcao.y * spawnAlertSpeed, 0f);


    }

}
