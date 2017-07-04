using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CBulletMove : MonoBehaviour {
    public float m_timeMove=2.0f;
    //private Transform m_myTranform;
    //private void Start()
    //{
    //    if (m_myTranform == null) m_myTranform = this.GetComponent<Transform>();
    //    Moveverment();
    //}
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
}
