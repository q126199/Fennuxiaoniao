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
    //点击pause按钮
    public void Pause()
    {
        //1.播放pause动画
        anim.SetBool("isPause",true);
        button.SetActive(false);
    }
    //点击了继续按钮
    public void Resume()
    {
        //1.播放resume动画
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
        
    }
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    //pause播放完动画调用
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }
    //reseme动画播完调用
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
