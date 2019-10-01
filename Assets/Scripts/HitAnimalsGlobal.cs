using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimalsGlobal : MonoBehaviour
{
    public GameObject CatObj;
    public GameObject ChickenObj;
    public GameObject DogObj;
    public GameObject LionObj;
    public GameObject PenguinObj;
    public float timer;
    public float restTime;
    public int score;

    private GameObject Cat;
    private GameObject Chicken;
    private GameObject Dog;
    private GameObject Lion;
    private GameObject Penguin;

    private float CatRebirthTime;
    private float ChickenRebirthTime;
    private float DogRebirthTime;
    private float LionRebirthTime;
    private float PenguinRebirthTime;

    void CatInitialize()
    {
        if (Cat != null) return;
        Cat = Instantiate(CatObj,
            new Vector3(-7.996099f, 4.0f, 23.43f),
            Quaternion.Euler(new Vector3(0.0f,180.0f,0.0f))) as GameObject;
    }

    void ChickenInitialize()
    {
        if (Chicken != null) return;
        Chicken = Instantiate(ChickenObj,
            new Vector3(-4.241651f, 4.0f, 23.21f),
            Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f))) as GameObject;
    }

    void DogInitialize()
    {
        if (Dog != null) return;
        Dog = Instantiate(DogObj,
            new Vector3(-0.2860985f, 4.0f, 23.35f),
            Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f))) as GameObject;
    }

    void LionInitialize()
    {
        if (Lion != null) return;
        Lion = Instantiate(LionObj,
            new Vector3(4.143902f, 4.0f, 23.07328f),
            Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f))) as GameObject;
    }

    void PenguinInitialize()
    {
        if (Penguin != null) return;
        Penguin = Instantiate(PenguinObj,
            new Vector3(8.553901f, 4.0f, 23.22f),
            Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f))) as GameObject;
    }

    void CheckDeath(GameObject obj, ref float objTimer)
    {
        if (obj == null) return;
        if (obj.transform.position.y < -12.0f)
        {
            objTimer = timer + 2.0f;
            score += 10;
            Destroy(obj);
        }
    }

    void RebirthCat()
    {
        if (Cat == null && timer > CatRebirthTime)
        {
            CatInitialize();
        }
    }

    void RebirthChicken()
    {
        if (Chicken == null && timer > ChickenRebirthTime)
        {
            ChickenInitialize();
        }
    }

    void RebirthDog()
    {
        if (Dog == null && timer > DogRebirthTime)
        {
            DogInitialize();
        }
    }

    void RebirthLion()
    {
        if (Lion == null && timer > LionRebirthTime)
        {
            LionInitialize();
        }
    }

    void RebirthPenguin()
    {
        if (Penguin == null && timer > PenguinRebirthTime)
        {
            PenguinInitialize();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0.0f;
        CatRebirthTime = 1.0f;
        ChickenRebirthTime = 1.0f;
        DogRebirthTime = 1.0f;
        LionRebirthTime = 1.0f;
        PenguinRebirthTime = 1.0f;
        restTime = 60.0f;
        CatInitialize();
        ChickenInitialize();
        DogInitialize();
        LionInitialize();
        PenguinInitialize();

    }

    // Update is called once per frame
    void Update()
    {
        if (restTime <= 0.0f)
        {
            Application.LoadLevel("PaintBall_EndScene");
        }
        timer += Time.deltaTime;
        restTime -= Time.deltaTime;
        CheckDeath(Chicken, ref ChickenRebirthTime);
        CheckDeath(Cat, ref CatRebirthTime);
        CheckDeath(Dog, ref DogRebirthTime);
        CheckDeath(Lion, ref LionRebirthTime);
        CheckDeath(Penguin, ref PenguinRebirthTime);
        RebirthCat();
        RebirthChicken();
        RebirthDog();
        RebirthLion();
        RebirthPenguin();
        PlayerPrefs.SetInt("score", score);
    }
}
