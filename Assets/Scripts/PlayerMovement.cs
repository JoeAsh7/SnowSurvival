using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 moveValue;

    private void Awake()
    {
        // Set up references
        moveValue = Vector2.zero;
    }

    private void Update()
    {
        Move();
    }

    // Public function that I can use to respond to Input Actions
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveValue = ctx.ReadValue<Vector2>();
    }
private void Move()
{
    Vector3 movement = new Vector3(moveValue.x, moveValue.y, 0) * speed * Time.deltaTime;
    Vector3 newPosition = transform.position + movement;

    // Clamp position values (use your desired bounds here)
    newPosition.x = Mathf.Clamp(newPosition.x, -8, 9f);
    newPosition.y = Mathf.Clamp(newPosition.y, -3.6f, -3.0f);

    transform.position = newPosition;
}
}
