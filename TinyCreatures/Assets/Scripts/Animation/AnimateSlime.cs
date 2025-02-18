using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSlime : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public static AnimateSlime Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void EatHappyEmogy()
    {
        anim.SetTrigger("eat");
    }

    public void SetHappyParametr(float number)
    {
        anim.SetFloat("happy", number);
    }
}
