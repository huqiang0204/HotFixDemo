﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;
using huqiang.UIComposite;
using huqiang.UIEvent;
using huqiang;
using UnityEngine;

public class TestPageH : HotFix.UIPage
{
    class View
    {
        public ImageElement Image;
        public UIDate Date;
        public TreeView TreeView;
        public TextInput Log;
        public GridScroll Scroll;
        public ScrollXS ScrollX;
        public ScrollYS ScrollY;
        public DragContent Drag;
        public UISlider Slider;
        public EventCallBack Last;
        public EventCallBack Next;
    }
    class Item
    {
        public TextElement Text;
    }
    View view;
    public override void Initial(ModelElement parent, object dat = null)
    {
        model = ModelManagerUI.CloneModel("baseUI", "asd");
        // view =LoadUI<View>("baseUI","asd");
        base.Initial(parent, dat);
        view = HotReflection.ComponentReflection<View>(model);
        //model.SetParent(UIPage.Root);
        // var view = model.ComponentReflection<View>();

        TreeViewNode node = new TreeViewNode();
        node.content = "root";
        for (int i = 0; i < 10; i++)
        {
            TreeViewNode son = new TreeViewNode();
            son.content = i.ToString() + "tss";
            node.child.Add(son);
            for (int j = 0; j < 6; j++)
            {
                TreeViewNode r = new TreeViewNode();
                r.content = j.ToString() + "sdfsdf";
                son.child.Add(r);
            }
        }
        view.TreeView.nodes = node;
        view.TreeView.Refresh();
        view.Log.TipString = "input";
       
        List<int> testData = new List<int>();
        for (int i = 0; i <166; i++)
            testData.Add(i);
        view.ScrollX.scroll.BindingData = testData;
        view.ScrollX.scroll.SetItemUpdate((o, e, i) => { Item it = o as Item;  it.Text.text = i.ToString(); }, (o) => { return HotReflection.ComponentReflection<Item>(o);});
        view.ScrollX.scroll.Refresh();

        view.ScrollY.scroll.BindingData = testData;
        view.ScrollY.scroll.SetItemUpdate((o, e, i) => { Item it = o as Item; it.Text.text = i.ToString(); }, (o) => { return HotReflection.ComponentReflection<Item>(o); });
        view.ScrollY.scroll.Refresh();

        view.Scroll.BindingData = testData;
        view.Scroll.Column = 16;
        view.Scroll.SetItemUpdate((o, e, i) => { Item it = o as Item; it.Text.text = i.ToString(); }, (o) => { return HotReflection.ComponentReflection<Item>(o); });
        view.Scroll.Refresh();
        view.Last.Click = (o, e) => { LoadPage<AniTestPageH>(); };
        view.Next.Click = (o, e) => { LoadPage<LayoutTestPageH>(); };
    }
}
