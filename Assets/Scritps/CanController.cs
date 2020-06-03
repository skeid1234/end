using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum MoveType 
{
    TransformTranslate,
    RigidbodyVelocity
}

public class CanController : MonoBehaviour
{
    public float Speed = 1;
    public MoveType MoveType = MoveType.RigidbodyVelocity;
    public Collider DeadCollider;
    public TrackableEventHandler Target;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    public bool IsMoving { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            switch (MoveType)
            {
                case MoveType.TransformTranslate:
                    break;
                case MoveType.RigidbodyVelocity:
                    _rigidbody.velocity = _direction.normalized * Speed;
                    break;
                default:
                    break;
            }
        }
    }

    public void StartMove(Vector3 directon, Collider deadCollider, TrackableEventHandler target)
    {
        _direction = directon;
        DeadCollider = deadCollider;
        Target = target;
        Target.TargetEvent += DestroyOnTargetLost;
        IsMoving = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == DeadCollider)
        {
            Destroy(gameObject);
        }
    }

    private void DestroyOnTargetLost(bool condition, GameObject target)
    {
        if (!condition)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Target.TargetEvent -= DestroyOnTargetLost;
    }
}
