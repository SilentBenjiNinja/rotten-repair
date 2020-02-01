using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int[] levelZombieAmounts;

    [SerializeField]
    public Image[,] zombieParts = new Image[Const.BODYPARTS, Const.MAXDECAYSTATES];

    [SerializeField]
    public List<ZombiePart> imageDictionary;

    private List<ZombiePart> inventory;

    private int currentScore;

    public void StartGame() { }

    public void StartLevel(int levelId) { }

    #region Buttons

    public void Ship() { }

    public void Salvage() { }

    public void DeletePart() { }

    #endregion

    #region Pause

    public void PauseGame() { }

    public void UnpauseGame() { }

    #endregion

    #region Zombie Builder

    public void BuildZombie(ZombieTypes type) { }

    public void AddZombiePart(ZombiePart part) { }

    #endregion

    #region Inventory

    

    #endregion
}
