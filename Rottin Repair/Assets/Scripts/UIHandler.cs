using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Collections;

public class UIHandler : MonoBehaviour
{
    public Button btn_salvage;
    public GameObject txt_cantSalvage;
    public Text txt_cantSalvageReason;

    public Button btn_ship;
    public GameObject txt_cantShip;
    public Text txt_cantShipReason;

    public Text txt_scoreValue;

    public GameObject grp_bottom;

    public GameObject prefab_inventoryItem;

    public GameObject img_pauseMenu;

    private void Awake()
    {
        // btn_salvage = this.transform.Find("grp_top").Find("grp_salvage").Find("btn_salvage*").GetComponent<Button>();
        // txt_cantSalvage = this.transform.Find("grp_top").Find("grp_salvage").Find("txt_cant_salvage*").gameObject;
        // txt_cantSalvageReason = this.transform.Find("grp_top").Find("grp_salvage").Find("txt_cant_salvage_reason*").GetComponent<Text>();

        // btn_ship = this.transform.Find("grp_top").Find("grp_ship").Find("btn_ship*").GetComponent<Button>();
        // txt_cantShip = this.transform.Find("grp_top").Find("grp_ship").Find("txt_cant_ship*").gameObject;
        // txt_cantShipReason = this.transform.Find("grp_top").Find("grp_ship").Find("txt_cant_ship_reason*").GetComponent<Text>();

        // txt_scoreValue = this.transform.Find("grp_top").Find("grp_score").Find("txt_score_value").GetComponent<Text>();

        // grp_bottom = this.transform.Find("grp_bottom").gameObject;

        // img_pauseMenu = this.transform.Find("img_pause_menu").gameObject;
    }

    private void Start()
    {
        HidePauseMenu();
        EnableShipping();
        EnableSalvaging();
        SetScore("0");
        while(grp_bottom.transform.childCount > 0)
        {
            Destroy(grp_bottom.transform.GetChild(0).gameObject);
        }
    }

    public void EnableSalvaging() {
        btn_salvage.interactable = true;
        txt_cantSalvage.SetActive(false);
        txt_cantSalvageReason.gameObject.SetActive(false);
    }

    public void DisableSalvaging(string reason) {
        btn_salvage.interactable = false;
        txt_cantSalvage.SetActive(true);
        txt_cantSalvageReason.gameObject.SetActive(true);
        txt_cantSalvageReason.text = reason;
    }

    public void EnableShipping() {
        btn_ship.interactable = true;
        txt_cantShip.SetActive(false);
        txt_cantShipReason.gameObject.SetActive(false);
    }

    public void DisableShipping(string reason) {
        btn_ship.interactable = false;
        txt_cantShip.SetActive(true);
        txt_cantShipReason.gameObject.SetActive(true);
        txt_cantShipReason.text = reason;
    }

    public void SetScore(string newValue) {
        txt_scoreValue.text = newValue;
    }

    public void AddInventoryItem(ZombiePart newPart) { }// add button listener

    public void RemoveInventoryItem(int position) { }   // how to determine which one to remove?

    public void ShowPauseMenu() { 
        img_pauseMenu.SetActive(false);
    }

    public void HidePauseMenu() {
        img_pauseMenu.SetActive(false);
    }
}
