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
    [SerializeField] GameObject enemyObject;
    public bool canSpawnEnemy = true;


    Player player;
    Rigidbody rb;

    void Start()
    {
        canSpawnEnemy = true;
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
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


    IEnumerator spawnEnemy()
    {
        canSpawnEnemy = false;
        Destroy(Instantiate(enemyObject, transform.position, Quaternion.identity), timeToDestroy);
        yield return new WaitForSeconds(timeToSpawn);
        canSpawnEnemy = true;
    }
}
