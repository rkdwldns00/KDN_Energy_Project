using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Switch : Trigger,Interaction
{
    public Sprite on;
    public Sprite off;
    public bool isSensor;
    SpriteRenderer render;
    float timer=0;
    protected override void OnEnable()
    {
        render = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSensor)
        {
            return;
        }
        input(true);
        output();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isSensor)
        {
            return;
        }
        input(false);
        output();
    }

    public void interaction()
    {
        if (isSensor)
        {
            return;
        }
        if (timer <= 0f)
        {
            timer = 1f;
            input(!IsActive);
            output();
        }
    }

    public override void input(bool val)
    {
        base.input(val);
        if (IsActive)
        {
            render.sprite = on;
        }
        else
        {
            render.sprite = off;
        }
    }
}
