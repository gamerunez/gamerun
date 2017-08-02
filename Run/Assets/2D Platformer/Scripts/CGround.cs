using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGround : MonoBehaviour {

    private Transform myTrf;
    private Vector2 currPosition = new Vector2();
    private float speedMove = -4.0f;
    public Vector2 CurrPosition
    {
        set{ 
            this.currPosition = value;
        }
        get
        {
            return this.currPosition;
        }
    }

    private CGroundSpawn groundManager;
    void Awake()
    {
        myTrf = GetComponent<Transform>();
    }

    public void SetUp(Vector2 _positionStart,CGroundSpawn _groundManager = null)
    {
        //this.groundManager = _groundManager;
        this.CurrPosition = _positionStart;
        transform.position = CurrPosition;
    }

    public void Move(float deltaTime)
    {
        CurrPosition = new Vector2(CurrPosition.x+deltaTime*speedMove, CurrPosition.y);
        myTrf.position = CurrPosition;
    }
}
