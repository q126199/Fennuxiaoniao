using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    //[SerializeField]
    //Button re; //���棻
    //[SerializeField]
    //Button home; //�ص��ؿ�ѡ�����
    //����������,��ʾ����

    private void Awake()
    {
        //�����¼�
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
