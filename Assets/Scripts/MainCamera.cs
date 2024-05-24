using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class MainCamera : MonoBehaviour
{
    private InputAction moveAction;

    public int metersPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        PlayerActions playerActions = new Actions().Player;
        playerActions.Enable();
        moveAction = playerActions.Move;
    }

    void Update()
    {
        Vector3 move = moveAction.ReadValue<Vector2>();
        Vector3 rotatedMove = transform.rotation * new Vector3(move.x, 0, move.y);
        rotatedMove.y = 0;
        transform.position += rotatedMove.normalized * metersPerSecond * Time.deltaTime;
    }
}
