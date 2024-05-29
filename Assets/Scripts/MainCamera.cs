using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class MainCamera : MonoBehaviour
{
    private InputAction zoomAction;
    private InputAction moveAction;

    public int metersPerSecond;
    public int minimumDistance;

    // Start is called before the first frame update
    void Start()
    {
        PlayerActions playerActions = new Actions().Player;
        playerActions.Enable();
        moveAction = playerActions.Move;
        zoomAction = playerActions.Zoom;
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        Vector3 position = transform.position;
        float speed = metersPerSecond * Time.deltaTime;
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 rotatedMove = transform.rotation * new Vector3(move.x, 0, move.y);
        rotatedMove.y = 0;
        position += speed * move.magnitude * rotatedMove.normalized;

        // Zoom
        Vector3 forward = transform.forward;
        float zoom = speed * zoomAction.ReadValue<float>();
        if (zoom < 0)
        {
            position += zoom * forward;
        }
        Physics.Raycast(position, forward, out RaycastHit hit);
        float zoomableDistance = Vector3.Distance(position, hit.point) - minimumDistance;
        while (zoomableDistance < 0)
        {
            position += zoomableDistance * forward;
            Physics.Raycast(position, forward, out hit);
            zoomableDistance = Vector3.Distance(position, hit.point) - minimumDistance;
        }
        if (zoom > 0)
        {
            position += Mathf.Min(zoom, zoomableDistance) * forward;
        }

        // Apply position
        transform.position = position;
    }
}
