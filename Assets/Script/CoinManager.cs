using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
