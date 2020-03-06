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

    public GameObject grp_quicktime;
    public RectTransform img_quicktimeCursor;

    public Button btn_head;
    public Button btn_body;
    public Button btn_armL;
    public Button btn_armR;
    public Button btn_legL;
    public Button btn_legR;
    
    private void Start()
    {
        HidePauseMenu();
        EnableShipping();
        EnableSalvaging();
        SetScore("0");
        grp_quicktime.SetActive(false);

        foreach(Transform t in grp_bottom.transform)
        {
          Destroy(t.gameObject);
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

    public void SetQuicktimeCursor(float value)
    {
        Vector3 pos1 = new Vector3(-500, 0, 0),
            pos2 = new Vector3(500, 0, 0);
        img_quicktimeCursor.localPosition = Vector3.Lerp(pos1, pos2, value);
    }

    public void AddInventoryItem(ZombiePart newPart) {
        Instantiate(prefab_inventoryItem, grp_bottom.transform);
        // add button with listener for 
    }

    public void RemoveInventoryItem(int position) {
        // how to determine which one to remove?
    }

    public void ShowPauseMenu() { 
        img_pauseMenu.SetActive(false);
    }

    public void HidePauseMenu() {
        img_pauseMenu.SetActive(false);
    }
}
