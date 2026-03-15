using System.Collections;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] public GameObject shieldObject;
    [SerializeField] public GameObject shieldPrefab;
    [SerializeField] public bool shieldActive = false;
    [SerializeField] public bool canGenerateShield = true;
    [SerializeField] public float shieldTimeActive;
    [SerializeField] public float shieldSpeed;
    [SerializeField] public float shieldPrefb_TimeToSpawn;

    void Start()
    {

        canGenerateShield = true;
    }

    void Update()
    {
        shieldSpeed = FindAnyObjectByType<RoundManager>().shieldPrefabSpeed;

        if (canGenerateShield == true)
        {
            StartCoroutine(ShieldPrefabGenerator());
        }


        if (shieldActive == true)
        {
            StartCoroutine(TurnOnShield());
        }


    }

    IEnumerator ShieldPrefabGenerator()
    {
        canGenerateShield = false;

        yield return new WaitForSeconds(shieldPrefb_TimeToSpawn);

        Vector3 posSpawn = new Vector3(-52, Random.Range(1f, 16f), -2.5f);
        Destroy(Instantiate(shieldPrefab, posSpawn, Quaternion.identity), 15f);
        


        canGenerateShield = true;

    }

     IEnumerator TurnOnShield()
    {
        shieldActive = false;

        #region Piscar Shield
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = true;
        #endregion

        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(shieldTimeActive);

        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }





}
