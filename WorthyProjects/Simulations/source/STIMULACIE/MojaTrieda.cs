using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace STIMULACIE
{
    class MojaTrieda
    {
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;
        Random rand = new Random();
        
        public void Start()
        {


            Thread.Sleep(5000);

            do
            {
                while (!Console.KeyAvailable)
                {
                    typ2();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        private void typ2()
        {
 

            string klavesy = "ad"; 

                    //                    StlacKlavesy(klavesy);
                    StlacKlavesy(klavesy);
            
                    DrzKlavesu(Keys.M, 0.50F, false);
                    StlacKlavesy(klavesy);
                    if (rand.Next(1, 3) == 2)
                    {
                        int x = rand.Next(2, 5);

                        DrzKlavesu(Keys.Space, x);
                        
                    }

                    /*nazov servera : gameteam , heslo : /login marektt 
                    potom ked budes mat vruke kompas tak klikni prvaym
                     tam najdes nieco s napisom prison na to klikni lavym a uz si tam
                     */


        }
        private void typ1()
        {
  

                    //                    StlacKlavesy(klavesy);
                    DrzKlavesu(Keys.A, 2);
                    DrzKlavesu(Keys.S, 3);
                    if (rand.Next(1, 3) == 2)
                    {
                        int x = rand.Next(2, 5);

                        DrzKlavesu(Keys.A, x);
                        DrzKlavesu(Keys.S, x);
                    }

                    /*nazov servera : gameteam , heslo : /login marektt 
                    potom ked budes mat vruke kompas tak klikni prvaym
                     tam najdes nieco s napisom prison na to klikni lavym a uz si tam
                     */
                    DrzKlavesu(Keys.D, 2);
                    DrzKlavesu(Keys.W, rand.Next(3,6));

                    Thread.Sleep(rand.Next(50, 100) * 10);
                    DrzKlavesu(Keys.M, 5);
                    Thread.Sleep(rand.Next(50, 100) * 10);
   

        }
        private void DrzKlavesu(System.Windows.Forms.Keys key, float seconds,bool GoFoward = true)
        {
            //            System.Windows.Forms.Keys key = Keys.M;
            Random r = new Random();
            DateTime t = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < t)
            {
                keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                Thread.Sleep(30);
                if (r.Next(1, 7) == 3)
                {
                    if (GoFoward == true)
                    {
                        keybd_event((byte)Keys.W, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                        Thread.Sleep(30);
                        keybd_event((byte)Keys.W, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                        Thread.Sleep(30);
                        keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                        Thread.Sleep(30);
                    }
                }
            }
            keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        private void StlacKlavesy(string klavesy)
        {

            foreach (char m in klavesy)
            {
                for (int i = 0; i < 12; i++)
                {
                    SendKeys.SendWait(m.ToString());
                    Thread.Sleep(100 + 10 * rand.Next(10));
                }
            }
        }
    }
}
