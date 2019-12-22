using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopTools
{
    public class Shop_Tools : MonoBehaviour
    {
        public GameObject Shop;
        public UI_Components UI_Components;
        public GameObject TrainerCard;

        #region Variables

        int Quantity;
        int Price;
        bool canBuy = true;

        ItemData SelectedItem;

        #endregion

        #region Button Methods

        public void OnClickButtonUp()
        {
            UpdateQuantity(1);
        }

        public void OnClickButtonUp_1()
        {
            UpdateQuantity(10);
        }

        public void OnClickButtonDown()
        {
            UpdateQuantity(-1);
        }

        public void OnClickButtonDown_1()
        {
            UpdateQuantity(-10);
        }

        #endregion

        #region Methods

        void UpdateQuantity(int QChange)
        {
            SelectedItem = ItemData.GetData(Shop.GetComponent<Shop_UI>().SelectedItem);

            int newQuan = Quantity + QChange;
            int maxQuan = 99 - SelectedItem.Stacksize;

            if (newQuan <= maxQuan && newQuan >= 1)
            {
                Quantity = newQuan;
                Price = SelectedItem.Price * Quantity;

                UpdateUI();
            }
        }

        void UpdateUI()
        {
            UI_Components.StockQuantity.GetComponentInChildren<Text>().text = Quantity.ToString();

            UI_Components.PriceText.GetComponentInChildren<Text>().text = string.Format("{0:###,###,###}{1}", Price, "$");

            if (Price > TrainerCard.GetComponent<TrainerCard>().PokeDollar)
            {
                UI_Components.PriceText.GetComponentInChildren<Text>().color = Color.red;
                canBuy = false;
            }
            else
            {
                UI_Components.PriceText.GetComponentInChildren<Text>().color = Color.white;
                canBuy = true;
            }

            //In Possession
            if (Inventory.ContainsItem(SelectedItem.Item))
            {
                UI_Components.HStacksize.GetComponent<Text>().text = "In Possession: " + "\n" + SelectedItem.Stacksize.ToString();
            }
            else
            {
                UI_Components.HStacksize.GetComponent<Text>().text = "In Possession: " + "\n" + "none";
            }
        }

        public void OnButtonClickBuy()
        {
            if (canBuy)
            {
                //add to inv
                for (int i = 0; i < Quantity; i++)
                {
                    if (Inventory.AddItem(SelectedItem.Item))
                    {
                        //remove money
                        TrainerCard.GetComponent<TrainerCard>().PokeDollar -= (Price / Quantity);
                    }
                }

                //reset Quantity
                Quantity = 99 - SelectedItem.Stacksize;

                UpdateUI();
            }
        }

        #endregion
    }

    #region SubClasses

    [System.Serializable]
    public class UI_Components
    {
        public GameObject StockQuantity;
        public GameObject PriceText;
        public GameObject HStacksize;
    }

    #endregion
}