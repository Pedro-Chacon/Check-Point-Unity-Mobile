using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] float coinSpawnTime = 5f;
    [SerializeField] public float coinSpeed;
    [SerializeField] public float transicaoTempoMoedas;
    [SerializeField] public float primeiroRound = 10f;
    [SerializeField] public float SegundoRound = 20f;
    [SerializeField] public float TerceiroRound = 20f;


    [SerializeField] public int coinCount;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] public Vector3 angulosRotacao = new Vector3(0f, 90f, 0f);
    public Transform coinLimitX;
    public Transform coinLimitX_1;
    public Transform coinLimitY;
    public Transform coinLimitY_1;

    bool canSpawnCoin;
    bool CoroutineTimeSpawnCoin;

    void Start()
    {

        StartCoroutine(IncreaseCoinVelocityOverTime());
        coinSpeed = 8f;
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
    IEnumerator IncreaseCoinVelocityOverTime()
    {
        CoroutineTimeSpawnCoin = true;
        yield return new WaitForSeconds(primeiroRound);
        print("Fim primero Round");
        canSpawnCoin = false;
        CoroutineTimeSpawnCoin = false;
        yield return new WaitForSeconds(transicaoTempoMoedas);
        canSpawnCoin = true;
        CoroutineTimeSpawnCoin = true;
        coinSpeed += 10f;

        yield return new WaitForSeconds(SegundoRound);
        print("Fim segundo Round");
        canSpawnCoin = false;
        CoroutineTimeSpawnCoin = false;
        yield return new WaitForSeconds(transicaoTempoMoedas);
        canSpawnCoin = true;
        CoroutineTimeSpawnCoin = true;
        coinSpeed += 10f;

        yield return new WaitForSeconds(TerceiroRound);
        canSpawnCoin = false;
        CoroutineTimeSpawnCoin = false;
        yield return new WaitForSeconds(transicaoTempoMoedas);
        canSpawnCoin = true;
        CoroutineTimeSpawnCoin = true;
        print("Fim terceiro Round");
        coinSpeed += 10f;
    }

    IEnumerator spawnCoin()
    {
        canSpawnCoin = false;

        if (CoroutineTimeSpawnCoin == true)
        {
            float randomPosX = Random.Range(coinLimitX.transform.position.x, coinLimitX_1.transform.position.x);
            float randomPosY = Random.Range(coinLimitY.transform.position.y, coinLimitY_1.transform.position.y);
            Vector3 SpawnVector = new Vector3(randomPosX, randomPosY, -2.5f);
            Destroy(Instantiate(coinPrefab, SpawnVector, Quaternion.Euler(0f, 0f, 90f)), 30f);
            coinPrefab.GetComponent<CoinObject>().coinSpeed = coinSpeed;
        }

        yield return new WaitForSeconds(coinSpawnTime);
        canSpawnCoin = true;
    }

}
