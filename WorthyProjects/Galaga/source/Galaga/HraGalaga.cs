using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Galaga
{
    class HraGalaga
    {
        int maxMeteoritov;
        int maxX;
        int maxY;
        int score;
        int Xscore = 50;
        int maxScore = 0;
        const string heslo = "ga1ei2lfn438ai7gsg90sgs";
        public HraGalaga(int MaxMeteoritov=20, int maxX=81, int maxY=21)
        {

            this.maxMeteoritov = MaxMeteoritov;
            this.maxX = maxX;
            this.maxY = maxY;
            score = 0;
        }
        private void UlozenieMaxScore(int maxScore)
        {
            string skore = Convert.ToString(maxScore);
            skore = EncryptStringSample.StringCipher.Encrypt(skore, heslo);
            System.IO.File.WriteAllText(@"maxScore.txt", skore);


        }
        private void NacitajMaxscore()
        {
            try
            {
                string ZakodovaneSkore = System.IO.File.ReadAllText(@"maxScore.txt");
                string PrelozeneSkore = EncryptStringSample.StringCipher.Decrypt(ZakodovaneSkore, heslo);
                maxScore = Convert.ToInt32(PrelozeneSkore);
            }
            catch {}
        }
        private void NakresliRamik()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int u = 0; u < maxX ; u++)
            {

                Console.Write(" ");
            }

            for (int o = 0; o < maxY -2; o++)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                for (int p = 0; p < maxX - 2; p++)
                {
                    Console.Write(" ");


                }
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int u = 0; u < maxX; u++)
            {
                Console.SetCursorPosition(u , maxY - 1);
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void ZaverecnaObrazovka()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(maxX / 2 - 2, maxY / 2 + 2);
            Console.Write("SCORE: " + score);
            Console.Write("        ");
            Console.WriteLine("HIGH SCORE: " + maxScore);
            int najScore = score;
            Console.SetCursorPosition(maxX / 2 - 2, maxY / 2 + 3);
            if (najScore > maxScore)
            {
                Console.Write("Prekonal si najvyššie skóre o " + (najScore - maxScore));
                UlozenieMaxScore(najScore);
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(maxX / 2 - 2, maxY / 2);
            Console.Write("BOOM!");
            SoundPlayer simpleSound = new SoundPlayer(@"Bomb.wav");
            simpleSound.Play();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Hra()
        {
            SoundPlayer music = new SoundPlayer(@"music.wav");
            music.PlayLooping();
            NacitajMaxscore();
            int pocetZnakovNsmrtelnosti = 0;
            bool nesmrtelnost = false;
            int pridaneScore = 0;
            int odcitanieRychlosti = 0;
            int pocetZadanychZnakov = 0;
            NakresliRamik();
            DateTime casZaciatkuHry = DateTime.Now;
            Random r = new Random();

            Raketaa m = new Raketaa(maxY - 2, maxX + 1);
            List<Meteorit> meteority = new List<Meteorit>();
            // urobi 5 meteoritov
            for (int a = 0; a < 5; a++)
            {
                Meteorit.TypMeteoritu typMeteoritu;
                typMeteoritu = (Meteorit.TypMeteoritu)r.Next(1, 4);

                meteority.Add(new Meteorit(r.Next(1, maxX -1), maxY, typMeteoritu ));
            }

            bool koniec = false;
            while (!koniec)
            {
                if (pocetZnakovNsmrtelnosti == 3)
                {
                    nesmrtelnost = true;
                    pocetZnakovNsmrtelnosti = 0;
                }
                if (pocetZadanychZnakov == 3)
                {
                    pridaneScore = 0;
                    //odcitanieRychlosti = pridaneScore;
                }
                DateTime aktualnyCas = DateTime.Now;
                TimeSpan rozdielCasov = aktualnyCas - casZaciatkuHry;
                score = Convert.ToInt32(rozdielCasov.TotalSeconds) + pridaneScore;
                Console.SetCursorPosition(0, 0);

                Console.Write("SCORE: " + score);
                int najScore = maxScore;
                if (score > maxScore)
                    najScore = score;
                Console.Write("       HIGH SCORE: " + najScore);
                    
                // vytvori novi meteorit ak neni plny pocet meteoritov
                if ((r.Next(0, 20) < 12) && (meteority.Count < maxMeteoritov))
                {
                    Meteorit.TypMeteoritu typMeteoritu;
                    typMeteoritu = (Meteorit.TypMeteoritu)r.Next(1, 4);
                    meteority.Add(new Meteorit(r.Next(1, maxX - 1), maxY, typMeteoritu));
                }

                // posuvaju sa meteority
                for (int p = 0; p < meteority.Count; p++)
                {
                    bool posun = meteority[p].Posun();
                    if (!posun)
                    {
                        //zisti ci je buracka, ak ano tak sa zobrazi zaverecna obrazovka a nastavi sa priznak ukoncenia
                        if (m.JeBuracka(meteority[p].X))
                        {
                            if (!nesmrtelnost)
                            {
                                koniec = true;
                                ZaverecnaObrazovka();
                                System.Threading.Thread.Sleep(4000);
                                break;
                            }
                        }
                        //zmaze meteorit ked sa uz nemoze posunut
                        meteority.RemoveAt(p);
                    }
                }
           /*     if (score == 50)
                {
                    zrychlenie = zrychlenie + 10;
                }*/
                //spomaluje program
                int spomalenie = 10000 - (score - odcitanieRychlosti) * 75;
                if (spomalenie < 500)
                {
                    spomalenie = 500;
                }
                for (int u = 0; u < spomalenie; u++)
                {
                    // ak je stlacena klavesa tak sa rozoznava ci to je sipka do prava,do lava a ine ak je dolava tak sa raketa posunie do lava a ak sa stalci sipka doprava tak sa raketa posunie do prava
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.RightArrow:
                                m.PosunVpravo();
                                break;
                            case ConsoleKey.LeftArrow:
                                m.PosunVlavo();
                                break;
                            case ConsoleKey.D:
                                m.PosunVpravo();
                                break;
                            case ConsoleKey.A:
                                m.PosunVlavo();
                                break;
                            case ConsoleKey.S:
                                pridaneScore += 50;
                                break;
                            case ConsoleKey.Q:
                                koniec = true;
                                break;
                            case ConsoleKey.F:
                                if (pocetZadanychZnakov == 0)
                                {
                                    pocetZadanychZnakov = pocetZadanychZnakov + 1;
                                }
                                break;
                            case ConsoleKey.K:
                                if (pocetZadanychZnakov == 1)
                                {
                                    pocetZadanychZnakov = pocetZadanychZnakov + 1;
                                }
                                break;
                            case ConsoleKey.I:
                                if (pocetZadanychZnakov == 2)
                                {
                                    pridaneScore += 50;
                                }
                                break;
                            case ConsoleKey.H:
                                if (pocetZnakovNsmrtelnosti == 0)
                                {
                                    pocetZnakovNsmrtelnosti = pocetZnakovNsmrtelnosti +1;
                                }
                                break;

                            case ConsoleKey.P:
                                if (pocetZnakovNsmrtelnosti == 1)
                                {
                                    pocetZnakovNsmrtelnosti = pocetZnakovNsmrtelnosti + 1;
                                }
                                break;

                            case ConsoleKey.O:
                                if (pocetZnakovNsmrtelnosti == 2)
                                {  
                                    pocetZnakovNsmrtelnosti = pocetZnakovNsmrtelnosti + 1;
                                }
                                break;
                            case ConsoleKey.G:                                                                
                                    nesmrtelnost = false;
                                break;
                            default:
                                pocetZadanychZnakov = 0;
                                pocetZnakovNsmrtelnosti = 0;
                                break;
                        }
                    }
                }


            }
            
        }
    }
}
