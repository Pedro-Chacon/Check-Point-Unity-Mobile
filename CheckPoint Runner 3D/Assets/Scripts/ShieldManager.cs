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

    // SWIPE
    [SerializeField] float minSwipeDistance = 100f;

    // POSI플O INICIAL DO TOQUE
    [SerializeField] private Vector2 startTouchPosition;

    // POSI플O FINAL DO TOQUE
    [SerializeField] private Vector2 endTouchPosition;

    [SerializeField] Player player;
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        player.GetComponent<BoxCollider>().enabled = true;
        canGenerateShield = true;
    }

    void Update()
    {
        shieldSpeed = FindAnyObjectByType<RoundManager>().shieldPrefabSpeed;

        if (canGenerateShield == true)
        {
            canGenerateShield = false;
            StartCoroutine(ShieldPrefabGenerator());
        }

        if (shieldActive == true)
        {
            shieldActive = false;
            StartCoroutine(TurnOnShield());
        }




        // VERIFICA SE EXISTE ALGUM TOQUE NA TELA
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // CAPTURA A POSI플O INICIAL DO TOQUE
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            // CAPTURA A POSI플O FINAL E VERIFICA O SWIPE
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                // PROCESSA O SWIPE
                DetectSwipe();
            }
        }

    }

    void DetectSwipe()
    {
        float deltaX = endTouchPosition.x - startTouchPosition.x;
        float deltaY = endTouchPosition.y - startTouchPosition.y;

        float SwipeDistance = Vector2.Distance(startTouchPosition, endTouchPosition);

        if (SwipeDistance < minSwipeDistance)
        {
            return;
        }

        if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
        {

            if (deltaY > 0 && player.EncostouShield == true)
            {
             
               
                    shieldActive = true;
                
            



            }
            else if (deltaY < 0)
            {



            }






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
        player.EncostouShield = false;
        shieldActive = false;
        player.canTakeDamage = false;

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

        #region Piscar Shield
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = true;
        #endregion

        shieldObject.gameObject.GetComponent<MeshRenderer>().enabled = false;
        player.canTakeDamage = true;

    }





}
