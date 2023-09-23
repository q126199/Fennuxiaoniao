using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    //[SerializeField]
    //Button re; //重玩；
    //[SerializeField]
    //Button home; //回到关卡选择界面
    //动画播放完,显示星星

    private void Awake()
    {
        //监听事件
       /* re.onClick.AddListener(() =>
        {
            GameManager._instance.Replay();
        });

        home.onClick.AddListener(() =>
        {
            GameManager._instance.Home();
        });
       */
        
    }
    public void Show() 
    {
        GameManager._instance.ShowStars();
    }
}
