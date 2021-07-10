using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvisibility : MonoBehaviour
{
    private SpriteRenderer enemySprite;

    public bool isInvisible = false;
    public float visibility = 50;
    public bool useVisibilityStates = false;
    public float visibleTime = 0.5f;
    public float invisibleTime = 1f;

    private bool visible = true;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        if(isInvisible)
            StartCoroutine(Visibility());
    }

    IEnumerator Visibility()
    {
        if (useVisibilityStates)
        {
            if (visible)
                yield return new WaitForSeconds(visibleTime);
            else
                yield return new WaitForSeconds(invisibleTime);
        }
        else
            yield return new WaitForSeconds(visibleTime);
        if (visible)
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, visibility / 255);
        else
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1);
        visible = !visible;
        StartCoroutine(Visibility());
    }
}
