using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemy : MonoBehaviour ,iBaseGame{
    private Vector2 position;
    public float speed = 0.0f;
   

    public Vector2 Position{
        get{ 
            return position;
        }
        set{ 
            position = value;
            if(transform != null)
                transform.position = position;
        }
    }

    public virtual void Setup(Vector2 _positionStart, float _velo)
    {
        Position = _positionStart;
        this.speed = _velo;
    }

    public void Move(float _deltaTime)
    {
        Position = new Vector2(Position.x+_deltaTime*speed,Position.y);
    }

    #region iBaseGame implementation

    public virtual void Initiate()
    {
        
    }

    public virtual void UpdateGame(float _deltaTime)
    {
        Move(_deltaTime);
    }

    #endregion
}

