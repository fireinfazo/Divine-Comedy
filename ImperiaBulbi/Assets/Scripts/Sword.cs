using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Sword : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 1f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
 
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("ZweiHanderOneAttack"))
        {
            anim.SetBool("ZweiHanderOneAttack", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("ZweiHanderTwoAttacks"))
        {
            anim.SetBool("ZweiHanderTwoAttacks", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("ZweiHanderThreeAttacks"))
        {
            anim.SetBool("ZweiHanderThreeAttacks", false);
            noOfClicks = 0;
        }
 
 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
 
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
 
            }
        }
    }
 
    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            anim.SetBool("ZweiHanderOneAttack", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
 
        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("ZweiHanderOneAttack"))
        {
            anim.SetBool("ZweiHanderOneAttack", false);
            anim.SetBool("ZweiHanderTwoAttacks", true);
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("ZweiHanderTwoAttacks"))
        {
            anim.SetBool("ZweiHanderTwoAttacks", false);
            anim.SetBool("ZweiHanderThreeAttacks", true);
        }
    }
}
