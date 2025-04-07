using UnityEngine;

public class Cookie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("衝突した相手: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーと接触！");
            ScoreManager.Instance.AddScore(10);
            gameObject.SetActive(false);
            GameManager.instance.CheckCookies();
        }
    }

}
