using huqiang.Data;
using huqiang.Manager2D;
using huqiang.UI;
using huqiang.UIComposite;
using huqiang.UIEvent;
using System;
using UnityEngine;
using huqiang;

public class AniTestPageH:HotFix.UIPage
{
    class View
    {
        public RenderImageElement render;
        public UIRocker rocker;
        public EventCallBack Last;
        public EventCallBack Next;
    }
    View view;
    public override void Initial(ModelElement parent, object dat = null)
    {
        model = ModelManagerUI.CloneModel("baseUI", "anitest");
        base.Initial(parent, dat);
        view = HotReflection.ComponentReflection<View>(model);
        view.rocker.Rocking = Rocking;
        view.rocker.Radius = 100;
        view.render.LoadAsync(() => new RolePageH(), null);
        view.Last.Click = (o, e) => { LoadPage<ScrollExTestPageH>(); };
        view.Next.Click = (o, e) => { LoadPage<TestPageH>(); };
    }
    void Rocking(UIRocker rocker)
    {
        view.render.Invoke(Rock, rocker.direction);
    }
    void Rock(RenderImageElement role,object obj)
    {
        (role.Scene.CurrentPage as RolePageH).Rocking((UIRocker.Direction) obj);
    }
    public override void Dispose()
    {
        view.render.Scene.InvokeDispose();
        base.Dispose();
    }
}
public class RolePageH : ScenePage
{
    GameObject go;
    Animator animator;
    public override void Initial(Transform trans, object dat)
    {
        var ins = ElementAsset.LoadAssets<GameObject>("base.unity3d","Sample");
        if(ins!=null)
        {
            go = GameObject.Instantiate<GameObject>(ins);
            go.transform.SetParent(trans);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            animator = go.GetComponent<Animator>();
        }
    }
    public void Rocking(UIRocker.Direction direction)
    {
        if (animator == null)
            return;
        switch(direction)
        {
            case UIRocker.Direction.Up:
                animator.Play("walk");
                break;
            case UIRocker.Direction.Down:
                animator.Play("idle");
                break;
            case UIRocker.Direction.Left:
                go.transform.localEulerAngles = Vector3.zero;
                break;
            case UIRocker.Direction.Right:
                go.transform.localEulerAngles = new Vector3(0,180,0);
                break;
        }
    }
}

