using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public Transform centrePoint; //centre of the area the agent wants to move around in
    public Transform target;
    private CharacterController characterController;
    public Animator animator; // Animator bile�eni
    public float speed;
    public float RotationSpeed;
    public float approachDistance = 3f; // Hedefe ne kadar yakla��laca�� mesafe
    public float visionDistance = 5f; // G�rme mesafesi

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0;
            float distanceToTarget = targetDirection.magnitude;

            // D��man�n hedefi g�rme mesafesine ula�mas� durumunda
            if (distanceToTarget <= visionDistance)
            {
                // Hedefe do�ru y�z
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

                // Hedefe do�ru ilerle
                if (distanceToTarget <= approachDistance)
                {
                    // E�er hedefe yeterince yak�nsa, hareket etmeyi durdur ve sald�r� animasyonunu oynat
                    agent.isStopped = true;
                    animator.SetBool("Slash", true);
                    animator.SetBool("IsWalking", false); // Hedefe yakla��rken y�r�me animasyonunu durdur
                }
                else
                {
                    // Hedefe do�ru ilerle
                    agent.isStopped = false;
                    characterController.Move(transform.forward * speed * Time.deltaTime);
                    animator.SetBool("Slash", false);
                    animator.SetBool("IsWalking", true); // Hedefe do�ru y�r�me animasyonunu ba�lat
                }
            }
            else
            {
                agent.isStopped = true;
                animator.SetBool("Slash", false);
                animator.SetBool("IsWalking", false);
            }
        }
    }
}



//    else
//    {
//        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
//        {
//            Vector3 point;
//            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
//            {
//                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
//                agent.SetDestination(point);
//            }
//        }
//    }

//}

//bool RandomPoint(Vector3 center, float range, out Vector3 result)
//{

//    Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
//    NavMeshHit hit;
//    if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
//    {
//        result = hit.position;
//        return true;
//    }

//    result = Vector3.zero;
//    return false;