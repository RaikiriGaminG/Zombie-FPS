using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public Text ammotext;

    public int ammocount = 5;

    public int score = 0;

    // This is a C# property - the code below isn't using it
    // as it is accessing the private static instance directly.
    // Use this property from other classes.
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager instance = null;


    // Use this for initialization
    void Start()
    {
        UpdateScore();
    }

    // Update score text field
    public void UpdateScore()
    {
        scoretext.text = "Score: " + score;
        ammotext.text = "Ammo: " + ammocount;
    }

    // set the score
    public void setscore(int s)
    {
        score = s;
        UpdateScore();
    }

    // increase the score
    public void incscore(int s)
    {
        score = score + s;
        UpdateScore();
    }

    void Awake()
    {
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // fire
    public void fire()
    {
        ammocount--;
        UpdateScore();
    }

    // collect ammo
    public void collectammo()
    {
        ammocount += 10;
        if (ammocount > 100) ammocount = 100;
        UpdateScore();
    }
}
