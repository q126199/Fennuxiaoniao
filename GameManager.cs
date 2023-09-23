using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<pig> pig;
    public static GameManager _instance;
    private Vector3 originPos;//��ʼ��λ��
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
    //��ʼ��С��
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)//��һֻС��
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
    //�ж���Ϸ�߼�
    public void NextBird()
    {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                //��һֻ�ɰ�
                Initialized();
            }
            else
            {
                //����
                lose.SetActive(true);
            }

        }
        else 
        {
            //Ӯ��
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
    public void Replay()  //����Ҳû�е���
    {
        SaveData();
        SceneManager.LoadScene(1);
    }
    public void Home() //û���ñ���ģ�������û
    {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void SaveData() {
         if(starsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel"))) {  //����õ��ǹؿ�Id:(Level+id)��Ȼ����ȡ����Ӧ�ؿ����ֵ����������Ƚ�
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starsNum);   //���µ�����������֮ǰ���򱣴����µ�
        } 
        //PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), 0); //����ͨ����Σ�������0����

        //�洢���е����Ǹ���
        int sum = 0;
        for (int i = 1; i <= totalNum; i++) {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalNum",sum);
        print(PlayerPrefs.GetInt("totalNum"));
    }
}
