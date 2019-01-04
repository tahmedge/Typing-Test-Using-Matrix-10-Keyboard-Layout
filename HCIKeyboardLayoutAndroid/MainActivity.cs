using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Globalization;
using Android.Content;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Plugin.Permissions;
using System.Threading.Tasks;
using Android.Views.InputMethods;
using Plugin.Messaging;
using Android.Graphics;

namespace HCIKeyboardLayoutAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static int val = 0;
        string temps;
        string[,] S = new string[3, 50];
        static Stopwatch stopWatch = new Stopwatch();
        //S[0,0]="asd";
        static int len = 0;
        static int track = 0;
        static TextView textcw;
        //Console.WriteLine("Hello World"+S[0,0][2]);
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public static void Reset()
        {
            val = 0;
            track++;
            len = 0;
            stopWatch.Reset();
            textcw.Text = "";
        }
        
        public string ComputeMistake()
        {
            string result="";
            for(int i=0;i<temps.Length;i++)
            {
                result += temps[i]+" -> "+S[track,i];
                len += S[track, i].Length;
                result += "\n";
            }
            return result;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<50;j++)
                {
                    S[i, j] = "";
                }
            }
            temps = Class1.func();
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            TextView textmain = FindViewById<TextView>(Resource.Id.textviewmain);
            TextView textname = FindViewById<TextView>(Resource.Id.textview0);
            textcw = FindViewById<TextView>(Resource.Id.textviewcorrectwrong);
            EditText text = FindViewById<EditText>(Resource.Id.textview1);
            text.SetOnKeyListener(null);
            text.SetSelection(val);
            textmain.Text = temps;

            //InputMethodManager imm = (InputMethodManager)getSystemService(Context.InputMethodService);;
            text.ShowSoftInputOnFocus=false;
      
            string s = textmain.Text;
            string temp="";
            string subject = "";

            for (int i=0;i<s.Length;i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    temp += Char.ToUpper(s[i]);
                }
                else temp += s[i];
            }

            textmain.Text=temp;

            Button buttonA = FindViewById<Button>(Resource.Id.buttonA);
            Button buttonB = FindViewById<Button>(Resource.Id.buttonB);
            Button buttonC = FindViewById<Button>(Resource.Id.buttonC);
            Button buttonD = FindViewById<Button>(Resource.Id.buttonD);
            Button buttonE = FindViewById<Button>(Resource.Id.buttonE);
            Button buttonF = FindViewById<Button>(Resource.Id.buttonF);
            Button buttonG = FindViewById<Button>(Resource.Id.buttonG);
            Button buttonH = FindViewById<Button>(Resource.Id.buttonH);
            Button buttonI = FindViewById<Button>(Resource.Id.buttonI);
            Button buttonJ = FindViewById<Button>(Resource.Id.buttonJ);
            Button buttonK = FindViewById<Button>(Resource.Id.buttonK);
            Button buttonL = FindViewById<Button>(Resource.Id.buttonL);
            Button buttonM = FindViewById<Button>(Resource.Id.buttonM);
            Button buttonN = FindViewById<Button>(Resource.Id.buttonN);
            Button buttonO = FindViewById<Button>(Resource.Id.buttonO);
            Button buttonP = FindViewById<Button>(Resource.Id.buttonP);
            Button buttonQ = FindViewById<Button>(Resource.Id.buttonQ);
            Button buttonR = FindViewById<Button>(Resource.Id.buttonR);
            Button buttonS = FindViewById<Button>(Resource.Id.buttonS);
            Button buttonT = FindViewById<Button>(Resource.Id.buttonT);
            Button buttonU = FindViewById<Button>(Resource.Id.buttonU);
            Button buttonV = FindViewById<Button>(Resource.Id.buttonV);
            Button buttonW = FindViewById<Button>(Resource.Id.buttonW);
            Button buttonX = FindViewById<Button>(Resource.Id.buttonX);
            Button buttonY = FindViewById<Button>(Resource.Id.buttonY);
            Button buttonZ = FindViewById<Button>(Resource.Id.buttonZ);
            Button buttonSpace = FindViewById<Button>(Resource.Id.buttonSpace);
            Button buttonSubmit = FindViewById<Button>(Resource.Id.buttonSubmit);
            buttonSubmit.Click += delegate
            {
                text.RequestFocus();
                InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(text.WindowToken, 0);
                text.SetSelection(val);
                if (textname.Text!="")
                {
                text.SetSelection(val);
                buttonA.Enabled = true;
                buttonB.Enabled = true;
                buttonC.Enabled = true;
                buttonD.Enabled = true;
                buttonE.Enabled = true;
                buttonF.Enabled = true;
                buttonG.Enabled = true;
                buttonH.Enabled = true;
                buttonI.Enabled = true;
                buttonJ.Enabled = true;
                buttonK.Enabled = true;
                buttonL.Enabled = true;
                buttonM.Enabled = true;
                buttonN.Enabled = true;
                buttonO.Enabled = true;
                buttonP.Enabled = true;
                buttonQ.Enabled = true;
                buttonR.Enabled = true;
                buttonS.Enabled = true;
                buttonT.Enabled = true;
                buttonU.Enabled = true;
                buttonV.Enabled = true;
                buttonW.Enabled = true;
                buttonX.Enabled = true;
                buttonY.Enabled = true;
                buttonZ.Enabled = true;
                buttonSpace.Enabled = true;
                buttonSubmit.Enabled = false;
                textname.Enabled = false;
                textname.Text = textname.Text+" (Matrix-10) ";
            }
            };

            buttonSpace.Click += delegate {
                if (temp[val] == ' ')
                {
                    text.Text += " ";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += " ";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);

                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                    Toast.MakeText(ApplicationContext, "Done", ToastLength.Long).Show();
                }
            };
            string ss = "";
            buttonA.Click += delegate {


                if (temp[val] == 'A')
                {
                    text.Text += "A";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);

                }
                else
                {
                    S[track, val] += "A";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";

                }
            };

            buttonB.Click += delegate {
                if (temp[val] == 'B')
                {
                    text.Text += "B";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "B";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonC.Click += delegate {
                if (temp[val] == 'C')
                {
                    text.Text += "C";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);

                }
                else
                {
                    S[track, val] += "C";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonD.Click += delegate {
                if (temp[val] == 'D')
                {
                    text.Text += "D";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "D";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);

                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonE.Click += delegate {
                if (temp[val] == 'E')
                {
                    text.Text += "E";
                    val++;

                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);

                }
                else
                {
                    S[track, val] += "E";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonF.Click += delegate {
                if (temp[val] == 'F')
                {
                    text.Text += "F";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "F";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonG.Click += delegate {
                if (temp[val] == 'G')
                {
                    text.Text += "G";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();

                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "G";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonH.Click += delegate {
                if (temp[val] == 'H')
                {
                    text.Text += "H";
                    val++;
                    text.SetSelection(val);

                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "H";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonI.Click += delegate {
                if (temp[val] == 'I')
                {
                    text.Text += "I";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "I";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonJ.Click += delegate {
                if (temp[val] == 'J')
                {
                    text.Text += "J";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "J";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonK.Click += delegate {
                if (temp[val] == 'K')
                {
                    text.Text += "K";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "K";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonL.Click += delegate {
                if (temp[val] == 'L')
                {
                    text.Text += "L";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "L";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonM.Click += delegate {
                if (temp[val] == 'M')
                {
                    text.Text += "M";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "M";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonN.Click += delegate {
                if (temp[val] == 'N')
                {
                    text.Text += "N";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "N";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonO.Click += delegate {
                if (temp[val] == 'O')
                {
                    text.Text += "O";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "O";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonP.Click += delegate {
                if (temp[val] == 'P')
                {
                    text.Text += "P";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "P";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonQ.Click += delegate {
                if (temp[val] == 'Q')
                {
                    text.Text += "Q";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "Q";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonR.Click += delegate {
                if (temp[val] == 'R')
                {
                    text.Text += "R";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "R";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonS.Click += delegate {
                if (temp[val] == 'S')
                {
                    text.Text += "S";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "S";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonT.Click += delegate {
                if (temp[val] == 'T')
                {
                    text.Text += "T";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {

                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "T";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonU.Click += delegate {
                if (temp[val] == 'U')
                {
                    text.Text += "U";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "U";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonV.Click += delegate {
                if (temp[val] == 'V')
                {
                    text.Text += "V";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "V";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonW.Click += delegate {
                if (temp[val] == 'W')
                {
                    text.Text += "W";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "W";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonX.Click += delegate {
                if (temp[val] == 'X')
                {
                    text.Text += "X";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "X";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonY.Click += delegate {
                if (temp[val] == 'Y')
                {
                    text.Text += "Y";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "Y";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };

            buttonZ.Click += delegate {
                if (temp[val] == 'Z')
                {
                    text.Text += "Z";
                    val++;
                    text.SetSelection(val);
                    if (val == 1)
                    {
                        stopWatch.Start();
                    }
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                }
                else
                {
                    S[track, val] += "Z";
                    textcw.Text = "Wrong!";
                    textcw.SetTextColor(Color.Crimson);
                }
                if (val == temp.Length)
                {
                    textcw.Text = "Correct!";
                    textcw.SetTextColor(Color.SeaGreen);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    string body = elapsedTime;
                    body += "\n\n\n";
                    body += ComputeMistake();
                    body += "\n\n" + len.ToString();
                    string username = textname.Text + ": " + (track + 1).ToString();
                    emailMessenger.SendEmail("tahmid26.iut@gmail.com", username, textmain.Text + "\n\n" + body);
                    Toast.MakeText(ApplicationContext, elapsedTime, ToastLength.Long).Show();
                    Reset();
                    text.Text = "";
                }
            };
        }


    }
}