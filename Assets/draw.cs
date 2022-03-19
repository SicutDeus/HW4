using System.Collections.Generic;
using UnityEngine.UI;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

public class draw : MonoBehaviour
{
    [SerializeField]
    InputField expr;
    [SerializeField]
    LineRenderer line;
    private static string checkGrade(string code, int powIndex)
    {
        int bracketcounter;
        int i;
        if (code[powIndex + 1] == '(')
        {
            bracketcounter = 1;
            i = 1;
            while (bracketcounter != 0)
            {
                i++;
                if (code[powIndex + i] == '(')
                {
                    bracketcounter++;
                }
                else if (code[powIndex + i] == ')')
                {
                    bracketcounter--;
                }
            }
            return code.Substring(powIndex + 1, i).ToString();
        }
        else
        {
            string grade = "";
            i = 0;
            while (powIndex + i != code.Length - 1 && code[powIndex + i + 1] != '*' && code[powIndex + i + 1] != '/' && code[powIndex + i + 1] != '-' && code[powIndex + i + 1] != '+')
            {
                i++;
                grade += code[powIndex + i].ToString();
            }
            return grade;
        }

    }
    private static string checkSubGrade(string code, int powIndex)
    {
        int i;
        if (code[powIndex - 1] == ')')
        {
            int bracketcounter = -1;
            i = -1;
            while (bracketcounter != 0)
            {
                i--;
                if (code[powIndex + i] == '(')
                {
                    bracketcounter++;
                }
                else if (code[powIndex + i] == ')')
                {
                    bracketcounter--;
                }
            }
            return code.Substring(powIndex + i, Math.Abs(i)).ToString();
        }
        else
        {
            string subgrade = "";
            i = 0;
            while (powIndex + i != 0 && code[powIndex + i - 1] != '*' && code[powIndex + i - 1] != '/' && code[powIndex + i - 1] != '-' && code[powIndex + i - 1] != '+')
            {
                i--;
                subgrade += code[powIndex + i].ToString();
            }
            return new string(subgrade.Reverse().ToArray());
        }
    }
    private static StringBuilder setPow(string code)
    {
        string grade = "";
        string subgrade = "";
        int powIndex = code.Length;
        while (code.IndexOf("^") != -1)
        {
            powIndex--;
            if (code[powIndex] == '^')
            {
                grade = checkGrade(code, powIndex);
                subgrade = checkSubGrade(code, powIndex);
                code = code.Replace($"{subgrade}^{grade}", $"(Pow({subgrade},{grade}))");
                powIndex = code.Length;
            }
        }
        return new StringBuilder(code);
    }
    private static StringBuilder setAbs(string code)
    {
        int index1, index2;
        while (code.IndexOf('|') != -1)
        {
            index1 = code.IndexOf("|");
            index2 = code.IndexOf("|", index1 + 1);
            code = code.Remove(index2, 1);
            code = code.Insert(index2, ")");
            code = code.Remove(index1, 1);
            code = code.Insert(index1, "Abs(");
        }
        return new StringBuilder(code);
    }
    static StringBuilder PreParser(StringBuilder code)
    {
        code = setPow(code.ToString());
        code.Replace("y =", "");
        code.Replace("y=", "");
        code.Replace("sin", "Sin");
        code.Replace("cos", "Cos");
        code.Replace("ctg", "1/Tan");
        code.Replace("tg", "Tan");
        code.Replace("ln", "Log");
        code.Replace("sqrt", "Sqrt");
        code.Replace("pi", $"(PI)");
        code.Replace("e", $"(E)");
        code = setAbs(code.ToString());
        Regex beforePattern = new Regex(@"[0-9x]{1}[a-zA-Z(]");//случаи, когда число/х перед функцией/скобкой
        Regex afterPattern = new Regex(@"\)[0-9a-zA-Z(]");//обработка случаев, когда после ) число,буква или (
        while (afterPattern.Matches(code.ToString()).Count != 0)
        {
            Match match2 = afterPattern.Match(code.ToString());
            code.Replace(match2.ToString(), $"{match2.ToString()[0]}*{match2.ToString()[1]}");
        }
        while (beforePattern.Matches(code.ToString()).Count != 0)
        {
            Match match3 = beforePattern.Match(code.ToString());
            code.Replace(match3.ToString(), $"{match3.ToString()[0]}*{match3.ToString()[1]}");
        }
        return code;

    }

    private async  void getDelegate(string ex)
    { 
        StringBuilder code = new StringBuilder(ex);
        code = PreParser(code);//преобразование строки в возможному для парсинга вида
        var options = Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default.WithImports("System.Math");
        var deleg = await CSharpScript.EvaluateAsync<Func<double, double>>($"x => {code.ToString()}",options);//получение делегата
        line.startWidth = 0.02f;
        Vector3[] points = new Vector3[2040];
        int i = 0;
        if(line.positionCount!=0)line.positionCount = 0;
        for (double x = 0; x <= 50 ; x += 0.025,i++)//построение графика
        {
           Vector3 Point = new Vector3((float)(x*0.221), (float)(deleg(x)));
           Debug.Log($"{Point.x} {Point.y}");
           line.positionCount++;
           line.SetPosition(i, Point);
        }
    }
    public void button_click()
    {
        getDelegate(expr.text);
    }

}

