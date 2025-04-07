using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask _stageLayer;
    [SerializeField] Eye _eye;
    private Rigidbody2D rb;
    private float speed = 7.5f;
    private Vector2 Direction;
    private Vector2 DirectionReserve;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = Vector2.left;
    }
    private void Update()
    {
        if (DirectionReserve != Vector2.zero)
        {
            CheckDirection(DirectionReserve);
        }
    }
    private void FixedUpdate()
    {
        Vector2 dist = Direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + dist);
    }
    private void CheckDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, _stageLayer);
        if (hit.collider == null)
        {
            Direction = direction;
            _eye.ChangeEye(Direction);
            DirectionReserve = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Point point = other.GetComponent<Point>();
        if (point != null)
        {
            int index = Random.Range(0, point.Directions.Count);
            DirectionReserve = point.Directions[index];
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // 進行方向が逆なら避ける
            Vector2 otherDir = other.gameObject.GetComponent<Enemy>()?.Direction ?? Vector2.zero;
            if (Vector2.Dot(Direction, otherDir) < -0.5f) // ほぼ正面から来たとき
            {
                // 進行方向をランダムに変更（例：上下左右のどれか）
                List<Vector2> candidates = new List<Vector2>
            {
                Vector2.left, Vector2.right, Vector2.up, Vector2.down
            };
                candidates.Remove(Direction); // 現在の方向は除外
                Vector2 newDir = candidates[Random.Range(0, candidates.Count)];
                DirectionReserve = newDir;
            }
        }
    }


}