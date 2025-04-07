using UnityEngine;
public class Eye : MonoBehaviour
{
    [SerializeField] private Sprite _eye_up;
    [SerializeField] private Sprite _eye_down;
    [SerializeField] private Sprite _eye_left;
    [SerializeField] private Sprite _eye_right;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeEye(Vector2 direction)
    {

        if (direction == Vector2.up)
        {
            spriteRenderer.sprite = _eye_up;
        }
        else if (direction == Vector2.down)
        {
            spriteRenderer.sprite = _eye_down;
        }
        else if (direction == Vector2.left)
        {
            spriteRenderer.sprite = _eye_left;
        }
        else if (direction == Vector2.right)
        {
            spriteRenderer.sprite = _eye_right;
        }
    }
}