using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBulletRandom : MonoBehaviour
{
    [SerializeField] public GameObject AddBullet;
    [SerializeField] public float timeToSpawn;
    [SerializeField] public float addBulletSpeed;
    [SerializeField] public Transform spawnAddBullet_X;
    bool canSpawnBullet;

    RoundManager roundManager;
    void Start()
    {
        canSpawnBullet = true;
        roundManager = FindAnyObjectByType<RoundManager>();
    }


    void Update()
    {
        addBulletSpeed = roundManager.addBulletSpeed;

        if(canSpawnBullet == true)
        {
            StartCoroutine(SpawnBullet());
        }
        
    }


    IEnumerator SpawnBullet()
    {
        canSpawnBullet = false;
        yield return new WaitForSeconds(timeToSpawn);
        Vector3 randomPosition = new Vector3(spawnAddBullet_X.transform.position.x,Random.Range(3, 12) ,-2.5f);
        Destroy(Instantiate(AddBullet, randomPosition, Quaternion.identity), 20f);
        canSpawnBullet = true;

    }



}
