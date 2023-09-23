using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class MapSelect : MonoBehaviour
{
    public int starsNum = 0;
    private bool isSelect = false;
    public GameObject locks;
    public GameObject stars;
    public GameObject panel;
    public GameObject map;
    public Text starstext;
    public int startNum = 1;
    public int endNum = 3;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();//用来清理游戏数据，关卡从0-1开始
        if (PlayerPrefs.GetInt("totalNum",0) >= starsNum) {

            isSelect = true;
        }
        if (isSelect) {
            locks.SetActive(false);
            stars.SetActive(true);
            //TODo:text星星的显示
            int counts = 0;
            for (int i = startNum; i <= endNum; i++) {
                counts += PlayerPrefs.GetInt("level" + i.ToString(), 0);
            }
            starstext.text = counts.ToString()+"/12";
        }
    }
    //地图鼠标点击事件

    public void Selected()
    {
        if (isSelect) {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }
   public void panelSelsect() {
        panel.SetActive(false);
        map.SetActive(true);
    }
  
}
