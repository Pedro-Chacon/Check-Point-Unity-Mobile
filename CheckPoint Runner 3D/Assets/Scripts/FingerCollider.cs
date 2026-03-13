
using Unity.VisualScripting;
using UnityEngine;

public class FingerCollider : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 12));
            
            transform.position = pos;


        }

    }
    private void OnTriggerEnter(Collider other)
    {
     

            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
        
    }






}
