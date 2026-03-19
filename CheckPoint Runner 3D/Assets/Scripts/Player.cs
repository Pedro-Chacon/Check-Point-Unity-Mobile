using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] public int life = 3;
    [SerializeField] public float jumpForce = 20f;
    [SerializeField] public float Dash = 20f;
    [SerializeField] public bool OnFloor;
    [SerializeField] public int jumpCount;
    [SerializeField] public bool isDead = false;
    [SerializeField] public bool canTakeDamage = true;

    Rigidbody rb;

    [Header("Touch Settings")]
    [SerializeField] private Vector2 startTouchPosition;
    [SerializeField] private Vector2 endTouchPosition;
    [SerializeField] float minSwipeDistance = 60f;
    bool fingerMoved = false;
    float touchStartTime;
    [SerializeField] float holdTime = 0.1f;



    ShieldManager shieldManager;
    MeshRenderer meshRenderer;
    void Start()
    {
        jumpCount = 0;
        rb = GetComponent<Rigidbody>();
        shieldManager = FindAnyObjectByType<ShieldManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
        canTakeDamage = true;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                fingerMoved = false;
                touchStartTime = Time.time;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                float distance = Vector2.Distance(startTouchPosition, touch.position);

                if (distance > minSwipeDistance)
                {
                    fingerMoved = true;
                }
            }

            else if (touch.phase == TouchPhase.Stationary)
            {
                // só pula se segurou tempo suficiente E não virou swipe
                if (!fingerMoved && Time.time - touchStartTime > holdTime)
                {
                    Jump();
                }
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
            }
        }


    }
    void Jump()
    {
        jumpCount++;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }


    void DetectSwipe()
    {
        float deltaY = endTouchPosition.y - startTouchPosition.y;
        float deltaX = endTouchPosition.x - startTouchPosition.x;

        float swipeDistance = Vector2.Distance(startTouchPosition, endTouchPosition);
        Touch touch = Input.GetTouch(0);

        // SE NÃO FOR SWIPE -> PULO
        if (swipeDistance < minSwipeDistance)
        {
            Jump();
            return;
        }

        // SE FOR SWIPE -> OUTRAS AÇÕES
        if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
        {
            if (deltaY > 0)
            {
                print("Cima");
            }
            else
            {
                print("Baixo");
            }
        }
    }

    IEnumerator PiscarDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.2f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.2f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.2f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.enabled = true;

        canTakeDamage = true;
        StopCoroutine(PiscarDamage());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShieldPrefab"))
        {
            shieldManager.shieldActive = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (canTakeDamage == true)
            {
                life--;
                StartCoroutine(PiscarDamage());
            }
        }



    }

}



