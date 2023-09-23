using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<pig> pig;
    public static GameManager _instance;
    private Vector3 originPos;//初始的位置
    public GameObject win;
    public GameObject lose;
    public GameObject[] stars;
    private int starsNum = 0;
    private int totalNum = 10;
    

    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
        
    }
    private void Start()
    {
        Initialized();
    }
    //初始化小鸟
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)//第一只小鸟
            {
                birds[0].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }
    //判定游戏逻辑
    public void NextBird()
    {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只飞吧
                Initialized();
            }
            else
            {
                //输了
                lose.SetActive(true);
            }

        }
        else 
        {
            //赢了
            win.SetActive(true);
        }
    }
    public void ShowStars()
    {
        StartCoroutine("show");
    }
     IEnumerator show() {
        for (; starsNum < birds.Count + 1; starsNum++)
        {
            if (starsNum >= stars.Length) {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            stars[starsNum].SetActive(true);
        }
        print(starsNum);
    }
    public void Replay()  //这里也没有调用
    {
        SaveData();
        SceneManager.LoadScene(1);
    }
    public void Home() //没调用保存的，看到了没
    {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void SaveData() {
         if(starsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel"))) {  //这里得到是关卡Id:(Level+id)，然后再取出对应关卡名字的星星数作比较
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starsNum);   //最新的星星数大于之前的则保存最新的
        } 
        //PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), 0); //无论通关如何，都保存0星星

        //存储所有的星星个数
        int sum = 0;
        for (int i = 1; i <= totalNum; i++) {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalNum",sum);
        print(PlayerPrefs.GetInt("totalNum"));
    }
}
