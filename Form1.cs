using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace SpeechToCode
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        bool cSharp = false;
        int i = 0;
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add("enum", "return", "run", "abstract", "static", "void", "get method", "set method", "method", "extends", "virtual", "public", "private", "protected", "internal", "create class", "read from file", "write to file", "create file", "try catch", "plus", "get input", "maximum", "minimum", "square", "absolute", "round", "sort array", "for each", "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "array", "new", "if statement", "else if statement", "else statement", "switch case", "main method", "space", "variable", "enter", "down", "up", "left", "right", "backspace", "tab", "print", "select all", "undo", "semicolon", "comment", "equals", "string", "integer", "double", "bool", "char", "quote", "convert to bool", "convert to double", "convert to string", "convert to int", "for loop", "while loop");
            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }

            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("Select a language");
            InitializeComponent();
        }

        public void say(string h)
        {
            s.Speak(h);
        }


        private void rec_SpeachRecognized(Object sender, SpeechRecognizedEventArgs e)
        {
            string selected = drop.Text;
            string r = e.Result.Text;
            string dir = Dir.Text;

            if (selected == "C#")
            {
                cSharp = true;
                label1.Text = "<Language: C# />";
            }
            else if (selected == "Java")
            {
                cSharp = false;
                label1.Text = "<Language: Java />";
            }
            else if (selected == "Python")
            {
                cSharp = false;
                label1.Text = "<Language: Python />";
            }
            else if (selected == "JavaScript")
            {
                cSharp = false;
                label1.Text = "<Language: JavaScript />";
            }

            if (cSharp == true)
            {
                if (r == "main method")
                {
                    SendKeys.Send("public static void Main{(}{)}");
                    SendKeys.Send("{Enter}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{Enter}");
                    SendKeys.Send("{Enter}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "variable")
                {
                    SendKeys.Send("variable" + i);
                    i++;
                }
                else if (r == "enter")
                {
                    SendKeys.Send("{ENTER}");
                }
                else if (r == "up")
                {
                    SendKeys.Send("{UP}");
                }
                else if (r == "down")
                {
                    SendKeys.Send("{DOWN}");
                }
                else if (r == "left")
                {
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "right")
                {
                    SendKeys.Send("{RIGHT}");
                }
                else if (r == "backspace")
                {
                    SendKeys.Send("{BS}");
                }
                else if (r == "tab")
                {
                    SendKeys.Send("{TAB}");
                }
                else if (r == "print")
                {
                    SendKeys.Send("Console.WriteLine{(}\"\"{)};");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "select all")
                {
                    SendKeys.Send("^a");
                }
                else if (r == "undo")
                {
                    SendKeys.Send("^z");
                }
                else if (r == "semicolon")
                {
                    SendKeys.Send(";");
                }
                else if (r == "comment")
                {
                    SendKeys.Send("//");
                }
                else if (r == "equals")
                {
                    SendKeys.Send("=");
                }
                else if (r == "string")
                {
                    SendKeys.Send("string");
                }
                else if (r == "integer")
                {
                    SendKeys.Send("int");
                }
                else if (r == "bool")
                {
                    SendKeys.Send("bool");
                }
                else if (r == "char")
                {
                    SendKeys.Send("char");
                }
                else if (r == "double")
                {
                    SendKeys.Send("double");
                }
                else if (r == "quote")
                {
                    SendKeys.Send("\"\"");
                }
                else if (r == "convert to bool")
                {
                    SendKeys.Send("Convert.ToBoolean{(}{)};");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "convert to string")
                {
                    SendKeys.Send("Convert.ToString{(}{)};");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "convert to int")
                {
                    SendKeys.Send("Convert.ToInt32{(}{)};");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "convert to double")
                {
                    SendKeys.Send("Convert.ToDouble{(}{)};");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "for loop")
                {
                    SendKeys.Send("for {(}int i = 0; i < variable" + i + "; i{+}{+}{)}{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "while loop")
                {
                    SendKeys.Send("while {(}true{)}{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "space")
                {
                    SendKeys.Send(" ");
                }
                else if (r == "if statement")
                {
                    SendKeys.Send("if {(}true{)}{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "else if statement")
                {
                    SendKeys.Send("else if {(}true{)}{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "else statement")
                {
                    SendKeys.Send("else{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "switch case")
                {
                    SendKeys.Send("switch {(}variable" + i + "{)}{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("case x:");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("break;");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("case y:");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("break;");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("case z:");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("break;");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("default:");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("break;");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("{}}");

                }
                else if (r == "array")
                {
                    SendKeys.Send("{[}{]}");

                }
                else if (r == "new")
                {
                    SendKeys.Send("new");

                }
                else if (r == "zero")
                {
                    SendKeys.Send("0");
                }
                else if (r == "one")
                {
                    SendKeys.Send("1");
                }
                else if (r == "two")
                {
                    SendKeys.Send("2");
                }
                else if (r == "three")
                {
                    SendKeys.Send("3");
                }
                else if (r == "four")
                {
                    SendKeys.Send("4");
                }
                else if (r == "five")
                {
                    SendKeys.Send("5");
                }
                else if (r == "six")
                {
                    SendKeys.Send("6");
                }
                else if (r == "seven")
                {
                    SendKeys.Send("7");
                }
                else if (r == "eight")
                {
                    SendKeys.Send("8");
                }
                else if (r == "nine")
                {
                    SendKeys.Send("9");
                }
                else if (r == "for each")
                {
                    SendKeys.Send("foreach {(}string variable in variable" + i + "{)}{{}{}}");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{TAB}");
                }
                else if (r == "sort array")
                {
                    SendKeys.Send("Array.Sort{(}variable" + i + "{)};");
                }
                else if (r == "maximum")
                {
                    SendKeys.Send("Math.Max{(}variable, variable" + i + "{)};");
                }
                else if (r == "minimum")
                {
                    SendKeys.Send("Math.Min{(}variable, variable" + i + "{)};");
                }
                else if (r == "square")
                {
                    SendKeys.Send("Math.Sqrt{(}variable{)};");
                }
                else if (r == "absolute")
                {
                    SendKeys.Send("Math.Abs{(}variable{)};");
                }
                else if (r == "round")
                {
                    SendKeys.Send("Math.Round{(}variable{)};");
                }
                else if (r == "get input")
                {
                    SendKeys.Send("Console.ReadLine{(}{)};");
                }
                else if (r == "plus")
                {
                    SendKeys.Send("{+}");
                }
                else if (r == "try catch")
                {
                    SendKeys.Send("try");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("catch {(}Exception e{)}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                }
                else if (r == "create file")
                {
                    SendKeys.Send("StreamWriter file = new StreamWriter{(}@\"" + dir + "\"{)};");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                    SendKeys.Send("{LEFT}");
                }
                else if (r == "write to file")
                {
                    SendKeys.Send("file.WriteLine{(}\" \"{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("file.Flush{(}{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("file.Close{(}{)};");

                }
                else if (r == "read from file")
                {
                    SendKeys.Send("StreamReader fileReader = new StreamReader{(}@\"" + dir + "\"{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("fileReader.BaseStream.Seek{(}0, SeekOrigin.Begin{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("string str = fileReader.ReadLine{(}{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("while {(}str != null{)}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("Console.WriteLine{(}str{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("str = fileReader.ReadLine{(}{)};");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("fileReader.Close{(}{)};");
                }
                else if (r == "create class")
                {
                    SendKeys.Send("class x");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");

                }
                else if (r == "public")
                {
                    SendKeys.Send("public");
                }
                else if (r == "private")
                {
                    SendKeys.Send("private");
                }
                else if (r == "protected")
                {
                    SendKeys.Send("protected");
                }
                else if (r == "internal")
                {
                    SendKeys.Send("internal");
                }
                else if (r == "extends")
                {
                    SendKeys.Send(":");
                }
                else if (r == "virtual")
                {
                    SendKeys.Send("virtual");
                }
                else if (r == "get method")
                {
                    SendKeys.Send("get {{} return variable" + i + "; {}}");
                }
                else if (r == "set method")
                {
                    SendKeys.Send("set {{} variable" + i + "= value; {}}");
                }
                else if (r == "get method")
                {
                    SendKeys.Send("get {{} return variable" + i + "; {}}");
                }
                else if (r == "method")
                {
                    SendKeys.Send("method" + i + "{(}{)}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                }
                else if (r == "static")
                {
                    SendKeys.Send("static");
                }
                else if (r == "void")
                {
                    SendKeys.Send("void");
                }
                else if (r == "abstract")
                {
                    SendKeys.Send("abstract");
                }
                else if (r == "enum")
                {
                    SendKeys.Send("enum x");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{{}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{ENTER}");
                    SendKeys.Send("{}}");
                }
                else if (r == "run")
                {
                    SendKeys.Send("{F5}");
                }
                else if (r == "return")
                {
                    SendKeys.Send("return");
                }
                else
                {

                }




            }
            else
            {
                say("Unsupported language selected");
            }


        }

        Point lastPoint;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,
                
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dir.Text = openFileDialog1.FileName;
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            label1.Focus();
        }

        private void drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}
