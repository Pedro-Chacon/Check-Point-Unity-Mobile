using UnityEngine;
using TMPro;
public class HudManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    public int coinCount;
    void Start()
    {
        coinCount = 0;
        
        
    }


    void Update()
    {
        coinText.text = "Coin Count: " + coinCount;
    }
}
