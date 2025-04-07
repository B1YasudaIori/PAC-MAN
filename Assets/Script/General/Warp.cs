using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public Transform warpRightPoint;
    public Transform warpLeftPoint;

    private bool isWarping = false; 
    public float WarpCooldown = 0.5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isWarping) return; // ワープ中はスルー

        if (other.gameObject.name == "WarpLeft")
        {
            StartCoroutine(Warp(warpRightPoint.position));
        }
        else if (other.gameObject.name == "WarpRight")
        {
            StartCoroutine(Warp(warpLeftPoint.position));
        }
    }

    private System.Collections.IEnumerator Warp(Vector3 destination)
    {
        isWarping = true;
        transform.position = destination;

        yield return new WaitForSeconds(WarpCooldown); // 一定時間待つ

        isWarping = false;
    }
}
