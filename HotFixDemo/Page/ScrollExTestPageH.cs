using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using huqiang.UI;
using huqiang.UIComposite;
using huqiang.UIEvent;
using UnityEngine;
using huqiang;

public class ScrollExTestPageH :HotFix.UIPage
{
    class View
    {
        public ScrollYExtand scroll;
        public EventCallBack Last;
        public EventCallBack Next;
        public DragContent Drag;
        public DropdownEx Dropdown;
    }
    View view;
    class TitleItem
    {
        public EventCallBack bk;
        public TextElement Text;
    }
    class SubItem
    {
        public TextElement Text;
    }
    public override void Initial(ModelElement parent, object dat = null)
    {
        model = ModelManagerUI.CloneModel("baseUI", "scrollex");
        base.Initial(parent, dat);
        view = HotReflection.ComponentReflection<View>(model);
        List<ScrollYExtand.DataTemplate> datas = new List<ScrollYExtand.DataTemplate>();
        ScrollYExtand.DataTemplate tmp = new ScrollYExtand.DataTemplate();
        tmp.Title = "test1";
        List<string> list = new List<string>();
        for (int i = 0; i < 22; i++)
            list.Add("tttt"+i.ToString());
        tmp.Hide = true;
        tmp.Data = list;
        datas.Add(tmp);

        tmp = new ScrollYExtand.DataTemplate();
        tmp.Title = "test2";
        list = new List<string>();
        for (int i = 0; i < 11; i++)
            list.Add("tttt" + i.ToString());
        tmp.Hide = true;
        tmp.Data = list;
        datas.Add(tmp);

        tmp = new ScrollYExtand.DataTemplate();
        tmp.Title = "test3";
        list = new List<string>();
        for (int i = 0; i < 7; i++)
            list.Add("tttt" + i.ToString());
        tmp.Hide = true;
        tmp.Data = list;
        datas.Add(tmp);

        view.scroll.BindingData = datas;
        view.scroll.SetTitleUpdate(TitleUpdate, (o) => { return HotReflection.ComponentReflection<TitleItem>(o); });
        view.scroll.SetItemUpdate(ItemUpdate, (o) => { return HotReflection.ComponentReflection<SubItem>(o); });
        view.scroll.Refresh();

        List<string> rr = new List<string>();
        for (int i = 0; i < 33; i++)
            rr.Add(i.ToString());
        view.Dropdown.BindingData = rr;

        view.Last.Click = (o, e) => { LoadPage<DrawPageH>(); };
        view.Next.Click = (o, e) => { LoadPage<AniTestPageH>(); };
    }
    ScrollYExtand.DataTemplate current;
    void TitleUpdate(object mod, object dat, int index)
    {
        TitleItem title = mod as TitleItem;
        ScrollYExtand.DataTemplate data = dat as ScrollYExtand.DataTemplate;
        title.Text.text = data.Title as string;
        title.bk.DataContext = data;
        title.bk.Click = (o, e) => {
            var dt = o.DataContext as ScrollYExtand.DataTemplate;
            if(dt.Hide)
            {
                view.scroll.OpenSection(dt);
                if(current!=dt)
                {
                    view.scroll.HideSection(current);
                }
                current = dt;
            }
            else
            {
                view.scroll.HideSection(dt);
                if (dt == current)
                    current = null;
            }
        };
    }
    void ItemUpdate(object mod,object data,int index)
    {
        SubItem item = mod as SubItem;
        item.Text.text = data as string;
    }

}
