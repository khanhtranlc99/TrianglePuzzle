using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerContaint : MonoBehaviour
{
    public LevelData levelData;
    public List<LevelData> lsLevelData;
    public TMP_Text txtLevel;
    public Button btnRetry;
    public GameObject objComplete;
    public Button btnNext;
    public GameObject winBox;
    public void Init()
   {
    
        btnRetry.onClick.AddListener(HandleRetry);
        btnNext.onClick.AddListener(HandleNext);
      if (PlayerPrefs.GetInt("CurrentLevel",0) >= lsLevelData.Count)
      {
        objComplete.SetActive(true);
      }
      else
      {
      txtLevel.text = "Level " + (PlayerPrefs.GetInt("CurrentLevel",0) + 1);
      levelData = Instantiate(lsLevelData[PlayerPrefs.GetInt("CurrentLevel",0)]);
      }
  
   
   }
   public void HandleRetry()
   {
        Initiate.Fade("GamePlayScene", Color.black, 2f);
    }
    public void HandleNext()
    {


        Initiate.Fade("GamePlayScene", Color.black, 2f);
    }

    public void HandleWin()
    {
        
    }
}
