using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance; // Singleton instance

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    public int win;
    public int lose;

    private Text shotBulletText;
    private Text enemyKilledText;



    EasyFileSave myFile; // 

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Example update logic, if needed
    }

    public int ShootBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            if (shotBulletText == null)
            {
                shotBulletText = GameObject.Find("ShotBullet").GetComponent<Text>();
            }
            shotBulletText.text = "SHOT BULLET: " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            if (enemyKilledText == null)
            {
                enemyKilledText = GameObject.Find("EnemyKilled").GetComponent<Text>();
            }
            enemyKilledText.text = "Enemy Killed: " + enemyKilled.ToString();
            WinProcces();
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave(); // dosya kaydedecek deðiþken
        LoadData();
    }

    public void SaveData()
    {
        //Verileri kaydetme;
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet",totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }

    public void LoadData()
    {
        //Kayýtlý verileri getirme
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }

    public void WinProcces()
    {

        if (enemyKilled >= 3) 
        {

            win++;

        


            Debug.Log("kazan");
      
            
        }
    }
    public void LoseProcces()
    {
        lose++;

  


        Debug.Log("Kaybet");
    
    }
}
