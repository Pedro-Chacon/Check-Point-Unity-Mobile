using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [Header("Round Options")]
    [SerializeField] public float primeiroRound = 10f;
    [SerializeField] public float SegundoRound = 20f;
    [SerializeField] public float TerceiroRound = 20f;
    [SerializeField] public float TransicaoTempoSpawn = 10f;

    [Header("Start Objects Velocity")]
    [SerializeField] public float enemySpeed = 30f;
    [SerializeField] public float coinSpeed = 8f;
    [SerializeField] public float addBulletSpeed = 8f;

    [SerializeField] public float obstaculo_3_Speed = 8f;
    AlertSystemThird AlertSystemThird;

    void Start()
    {
        AlertSystemThird = FindAnyObjectByType<AlertSystemThird>();
        StartCoroutine(IncreaseObjectsVelocity());
    }

    void Update()
    {
        
    }
    
    IEnumerator IncreaseObjectsVelocity()
    {
        print("Começou primero Round");
        yield return new WaitForSeconds(primeiroRound);
        print("Fim primero Round");
        enemySpeed += 10f;
        coinSpeed += 10f;
        addBulletSpeed += 10f;
        obstaculo_3_Speed += 10f;
        AlertSystemThird.InitialPosition.transform.position += new Vector3(10f, 0f, 0f);

        yield return new WaitForSeconds(TransicaoTempoSpawn);


        print("Começou segundo Round");
        yield return new WaitForSeconds(SegundoRound);
        print("Fim segundo Round");
        enemySpeed += 10f;
        coinSpeed += 10f;
        addBulletSpeed += 10f;
        obstaculo_3_Speed += 10f;
    


        yield return new WaitForSeconds(TransicaoTempoSpawn);


        print("Começou terceiro Round");
        yield return new WaitForSeconds(TerceiroRound);
        print("Fim terceiro Round");
        enemySpeed += 10f;
        coinSpeed += 10f;
        addBulletSpeed += 10f;
        obstaculo_3_Speed += 10f;
    

    }
}
