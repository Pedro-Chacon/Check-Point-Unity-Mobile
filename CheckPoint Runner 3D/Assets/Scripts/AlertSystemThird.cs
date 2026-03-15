using UnityEngine;
using System.Collections;


public class AlertSystemThird : MonoBehaviour
{

    [Header("Propiedades Obstaculo")]
    public float obstaculeSpeed;
    public float obstaculeRotationSpeed;
    public Vector3 rotationAleatory;

    //Se quiser aumentar a VELOCIDADE, TEM QUE AUMETAR OS OUTROS FATORES TBM
    // Da pro player cortar o brick damage e dai desativa o mesh renderer dele
    // Criar dps um script Manager q aumenta a velocidade de todos por ROUND??
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
       

        if (canSpawnDamageBrick)
        {
            StartCoroutine(SpawnDamageBrick());
        }

        //FAZER GIRAR
        transform.Rotate(rotationAleatory * obstaculeRotationSpeed * Time.deltaTime);
    }

    IEnumerator SpawnDamageBrick()
    {
        int varSpeed = 0;

        rb.linearVelocity = new Vector3(varSpeed, rb.linearVelocity.y, rb.linearVelocity.z);

        transform.position = InitialPosition.transform.position;

        //ROTACIONAR EM POS ALEATORIA
        Vector3 angulosRotacao = new Vector3(0f, 0, (Random.Range(0f, 360f)));
        rotationAleatory = new Vector3(0f, 0, (Random.Range(0f, 360f)));
        canSpawnDamageBrick = false;
        meshRendererBrickDamage.enabled = false;
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;

        //POSICAO Y
        transform.position = new Vector3(transform.position.x, Random.Range(5f, 10f), 4.4f);


        yield return new WaitForSeconds(tempoDesativo);
        print("Ativou OBJETO");

       //APLICA VELOCIDADE EM X
        rb.linearVelocity = new Vector3(obstaculeSpeed, rb.linearVelocity.y, rb.linearVelocity.z);


        //Código para piscar
        #region Piscar
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(2f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.5f);
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

        print("desativou OBJETO");
        yield return new WaitForSeconds(tempoAtivo);

        canSpawnDamageBrick = true;

    }


}
