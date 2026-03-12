using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] float coinSpawnTime = 5f;
    public int coinCount;
    [SerializeField] GameObject coinPrefab;
    public Vector3 angulosRotacao = new Vector3(0f, 90f, 0f);
    public Transform coinLimitX;
    public Transform coinLimitX_1;
    public Transform coinLimitY;
    public Transform coinLimitY_1;

    bool canSpawnCoin;
    void Start()
    {
        canSpawnCoin = true;
        coinCount = 0;
    }

 
    void Update()
    {
        
        if (canSpawnCoin == true)
        {
            StartCoroutine(spawnCoin());
        }


    }

    IEnumerator spawnCoin()
    {
        canSpawnCoin = false;
        float randomPosX = Random.Range(coinLimitX.transform.position.x, coinLimitX_1.transform.position.x);
        float randomPosY = Random.Range(coinLimitY.transform.position.y, coinLimitY_1.transform.position.y);
        Vector3 SpawnVector = new Vector3(randomPosX, randomPosY, -2.5f);
        Destroy(Instantiate(coinPrefab, SpawnVector, Quaternion.Euler(0f, 0f, 90f)), 30f);



        yield return new WaitForSeconds(coinSpawnTime);
        canSpawnCoin = true;
    }

}
