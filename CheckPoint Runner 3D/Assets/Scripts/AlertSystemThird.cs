using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class AlertSystemThird : MonoBehaviour
{

    [Header("Propiedades Obstaculo")]
    public float obstaculeSpeed;
    public float obstaculeRotationSpeed;
    public Vector3 rotationAleatory;

    public Material enemyMaterial;
    public Material enemyBrokenMaterial;

    [SerializeField] float tempoAtivo;
    [SerializeField] float tempoDesativo;
    public GameObject damageBrick;
    public GameObject Alert1;
    public GameObject Alert2;
    public Transform InitialPosition;
    MeshRenderer meshRendererAlert1;
    MeshRenderer meshRendererAlert2;
    MeshRenderer meshRendererBrickDamage;
    bool canSpawnDamageBrick;
    Rigidbody rb;
    RoundManager RoundManager;
    void Start()
    {
        canSpawnDamageBrick = true;
        meshRendererAlert1 = Alert1.GetComponent<MeshRenderer>();
        meshRendererAlert2 = Alert2.GetComponent<MeshRenderer>();
        meshRendererBrickDamage = damageBrick.GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        RoundManager = FindAnyObjectByType<RoundManager>();
    }


    void Update()
    {
       obstaculeSpeed = RoundManager.obstaculo_3_Speed;

        if (canSpawnDamageBrick)
        {
            StartCoroutine(SpawnDamageBrick());
        }

        //FAZER GIRAR
        transform.Rotate(rotationAleatory * obstaculeRotationSpeed * Time.deltaTime);
    }

    IEnumerator SpawnDamageBrick()
    {
        meshRendererAlert1.material = enemyMaterial;
        meshRendererAlert2.material = enemyMaterial;
        yield return new WaitForSeconds(0.1f);




        canSpawnDamageBrick = false;

        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, rb.linearVelocity.z);

        transform.position = InitialPosition.transform.position;

        //ROTACIONAR EM POS ALEATORIA
        Vector3 angulosRotacao = new Vector3(0f, 0, (Random.Range(0f, 360f)));
        rotationAleatory = new Vector3(0f, 0, (Random.Range(0f, 360f)));

        
        meshRendererBrickDamage.enabled = false;
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;

        //POSICAO Y
        transform.position = new Vector3(transform.position.x, Random.Range(5f, 10f), 4.4f);

       //APLICA VELOCIDADE EM X
        rb.linearVelocity = new Vector3(obstaculeSpeed, rb.linearVelocity.y, rb.linearVelocity.z);


        

    }

    IEnumerator Piscar_E_Ativar()
    {
        //Código para piscar
        #region Piscar
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.1f);
        #endregion

        meshRendererBrickDamage.enabled = true;
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;

        yield return new WaitForSeconds(tempoAtivo);
        canSpawnDamageBrick = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            meshRendererBrickDamage.enabled = false;
            meshRendererAlert1.material = enemyBrokenMaterial;
            meshRendererAlert2.material = enemyBrokenMaterial;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AtivarAlertSystemThird"))
        {
            StartCoroutine(Piscar_E_Ativar());
        }
    }



}
