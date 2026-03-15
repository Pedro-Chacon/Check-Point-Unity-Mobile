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
    [SerializeField] public float enemySpeed;
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject spawnEnemyObject;

    public bool canSpawnEnemy = true;


    Player player;
    Rigidbody rb;
    MeshRenderer meshRenderer;
    RoundManager roundManager;

    void Start()
    {
        roundManager = FindAnyObjectByType<RoundManager>();
        canSpawnEnemy = true;
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
        meshRenderer = GetComponent<MeshRenderer>();

        
    }

    void Update()
    {
        enemySpeed = roundManager.enemySpeed;

        if (canSpawnEnemy == true)
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
