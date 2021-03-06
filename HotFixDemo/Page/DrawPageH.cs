﻿using huqiang;
using huqiang.UI;
using huqiang.UIComposite;
using huqiang.UIEvent;
using UnityEngine;

public class DrawPageH : HotFix.UIPage
{
    class View
    {
        public Paint draw;
        public UIPalette Palette;
        public RawImageElement color;
        public TextElement tip;
        public UISlider sizeS;
        public EventCallBack mod0;
        public EventCallBack mod1;
        public EventCallBack mod2;
        public EventCallBack Last;
        public EventCallBack Next;
    }
    View view;
    public override void Initial(ModelElement parent, object dat = null)
    {
        model = ModelManagerUI.CloneModel("baseUI", "drawing");
        base.Initial(parent, dat);
        view = HotReflection.ComponentReflection<View>(model);
        view.Palette.TemplateChanged = view.Palette.ColorChanged = (o) => {
            view.draw.BrushColor = o.SelectColor;
            view.color.color = o.SelectColor;
        };
        view.sizeS.OnValueChanged = (o) => {
            float a = o.Percentage * 78;
            a += 2;
            view.draw.BrushSize = a;
            view.tip.text = "画笔尺寸:" + a.ToString();
        };
        view.mod0.Click = (o, e) => { view.draw.drawModel = Paint.DrawModel.Brush; };
        view.mod1.Click = (o, e) => { view.draw.drawModel = Paint.DrawModel.Scale; };
        view.mod2.Click = (o, e) => { view.draw.drawModel = Paint.DrawModel.Rotate; };
        view.Last.Click = (o, e) => { LoadPage<LayoutTestPageH>(); };
        view.Next.Click = (o, e) => { LoadPage<ScrollExTestPageH>(); };
    }
}
