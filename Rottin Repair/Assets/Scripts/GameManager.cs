using System.Collections; using System.Collections.Generic; using UnityEngine; using Collections; using System.Linq;  public class GameManager : MonoBehaviour {
    [SerializeField]     public UIHandler uiHandler;      [Header("AssetsConfig")]      [SerializeField]     public List<ZombiePart> imageDictionary;      #region Game Flow      [Header("LevelConfig")]      [SerializeField]     public int[] levelZombieAmounts;      private int currentScore;     private int CurrentScore     {         get => currentScore;         set         {             currentScore = value;             uiHandler.SetScore(value.ToString());         }     }
     private int currentLevel;     private int CurrentLevel     {         get => currentLevel;         set         {             currentLevel = value;             if (CurrentLevel >= levelZombieAmounts.Length) {                 EndGame();             }
        }
    }      private int currentLevelZombie;     private int CurrentLevelZombie     {         get => currentLevelZombie;         set         {             currentLevelZombie = value;             if (CurrentLevelZombie >= levelZombieAmounts[CurrentLevel]) {
                StartLevel(CurrentLevel+1);             }             else
            {
                BringInNextZombie();
            }         }
    } 
    private void Start()     {
        StartGame();
    }
     public void StartGame() {         currentScore = 0;         StartLevel(0);     }      public void StartLevel(int levelId) {}      public void EndGame() { }       private IEnumerator QuickTimeEvent() {         float phaseShift = Random.Range(-Mathf.PI, Mathf.PI);         float frequency = GetFrequency();         float startingTime = Time.time;          bool isClicked = false;         float currentCursorPosition = phaseShift;         while(isClicked == false)         {
            currentCursorPosition = (float)(0.5 * Mathf.Sin(frequency * (Time.time - startingTime) + phaseShift) + 0.5);             print(currentCursorPosition);             yield return null;
            if (Input.anyKey)             {
                isClicked = true;
            }
        }
        AddToInventory(GetPartsForQuicktimeEvent(currentCursorPosition));
    }      private float GetFrequency()     {         // TO DO: implement frequency depending on zombie value         return 3;
    }

    private List<ZombiePart> GetPartsForQuicktimeEvent(float quicktimeResult)     {         float partSalvagePercentage = 0;
        int additionalPart = 0;          // TO DO: check current position against dictionary of positions         // green zone         if(quicktimeResult < 0.6 && quicktimeResult > 0.4)         {
            partSalvagePercentage = 1;
        }
        //blue zone         else if(quicktimeResult < 0.8 && quicktimeResult > 0.2)         {
            partSalvagePercentage = 0.5f;
        }
         if (partSalvagePercentage == 0.5f && currentSetup.parts.Count % 2 == 1)         {
            if (Random.Range(0, 1) > 0.5f) {
                additionalPart = 1;             }             else             {
                additionalPart = -1;
            }
        }
        int partsToPickFromZombie = (int)((currentSetup.parts.Count + additionalPart) * partSalvagePercentage);         List<ZombiePart> returnValue = new List<ZombiePart>();          // add random parts from table to inventory according to result         return returnValue;
    }      #endregion      #region Button Callbacks

    // play shipping animation and sounds
    public void Ship()
    {
        CurrentScore += currentSetup.SetupScore;         CurrentLevelZombie += 1; 
    }

    // disable all buttons and inventory
    public void Salvage()
    {
        StartCoroutine(QuickTimeEvent());
    }

    public void PauseGame() {         Time.timeScale = 0;
        uiHandler.ShowPauseMenu();     }
         public void UnpauseGame() {
        Time.timeScale = 1;         uiHandler.HidePauseMenu();     } 
    #endregion      #region Zombie Builder     
    public ZombieSetup currentSetup;      public void BringInNextZombie() {         currentSetup = new ZombieSetup();         currentSetup.parts = new Dictionary<Parts, ZombiePart>();
        for (int i = 0; i < Const.BODYPARTS; i++)
        {
            AddRandomPartToDictionary((Parts)(i+1));
        }
        // TO DO: show images; play in animation and sounds     } 
    public void AddZombiePart(ZombiePart part) {         DeletePartFromInventory(part);         currentSetup.AddPart(part);
        // TO DO: refresh images     }      public void DeletePartFromTable(Parts partToRemove) {         currentSetup.RemovePart(partToRemove);         // TO DO: refresh images
    }

    private void AddRandomPartToDictionary(Parts part) {
        List<ZombiePart> partsList = imageDictionary.Where(zp => zp.part == part) as List<ZombiePart>;         currentSetup.parts.Add(part, partsList[Random.Range(0, partsList.Count)]);
    } 
    #endregion

    #region Inventory

    private List<ZombiePart> inventoryList = new List<ZombiePart>(); 
    public void DeletePartFromInventory(ZombiePart partToRemove) {         if (inventoryList.Contains(partToRemove))
        {
            inventoryList.Remove(partToRemove);
        }         // TO DO: refresh images     }      public void AddToInventory(List<ZombiePart> partList) {         if(inventoryList.Count + partList.Count <= Const.MAXINVENTORYSPACE)
        {
            inventoryList.AddRange(partList);             // TO DO: refresh images
        }     }

    #endregion
} 