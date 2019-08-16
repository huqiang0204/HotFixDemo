using huqiang.UI;
using System;
using System.Collections.Generic;
using System.Text;

public class HotReflection
{
    public static TempReflection ObjectFelds(object obj)
    {
        var fs = obj.GetType().GetFields();
        TempReflection temp = new TempReflection();
        temp.Top = fs.Length;
        ReflectionModel[] reflections = new ReflectionModel[temp.Top];
        for (int i = 0; i < fs.Length; i++)
        {
            ReflectionModel r = new ReflectionModel();
            r.field = fs[i];
            r.FieldType = fs[i].FieldType;
            r.name = fs[i].Name;
            reflections[i] = r;
        }
        temp.All = reflections;
        return temp;
    }
    public static void ComponentReflection(ModelElement mod, object obj)
    {
        var r = ObjectFelds(obj);
        ModelManagerUI.LoadToGameR(mod, r, "");
        ReflectionModel[] all = r.All;
        for (int i = 0; i < all.Length; i++)
            all[i].field.SetValue(obj, all[i].Value);
    }
    public static T ComponentReflection<T>(ModelElement mod)where T:class,new()
    {
        T t = new T();
        ComponentReflection(mod,t);
        return t;
    }
}