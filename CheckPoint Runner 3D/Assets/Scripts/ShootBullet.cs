using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] public float shootSpeed;
    [SerializeField] public GameObject bullet;
    [SerializeField] public int municao = 3;
    [SerializeField] public Transform spawnTiro;

    // POSI플O INICIAL DO TOQUE
    [SerializeField] private Vector2 startTouchPosition;

    // POSI플O FINAL DO TOQUE
    [SerializeField] private Vector2 endTouchPosition;


  

    private void Start()
    {
       
    }
    void Update()
    {
       
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


        if (deltaX > 1)
        {
            print("Direita");

            if (municao > 0)
            {
                municao--;
                Destroy(Instantiate(bullet, spawnTiro.transform.position, Quaternion.identity), 3);
                
            }



        }
        else if (deltaX < 1)
        {
            print("Esquerda");
       

        }

        if (deltaY > 1)
        {
            print("Cima");
       
        }
        else if (deltaY < 1)
        {
            print("Baixo");
       
        }

    }
}

