using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationMovement : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform dest;
    public bool hasReachedDest;
    public Transform atThisDest; 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        Invoke("LateEnable",.5f);
    }

    void LateEnable()
    {
        SetDest(Player.self.transform);
    }

    public void SetDest(Transform point)
    {
        if(!agent.enabled)
        {
            agent.enabled = true; 
        }
        dest = point;
        hasReachedDest = false; 
        agent.SetDestination(point.position);
    }

    private void Update()
    {
        if(agent != null && dest != null)
        {
            agent.SetDestination(dest.position);

            if(agent.remainingDistance < 2)
            {
                transform.position = dest.position;
            }
        }



        if(agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
           
            Disable(); 
        }

       // Debug.Log(" dest: " + dest.position);
    }

    void Disable()
    {
        agent.enabled = false;
        atThisDest = dest;
        hasReachedDest = true;
        dest = null;
        this.enabled = false; 
    }

}
