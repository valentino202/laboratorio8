using System;
using UnityEngine;
using UnityEngine.InputSystem;


[Serializable]
public class PlayerStats
{

    public int Life;
    public int Atk;
}


public class Player : MonoBehaviour
{
    public InputSystem_Actions input;

    public PlayerStats playerStats;

    public float step = 5;
    public float delay;
    public bool ableMove = true;
    public Vector2 moveInput;

    public Vector2 MapLimits = new Vector2(10, 8);
    private void Awake()
    {
        input = new();
    }
    private void OnEnable()
    {
        input.Enable();

        input.Player.Move.started += OnMove;
        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;
    }
    private void OnDisable()
    {
        input.Player.Move.started -= OnMove;
        input.Player.Move.performed -= OnMove;
        input.Player.Move.canceled -= OnMove;

        input.Disable();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        MovementMechanic(moveInput);

    }
    void Start()
    {

    }

    private void Update()
    {

    }
    public void MovementMechanic(Vector3 dir)
    {
        dir.Normalize();
        if (ableMove)
        {
            Invoke("EnableMovement", delay);
            transform.position += dir * step;
            ableMove = false;

        }


        MapLimitValidation(transform.position);
    }
    public void EnableMovement()
    {
        ableMove = true;
    }
    public void MapLimitValidation(Vector2 playerPositon)
    {
        float PlayerPosX = playerPositon.x;
        float PlayerPosY = playerPositon.y;

        bool LimitX = PlayerPosX >= MapLimits.x || PlayerPosX <= -MapLimits.x;
        bool LimitY = PlayerPosY >= MapLimits.y || PlayerPosY <= -MapLimits.y;

        if (LimitX || LimitY)
        {
            throw new Exception(" Se intento atravezar los limites del mapa");
        }
    }

}
