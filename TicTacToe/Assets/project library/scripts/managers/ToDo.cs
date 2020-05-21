using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDo : MonoBehaviour {


    public bool active;

    public List<string> toDoList = new List<string>();

  

    private void Start()
    {
        if (active)
        {
            PrintToDoList();
        }

    }

    void PrintToDoList()
    {
        Debug.Log("TODO ------------------------------------------------------------------------------------------------------------------ \n");
        for (int i = 0; i < toDoList.Count; i++)
        {
            Debug.Log((i + 1) + " " + "- " + toDoList[i] + "\n");
        }
        Debug.Log("------------------------------------------------------------------------------------------------------------------------");
    }

}
