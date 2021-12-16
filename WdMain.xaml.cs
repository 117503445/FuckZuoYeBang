using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using TLib.Windows;
namespace FuckZuoYeBang
{
    /// <summary>
    /// WdMain.xaml 的交互逻辑
    /// </summary>
    public partial class WdMain : Window
    {
        int sleepMilliseconds = 500;
        dynamic jsonStr;
        int x1;
        int y1;
        int x2;
        int y2;
        int x3;
        int y3;
        public WdMain()
        {
            InitializeComponent();
            HotKey hotKey = new HotKey(ModifierKeys.Alt,Key.R);
            hotKey.HotKeyPressed += HotKey_HotKeyPressed;
            Timer.Interval = TimeSpan.FromMilliseconds(500);
            Timer.Tick += Timer_Tick;
            jsonStr = JValue.Parse(File.ReadAllText("config.json"));
            sleepMilliseconds = jsonStr.sleepMilliseconds;
            x1 = jsonStr.x1;
            x2 = jsonStr.x2;
            x3 = jsonStr.x3;
            y1 = jsonStr.y1;
            y2 = jsonStr.y2;
            y3 = jsonStr.y3;
        }

        private void HotKey_HotKeyPressed(HotKey obj)
        {
            Console.WriteLine("Hotkey");
            //Application.Current.Shutdown();
            BtnMain_Click(null, null);
            Console.WriteLine("Hotkey end");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

    
        }

        private DispatcherTimer Timer = new DispatcherTimer();
        private bool isFucking = false;
        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            isFucking = !isFucking;
            Console.WriteLine("status change to: "+isFucking);
            if (isFucking) {
                BtnMain.Content = "Fucking !!!";
                //Timer.Start();
                Dispatcher.Invoke(async ()=> {

                    while (isFucking)
                    {
                        Console.WriteLine("cur status is "+isFucking);
                        if (!isFucking) { break; }
                        Console.WriteLine(1);
                        Console.WriteLine(jsonStr.x1);
                        MouseSimulation.MoveTo(new System.Drawing.Point(x1, y1));//领取
                        Console.WriteLine(2);
                        MouseSimulation.Click(MouseButton.Left);
                        await Task.Delay(sleepMilliseconds);
                        //Thread.Sleep(sleepMilliseconds);

                        Console.WriteLine("cur status is " + isFucking);
                        if (!isFucking) { break; }
                        MouseSimulation.MoveTo(new System.Drawing.Point(x2, y2));//统计
                        MouseSimulation.Click(MouseButton.Left);
                        if (!isFucking) { break; }
                        await Task.Delay(sleepMilliseconds);
                        //Thread.Sleep(sleepMilliseconds);

                        Console.WriteLine("cur status is " + isFucking);
                        if (!isFucking) { break; }
                        MouseSimulation.MoveTo(new System.Drawing.Point(x3, y3));//题目解答
                        MouseSimulation.Click(MouseButton.Left);
                        if (!isFucking) { break; }
                        await Task.Delay(sleepMilliseconds);
                        //Thread.Sleep(sleepMilliseconds);


                    }
                });
                Console.WriteLine("invoke end");
            }
            else
            {
                BtnMain.Content = "Press me to fuck";
                //Timer.Stop();
            }
        }
    }
}
