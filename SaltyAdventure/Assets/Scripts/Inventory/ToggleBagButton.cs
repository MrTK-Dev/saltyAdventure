using UnityEngine;
using UnityEngine.UI;

public class ToggleBagButton : MonoBehaviour
{
    ToggleBagButton instance;

    public GameObject Handler;
    public GameObject Bag;

    public void ToggleBag()
    {
        //give Bag to the handler
        Handler.GetComponent<BagSwitchHandler>().SwitchBag(Bag);

        //replace with different art while selected
        ColorBlock color = GetComponent<Button>().colors;
        color.selectedColor = Color.red;
        GetComponent<Button>().colors = color;
    }
}
