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
    private float LerpSpeed = 0.03f;
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

        if (Input.GetMouseButtonDown(1))
        {
            DrainMana(10);
        }

        if (manaSlider.value != easeManaSlider.value)
        {
            easeManaSlider.value = Mathf.Lerp(easeManaSlider.value, mana, LerpSpeed);
        }
    }

    public void DrainMana(float ManaDrain)
    {
        mana -= ManaDrain;
    }
}
