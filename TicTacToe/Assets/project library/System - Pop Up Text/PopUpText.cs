using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField] GameObject art; 
    [SerializeField] Animator anim;
    [SerializeField] float disableTime; 

    public void OnActivation(string animationToPlay)
    {
        art.SetActive(false);
        anim.Play(animationToPlay, -1, 0);
        art.SetActive(true);
        Invoke("Disable", disableTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    public void PlayAnimation(string animationToPlay)
    {
        anim.Play(animationToPlay, -1, 0);
    }



}
