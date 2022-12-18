using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    public Player player;
    //public GameObject 
    void Start()
    {
        
    }
    private void Update()
    {
        //if()
        //{
        //    CreateArmy();
        //}    
    }
    public void CreateArmy()
    {
        Player gamePlayer = Instantiate(player, new Vector3(0.65f, 0, 0.37f), Quaternion.identity);
        gamePlayer.gameObject.SetActive(true);
        
    }    
}  

