using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : MonoBehaviour
{
    public void UpdateSlider(int maxHP, int curHP)
    {
        gameObject.GetComponent<Slider>().maxValue = maxHP;
        gameObject.GetComponent<Slider>().value = curHP;
    }

    public IEnumerator SliderAnimation(int curHP)
    {
        for (int i = 0; i < gameObject.GetComponent<Slider>().value - curHP; i++)
        {
            gameObject.GetComponent<Slider>().value--;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
