using UnityEngine;

public class Obstacule3 : MonoBehaviour
{
    [Header("Propiedades Obstaculo")]
    public float obstaculeSpeed;
    public float obstaculeRotationSpeed;
    public Vector3 rotationAleatory;

    public Material enemyBrokenMaterial;

    public GameObject orb1;
    public GameObject orb2;
    public GameObject damageBrick;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(obstaculeSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        rotationAleatory = new Vector3(0f, 0, (Random.Range(0f, 360f)));
        transform.Rotate(rotationAleatory * obstaculeRotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            orb1.gameObject.GetComponent<MeshRenderer>().material = enemyBrokenMaterial;
            orb2.gameObject.GetComponent<MeshRenderer>().material = enemyBrokenMaterial;
            damageBrick.SetActive(false);
        }
    }
}
