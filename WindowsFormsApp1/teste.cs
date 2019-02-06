using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    class Teste
    {
        int div;
        public string s;

        public static int Procedimento(int num, bool tf)
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = @"{ ""nome"" : ""Vinicius"", ""sobrenome"" : ""Apolinario"", ""email"": ""vinicius@live.com"" }";
            dynamic resultado = serializer.DeserializeObject(json);
            MessageBox.Show("  ==  Resultado da leitura do arquivo JSON  == ");
            foreach (KeyValuePair<string, object> entry in resultado)
            {
                var key = entry.Key;
                var value = entry.Value as string;
                MessageBox.Show(String.Format("{0} : {1}", key, value));
            }

            MessageBox.Show(serializer.Serialize(resultado));
            return 0;
                
        }

        public static string ModificaString( string ss)
        {
            String[] expressions = { "16 + 21", "31 * 3", "28 / 3",
                               "42 - 18", "12 * 7",
                               "2, 4, 6, 8" };
            String pattern = @"(\d+)\s+([-+*/])\s+(\d+)";
            foreach (var expression in expressions)
                foreach (Match m in Regex.Matches(expression, pattern))
                {
                    int value1 = Int32.Parse(m.Groups[1].Value);
                    int value2 = Int32.Parse(m.Groups[3].Value);
                    switch (m.Groups[2].Value)
                    {
                        case "+":
                            ss = ss + " " + String.Format("{0} = {1}", m.Value, value1 + value2);
                            break;
                        case "-":
                            ss = ss + " " + String.Format("{0} = {1}", m.Value, value1 - value2);
                            break;
                        case "*":
                            ss = ss + " " + String.Format("{0} = {1}", m.Value, value1 * value2);
                            break;
                        case "/":
                            ss = ss + " " + String.Format("{0} = {1:N2}", m.Value, value1 / value2);
                            break;
                    }
                }
            return ss;
        }

    }
}
