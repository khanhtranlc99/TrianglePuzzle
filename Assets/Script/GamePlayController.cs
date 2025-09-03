using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
     public static GamePlayController Instance;
     public PlayerContaint playerContaint;
     public InputController inputController;
     private void Awake()
     {
        Instance = this;
     }

     private void Start()
     {
        playerContaint.Init();
     } 

}
