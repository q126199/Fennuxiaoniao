using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class pig : MonoBehaviour
{
    public float maxSpeed = 10;  //撞击最大速度
    public float minSpeed = 5;   //撞击最小速度
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;
    public AudioClip hurtClip;
    public AudioClip dead;
    public AudioClip birdCollision;

    public bool isPig = false;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)//碰撞检测函数1
    {
        //print(collision.relativeVelocity.magnitude);
        if (collision.gameObject.tag == "Player") 
        {
            AudioPlay(birdCollision);
            collision.transform.GetComponent<Bird>().Hurt();
        }
        if (collision.relativeVelocity.magnitude > maxSpeed)//大于最大速度，直接死亡
        {
            Dead(); //直接死亡
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed) {

            render.sprite = hurt;
            AudioPlay(hurtClip);
        }
    }

   public void Dead() {
        if (isPig)
        {
            GameManager._instance.pig.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position + new Vector3(0,0.7f,0), Quaternion.identity);
        Destroy(go,1.5f);
        //播放音乐
        AudioPlay(dead);
    }
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    /* private void OnTriggerEnter2D(Collider2D collision)//碰撞检测函数2
    {
        
    }
    */
}
