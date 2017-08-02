using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CBulletMove : MonoBehaviour {
    public float m_timeMove=2.0f;
    public GameObject effectExplosion;      
    public void SetUp()
    {
        Moveverment();
    }
    private void Moveverment()
    {
        transform.DOMoveX(10, m_timeMove).SetRelative().OnComplete(DestroyWhenCompletMove);
    }
    private void StopMove()
    {
        transform.DOKill();
    }
    private void DestroyWhenCompletMove()
    {
        StopMove();
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(effectExplosion).transform.position = transform.position;
        }
    }
}
