using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyRun : CEnemy {
    private float speedStart = 0;
    public override void Initiate()
    {
        base.Initiate();
       
    }

    public override void Setup(Vector2 _positionStart, float _velo)
    {
        base.Setup(_positionStart, _velo);
        speedStart = speed;
        StartCoroutine(UpdateMoverment());
    }
    private IEnumerator UpdateMoverment()
    {
        float timeDelay = Random.Range(1.0f, 1.5f);;

        while (true)
        {
            yield return new WaitForSeconds(timeDelay);
            if (speed == 0)
            {
                timeDelay = Random.Range(0.2f, 0.75f);
                speed = speedStart;
            }
            else
            {
                speed = 0; 
            }
        }
    }

    public override void UpdateGame(float _deltaTime)
    {
        base.UpdateGame(_deltaTime);
    }
}
