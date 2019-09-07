using huqiang.Data;
using System;
using UnityEngine;

public class Main
{
    public void Start()
    {
        HotFix.UIPage.Root = UIPage.Root;
        HotFix.UIPage.LoadPage<TestPageH>();
    }
    public void Show(object dat)
    {
        if (HotFix.UIPage.CurrentPage != null)
            HotFix.UIPage.CurrentPage.Show(dat);
    }
    public void Update(float time)
    {
        HotFix.UIPage.Refresh(time);
    }
    public void Cmd(DataBuffer dat)
    {
        if (HotFix.UIPage.CurrentPage != null)
            HotFix.UIPage.CurrentPage.Cmd(dat);
    }
    public void UpdateData(string cmd,object dat)
    {
        HotFix.UIPage.UpdateData(cmd, dat);
    }
    public void Resize()
    {
        if (HotFix.UIPage.CurrentPage != null)
            HotFix.UIPage.CurrentPage.ReSize();
    }
    public void ChangeLanguage()
    {
        if (HotFix.UIPage.CurrentPage != null)
            HotFix.UIPage.CurrentPage.ChangeLanguage();
    }
    public void Dispose()
    {
        if (HotFix.UIPage.CurrentPage != null)
            HotFix.UIPage.CurrentPage.Dispose();
    }
}