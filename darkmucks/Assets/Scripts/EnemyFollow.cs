using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    private CharacterController characterController;
    public float speed;
    public float RotationSpeed;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(target!=null)
        {
            Vector3 TargetDirection = target.position - transform.position;
            TargetDirection.y = 0;
            Quaternion TargetRotation = Quaternion.LookRotation(TargetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation,RotationSpeed*Time.deltaTime);
            characterController.Move(transform.forward*speed*Time.deltaTime);
        }
    }
}
