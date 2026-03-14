using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class AlertSystem : MonoBehaviour
{
    [Header("Alert Object")]
    [SerializeField] float alertSpeed = 35f;

    [Header("Enemy Object")]
    [SerializeField] float timeToSpawn = 3f;
    [SerializeField] float timeToDestroy = 5f;
    [SerializeField] public float enemySpeed = 30f;
    [SerializeField] public float primeiroRound = 10f;
    [SerializeField] public float SegundoRound = 20f;
    [SerializeField] public float TerceiroRound = 20f;
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject spawnEnemyObject;

    public bool canSpawnEnemy = true;


    Player player;
    Rigidbody rb;
    MeshRenderer meshRenderer;

    void Start()
    {
        StartCoroutine(IncreaseEnemyVelocityOverTime());
        canSpawnEnemy = true;
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(canSpawnEnemy == true)
        {
            StartCoroutine(spawnEnemy());
        }
   
    }

    private void FixedUpdate()
    {

        Vector3 direcao = player.transform.position - transform.position;
        direcao = direcao.normalized;
        rb.linearVelocity = new Vector3(0f, direcao.y * alertSpeed, 0f);


    }
    IEnumerator IncreaseEnemyVelocityOverTime()
    {
        yield return new WaitForSeconds(primeiroRound);
        print("Fim primero Round");
        enemySpeed += 10f;
        yield return new WaitForSeconds(SegundoRound);
        print("Fim segundo Round");
        enemySpeed += 10f;
        yield return new WaitForSeconds(TerceiroRound);
        print("Fim terceiro Round");
        enemySpeed += 10f;
    }

    IEnumerator spawnEnemy()
    {
        canSpawnEnemy = false;

        //Piscar Alert
        #region Piscar Alert
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(2f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        #endregion

        Destroy(Instantiate(enemyObject, spawnEnemyObject.transform.position, Quaternion.identity), timeToDestroy);
        yield return new WaitForSeconds(timeToSpawn);
        canSpawnEnemy = true;
    }
}
