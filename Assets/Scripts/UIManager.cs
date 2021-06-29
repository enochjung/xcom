using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * UIManager
 *
 * UI 관련 기능을 포함.
 *
 * public void ChangeLevel(int level)
 * UI의 level 값을 변경해서 출력
 * @ int level : 출력하고자 하는 level 값
 *
 * public void ChangeLife(int life)
 * UI의 life 값을 변경해서 출력
 * @ int life : 출력하고자 하는 Player의 life 값
 *
 * public void LevelClear(int level)
 * 1. UI에 클리어 문구 출력
 * 2. 3초 대기
 * 3. GameManager를 통해 다음 레벨 실행
 * @ int level : 클리어한 레벨
 * 
 * public void GameOver()
 * 1. UI에 게임 오버 문구 출력
 * 2. 다시 시작 버튼을 누르면 GameManager를 통해 새 게임 실행
 * 
 * made by EnochJung
 * 2021/06/28 생성
 **/
public class UIManager : MonoBehaviour
{
	GameObject gameManager;

	Text levelText;
	Text lifeText;
	Text bigText;

	void Start()
	{
		gameManager = GameObject.Find("GameManager");
		levelText = GameObject.Find("Level").GetComponent<Text>();
		lifeText = GameObject.Find("Life").GetComponent<Text>();
		bigText = GameObject.Find("BigText").GetComponent<Text>();

		ChangeBigText("");
	}

	public void ChangeLevel(int level)
	{
		levelText.text = "Level : " + level;
	}

	public void ChangeLife(int life)
	{
		lifeText.text = "Life : " + life;
	}

	void ChangeBigText(string text)
	{
		bigText.text = text;
	}

	public void LevelClear(int level)
	{
		ChangeBigText("Level " + level + " Clear!");
		StartCoroutine(WaitAndCallNewLevel(3f, level + 1));
	}

	IEnumerator WaitAndCallNewLevel(float second, int level)
	{
		yield return new WaitForSeconds(second);
		CallNewLevel(level);
	}

	void CallNewLevel(int level)
	{
		ChangeBigText("");
		gameManager.GetComponent<GameManager>().LevelStart(level);
	}

	public void GameOver()
	{
		ChangeBigText("Game Over!\nPress R to Restart.");
		StartCoroutine(RestartIfPressR());
	}

	IEnumerator RestartIfPressR()
	{
		yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
		CallNewLevel(1);
	}
}