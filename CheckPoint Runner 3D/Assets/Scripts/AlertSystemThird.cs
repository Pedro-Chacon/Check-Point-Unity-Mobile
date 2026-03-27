using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class AlertSystemThird : MonoBehaviour
{
    [Header("Propiedades Obstaculo")]
    public float obstaculeSpeed;
    public float obstaculeRotationSpeed;
    public Vector3 rotationAleatory;

    [SerializeField] float tempoAtivo;
    [SerializeField] float tempoDesativo;

    public GameObject AlertSystemThird_Prefab;

    public Transform InitialPosition;


    bool canSpawnDamageBrick;
    bool isRunning;

    Rigidbody rb_prefab;
    RoundManager RoundManager;

    void Start()
    {
        canSpawnDamageBrick = true;

        rb_prefab = AlertSystemThird_Prefab.GetComponent<Rigidbody>();

        RoundManager = FindAnyObjectByType<RoundManager>();
    }

    void Update()
    {
        

        obstaculeSpeed = RoundManager.obstaculo_3_Speed;
        if (canSpawnDamageBrick)
        {
            StartCoroutine(SpawnDamageBrick());
        }
    }

    IEnumerator SpawnDamageBrick()
    {
        canSpawnDamageBrick = false;
        
        yield return new WaitForSeconds(5f);

        GameObject Obstacule3 = Instantiate(AlertSystemThird_Prefab, new Vector3(-64f, Random.Range(2f, 13f), -2.5f), Quaternion.identity);
        Destroy(Obstacule3, 10f);


        yield return new WaitForSeconds(5f);
        canSpawnDamageBrick = true;

    }




    private void OnTriggerExit(Collider other)
    {

    }
}