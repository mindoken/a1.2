using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class BonusBaseScript : MonoBehaviour
{
    protected Color color = Color.yellow;
    protected Color textColor = Color.black;
    protected String text = "+100";
    public GameObject bonusPrefab;

    private const int pointsPerActivation = 100;
    private const float deltaY = 0.02f;

    protected virtual void BonusActivate()
    {
    UnityEngine.Debug.Log("Бонус пойман");
      prefabmanger.instance.GameData.points+= pointsPerActivation;
    }

    protected virtual void initializeFields(){}

    void initializeBonus()
    {
        initializeFields();
        gameObject.GetComponent<SpriteRenderer>().color = color;
        var textComponent = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = text;
        textComponent.color = textColor;
    }

    void Start()
    {
        initializeBonus();
    }


  void Update()
    {
        if (Time.timeScale > 0)
        {
            var pos = transform.position;
            pos.y = gameObject.transform.position.y - deltaY;
            transform.position = pos;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.CompareTag("Player")) {
      BonusActivate();
      Destroy(gameObject);
    }
    if (other.gameObject.CompareTag("Wall")) { Destroy(gameObject); }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            BonusActivate();
            Destroy(gameObject);
        }
    }*/
}
