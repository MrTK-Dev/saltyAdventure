using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battle_MoveDescription : MonoBehaviour
{
    public GameObject Battle_Manager;
    public UI_Reference_MoveDescription UI;

    public Sprite Special, Physical, Status;    //TODO change to SpriteSheet

    public void OpenDescription(BaseMove newMove)
    {
        MoveData moveData = MoveData.GetData(newMove.Move);

        UI.Name.text = moveData.Name;
        UI.Description.text = moveData.Description;
        UI.Stats.text = "";

        TriggerType(moveData.Type);
        TriggerCategory(moveData.Category);
        TriggerStats(newMove);

        gameObject.SetActive(true);
    }

    void TriggerType(P_Type Type)
    {
        TypeData typeData = TypeData.GetData(Type);

        UI.Type.GetComponentInChildren<TextMeshProUGUI>().text = typeData.Name;

        if (ColorUtility.TryParseHtmlString("#" + typeData.Hex, out Color color))
            UI.Type.GetComponent<Image>().color = color;

        else
            Logger.Warning(GetType(), "'" + typeData.Name + "' does not have a valid Hex-Color! Returning to default.");

        UI.Type.SetActive(true);
    }

    void TriggerCategory(AttackCategory Category)
    {
        Sprite newSprite = null;

        switch (Category)
        {
            case AttackCategory.Physical:
                newSprite = Physical;
                break;
            case AttackCategory.Special:
                newSprite = Special;
                break;
            case AttackCategory.Status:
                newSprite = Status;
                break;
            default:
                Logger.Error(GetType(), "Choosen Move does not have a valid Category!");
                break;
        }

        UI.Category.GetComponent<Image>().sprite = newSprite;

        UI.Category.SetActive(true);
    }

    void TriggerStats(BaseMove newMove)
    {
        string newString =
            MoveData.GetData(newMove.Move).Power + "\n" +
            MoveData.GetData(newMove.Move).Accuracy;

        UI.Stats.text = newString;
    }

    public void ResetDescription()
    {
        gameObject.SetActive(false);

        UI.Name.text = "";
        UI.Description.text = "";
        UI.Stats.text = "";
    }

    #region SubClasses

    [System.Serializable]
    public class UI_Reference_MoveDescription
    {
        public Text Name, Description, Stats;
        public GameObject Type, Category;
    }

    #endregion
}
