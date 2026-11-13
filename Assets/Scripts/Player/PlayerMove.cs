using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveable
{
    [SerializeField] private float _movementSpeed;

    private Vector2 _moveInput;
    private Rigidbody rb;
    private float _rotationSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _rotationSpeed = 10;
    }

    public void Move(Vector2 input)
    {
        _moveInput = input;
    }

    private void Update()
    {
        rb.linearVelocity = new Vector3(_moveInput.x * _movementSpeed, rb.linearVelocity.y, _moveInput.y * _movementSpeed);

        Vector3 lookDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
        if(lookDirection.sqrMagnitude > 0.01f)
        {
            Quaternion target = Quaternion.LookRotation(lookDirection);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, target, _rotationSpeed * Time.deltaTime));
        }

        Debug.Log(_movementSpeed);
    }


    public void ModifySpeed(float modifier)
    {
        _movementSpeed += modifier;
    }
   
}
