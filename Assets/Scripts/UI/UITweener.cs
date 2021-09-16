using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// https://www.youtube.com/watch?v=Ll3yujn9GVQ
public enum UIAnimationTypes
{
    Move, 
    Scale,
    ScaleX,
    ScaleY,
    Fade
}
public class UITweener : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject objectToAnimate;
    
    public UIAnimationTypes animationType;
    public LeanTweenType easeType;
    public float duration;
    public float delay;

    public bool loop;
    public bool pingPong;

    public bool startPositionOffset;
    public Vector3 from;
    public Vector3 to;

    public bool showOnEnable;
    public bool workOnHover;
    public bool workOnDisable; 
    
    private LTDescr tweenObject;

    public void OnEnable()
    {
        if (showOnEnable)
        {
            Show();
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (workOnHover)
        {
            Show();
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (workOnHover)
        {
            SwapDirection();
            Show();
            tweenObject.setOnComplete(() =>
            {
                SwapDirection();
            });
        }
    }

    public void Show()
    {
        HandleTween();
    }

    public void HandleTween()
    {
        if (objectToAnimate == null)
        {
            objectToAnimate = gameObject;
        }

        switch (animationType)
        {
            case UIAnimationTypes.Fade:
                Fade();
                break;
            case UIAnimationTypes.Move:
                MoveAbsolute();
                break;
            case UIAnimationTypes.Scale:
                Scale();
                break;
            case UIAnimationTypes.ScaleX:
                Scale();
                break;
            case UIAnimationTypes.ScaleY:
                Scale();
                break;
        }

        tweenObject.setDelay(delay);
        tweenObject.setEase(easeType);

        if (loop)
        {
            tweenObject.loopCount = int.MaxValue;
        }

        if (pingPong)
        {
            tweenObject.setLoopPingPong();
        }
    }

    public void Fade()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        if (startPositionOffset)
        {
            objectToAnimate.GetComponent<CanvasGroup>().alpha = from.x;
        }

        tweenObject = LeanTween.alphaCanvas(objectToAnimate.GetComponent<CanvasGroup>(), to.x, duration);
    }

    public void MoveAbsolute()
    {
        objectToAnimate.GetComponent<RectTransform>().anchoredPosition = from;

        tweenObject = LeanTween.move(objectToAnimate.GetComponent<RectTransform>(), to, duration);
    }

    public void Scale()
    {
        if (startPositionOffset)
        {
            objectToAnimate.GetComponent<RectTransform>().localScale = from;
        }

        tweenObject = LeanTween.scale(objectToAnimate, to, duration);
    }

    void SwapDirection()
    {
        var temp = from;
        from = to;
        to = temp;
    }

    public void Disable()
    {
        SwapDirection();
        HandleTween();

        tweenObject.setOnComplete(() =>
        {
            SwapDirection();
            gameObject.SetActive(false);
        });
    }


    
}
