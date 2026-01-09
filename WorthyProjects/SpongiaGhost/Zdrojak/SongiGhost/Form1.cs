using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SongiGhost
{
    public partial class Form1 : Form
    {
        bool doprava;
        bool dolava;

        bool prehral;

        bool spustenaHra = false;        
                
        List<PictureBox> poschodia = new List<PictureBox>();
        List<PictureBox> duchovia = new List<PictureBox>();

        DateTime casZaciatkuHry;

        Label l = new Label();
        Label ovladanie = new Label();
        Label gameOVER = new Label();
        Label tryAgain = new Label();
        Label score = new Label();
        Label maxScore = new Label();

        int najvyssiePoschodie = 0;
        int vyskaPoschodia = 150;
        int poschodie;
        int ScoreC;
        int maxScoreC;
        int dlkaListu;

        Image duchPrava;
        Image duchLava;

        private void padnutie()
        {

            hrac.Location = new Point(hrac.Location.X, hrac.Location.Y + vyskaPoschodia);
            poschodie--;
        
        }

        private bool stojiNaDoske()
        {
            
            if (poschodie == 0)
                return true;


            dlkaListu = poschodia.Count();
            for (int i = 0; i < dlkaListu; i++)
            {

                if (hrac.Location.Y + hrac.Size.Height == poschodia[i].Location.Y)
                {

                    if (hrac.Location.X + hrac.Size.Width * 0.8 > poschodia[i].Location.X && hrac.Location.X - hrac.Size.Width * 0.2 < poschodia[i].Location.X + poschodia[i].Size.Width)
                    {
                        return true;
                    } 

                }
            }
            return false;
        }

        private bool dotykaSaDucha()
        {

            int dlkaListu = duchovia.Count();
            for (int i = 0; i < dlkaListu; i++)
            {
                int vSebeX = 15;
                int vSebeY = 10;

//                if ((hrac.Location.Y + hrac.Size.Height > duchovia[i].Location.Y &&
//                   hrac.Location.Y + hrac.Size.Height <= duchovia[i].Location.Y + duchovia[i].Size.Height) ||
//                   (hrac.Location.Y > duchovia[i].Location.Y &&
//                   hrac.Location.Y <= duchovia[i].Location.Y + duchovia[i].Size.Height))
                if ((hrac.Location.Y + hrac.Size.Height > duchovia[i].Location.Y  + vSebeY &&
                   hrac.Location.Y + hrac.Size.Height <= duchovia[i].Location.Y + duchovia[i].Size.Height) ||
                   (hrac.Location.Y > duchovia[i].Location.Y &&
                   hrac.Location.Y <= duchovia[i].Location.Y + duchovia[i].Size.Height - vSebeY))
                {

                    if ((hrac.Location.X + hrac.Size.Width > duchovia[i].Location.X + vSebeX &&
                       hrac.Location.X + hrac.Size.Width <= duchovia[i].Location.X + duchovia[i].Size.Width) ||
                       (hrac.Location.X > duchovia[i].Location.X &&
                       hrac.Location.X <= duchovia[i].Location.X + duchovia[i].Size.Width - vSebeX))

/*                        if ((hrac.Location.X + hrac.Size.Width > duchovia[i].Location.X &&
                           hrac.Location.X + hrac.Size.Width <= duchovia[i].Location.X + duchovia[i].Size.Width) ||
                           (hrac.Location.X > duchovia[i].Location.X &&
                           hrac.Location.X <= duchovia[i].Location.X + duchovia[i].Size.Width))  */
                    {
                        try
                        {
                            SoundPlayer simpleSound = new SoundPlayer(@"duchovzvuk.wav");
                            simpleSound.Play();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error ocured. " + ex.Message);
                            Close();
                        }

                        return true;

                    }

                }
            }
            return false;       
        }

        public Form1()
        {

            InitializeComponent();

            duchLava = null;
            duchPrava = null;


        }

        private void plosiny()
        {

            Image image = null;

            try
            {
                image = Image.FromFile("stena2.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.Message + " can't be read.");
                Close();
            }
            int Y = 150;
            int X = 150;
            int vyska = panel.Size.Height;
            int dlzka = panel.Size.Width;
            int prebehlo = 0;
            while (vyska - Y > 150 * 2)
            {
                int y = panel.Size.Height - podlaha.Size.Height * 2 - Y;
                while (dlzka - X > 150)
                {
                    PictureBox p = new PictureBox();
                    p.Size = new Size(150, 50);
                    if (prebehlo == 1)
                    {
                        p.Location = new Point(X + 150, y);                        
                    }
                    else
                    {
                        p.Location = new Point(X, y);                        
                    }
                    p.Image = image;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (p.Location.X < dlzka - 150)
                    {
                        panel.Controls.Add(p);
                        poschodia.Add(p);
                    }

                    X += 300;
                }               
                prebehlo++;
                X = 150;
                najvyssiePoschodie++;
                Y += vyskaPoschodia;
                
                if (prebehlo == 2)
                    prebehlo = 0;                

            }            

        }

        private PictureBox hrac;

        private void panacik()
        {

            Image image = null;

            try
            {
                image = Image.FromFile("postava.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.Message + " can't be read.");
                Close();
            }
            hrac = new PictureBox();
            hrac.Size = new Size(75, 100);
            hrac.Location = new Point(panel.Size.Width / 2, panel.Size.Height - podlaha.Size.Height * 2 - hrac.Size.Height);
            hrac.Image = image;
            hrac.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(hrac);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DUCH.Stop();            
            pohyb_ducha.Stop();

            try
            {
                duchPrava = Image.FromFile("duch.png");
                duchLava = Image.FromFile("duch.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.Message + " can't be read.");
                Close();
            }

            duchLava.RotateFlip(RotateFlipType.Rotate180FlipY);


            l.Text = "PRESS 'ENTER' KEY TO START";            
            l.AutoSize = true;
            l.Font = new Font("Ravie" , 20);
            panel.Controls.Add(l);
            l.Location = new Point(panel.Size.Width / 2 - l.Size.Width / 2, panel.Size.Height / 2);
            
            ovladanie.Text = "\nA / < : MOVE LEFT    W / ^ / spacebar : JUMP    D / > : MOVE RIGHT";         
            ovladanie.Font = new Font("Ravie", 20);
            ovladanie.AutoSize = true;
            panel.Controls.Add(ovladanie);
            ovladanie.Location = new Point(panel.Size.Width / 2 - ovladanie.Size.Width / 2, panel.Size.Height / 2);
            try
            {

                string cislo = System.IO.File.ReadAllText(@"skore.txt");
                maxScoreC = Convert.ToInt32(cislo);                

            }
            catch
            {

                maxScoreC = 0;

            }

        }

        private void urobPodlahu()
        {
            //----------Z DIZAJNERA

            this.podlaha = new System.Windows.Forms.PictureBox();
            this.podlaha.Name = "podlaha";
//            this.podlaha.Location = new System.Drawing.Point(0, 617);
  //          this.podlaha.Size = new System.Drawing.Size(1284, 34);
            this.podlaha.Location = new System.Drawing.Point(0, panel.Size.Height-34 * 2);
            this.podlaha.Size = new System.Drawing.Size(panel.Size.Width, 34);
            this.podlaha.TabIndex = 0;
            this.podlaha.TabStop = false;

            //-------------MOJE
            try
            {
                Image image = Image.FromFile("stena3.png");
                podlaha.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.Message + " can't be read.");
                Close();
            }
            
            
            podlaha.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(podlaha);
//            this.podlaha.Dock = System.Windows.Forms.DockStyle.Bottom;
        }

        private void ulozSkore()
        {

            if (maxScoreC < ScoreC)
            {

                TextWriter txt = new StreamWriter("skore.txt");
                txt.Write(ScoreC);
                txt.Close();

            }
        
        }

        private void Score()
        {

            DateTime aktualnyCas = DateTime.Now;
            TimeSpan rozdielCasov = aktualnyCas - casZaciatkuHry;
            ScoreC = Convert.ToInt32(rozdielCasov.TotalSeconds);
            score.Text = "SCORE : " + ScoreC.ToString();
            score.Font = new Font("Ravie", 20);

            maxScore.Text = "   HIGHEST SCORE : " + maxScoreC;
            maxScore.Font = new Font("Ravie", 20);
            
        }

        private void HRA()
        {

            casZaciatkuHry = DateTime.Now;
            Image image = null;
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@"ghost02.wav");
                simpleSound.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured. " + ex.Message);
                Close();
            }            

            panel.BackgroundImage = image;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            poschodie = 0;

            urobPodlahu();
            plosiny();            
            
            panacik();
            
            urobDucha();

            l.Hide();
            ovladanie.Hide();

            Score();

            score.AutoSize = true;
            score.Location = new Point(0, 0);
            score.ForeColor = Color.White;            
            panel.Controls.Add(score);

            maxScore.AutoSize = true;
            maxScore.Location = new Point(0 + score.Size.Width + maxScore.Size.Width, 0);
            maxScore.ForeColor = Color.White;
            panel.Controls.Add(maxScore);

            DUCH.Start();
            pohyb_ducha.Start();

            spustenaHra = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (spustenaHra)
            {

                Image image = null;

                try
                {
                    image = Image.FromFile("postava.png");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocured " + ex.Message + " can't be read.");
                    Close();
                }

                switch (e.KeyCode)
                {
                        
                    case Keys.A:
                    case Keys.Left:
                        pohyb.Start();
                        dolava = true;
                        doprava = false;                        
                        image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        hrac.Image = image;
                        hrac.SizeMode = PictureBoxSizeMode.StretchImage;

                        break;

                        

                    case Keys.D:
                    case Keys.Right:
                        pohyb.Start();
                        dolava = false;
                        doprava = true;                        
                        hrac.Image = image;
                        hrac.SizeMode = PictureBoxSizeMode.StretchImage;

                        break;

                    case Keys.Space:
                    case Keys.W:
                    case Keys.Up:
                        if (poschodie != najvyssiePoschodie)
                        {
                            hrac.Location = new Point(hrac.Location.X, hrac.Location.Y - vyskaPoschodia);
                            poschodie++;
                            bool stoji = stojiNaDoske();

                            if (!stoji)
                            {
                                padnutie();
                            }

                        }

                        break;
                }

            }
            else
            {

                if (e.KeyCode == Keys.Q)
                {

                    Close();
                
                }

                if (e.KeyCode == Keys.Enter)
                {

                    DUCH.Stop();                    
                    pohyb_ducha.Stop();

                    panel.Controls.Clear();

                    duchovia.Clear();
                    poschodia.Clear();                    

                    HRA();


                }

            }

        }

        private void pohyb_Tick(object sender, EventArgs e)
        {

            if (doprava && hrac.Location.X  + hrac.Size.Width != panel.Size.Width)
            {

                hrac.Location = new Point(hrac.Location.X + 5, hrac.Location.Y);                

                bool stoji = stojiNaDoske();

                if (!stoji)
                    padnutie();

            }



            if (dolava && hrac.Location.X  != 0)
            {

                hrac.Location = new Point(hrac.Location.X - 5, hrac.Location.Y);

                bool stoji = stojiNaDoske();                

                if (!stoji)
                    padnutie();

            }
            
                

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode) 
            {
                case Keys.A:
                case Keys.Left:     
                    dolava = false;
                    
                    break;

                case Keys.D:
                case Keys.Right:
                    doprava = false;
                    
                    break;
            }            
            
        }

        private void urobDucha()
        {            

            PictureBox d = new PictureBox();
            d.Size = new Size(75, 100);

            Random r = new Random();
            int nahodne = r.Next(4);

            if (nahodne == 0)
            {
                d.Location = new Point(panel.Location.X, panel.Size.Height / 2 + panel.Size.Height / 4 - podlaha.Size.Height * 2);                
            }

            if (nahodne == 1)
            {
                d.Location = new Point(panel.Location.X, panel.Size.Height / 4 - podlaha.Size.Height * 2);                
            }

            if (nahodne == 2)
            {
                d.Location = new Point(panel.Size.Width - d.Size.Width, panel.Size.Height / 2 + panel.Size.Height / 4 - podlaha.Size.Height * 2);
            }

            if (nahodne == 3)
            {
                d.Location = new Point(panel.Size.Width - d.Size.Width, panel.Size.Height / 4 - podlaha.Size.Height * 2);                
            }
           
            d.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(d);

            d.BackColor = Color.Transparent;

            duchovia.Add(d);
            for (int i = 0; i < dlkaListu; i++)
            {

                poschodia[i].BringToFront();

            }
        }

        private void DUCH_Tick(object sender, EventArgs e)
        {

            urobDucha();                        

        }

        private void Koniec()
        {

            dolava = false;
            doprava = false;

            DUCH.Stop();            
            pohyb_ducha.Stop();

            gameOVER.Text = "GAME OVER";            
            gameOVER.AutoSize = true;
            gameOVER.Font = new Font("Ravie", 20);
            panel.Controls.Add(gameOVER);            
            gameOVER.BringToFront();
            gameOVER.Location = new Point(panel.Size.Width / 2 - gameOVER.Size.Width / 2, panel.Size.Height / 2); 

            tryAgain.Text = "PRESS 'ENTER' KEY TO TRY AGAIN OR 'Q' TO EXIT";
            tryAgain.Font = new Font("Ravie", 20);
            tryAgain.AutoSize = true;
            panel.Controls.Add(tryAgain);             
            tryAgain.BringToFront();
            tryAgain.Location = new Point(panel.Size.Width / 2 - tryAgain.Size.Width / 2, panel.Size.Height / 2+gameOVER.Size.Height);

            spustenaHra = false;            

        }

        Random r = new Random();
        private void pohyb_ducha_Tick(object sender, EventArgs e)
        {            

            pohyb_ducha.Stop();

            Image image = null;

            try
            {
                image = Image.FromFile("duch.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.Message + " can't be read.");
                Close();
            }

            Score();            

            int dlkaListu = duchovia.Count();

            for (int i = 0; i < dlkaListu; i++)
            {

                int posunX = r.Next(1, 7);
                int posunY = r.Next(1, 5);
                if (r.Next(1, 30) > 28)
                {
                    posunX = -posunX;
                    posunY = -posunY;
                }

                int duchX = duchovia[i].Location.X, duchY = duchovia[i].Location.Y;
                if (duchovia[i].Location.X > hrac.Location.X)
                {

                    duchX -= posunX;
                    if (duchovia[i].Image != duchLava)
                        duchovia[i].Image = duchLava;

                }

                if (duchovia[i].Location.X < hrac.Location.X)
                {

                    duchX += posunX;
                    if (duchovia[i].Image != duchPrava)
                        duchovia[i].Image = duchPrava;

                }

                if (duchovia[i].Location.Y > hrac.Location.Y)
                {
                    
                    duchY -= posunY;

                }

                if (duchovia[i].Location.Y < hrac.Location.Y)
                {
                    
                    duchY += posunY;

                }


                bool posuvaSa = true;

                for (int a = 0; a < dlkaListu; a++)
                {
                    if (i != a)
                    {
                        if ((duchY + duchovia[i].Size.Height > duchovia[a].Location.Y + 10 &&
                       duchY + duchovia[i].Size.Height <= duchovia[a].Location.Y + duchovia[a].Size.Height) ||
                       (duchY > duchovia[a].Location.Y &&
                       duchY <= duchovia[a].Location.Y + duchovia[a].Size.Height - 10))
                        {

                            if ((duchX + duchovia[i].Size.Width > duchovia[a].Location.X + 10 &&
                           duchX + duchovia[i].Size.Width <= duchovia[a].Location.X + duchovia[i].Size.Width) ||
                           (duchX > duchovia[a].Location.X &&
                           duchX <= duchovia[a].Location.X + duchovia[a].Size.Width - 10))
                            {
                                posuvaSa = false;
                            }

                        }
                    }
                }
                if (posuvaSa)
                    duchovia[i].Location = new Point(duchX, duchY);

                 prehral = dotykaSaDucha();

                 if (prehral)
                 {
                     ulozSkore();
                     Koniec();
                     return;
                 }                

             }
            pohyb_ducha.Start();

         }

     }

}

