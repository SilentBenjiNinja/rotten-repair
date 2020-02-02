using System.Collections; using System.Collections.Generic; using UnityEngine; using Collections; using System.Linq;  public class GameManager : MonoBehaviour {
    [SerializeField]     public UIHandler uiHandler;      [SerializeField]     public SoundManager soundManager;      [Header("AssetsConfig")]      [SerializeField]     public List<ZombiePart> imageDictionary;      [SerializeField]     public List<ZombiePartSilhouettes> silhouetteDictionary;      #region Game Flow      [Header("LevelConfig")]      [SerializeField]     public int[] levelZombieAmounts;      [Header("Debug")]      [SerializeField]     private int currentScore;     private int CurrentScore     {         get => currentScore;         set         {             currentScore = value;             uiHandler.SetScore(value.ToString());         }     }
     [SerializeField]     private int currentLevel;     private int CurrentLevel     {         get => currentLevel;         set         {             currentLevel = value;             if (CurrentLevel >= levelZombieAmounts.Length) {                 EndGame();             }         }
    }
     [SerializeField]     private int currentLevelZombie;     private int CurrentLevelZombie     {         get => currentLevelZombie;         set         {             currentLevelZombie = value;             if (CurrentLevelZombie >= levelZombieAmounts[CurrentLevel]) {                 CurrentLevel += 1;                 StartLevel(CurrentLevel);
            }             else             {
                BringInNextZombie();
            }
        }     }
     private void Start()
    {         StartGame();
    }      private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {  }         else if (Input.GetKeyDown(KeyCode.Alpha2)) { }         else if (Input.GetKeyDown(KeyCode.Alpha3)) { }         else if (Input.GetKeyDown(KeyCode.Alpha4)) { }         else if (Input.GetKeyDown(KeyCode.Alpha5)) { }         else if (Input.GetKeyDown(KeyCode.Alpha6)) { }         else if (Input.GetKeyDown(KeyCode.Alpha7)) { }         else if (Input.GetKeyDown(KeyCode.Alpha8)) { }         else if (Input.GetKeyDown(KeyCode.Alpha9)) { }         else if (Input.GetKeyDown(KeyCode.Alpha0)) { }
    }

    public void StartGame() {         CurrentScore = 0;         StartLevel(0);     }      public void StartLevel(int levelId) {         // play level start animation         BringInNextZombie();     }      public void EndGame() {         soundManager.PlaySound("win");
    }       private IEnumerator QuickTimeEvent() {         uiHandler.grp_quicktime.SetActive(true);         float phaseShift = Random.Range(-Mathf.PI, Mathf.PI);         float frequency = GetFrequency();         float startingTime = Time.time;          bool isClicked = false;         float currentCursorPosition = phaseShift;         while(isClicked == false)         {
            currentCursorPosition = (float)(0.5 * Mathf.Sin(frequency * (Time.time - startingTime) + phaseShift) + 0.5);             yield return null;             uiHandler.SetQuicktimeCursor(currentCursorPosition);
            if (Input.anyKey)             {
                isClicked = true;
            }
        }         uiHandler.SetQuicktimeCursor(currentCursorPosition);         uiHandler.grp_quicktime.SetActive(false);
        AddToInventory(GetPartsForQuicktimeEvent(currentCursorPosition));         
    }      private float GetFrequency()     {         // TO DO: implement frequency depending on zombie value         return 3;
    }

    private List<ZombiePart> GetPartsForQuicktimeEvent(float quicktimeResult)     {         float partSalvagePercentage = 0;
        int additionalPart = 0;          // TO DO: check current position against dictionary of positions         // green zone         if(quicktimeResult < 0.6 && quicktimeResult > 0.4)         {
            partSalvagePercentage = 1;
        }
        //yellow zone         else if(quicktimeResult < 0.8 && quicktimeResult > 0.2)         {
            partSalvagePercentage = 0.5f;
        }
         if (partSalvagePercentage == 0.5f && currentSetup.parts.Count % 2 == 1)         {
            if (Random.Range(0, 1) > 0.5f) {
                additionalPart = 1;             }             else             {
                additionalPart = -1;
            }
        }
        soundManager.PlaySound("salvage");         int partsToPickFromZombie = (int)((currentSetup.parts.Count + additionalPart) * partSalvagePercentage);         List<ZombiePart> returnValue = new List<ZombiePart>();          // add random parts from table to inventory according to result
        return returnValue;     }      #endregion 
    #region Button Callbacks

    // play shipping animation and sounds
    public void Ship()
    {         CurrentScore += currentSetup.SetupScore;         CurrentLevelZombie += 1;
        soundManager.PlaySound("ship");
    }

    // disable all buttons and inventory
    public void Salvage()     {
        StartCoroutine(QuickTimeEvent());
    }

    public void PauseGame() {         Time.timeScale = 0;
        uiHandler.ShowPauseMenu();     }
         public void UnpauseGame() {
        Time.timeScale = 1;         uiHandler.HidePauseMenu();     } 
    #endregion      #region Zombie Builder      [HideInInspector]
    public ZombieSetup currentSetup;      [Header("Display")]      [SerializeField]     public DisplayZombie displayZombie;      public void BringInNextZombie() {         currentSetup = new ZombieSetup();         for (int i = 0; i < Const.BODYPARTS; i++)
        {
            AddRandomPartToDictionary((Parts)(i+1));
        }         displayZombie.Show(currentSetup);
        // play in animation and sounds     } 
    public void AddZombiePart(ZombiePart part) {         DeletePartFromInventory(part);         currentSetup.AddPart(part);
        // TO DO: refresh images     }      public void DeletePartFromTable(Parts partToRemove) {         currentSetup.RemovePart(partToRemove);         soundManager.PlaySound("remove");         // TO DO: refresh images
    }

    private void AddRandomPartToDictionary(Parts part) {         List<ZombiePart> partsList = GetListOfZombieParts(part);
        ZombiePart partToAdd = partsList[Random.Range(0, partsList.Count)];         currentSetup.AddPart(partToAdd);
    }      private List<ZombiePart> GetListOfZombieParts(Parts part)
    {         List<ZombiePart> returnValue = new List<ZombiePart>();
        foreach (ZombiePart z in imageDictionary)
        {
            if(z.part == part)
            {
                returnValue.Add(z);
            }
        }         return returnValue;
    } 
    #endregion

    #region Inventory

    private List<ZombiePart> inventoryList = new List<ZombiePart>(); 
    public void DeletePartFromInventory(ZombiePart partToRemove) {         if (inventoryList.Contains(partToRemove))
        {
            inventoryList.Remove(partToRemove);
        }         soundManager.PlaySound("remove");
        // TO DO: refresh images
    }      public void AddToInventory(List<ZombiePart> partList) {         if(inventoryList.Count + partList.Count <= Const.MAXINVENTORYSPACE)
        {
            inventoryList.AddRange(partList);             foreach (ZombiePart p in partList)
            {                 uiHandler.AddInventoryItem(p);             }         }     }

    #endregion
} 