using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationManager : MonoBehaviour {

    public static NavigationManager self; 

    [SerializeField]
    NavMeshSurface[] navMeshSurfaces;




    private void Awake()
    {
        self = this;
    }

    private void Start()
    {
        for(int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }
}
