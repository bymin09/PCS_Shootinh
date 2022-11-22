using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //싱글턴 객체
    public static ScoreManager Instance = null;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    //Get/Set 프라퍼티 만들기

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore++;

            //4. 화면에 점수 변화
            currentScoreUI.text = "현재점수 : " + currentScore.ToString("D8");

            //목표 : 최고 점수를 표시하고 싶다.
            //1번. 현재 점수가 최고점수보다 크니까123
            //만약 현재점수가 최고 점수를 초과 하였다면.
            if (currentScore > bestScore)
            {
                //2. 최고점수를 갱신 시킨다.
                bestScore = currentScore;
                //3. 최고점수를 UI에 표시
                bestScoreUI.text = "최고점수 : " + bestScore;
                //4. 최고점수를 저장하고 싶다.
                PlayerPrefs.SetFloat("Best", bestScore);

            }
        }
    }


    //현재점수 UI;
    public Text currentScoreUI;
    //현재점수
    //인스펙터 창에서 가리기
    [System.NonSerialized] // = HideInInspector
    private int currentScore;

    //목표 : 최고점수를 표기하고 싶다.
    //필요 속성 : 최고점수UI, 최고점수 기력
    //최고점수UI
    public Text bestScoreUI;
    //최고점수
    private float bestScore;


    //현재 점수가 ㅗ치고 점수보다 크니까
    //최고점수를 갱신 시킨다.
    //최고 점수 UI에 표시

    //목표 : 최고점수를 불러와 bestScore 변수에 할당하고 불러오고 싶다
    //순서 : 최고점수를 불러와 bestScore에 붙여주기
    // 최고점수를 화면에 표시하기.
    private void Start()
    {
        //순서 1 : 최고점수를 불러와 bestScore에 불러오기
        bestScore = PlayerPrefs.GetFloat("Best");
        bestScoreUI.text = "최고점수  : " + bestScore;
    }

    //currentScore 값을 넣고 화면에 표시하기
    //currentScore 값 읽어 오기
    public int GetScore()
    {
        return currentScore;
    }
}