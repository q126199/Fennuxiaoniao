using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausepanel : MonoBehaviour
{
    private Animator anim;
    public GameObject button;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    //���pause��ť
    public void Pause()
    {
        //1.����pause����
        anim.SetBool("isPause",true);
        button.SetActive(false);
    }
    //����˼�����ť
    public void Resume()
    {
        //1.����resume����
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
        
    }
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    //pause�����궯������
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }
    //reseme�����������
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
