using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinPanelScript : MonoBehaviour
{   
    [SerializeField] public TextMeshProUGUI grade;
    private int score;
    [SerializeField]public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grade.text = scoreManager.getScore().ToString();
    }
}
