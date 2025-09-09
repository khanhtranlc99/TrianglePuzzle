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
    public Button btnSetting;
    public SettingPanel settingBox;
    public void Init()
   {
    
        btnRetry.onClick.AddListener(HandleRetry);
        btnNext.onClick.AddListener(HandleNext);
        btnSetting.onClick.AddListener(HandleSetting);
        settingBox.Init();
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
        GameManager.Instance.adsController.ShowInterstitialAd(() => Initiate.Fade("GamePlayScene", Color.black, 2f));
        GameManager.Instance.musicController.HandleClick(GameManager.Instance.musicController.click);
    }
    public void HandleNext()
    {
        var temp = PlayerPrefs.GetInt("CurrentLevel", 0) + 1;
        PlayerPrefs.SetInt("CurrentLevel", temp);
        GameManager.Instance.adsController.ShowInterstitialAd(() => Initiate.Fade("GamePlayScene", Color.black, 2f));
        GameManager.Instance.musicController.HandleClick(GameManager.Instance.musicController.click);
    }

    public void HandleWin()
    {
        GameManager.Instance.musicController.HandleClick(GameManager.Instance.musicController.win);
        winBox.SetActive(true);
    }
    public void HandleSetting()
    {
        GameManager.Instance.musicController.HandleClick(GameManager.Instance.musicController.click);
        settingBox.gameObject.SetActive(true);
    }
}
