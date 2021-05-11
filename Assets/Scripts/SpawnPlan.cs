using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlan : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject FinishLine;
    

    private GameObject platforms;

    private int index = 0;
    private int count = 2;
    private Vector3 poolPosition = new Vector3(0,150,0);

    int Finish = 0;

    Vector3 reSpawnPosition;

    private void Update()
    {
        if(GameManager.instance.isGameOver)
        {
            return;
        }

        
        if(GameManager.instance.isEmpty && Finish<11)
        {
            ReSpawn();
        }
    }

    void ReSpawn()
    {
        reSpawnPosition = new Vector3(6, -12, 250-Finish*3);

        if(Finish == 10)
        {
            platforms = Instantiate(FinishLine, reSpawnPosition, Quaternion.identity);
        }
        else
        {
            GameManager.instance.isEmpty = false;
            int num = Random.Range(0, 3);
            Debug.Log(num);

            platforms = Instantiate(platformPrefab[num], reSpawnPosition, Quaternion.identity);

            platforms.SetActive(false);
            platforms.SetActive(true);
        }
        

        Finish++;

        
    }
}
