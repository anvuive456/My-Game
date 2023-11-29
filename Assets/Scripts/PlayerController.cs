using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask longGrassLayer;
    private bool _isMoving;

    private Vector2 _input;

    private Animator _animator;
    public VariableJoystick joystick;
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private CameraController _cameraController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _cameraController = GetComponent<CameraController>();
    }

    private void AnimateSprite(float x, float y)
    {
        _animator.SetFloat(MoveX, x);
        _animator.SetFloat(MoveY, y);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            if (_cameraController.IsBattling)
                _cameraController.SwitchToPlayer();
            else 
                _cameraController.SwitchToBattle();
        }

        if (!_isMoving)
        {
            // _input.x = Input.GetAxisRaw("Horizontal");
            // _input.y = Input.GetAxisRaw("Vertical");

            _input = joystick.Direction;

            //remove diogal movement
            if (_input.x != 0) _input.y = 0;

            if (_input != Vector2.zero)
            {
                AnimateSprite(_input.x, _input.y);

                var targetPos = transform.position;
                targetPos.x += _input.x;
                targetPos.y += _input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        _animator.SetBool(IsMoving, _isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        _isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        _isMoving = false;

        CheckForEncounters();
    }


    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }

    private const double MeetFoeRate = 10.0;

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101) <= MeetFoeRate)
            {
                Debug.Log("Nhào vô cu");
            }
        }
    }
}