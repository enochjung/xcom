using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작업자 : 박한샘
// 문제! 스크립트에 의해 성성된 alien은 alien(clone)이란 이름을 갖고있음
// -> 총알 맞아도 피해 X, Tag로 하면 해결될 듯
// 첫 번째 친구는 괜찮은데 그 뒤로 안 맞거나 한대만 맞아도 죽는 애들 생김
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private GameObject[] aliens;
    [SerializeField]
    private GameObject[] cover;
    [SerializeField]
    private GameObject alien;
    
    
    public void LevelStart(int level)
    {
        if(level == 1)
            AlienGenerator(4);
        else if(level == 2)
            AlienGenerator(8);
        else if(level == 3)
            AlienGenerator(12);
    }

    public void GameOver()
    {
        //UI.GameOver();
    }

    private void AlienGenerator(int num)
    {
        aliens = new GameObject[num];
        for(int i = 0; i < num/4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                aliens[i*4+j] = Instantiate(alien) as GameObject;
                aliens[i*4+j].transform.position = new Vector3(-7+4*j,4-3*i,0);
            }
        }
    }

    // alien 배열 확인하는 함수
    private bool CheckAliens()
    {
        for(int i = 0; i < aliens.Length; i++)
            if(aliens[i] != null)
                return false;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelStart(level);
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckAliens())
            //UI.LevelClear(level);
            LevelStart(++level);
    }
}
