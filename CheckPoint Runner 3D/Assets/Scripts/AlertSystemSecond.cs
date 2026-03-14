using System.Collections;
using UnityEngine;

public class AlertSystemSecond : MonoBehaviour
{
    [SerializeField] float tempoAtivo;
    [SerializeField] float tempoDesativo;
    public GameObject damageBrick;
    public GameObject Alert1;
    public GameObject Alert2;
    MeshRenderer meshRendererAlert1;
    MeshRenderer meshRendererAlert2;
    MeshRenderer meshRendererBrickDamage;
    bool canSpawnDamageBrick;
    void Start()
    {
        canSpawnDamageBrick = true;
        meshRendererAlert1 = Alert1.GetComponent<MeshRenderer>();
        meshRendererAlert2 = Alert2.GetComponent<MeshRenderer>();
        meshRendererBrickDamage = damageBrick.GetComponent<MeshRenderer>();

    }

    void Update()
    {
        if (canSpawnDamageBrick) 
        {
            StartCoroutine(SpawnDamageBrick());
        }
    }

    IEnumerator SpawnDamageBrick()
    {

        canSpawnDamageBrick = false;
        meshRendererBrickDamage.enabled = false;
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;

        transform.position = new Vector3(transform.position.x, Random.Range(1f, 13f), transform.position.z);

        yield return new WaitForSeconds(tempoDesativo);

        //Código para piscar
        #region Piscar
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(2f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRendererAlert1.enabled = false;
        meshRendererAlert2.enabled = false;
        yield return new WaitForSeconds(0.1f);
        #endregion

        meshRendererBrickDamage.enabled = true;
        meshRendererAlert1.enabled = true;
        meshRendererAlert2.enabled = true;

        yield return new WaitForSeconds(tempoAtivo);

        canSpawnDamageBrick = true;

    }



}
