using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {


    public FeetPart feets;
    public AnimationControllerCustom anim;
    public SpriteRenderer render;


    private void Start()
    {
        feets = GetComponentInParent<FeetPart>();
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (feets.render.flipX)
        render.flipX = true;
        else render.flipX = false;
    }

    private void LateUpdate()
    {

        AnimationControlBody();

        FixPosition();
    }

    private void AnimationControlBody()
    {
        if (feets.isJumping)
        {

            if (feets.rb.velocity.x == 0)
                anim.ChangeAnimation(AnimationName.gun_jumpUp);
            else anim.ChangeAnimation(AnimationName.gun_jumpFront);
        }

        else if (feets.ismoving)
        {
            if (feets.iswalking) anim.ChangeAnimation(AnimationName.gun_walk);
        }

        else anim.ChangeAnimation(AnimationName.gun_idle);
    }

    private void FixPosition()
    {
        if (feets.render.flipX)
        {
            if (feets.ismoving) transform.localPosition = new Vector2(-0.059f, transform.localPosition.y);
            //else if (feets.isJumping)transform.localPosition = new Vector2(0.026f, 0.132f);


            if (feets.isJumping && feets.rb.velocity.x == 0) transform.localPosition = new Vector2(0.026f, 0.132f);
            else if (feets.isJumping && feets.rb.velocity.x != 0) transform.localPosition = new Vector2(0.026f, 0.132f);
          
            else if (!feets.ismoving) transform.localPosition = new Vector2(-0.063f, 0.107f);

        }

        else
        {
            if (feets.ismoving) transform.localPosition = new Vector2(0.06f, transform.localPosition.y);
            if (feets.isJumping && feets.rb.velocity.x == 0) transform.localPosition = new Vector2(0.018f, 0.143f);
            else if (feets.isJumping && feets.rb.velocity.x != 0) transform.localPosition = new Vector2(-0.046f, 0.126f);

          
            
        }
    }

}
