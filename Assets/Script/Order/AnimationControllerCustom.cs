using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationControllerCustom : MonoBehaviour
{
    //array que contiene a todas las animaciones
    public AnimationInfo[] animations;

    //animacion actual
    [HideInInspector] // la oculta en el editor
    public AnimationInfo currentAnimation;

    //esta variable controla el tiempo de reproduccion
    public float timer;

    //encargado de pintar la imagen
    public SpriteRenderer sp;

    //la posicion dentro de la animacion actual
    public int frame;

    //si se reporduce o no la animcion
    public bool stopAnimation;

	// Use this for initialization
	void Start ()
    {

        //le pido el componente al objeto y lo guardo en la variable
        sp = GetComponent<SpriteRenderer>();

        //le digo que la animacion actual es la que esta en el indice 1 // IDLE
       // ChangeAnimation("idle");

    }
	
	// Update is called once per frame
	void Update ()
    {
        //sumo el tiempo real
        timer += Time.deltaTime;
        //si el tiempo real no llega al tiempo deseado sali de la funcion
        //recordar emilio y su edad
        //o esta en stop
        if (timer <  1 / currentAnimation.frameRate  || stopAnimation == true) return;
        //paso de fraqme
        frame++;
        //reinicio el timer 
        timer = 0;

        SetFrame();


    }

    //le digo al sprite que muestre la imagen del frame actual
    //cambia la imagen
    public void SetFrame()
    {
        //pregunto si el frame actual es mas grando o igual que la cantidad de imagenes
        if (frame >= currentAnimation.sprites.Length)
        {
            //si la animacion es loopeable, volve a cero
            if (currentAnimation.loop == true)
            {
                frame = 0;
            }
            else
            {
                //sino frena la animcion
                stopAnimation = true;
                //volve al ultimo frame
                frame--;
                //si hay una proxima animacion
                if(currentAnimation.nextAnimation != "none")
                {
                    ChangeAnimation(currentAnimation.nextAnimation);
                }

            }
                
           
        }

        //cambio la imagen por la de ese frame
        if(sp != null)
        sp.sprite = currentAnimation.sprites[frame];
        CheckForAnimationEvents();
    }

    //Esta funcion busca y cambia la animacion
    public void ChangeAnimation(string nextAnimation)
    {

        //si la proxima animacion es la animacion actual, bueno no sigas
        if (nextAnimation == currentAnimation.name) return;

        //se vuelve a reproducir la animacion
        stopAnimation = false;

        //paso por todas las animaciones
        for (int i = 0; i < animations.Length; i++)
        {
            //pregunto si la animacion que busco tiene el mismo nombre que la animacion del array
            if(nextAnimation == animations[i].name)
            {
                //si tiene el mismo nombre, cambio la animacion
                //diciendo que la animacion actual es la que tiene el mismo nombre 
                currentAnimation = animations[i];
                //reinicio el frame
                frame = 0;
                //cambio la imagen
                SetFrame();

            }
        }

    }

    public void CheckForAnimationEvents()
    {
        //paso por todos los eventos de animacion
        for (int i = 0; i < currentAnimation.animationsEvents.Length; i++)
        {
            
            if (frame == currentAnimation.animationsEvents[i].frame && currentAnimation.animationsEvents[i] != null)
            {
                //SendMessage me permite llamar a una funcion por el nombre a modo de string
                //si la funcion este dentro del GameObject
                SendMessage(currentAnimation.animationsEvents[i].functionName);
               

            }
        }
    }


}



[System.Serializable]
public class AnimationInfo
{
    //nombre de la animacion
    public string name;
    //sprites de la animacion
    public Sprite[] sprites;
    //loopeable
    public bool loop;
    public AnimationEvent[] animationsEvents;

    //velocidad de reproduccion
    public float frameRate;
    //la proxima animacion cuando termino
    public string nextAnimation = "none";

}

[System.Serializable]
public class AnimationEvent
{
    //frame donde quiero que se ejecute la funcion
    public int frame;
    //nombre de la funcion que se va a ejecutar en ese frame
    public string functionName;
}