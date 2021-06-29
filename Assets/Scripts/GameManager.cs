using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 문제! 스크립트에 의해 성성된 alien은 alien(clone)이란 이름을 갖고있음
// -> 총알 맞아도 피해 X, Tag로 하면 해결될 듯
// 플레이어도 마찬가지

/**
* GameManager
*
* 스테이지 관리 기능
*
* public void LevelStart(int level)
* level에 해당하는 스테이지 생성(에이리언 위치, 개수, 엄폐물 등등)
* @ int level : 생성하고자 하는 스테이지 레벨
*
* public void Gameover()
* player에서 health가 0이 되었을 때 호출되는 메소드
* 남아있는 alien 제거 후 UIManager의 GameOver 호출
*
* 메이드 인 SAEM
* 2021.06.29 제작
**/
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> aliens = new List<GameObject>();

    [SerializeField]
    private List<GameObject> covers;

    [SerializeField]
    private GameObject AlienPrefab;

    [SerializeField]
    GameObject PlayerPrefab;

    //[SerializeField]
    //GameObject CoverPrefab;

    private int level = 1;
    private int health = 3;
    private bool over = false;
    private bool isPlaying = false;
    private GameObject player;
    private GameObject UIManager;
    
    public void LevelStart(int level)
    {
        UIManager.GetComponent<UIManager>().ChangeLevel(level);
        UIManager.GetComponent<UIManager>().ChangeLife(health);
        this.level = level;
        over = false;

        // player 생성
        player = Instantiate(PlayerPrefab) as GameObject;
        player.transform.position = new Vector3(0,-4,0);
        
        if(level == 1)
            AlienGenerator(4);
        else if(level == 2)
            AlienGenerator(8);
        else if(level == 3)
            AlienGenerator(12);

        isPlaying = true;
    }

    public void GameOver()
    {
        over = true;

        for(int i = 0; i < aliens.Count; i++)
            Destroy(aliens[i]);
        aliens.Clear();

        /*
        for(int i = 0; i < covers.Count; i++)
            Destroy(covers[i]);
        covers.Clear();
        */

        isPlaying = false;
        Destroy(player);
        UIManager.GetComponent<UIManager>().GameOver();
    }

    private void AlienGenerator(int num)
    {
        for(int i = 0; i < num/4; i++)
            for(int j = 0; j < 4; j++)
                aliens.Add(Instantiate(AlienPrefab, new Vector3(-7+4*j,4-3*i,0), Quaternion.identity) as GameObject);
    }

    // alien 배열 확인하는 함수
    void CheckClear()
    {
        aliens.RemoveAll(item => item == null);
        if(aliens.Count == 0 && over == false && isPlaying == true)
        {
            Debug.Log("Clear : " + aliens.Count + " " + over);
            Destroy(player);
            UIManager.GetComponent<UIManager>().LevelClear(level);
            isPlaying = false;        
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.Find("UIManager");
        LevelStart(level);
    }

    // Update is called once per frame
    void Update()
    {
        CheckClear();
    }
}
