using UnityEngine;
using UnityEngine.UI;

public class ToggleBagButton : MonoBehaviour
{
    public GameObject UI;

    public void ToggleBag()
    {
        BagData Bag = BagData.Database[transform.GetSiblingIndex()];

        UI.GetComponent<Inventory_UI>().SetActiveBag(Bag);

        //replace with different art while selected
        ColorBlock color = GetComponent<Button>().colors;
        color.selectedColor = Color.red;
        GetComponent<Button>().colors = color;
    }
}
