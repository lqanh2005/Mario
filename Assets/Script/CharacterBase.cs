using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRender;
    public Rigidbody2D rigidbody2D;
    public float jumpForce;
    public float speed;
    public bool groundCheck;

    public abstract void Init();
    public abstract void Hit(HitType hitType);
    public virtual void Die()
    {
        GamePlayController.instance.ChangeCharector(CharectorType.Small);
        GamePlayController.instance.HandleSetCurrentToFirstPossition();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(ActionType.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(ActionType.Right);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(ActionType.Jump);
        }
        if (!Input.anyKey)
        {
            if (groundCheck) // cham dat
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Jump");
            }
        }
        if (!groundCheck)
        {
            animator.Play("Jump");
        }
    }
    public virtual void Move(ActionType actionTypeParam)
    {
        if (!groundCheck)
        {
            return;
        }
        switch (actionTypeParam)
        {
            case ActionType.Left:

                rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
                spriteRender.transform.localScale = new Vector3(-1, 1, 1);
                if (groundCheck)
                {
                    animator.Play("Move");
                }
                else
                {
                    animator.Play("Jump");
                }
                break;
            case ActionType.Right:
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
                spriteRender.transform.localScale = new Vector3(1, 1, 1);
                if (groundCheck)
                {
                    animator.Play("Move");
                }
                else
                {
                    animator.Play("Jump");
                }
                break;
            case ActionType.Jump:
                animator.Play("Jump");
                rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, 2 * jumpForce), ForceMode2D.Impulse);
                break;
        }
    }
}
public enum ActionType
{
    Left,
    Right,
    Jump
}
public enum HitType
{
    RedMusrom,
    GreenMusrom,
    Star,
    Flower,
    Enemy,
    Brick,
    DieZone
}