using UnityEngine;

public class DestroyWall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacule3"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("AddBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
