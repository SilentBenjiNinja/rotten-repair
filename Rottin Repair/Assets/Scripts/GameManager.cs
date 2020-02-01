using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.UI; using Collections;  public class GameManager : MonoBehaviour {     [Header("AssetsConfig")]      [SerializeField]     public List<ZombiePart> imageDictionary;      #region Game Flow      [Header("LevelConfig")]      [SerializeField]     public int[] levelZombieAmounts;      private int currentScore;     private int CurrentScore     {         get => currentScore;         set         {             currentScore = value;             // TO DO: add UI score counter         }     }
     private int currentLevel;     private int CurrentLevel     {         get => currentLevel;         set         {             currentLevel = value;             // TO DO: when current level above level amount, win game
        }
    }      private int currentLevelZombies;     private int CurrentLevelZombies     {         get => currentLevelZombies;         set         {             currentLevelZombies = value;             // TO DO: when above limit for this level, trigger new level
        }
    } 
    private void Start()     {
        StartGame();
    }
     public void StartGame() {         currentScore = 0;         StartLevel(0);     }      public void StartLevel(int levelId) { }      #endregion      #region Button Callbacks

    // count up score     // play shipping animation and sounds
    // raise zombie counter for current level
    // if zombie counter for this level has reached limit:
    // start next level / win the game
    // else bring in next zombie
    public void Ship() { }

    // disable all buttons and inventory
    // trigger salvage mini-game
    public void Salvage() { }

    #endregion

    #region Zombie Builder     
    private ZombieSetup currentSetup; 
    // set current setup to a new random zombie and start in animation
    public void BringInNextZombie() { }

    // if the current setup doesn't already contain the given zombie part:
    // remove it from inventory and add to setup
    public void AddZombiePart(ZombiePart part) { }
     // remove given part from current setup
    public void DeletePartFromTable(ZombiePart partToRemove) { } 
    #endregion
     #region Inventory      private List<ZombiePart> inventory; 
    // remove given part from inventory
    public void DeletePartFromInventory(ZombiePart partToRemove) { }

    #endregion
         #region Pause
         // set time scale to 0 and open big pause popup
    public void PauseGame() { }
         // set time scale to 1 and close pause popup
    public void UnpauseGame() { }
    
    #endregion 
} 