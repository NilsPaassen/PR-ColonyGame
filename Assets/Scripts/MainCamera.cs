using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class MainCamera : MonoBehaviour
{
    private InputAction zoomAction;
    private InputAction moveAction;
    private InputAction rotateAction;

    public int metersPerSecond;
    public int degreesPerSecond;
    public int minimumAngle;
    public int maximumAngle;
    public int minimumDistance;

    // Start is called before the first frame update
    void Start()
    {
        PlayerActions playerActions = new Actions().Player;
        playerActions.Enable();
        zoomAction = playerActions.Zoom;
        moveAction = playerActions.Move;
        rotateAction = playerActions.Rotate;
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        float speed = metersPerSecond * Time.deltaTime;
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 rotatedMove = transform.rotation * new Vector3(move.x, 0, move.y);
        rotatedMove.y = 0;
        transform.position += speed * move.magnitude * rotatedMove.normalized;

        // Zoom
        float zoom = speed * zoomAction.ReadValue<float>();
        if (zoom < 0)
        {
            transform.position += zoom * transform.forward;
        }
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
        float zoomableDistance = Vector3.Distance(transform.position, hit.point) - minimumDistance;
        while (zoomableDistance < 0)
        {
            transform.position += zoomableDistance * transform.forward;
            Physics.Raycast(transform.position, transform.forward, out hit);
            zoomableDistance = Vector3.Distance(transform.position, hit.point) - minimumDistance;
        }
        if (zoom > 0)
        {
            transform.position += Mathf.Min(zoom, zoomableDistance) * transform.forward;
        }

        // Rotate
        float degreesSpeed = degreesPerSecond * Time.deltaTime;
        Vector2 rotate = rotateAction.ReadValue<Vector2>();
        transform.RotateAround(hit.point, Vector3.down, degreesSpeed * rotate.x);
        float currentAngle = transform.rotation.eulerAngles.x;
        transform.RotateAround(
            hit.point,
            transform.rotation * Vector3.right,
            Mathf.Clamp(
                degreesSpeed * rotate.y,
                minimumAngle - currentAngle,
                maximumAngle - currentAngle
            )
        );
    }
}
