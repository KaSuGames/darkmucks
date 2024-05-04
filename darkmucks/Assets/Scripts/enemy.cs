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
    public Animator animator; // Animator bileþeni
    public float speed;
    public float RotationSpeed;
    public float approachDistance = 3f; // Hedefe ne kadar yaklaþýlacaðý mesafe
    public float visionDistance = 5f; // Görme mesafesi

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

            // Düþmanýn hedefi görme mesafesine ulaþmasý durumunda
            if (distanceToTarget <= visionDistance)
            {
                // Hedefe doðru yüz
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

                // Hedefe doðru ilerle
                if (distanceToTarget <= approachDistance)
                {
                    // Eðer hedefe yeterince yakýnsa, hareket etmeyi durdur ve saldýrý animasyonunu oynat
                    agent.isStopped = true;
                    animator.SetBool("Slash", true);
                    animator.SetBool("IsWalking", false); // Hedefe yaklaþýrken yürüme animasyonunu durdur
                }
                else
                {
                    // Hedefe doðru ilerle
                    agent.isStopped = false;
                    characterController.Move(transform.forward * speed * Time.deltaTime);
                    animator.SetBool("Slash", false);
                    animator.SetBool("IsWalking", true); // Hedefe doðru yürüme animasyonunu baþlat
                }
            }
            else
            {
                if (agent.remainingDistance <= agent.stoppingDistance) //done with path
                {
                    Vector3 point;
                    if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                    {
                        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                        agent.SetDestination(point);
                    }
                }
                animator.SetBool("Slash", false);
                animator.SetBool("IsWalking", true);
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}