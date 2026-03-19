using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [Header("Round Options")]
    [SerializeField] public float primeiroRound = 10f;
    [SerializeField] public float SegundoRound = 20f;
    [SerializeField] public float TerceiroRound = 20f;
    [SerializeField] public float TempoAteComecarOsRounds = 10f;
    [SerializeField] public float TransicaoTempoSpawn = 10f;

    [Header("Start Objects Velocity")]
    [SerializeField] public float enemySpeed = 30f;
    [SerializeField] public float coinSpeed = 8f;
    [SerializeField] public float addBulletSpeed = 8f;
    [SerializeField] public float shieldPrefabSpeed = 8f;
    [SerializeField] public float obstaculo_3_Speed = 8f;

     Obstacule3 obstacule3;


    void Start()
    {

        StartCoroutine(IncreaseObjectsVelocity());
    }

    void Update()
    {

    }
    
    IEnumerator IncreaseObjectsVelocity()
    {
        yield return new WaitForSeconds(TempoAteComecarOsRounds);
        print("Acabou tempo de espera de começar os Rounds");

        print("Vai começar primeiro Round");
        yield return new WaitForSeconds(primeiroRound);
        print("Começou primero Round");
        enemySpeed += 10f;
        coinSpeed += 10f;
        addBulletSpeed += 10f;
        obstaculo_3_Speed += 10f;
        shieldPrefabSpeed += 10f;

        print("Fim primero Round");
        yield return new WaitForSeconds(TransicaoTempoSpawn);


        print("Vai começar segundo Round");
        yield return new WaitForSeconds(SegundoRound);
        print("Começou segundo Round");
        enemySpeed += 10f;
        coinSpeed += 10f;
        addBulletSpeed += 10f;
        obstaculo_3_Speed += 10f;
        shieldPrefabSpeed += 10f;


        print("Fim segundo Round");
        yield return new WaitForSeconds(TransicaoTempoSpawn);


        print("Vai começar terceiro Round");
        yield return new WaitForSeconds(TerceiroRound);
        print("Começou terceiro Round");
        enemySpeed += 10f;
        coinSpeed += 10f;
        addBulletSpeed += 10f;
        obstaculo_3_Speed += 10f;
        shieldPrefabSpeed += 10f;

        print("Fim terceiro Round");
    }
}
