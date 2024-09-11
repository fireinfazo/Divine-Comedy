using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Slider manaSlider;
    public Slider easeManaSlider;
    public float maxMana = 100f;
    public float mana;
    private float lerpSpeed = 0.03f;

    void Start()
    {
        mana = maxMana;
    }

    void Update()
    {
        if (manaSlider.value != mana)
        {
            manaSlider.value = mana;
        }

        if (manaSlider.value != easeManaSlider.value)
        {
            easeManaSlider.value = Mathf.Lerp(easeManaSlider.value, mana, lerpSpeed);
        }
    }

    public void DrainMana(float manaDrain)
    {
        mana -= manaDrain;
        mana = Mathf.Max(mana, 0);
    }
}