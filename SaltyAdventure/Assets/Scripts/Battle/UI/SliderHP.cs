using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : MonoBehaviour
{
    public Image FillImg;

    public void UpdateSlider(int maxHP, int curHP)
    {
        GetComponent<Slider>().maxValue = maxHP;
        GetComponent<Slider>().value = curHP;

        CheckColor();
    }

    public void AttackAnimation()
    {
        GetComponent<Slider>().value--;
        CheckColor();
    }

    public void HealAnimation()
    {
        GetComponent<Slider>().value++;
        CheckColor();
    }

    void CheckColor()
    {
        float Percentage = GetComponent<Slider>().value / GetComponent<Slider>().maxValue;

        if (Percentage >= 0.4f)
            FillImg.color = new Color(66f / 255f, 149f / 255f, 0);
        else if (Percentage < 0.4f && Percentage > 0.15f)
            FillImg.color = new Color(255f / 255f, 149f / 255f, 0);
        else
            FillImg.color = new Color(255f / 255f, 0, 0);
    }
}
