using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagicButtonAnimations : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Animator pulseAnim;
    [SerializeField] GameObject flashAnim;


    [Header("ON ENABLE")]
    [SerializeField] bool pulseOnEnable;
    [SerializeField] bool flashOnEnable;
    [SerializeField] bool slideInOnEnable;
    [Header("ON PRESS")]
    [SerializeField] bool slideOutOnPress;
    [Header("MISC.")]
    [SerializeField] bool disableAfterSlideOut; 

    private void OnEnable()
    {
        CheckForOnEnableAnimations();
    }

    void CheckForOnEnableAnimations()
    {
        if (pulseOnEnable)
        {
            PlayPulse();
        }
        if (flashOnEnable)
        {
            PlayFlash();
        }

        if (slideInOnEnable)
            SlideIn();
    }


    public void OnPress()
    {
        if (slideOutOnPress)
        {
            SlideOut();
        }
    }


    public void SlideIn()
    {
        anim.Play("slide in", 0, 0);
    }

    public void SlideOut()
    {
        anim.Play("slide out", 0, 0);
        if (disableAfterSlideOut)
            Invoke("DisableAfterAnimation", anim.GetCurrentAnimatorStateInfo(0).length);
    }

    public void PlayPulse()
    {
        pulseAnim.enabled = true;
    }

    public void StopPulse()
    {
        pulseAnim.enabled = false;
    }

    public void PlayFlash()
    {
        flashAnim.SetActive(true);
    }

    public void StopFlash()
    {
        flashAnim.SetActive(false);
    }

    void DisableAfterAnimation()
    {
        gameObject.SetActive(false);
    }


}
