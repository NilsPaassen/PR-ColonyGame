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

    private float remainingZoom = 0;

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
        // Zoom
        float time = Time.deltaTime;
        float speed = metersPerSecond * time;
        float zoom = speed * zoomAction.ReadValue<float>();
        if (zoom == 0)
        {
            zoom = Mathf.MoveTowards(0, remainingZoom, speed);
            remainingZoom -= zoom;
        }
        else
        {
            remainingZoom = 0;
            if (!Mathf.Approximately(zoom, speed) && Mathf.Abs(zoom) > speed)
            {
                remainingZoom = zoom;
                zoom = Mathf.Sign(zoom) * speed;
                remainingZoom -= zoom;
            }
        }
        float alreadyZoomed = 0;
        if (zoom < 0)
        {
            transform.position += zoom * transform.forward;
            alreadyZoomed += zoom;
        }
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
        float zoomableDistance = Vector3.Distance(transform.position, hit.point) - minimumDistance;
        if (!Mathf.Approximately(alreadyZoomed, -speed))
        {
            while (zoomableDistance < 0)
            {
                float toZoom = Mathf.Max(zoomableDistance, -speed - alreadyZoomed);
                transform.position += toZoom * transform.forward;
                alreadyZoomed += toZoom;
                if (Mathf.Approximately(alreadyZoomed, -speed))
                {
                    break;
                }
                Physics.Raycast(transform.position, transform.forward, out hit);
                zoomableDistance =
                    Vector3.Distance(transform.position, hit.point) - minimumDistance;
            }
        }
        if (zoom > 0 && zoomableDistance > 0)
        {
            transform.position += Mathf.Min(zoom, zoomableDistance) * transform.forward;
            if (Mathf.Approximately(zoomableDistance, zoom) || zoomableDistance < zoom)
            {
                remainingZoom = 0;
            }
        }

        // Move
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 rotatedMove = transform.rotation * new Vector3(move.x, 0, move.y);
        rotatedMove.y = 0;
        transform.position += speed * move.magnitude * rotatedMove.normalized;

        // Rotate
        float degreesSpeed = degreesPerSecond * time;
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
