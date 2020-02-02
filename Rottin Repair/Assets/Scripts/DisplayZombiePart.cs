using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Collections;

public class DisplayZombiePart : MonoBehaviour
{
    public GameManager gameManager;

    public Text txt_InventoryItemStat;

    public Image img_inventoryItemSilhouette;
    public Image img_inventoryItem;

    void Create(ZombiePart part)
    {
        txt_InventoryItemStat.text = part.decayState.ToString();

        // TO DO: silhouettes
        // img_inventoryItemSilhouette.sprite = gameManager.silhouetteDictionary[part.part];

        img_inventoryItem.sprite = part.sprite;
    }
}
