using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySell : MonoBehaviour
{
    public GameObject ShopController;
    public GameObject TrainerCard;

    public Text StockQuantity;
    public Text PriceText;
    public Text HStacksize;

    public int Quantity;
    public int Price;

    public bool canBuy = true;

    public void ButtonUp()
    {
        UpdateQuantity(1);
    }

    public void ButtonDown()
    {
        UpdateQuantity(-1);
    }

    public void ButtonUp2()
    {
        UpdateQuantity(10);
    }

    public void ButtonDown2()
    {
        if (Quantity == 1)
        {
            int newChange = (99 - Quantity) - getHItem().StackSize;
            UpdateQuantity(newChange);
        }
        else
        {
            UpdateQuantity(-10);
        }
    }

    void UpdateQuantity(int QChange)
    {
        int newQuan = Quantity + QChange;
        int maxQuan = 99 - getHItem().StackSize;

        if (newQuan <= maxQuan && newQuan >= 1)
        {
            Quantity = newQuan;
            Price = getHItem().Price * Quantity;

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        StockQuantity.text = Quantity.ToString();

        PriceText.text = string.Format("{0:###,###,###}{1}", Price, "$");

        if (Price > TrainerCard.GetComponent<TrainerCard>().PokeDollar)
        {
            PriceText.color = Color.red;
            canBuy = false;
        }
        else
        {
            PriceText.color = Color.white;
            canBuy = true;
        }

        //In Possession
        if (InventoryController.instance.CheckIfPlayerHasItem(getHItem()))
        {
            HStacksize.text = "In Possession: " + "\n" + getHItem().StackSize.ToString();
        }
        else
        {
            HStacksize.text = "In Possession: " + "\n" + "none";
        }
    }

    public void ResetQ(int newPrice)
    {
        if (getHItem().StackSize == 99)
        {
            Quantity = 0;
        }
        else
        {
            Quantity = 1;
        }
        //Quantity = 1;

        Price = newPrice;

        UpdateUI();
    }

    public void BuyOnButtonClick()
    {
        if (canBuy)
        {
            //add to inv
            for (int i = 0; i < Quantity; i++)
            {
                if (InventoryController.instance.AddItemToInventory(getHItem()))
                {
                    //remove money
                    TrainerCard.GetComponent<TrainerCard>().PokeDollar -= (Price / Quantity);
                }
            }

            //reset Quantity
            Quantity = 99 - getHItem().StackSize;

            UpdateUI();
        }
    }

    Item getHItem()
    {
        return ShopController.GetComponent<ShopController>().HItem;
    }
}
