using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace Captain_Claw
{
    public partial class Form1 : Form
    {
        //playlist
        //WMPLib.IWMPPlaylist playlist = player.playlistCollection.newPlaylist("NewPlaylist");
        //// Add files to playlist. You can make use of a loop to add multiple files
        //WMPLib.IWMPMedia fileMedia = player.newMedia(filePath);
        //playlist.appendItem(fileMedia);
        //player.currentPlaylist = playlist;
        //player.Ctlcontrols.play();
        WMPLib.WindowsMediaPlayer enemysounds = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer levelsound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer clawsound = new WMPLib.WindowsMediaPlayer();
        Pen p2 = new Pen(Color.HotPink,5);
        Random r = new Random();
        List<randomnums> randomidleofficer = new List<randomnums>();
        Font f1 = new Font("Droid Sans Mono", 40);
        Bitmap offimage;
        Bitmap winbg = new Bitmap("winbg.gif");
        Bitmap youwin = new Bitmap("youwin.png");
        Bitmap playagain = new Bitmap("playagain.png");
        Bitmap playagainhighlighted = new Bitmap("playagainhighlighted.png");
        Bitmap gameover = new Bitmap("gameover.png");
        Bitmap loseimage = new Bitmap("dead.png");
        Bitmap elevatorimage = new Bitmap("Level1\\ELEVATORS\\1.png");
        Bitmap startscreen = new Bitmap("claw_logo.png");
        Bitmap menubg = new Bitmap("Menuclaw1.png");
        Bitmap level1button = new Bitmap("Menu\\Select Level\\level1.png");
        Bitmap level2button = new Bitmap("Menu\\Select Level\\level2.png");
        Bitmap backbutton = new Bitmap("Menu\\Select Level\\back.png");
        Bitmap level1buttonhighlighted = new Bitmap("Menu\\Select Level\\level12.png");
        Bitmap level2buttonhighlighted = new Bitmap("Menu\\Select Level\\level22.png");
        Bitmap backbuttonhighlighted = new Bitmap("Menu\\Select Level\\back2.png");
        Bitmap playbutton = new Bitmap("Menu\\play.png");
        Bitmap selectlevel = new Bitmap("Menu\\selectlevel.png");
        Bitmap quitbutton = new Bitmap("Menu\\quit.png");
        Bitmap playbuttonhighlited = new Bitmap("Menu\\play2.png");
        Bitmap selectlevelhighlited = new Bitmap("Menu\\selectlevel2.png");
        Bitmap quitbuttonhighlited = new Bitmap("Menu\\quit2.png");
        Bitmap healthimg = new Bitmap("Level1\\HEALTH\\BREADWATER1.png");
        Bitmap level1bg = new Bitmap("Level1\\level1_backgroundd.jpg");
        Bitmap level2bg = new Bitmap("Level1\\level2_backgroundd.jpg");
        Bitmap bulletimage = new Bitmap("Level1\\bullet.png");
        Bitmap ladder1 = new Bitmap("Ladder1.jpg");
        Bitmap face = new Bitmap("face1.png");
        Bitmap scoreimg = new Bitmap("score.png");
        Bitmap clawdead = new Bitmap("Claw_Movements\\dead.png");
        Bitmap officerdead = new Bitmap("Level1\\OFFICER\\officerdead.png");
        Bitmap soldierdead = new Bitmap("Level2\\SOLDIER\\death.png");
        Timer t = new Timer();
        List<Bitmap> healthbarframes = new List<Bitmap>();
        List<Bitmap> clawframes = new List<Bitmap>();
        List<Bitmap> flippedclawframes = new List<Bitmap>();
        List<Bitmap> jumpframes = new List<Bitmap>();
        List<Bitmap> flippedjumpframes = new List<Bitmap>();
        List<Bitmap> standframes = new List<Bitmap>();
        List<Bitmap> flippedstandframes = new List<Bitmap>();
        List<Bitmap> kickframes = new List<Bitmap>();
        List<Bitmap> flippedkickframes = new List<Bitmap>();
        List<Bitmap> pistolframes = new List<Bitmap>();
        List<Bitmap> flippedpistolframes = new List<Bitmap>();
        List<Bitmap> punchframes = new List<Bitmap>();
        List<Bitmap> flippedpunchframes = new List<Bitmap>();
        List<Bitmap> swordframes = new List<Bitmap>();
        List<Bitmap> flippedswordframes = new List<Bitmap>();
        List<Bitmap> climbframes = new List<Bitmap>();
        List<Actor> Claw = new List<Actor>();
        List<elevator> elevatorr = new List<elevator>();
        List<Enemy1> Officer = new List<Enemy1>();
        List<Bitmap> officerframes = new List<Bitmap>();
        List<Bitmap> flippedofficerframes = new List<Bitmap>();
        List<Bitmap> officeridleframes = new List<Bitmap>();
        List<Bitmap> flippedofficeridleframes = new List<Bitmap>();
        List<Bitmap> officerswordframes = new List<Bitmap>();
        List<Bitmap> flippedofficerswordframes = new List<Bitmap>();
        List<Bitmap> door1 = new List<Bitmap>();
        List<Bitmap> coinframes = new List<Bitmap>();
        List<Bitmap> loadinglevel1frames = new List<Bitmap>();
        List<Bitmap> loadinglevel2frames = new List<Bitmap>();
        List<coins> co = new List<coins>();
        List<health> heal = new List<health>();

        List<Enemy2> Soldier = new List<Enemy2>();
        List<Bitmap> soldierframes = new List<Bitmap>();
        List<Bitmap> flippedsoldierframes = new List<Bitmap>();
        List<Bitmap> soldieridleframes = new List<Bitmap>();
        List<Bitmap> flippedsoldieridleframes = new List<Bitmap>();
        List<Bitmap> soldiergunframes = new List<Bitmap>();
        List<Bitmap> flippedsoldiergunframes = new List<Bitmap>();

        int level = -1;
        int clawdirection = 1, stand = 1, bgx = 0, bgy = 0, bgcutx = 6, bgcuty = 320, flagjump = 0, jumpagain = 1, ctjump = 0, ijump = 0, floor1 = 620, falling = 0,floor1temp=620,floor2temp=300;
        int countidle = 0, countkick = 0, countpistol = 0, countpunch = 0, countsword = 0,temp=0,floor2=300, ladder1x = 0, ladder1y = 0, countofficer=0,healthbarwidth=106, healthbarheight=10;
        int enemynotice = 20,score=0,doorx=100,doory=90,counterhealth=0,counterselectlevel=0;
        int enemy2notice = 350;
        bool kick = false,pistol=false,punch=false,sword=false,climbup= false,climbdown = false,openthedoor=false,levelcounter=false,laserright=false,laserleft=false;
        int xgroup1 = 400, ygroup1 = 620, xgroup2 = 1000, ygroup2 = 100, laserrangex = 0,laserrangey=0;
        int playx=650, playy=370, selectlevelx= 650, selectlevely=490, quitx= 650, quity=610;
        int level1x = 650, level1y = 370, level2x = 650, level2y = 490, backx = 650, backy = 610;
        int countlogoscreen = 0,countloadinglevel1=0,countloadinglevel2=0, indexloadinglevel1=0, indexloadinglevel2=0, hightlight=0,highlight2=0,cterror=0;
        float logoopacity = 100, playagain1x = 900, playagain1y = 500, playagain2x = 560, playagain2y = 700, highlightplayagain = 0, cterror2 = 0;

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.Paint += Form1_Paint1;
            this.Load += Form1_Load1;
            this.WindowState = FormWindowState.Maximized;
            t.Tick += T_Tick;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseClick += Form1_MouseClick;
            this.KeyUp += Form1_KeyUp;
            this.KeyPress += Form1_KeyPress;
            this.KeyDown += Form1_KeyDown;
            t.Start();
            t.Interval = 1000 / 60;
            levelsound.URL = "ClawSounds\\Title.mp3";
            levelsound.controls.play();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (level == 6)
            {
                if (e.X >= playagain2x && e.X <= playagain2x + playagain.Width)
                {
                    if (e.Y >= playagain2y && e.Y <= playagain2y + playagain.Height)
                    {
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
            if (level == 7)
            {
                if (e.X >= playagain1x && e.X <= playagain1x + playagain.Width)
                {
                    if (e.Y >= playagain1y && e.Y <= playagain1y + playagain.Height)
                    {
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
        }

        public static Bitmap ChangeOpacity(Image img, float opacityvalue)//opacity function for the logo
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (level == 0)
            {
                if (e.X >= quitx && e.X <= quitx + quitbutton.Width)
                {
                    if (e.Y >= quity && e.Y <= quity + quitbutton.Height)
                    {
                        System.Windows.Forms.Application.Exit();
                        System.Environment.Exit(1);
                    }
                }
                if (e.X >= playx && e.X <= playx + playbutton.Width)
                {
                    if (e.Y >= playy && e.Y <= playy + playbutton.Height)
                    {
                        level = 2;
                    }
                }

                if (e.X >= selectlevelx && e.X <= selectlevelx + selectlevel.Width)
                {
                    if (e.Y >= selectlevely && e.Y <= selectlevely + selectlevel.Height)
                    {
                        level = 1;
                        levelcounter = true;
                    }
                }

                
            }
            if (level == 1)
            {
                if (counterselectlevel > 4)
                {
                    if (e.X >= level1x && e.X <= level1x + playbutton.Width)
                    {
                        if (e.Y >= level1y && e.Y <= level1y + playbutton.Height)
                        {
                            level = 2;
                        }
                    }

                    if (e.X >= level2x && e.X <= level2x + selectlevel.Width)
                    {
                        if (e.Y >= level2y && e.Y <= level2y + selectlevel.Height)
                        {
                            level = 4;
                        }
                    }

                    if (e.X >= backx && e.X <= backx + backbutton.Width)
                    {
                        if (e.Y >= backy && e.Y <= backy + backbutton.Height)
                        {
                            level = 0;
                            counterselectlevel = 0;
                            levelcounter = false;
                        }
                    }

                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (level == 6)
            {
                if (e.X >= playagain2x && e.X <= playagain2x + playagain.Width)
                {
                    if (e.Y >= playagain2y && e.Y <= playagain2y + playagain.Height)
                    {
                        highlightplayagain = 1;
                    }
                    else
                    {
                        highlightplayagain = 0;
                    }
                }
                else
                {
                    highlightplayagain = 0;
                }
            }
            if (level==7)
            {
                if (e.X >= playagain1x && e.X <= playagain1x + playagain.Width)
                {
                    if (e.Y >= playagain1y && e.Y <= playagain1y + playagain.Height)
                    {
                        highlightplayagain= 1;
                    }
                    else
                    {
                        highlightplayagain = 0;
                    }
                }
                else
                {
                    highlightplayagain = 0;
                }
            }
            if(levelcounter==true)
            {
                counterselectlevel++;
            }
            if (level == 0)
            {
                if (e.X >= playx && e.X <= playx + playbutton.Width)
                {
                    if (e.Y >= playy && e.Y <= playy + playbutton.Height)
                    {
                        hightlight = 1;
                    }
                }
                else
                {
                    hightlight = 0;
                }

                if (e.X >= selectlevelx && e.X <= selectlevelx + selectlevel.Width)
                {
                    if (e.Y >= selectlevely && e.Y <= selectlevely + selectlevel.Height)
                    {
                        hightlight = 2;
                    }
                }
                else
                {
                    hightlight = 0;
                }

                if (e.X >= quitx && e.X <= quitx + quitbutton.Width)
                {
                    if (e.Y >= quity && e.Y <= quity + quitbutton.Height)
                    {
                        hightlight = 3;
                    }
                }
                else
                {
                    hightlight = 0;
                }
            }
            if(level==1)
            {
                if (e.X >= level1x && e.X <= level1x + playbutton.Width)
                {
                    if (e.Y >= level1y && e.Y <= level1y + playbutton.Height)
                    {
                        highlight2 = 1;
                    }
                }
                else
                {
                    highlight2 = 0;
                }

                if (e.X >= level2x && e.X <= level2x + selectlevel.Width)
                {
                    if (e.Y >= level2y && e.Y <= level2y + selectlevel.Height)
                    {
                        highlight2 = 2;
                    }
                }
                else
                {
                    highlight2 = 0;
                }

                if (e.X >= backx && e.X <= backx + quitbutton.Width)
                {
                    if (e.Y >= backy && e.Y <= backy + quitbutton.Height)
                    {
                        highlight2 = 3;
                    }
                }
                else
                {
                    highlight2 = 0;
                }
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(level==5)
            {
                laserright = false;
                laserleft = false;
                if(clawdirection==1)
                {
                    laserrangex = Claw[0].x + clawframes[0].Width + 25;
                    laserrangey = Claw[0].y + clawframes[0].Height / 4;
                }
                if (clawdirection == -1)
                {
                    laserrangex = Claw[0].x - clawframes[0].Width;
                    laserrangey = Claw[0].y + clawframes[0].Height / 4;
                }

            }
            if (level == 3 || level == 5 && clawframes.Count != 0)
            {
                if (flagjump == 0 && pistol == false)
                {
                    stand = 1;
                }
                Claw[0].indeximg = 0;
                Claw[0].indexjump = 0;
                Claw[0].indexidle = 0;
            }
        }
        public void gravity(int x, int y)
        {
            if (level == 3)
            {
                if (climbup == false && climbdown == false)
                {
                    if (y <= floor1)
                    {
                        falling = 1;
                        Claw[0].y += 3;
                        if (floor1 - y <= 15)
                        {
                            Claw[0].y = floor1;
                            jumpagain = 1;
                            falling = 0;
                        }
                    }
                }
            }
            if (level == 5)
            {
                if (Claw[0].iup == 0&& Claw[0].idown == 0)
                {
                    if (y <= floor1)
                    {
                        falling = 1;
                        Claw[0].y += 3;
                        if (floor1 - y <= 15)
                        {
                            Claw[0].y = floor1;
                            jumpagain = 1;
                            falling = 0;
                        }
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(level==5)
            {
                if(e.KeyCode==Keys.A)
                {
                    if(clawdirection==1)
                    {
                        laserrangex+=40;
                        laserright = true;
                    }
                    if(clawdirection==-1)
                    {
                        laserrangex-=40;
                        laserleft = true;
                    }
                   

                }
            }
            if (level == 3 || level == 5)
            {
                if (e.KeyCode == Keys.Up)//climb up
                {
                    if (level == 3)
                    {
                        if (climbdown == false)
                        {
                            if (Claw[0].x + 10 > ladder1x && Claw[0].x < ladder1x + ladder1.Width)
                            {
                                climbup = true;
                                flagjump = 0;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Down)//go down
                {
                    if (level == 3)
                    {
                        if (climbup == false)
                        {
                            if (Claw[0].x + 10 > ladder1x && Claw[0].x < ladder1x + ladder1.Width)
                            {
                                Claw[0].y += 110;
                                climbdown = true;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Right && flagjump == 0 && falling == 0&& Claw[0].iup == 0 && Claw[0].idown == 0)
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            //don't pass border right
                            if (Claw[0].x + clawframes[0].Width < this.ClientSize.Width)
                            {
                                if (level == 5)
                                {
                                    elevatorr[0].x -= 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {

                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x -= 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x -= 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x -= 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                {
                                    heal[i].x -= 4;
                                }

                                for (int i = 0; i < Officer.Count; i++)
                                {
                                    Officer[i].x -= 4;
                                }
                                for (int i = 0; i < co.Count; i++)
                                {
                                    co[i].x -= 4;
                                }
                                doorx -= 4;
                                ladder1x -= 4;//ladder position remains
                                stand = 0;
                                clawdirection = 1;
                                bgcutx += 4;
                                Claw[0].x += 4;
                                Claw[0].indeximg++;
                                if (Claw[0].indeximg == 10)
                                {
                                    Claw[0].indeximg = 0;
                                }
                            }
                            else
                            {
                                if(level==5)
                                {
                                    elevatorr[0].x += 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x += 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x += 4;
                                    }
                                }
                                
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x += 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                {
                                    heal[i].x += 4;
                                }
                                for (int i = 0; i < co.Count; i++)
                                {
                                    co[i].x += 4;
                                }
                                for (int i = 0; i < Officer.Count; i++)
                                {
                                    Officer[i].x += 4;
                                }
                                doorx += 4;
                                ladder1x += 4;
                                bgcutx -= 4;
                                Claw[0].x -= 4;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Left && flagjump == 0 && falling == 0&& Claw[0].iup == 0 && Claw[0].idown == 0)
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            //don't pass border left
                            if (Claw[0].x > bgx + clawframes[0].Width)
                            {
                                if (level == 5)
                                {
                                    elevatorr[0].x += 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x += 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x += 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x += 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                {
                                    heal[i].x += 4;
                                }
                                for (int i = 0; i < co.Count; i++)
                                {
                                    co[i].x += 4;
                                }
                                for (int i = 0; i < Officer.Count; i++)
                                {
                                    Officer[i].x += 4;
                                }
                                doorx += 4;
                                ladder1x += 4;
                                stand = 0;
                                clawdirection = -1;
                                bgcutx -= 4;
                                Claw[0].x -= 4;
                                Claw[0].indeximg++;
                                if (Claw[0].indeximg == 10)//reset frames
                                {
                                    Claw[0].indeximg = 0;
                                }
                            }
                            else
                            {
                                if (level == 5)
                                {
                                    elevatorr[0].x -= 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x -= 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x -= 4;
                                    }
                                }

                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x -= 4;
                                }
                                for (int i = 0; i < heal.Count; i++)
                                {
                                    heal[i].x -= 4;
                                }
                                for (int i = 0; i < co.Count; i++)
                                {
                                    co[i].x -= 4;
                                }
                                for (int i = 0; i < Officer.Count; i++)
                                {
                                    Officer[i].x -= 4;
                                }
                                doorx -= 4;
                                ladder1x -= 4;
                                bgcutx += 4;
                                Claw[0].x += 4;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Space && jumpagain == 1 && falling == 0)//while jumping
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            jumpagain = 0;
                            ijump++;
                            if (clawdirection == 1)//jump while looking right
                            {
                                if (Claw[0].x + clawframes[0].Width < this.ClientSize.Width)
                                {
                                    stand = 0;
                                    flagjump = 1;
                                }
                            }
                            if (clawdirection == -1)//jump while looking left
                            {
                                if (Claw[0].x > bgx + clawframes[0].Width)//don't pass border left
                                {
                                    stand = 0;
                                    flagjump = 1;
                                }
                            }
                        }
                    }
                }
                if (level == 5)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (Claw[0].x >= elevatorr[0].x && Claw[0].x <= elevatorr[0].x + elevatorimage.Width)
                        {
                            if (Claw[0].y + clawframes[0].Height >= elevatorr[0].y && Claw[0].y + clawframes[0].Height <= elevatorr[0].y + elevatorimage.Height)
                            {
                                Claw[0].y = elevatorr[0].y - clawframes[0].Height;
                                if (floor1 == floor1temp&&Claw[0].idown==0)
                                {
                                    Claw[0].iup = 1;
                                    floor1 = floor2temp;
                                    Claw[0].idown = 0;
                                }
                                
                                if (floor1 == floor2temp-clawframes[0].Height&&Claw[0].iup==0)
                                {
                                    Claw[0].idown = 1;
                                    floor1 = floor1temp;
                                    Claw[0].iup = 0;

                                }
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.C)//while kicking
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            kick = true;
                        }
                    }
                }
                if (e.KeyCode == Keys.Z)
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            punch = true;
                        }
                    }
                }
                if (e.KeyCode == Keys.X)
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            sword = true;
                        }
                    }
                }
                if (e.KeyCode == Keys.F)//while firing single bullet
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            bullets pnn = new bullets();
                            if (clawdirection == 1)
                            {
                                pnn.x = Claw[0].x + pistolframes[0].Width;
                                pnn.y = Claw[0].y + pistolframes[0].Height / 4;
                                pnn.dir = 1;
                            }
                            if (clawdirection == -1)
                            {
                                pnn.x = Claw[0].x - pistolframes[0].Width + bulletimage.Width + 40;
                                pnn.y = Claw[0].y + pistolframes[0].Height / 4;
                                pnn.dir = -1;
                            }
                            Claw[0].bullet.Add(pnn);
                            clawsound.URL = "ClawSounds\\GUNSHOT.WAV";
                            clawsound.controls.play();
                            pistol = true;
                        }
                    }
                }
                if (e.KeyCode == Keys.G)//while firing multi bullet
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            bullets pnn = new bullets();
                            bullets pnn2 = new bullets();

                            if (clawdirection == 1)
                            {
                                pnn.x = Claw[0].x + pistolframes[0].Width;
                                pnn.y = Claw[0].y + pistolframes[0].Height / 4;
                                pnn.dir = 1;
                                pnn2.x = Claw[0].x + pistolframes[0].Width - 10;
                                pnn2.y = Claw[0].y + pistolframes[0].Height / 4 - 15;
                                pnn2.dir = 1;
                            }
                            if (clawdirection == -1)
                            {
                                pnn.x = Claw[0].x - pistolframes[0].Width + bulletimage.Width + 40;
                                pnn.y = Claw[0].y + pistolframes[0].Height / 4;
                                pnn.dir = -1;
                                pnn2.x = Claw[0].x - pistolframes[0].Width + bulletimage.Width + 30;
                                pnn2.y = Claw[0].y + pistolframes[0].Height / 4 - 15;
                                pnn2.dir = -1;
                            }
                            Claw[0].bullet.Add(pnn);
                            Claw[0].bullet.Add(pnn2);
                            clawsound.URL = "ClawSounds\\GUNSHOT.WAV";
                            clawsound.controls.play();
                            clawsound.URL = "ClawSounds\\GUNSHOT.WAV";
                            clawsound.controls.play();
                            pistol = true;
                        }
                    }
                }
                if (e.KeyCode == Keys.O)//open the door
                {
                    if (level == 3 || level == 5)
                    {
                        if (Claw[0].death == 0)
                        {
                            if (Claw[0].x >= doorx && Claw[0].x <= doorx + door1[0].Width)
                            {
                                if (Claw[0].y >= doory && Claw[0].y <= doory + door1[0].Height)
                                {
                                    openthedoor = true;

                                }
                            }
                        }
                    }
                }
            }
        }
        public void addcoinslvl1()
        {
            /*--------------------------------------------------------------  Add coins For Level 1  --------------------------------------------------------------*/
            for (int i = 0; i < 10; i++)
            {
                coins coin = new coins();
                coin.x = xgroup1;
                coin.y = ygroup1;
                xgroup1 += 80;
                ygroup1 -= 10;
                co.Add(coin);
            }
            for (int i = 0; i < 15; i++)
            {
                coins coin = new coins();
                coin.x = xgroup2;
                coin.y = ygroup2;
                xgroup2 += 80;
                ygroup2 -= 5;
                co.Add(coin);
            }

        }
        public void addclaw()
        {
            /*--------------------------------------------------------------  Add Claw  --------------------------------------------------------------*/
            //Add Captain Claw
            Actor pnn = new Actor();
            pnn.x = 100;
            pnn.y = 620;
            pnn.indeximg = 0;
            pnn.indexjump = 0;
            pnn.indexidle = 0;
            pnn.indexkick = 0;
            Claw.Add(pnn);
            if (level == 3 || level == 5)
            {
                ladder1.MakeTransparent(Color.Black);
                ladder1x = bgcutx + level1bg.Width - (ladder1.Width * 4);
                ladder1y = Claw[0].y - ladder1.Height;
                /*--------------------------------------------------------------  Health Bar Frames  --------------------------------------------------------------*/
                for (int i = 1; i < 10; i++)
                {
                    Bitmap bim = new Bitmap("HealthBar\\" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    healthbarframes.Add(bim);
                }
                /*--------------------------------------------------------------  Claw Frames  --------------------------------------------------------------*/
                // captain claw movement frames 
                for (int i = 1; i < 11; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    clawframes.Add(bim);
                }
                // captain claw flipped movement frames 
                for (int i = 1; i < 11; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedclawframes.Add(bim);
                }
                // captain claw Jump frames
                for (int i = 1; i < 13; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "jump" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    jumpframes.Add(bim);
                }
                // captain claw flipped Jump frames
                for (int i = 1; i < 13; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "jump" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedjumpframes.Add(bim);
                }
                // captain claw Stand frames
                for (int i = 1; i < 9; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "idle" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    standframes.Add(bim);
                }
                // captain claw Flipped Standing frames
                for (int i = 1; i < 9; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "idle" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedstandframes.Add(bim);
                }
                // captain claw kick frames
                for (int i = 0; i < 5; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "kick" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    kickframes.Add(bim);
                }
                // captain claw Flipped kick frames
                for (int i = 0; i < 5; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "kick" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedkickframes.Add(bim);
                }
                // captain claw pistol frames
                for (int i = 1; i < 7; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "pistol" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    pistolframes.Add(bim);
                }
                // captain claw Flipped pistol frames
                for (int i = 1; i < 7; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "pistol" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedpistolframes.Add(bim);
                }
                // captain claw punch frames
                for (int i = 1; i < 5; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "punch" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    punchframes.Add(bim);
                }
                // captain claw punch pistol frames
                for (int i = 1; i < 5; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "punch" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedpunchframes.Add(bim);
                }
                // captain claw sword frames
                for (int i = 1; i < 6; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "sword" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    swordframes.Add(bim);
                }
                // captain claw Flipped sword frames
                for (int i = 1; i < 6; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "sword" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    flippedswordframes.Add(bim);
                }
                // captain claw Climb Ladder frames
                for (int i = 1; i < 14; i++)
                {
                    Bitmap bim = new Bitmap("Claw_Movements\\" + "climb" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    climbframes.Add(bim);
                }
            }
        }
        public void addofficers ()
        {
            if (level == 3)
            {
                /*--------------------------------------------------------------  Add Officers  --------------------------------------------------------------*/
                Enemy1 officer1 = new Enemy1();
                officer1.x = 300;
                officer1.y = 620;
                officer1.indexidle = 0;
                officer1.indeximgleft = 0;
                officer1.indeximgright = 0;
                officer1.dir = 1;
                Officer.Add(officer1);
                Enemy1 officer2 = new Enemy1();
                officer2.x = 350;
                officer2.y = 100;
                officer2.indexidle = 0;
                officer2.indeximgleft = 0;
                officer2.indeximgright = 0;
                officer2.dir = -1;
                Officer.Add(officer2);
                Enemy1 officer3 = new Enemy1();
                officer3.x = 700;
                officer3.y = 100;
                officer3.indexidle = 0;
                officer3.indeximgleft = 0;
                officer3.indeximgright = 0;
                officer3.dir = 1;
                Officer.Add(officer3);
                Enemy1 officer4 = new Enemy1();
                officer4.x = 2000;
                officer4.y = 100;
                officer4.indexidle = 0;
                officer4.indeximgleft = 0;
                officer4.indeximgright = 0;
                officer4.dir = 1;
                Officer.Add(officer4);
                Enemy1 officer5 = new Enemy1();
                officer5.x = 2000;
                officer5.y = 620;
                officer5.indexidle = 0;
                officer5.indeximgleft = 0;
                officer5.indeximgright = 0;
                officer5.dir = -1;
                Officer.Add(officer5);
                Enemy1 officer6 = new Enemy1();
                officer6.x = 1000;
                officer6.y = 620;
                officer6.indexidle = 0;
                officer6.indeximgleft = 0;
                officer6.indeximgright = 0;
                officer6.dir = -1;
                Officer.Add(officer6);
                Enemy1 officer7 = new Enemy1();
                officer7.x = 1300;
                officer7.y = 100;
                officer7.indexidle = 0;
                officer7.indeximgleft = 0;
                officer7.indeximgright = 0;
                officer7.dir = 1;
                Officer.Add(officer7);
                for (int i = 0; i < Officer.Count; i++)
                {
                    randomnums rn = new randomnums();
                    rn.num = r.Next(0, 300);
                    randomidleofficer.Add(rn);
                }
            }
        }
        public void addsoldiers()
        {
            if (level == 5)
            {
                /*--------------------------------------------------------------  Add Officers  --------------------------------------------------------------*/
                Enemy2 soldier1 = new Enemy2();
                soldier1.x = 300;
                soldier1.y = 620;
                soldier1.indexidle = 0;
                soldier1.indeximgleft = 0;
                soldier1.indeximgright = 0;
                soldier1.dir = 1;
                Soldier.Add(soldier1);
                Enemy2 soldier2 = new Enemy2();
                soldier2.x = 350;
                soldier2.y = 100;
                soldier2.indexidle = 0;
                soldier2.indeximgleft = 0;
                soldier2.indeximgright = 0;
                soldier2.dir = -1;
                Soldier.Add(soldier2);
                Enemy2 soldier3 = new Enemy2();
                soldier3.x = 700;
                soldier3.y = 100;
                soldier3.indexidle = 0;
                soldier3.indeximgleft = 0;
                soldier3.indeximgright = 0;
                soldier3.dir = 1;
                Soldier.Add(soldier3);
                Enemy2 soldier4 = new Enemy2();
                soldier4.x = 2000;
                soldier4.y = 100;
                soldier4.indexidle = 0;
                soldier4.indeximgleft = 0;
                soldier4.indeximgright = 0;
                soldier4.dir = 1;
                Soldier.Add(soldier4);
                Enemy2 soldier5 = new Enemy2();
                soldier5.x = 2000;
                soldier5.y = 620;
                soldier5.indexidle = 0;
                soldier5.indeximgleft = 0;
                soldier5.indeximgright = 0;
                soldier5.dir = -1;
                Soldier.Add(soldier5);
                Enemy2 soldier6 = new Enemy2();
                soldier6.x = 1000;
                soldier6.y = 620;
                soldier6.indexidle = 0;
                soldier6.indeximgleft = 0;
                soldier6.indeximgright = 0;
                soldier6.dir = -1;
                Soldier.Add(soldier6);
                Enemy2 soldier7 = new Enemy2();
                soldier7.x = 1300;
                soldier7.y = 100;
                soldier7.indexidle = 0;
                soldier7.indeximgleft = 0;
                soldier7.indeximgright = 0;
                soldier7.dir = 1;
                Soldier.Add(soldier7);
                for (int i = 0; i < Soldier.Count; i++)
                {
                    randomnums rn = new randomnums();
                    rn.num = r.Next(0, 300);
                    randomidleofficer.Add(rn);
                }
            }
        }
        public void addelevator()
        {
            elevator pnn = new elevator();
            pnn.x = 2500;
            pnn.y = 720;
            elevatorr.Add(pnn);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            if(level==6)
            {
                Cursor.Show();
                if (cterror2==0)
                {
                    Cursor.Show();
                    levelsound.URL = "ClawSounds\\win.mp3";
                    levelsound.controls.play();
                }
                cterror2++;
            }
            /*--------------------------------------------------------------  Laser Code  --------------------------------------------------------------*/
            if (laserright == true)
            {
                    for (int k = 0; k < Soldier.Count; k++)
                    {
                        if (Soldier[k].x > Claw[0].x)
                        {
                            if (laserrangex >= Soldier[k].x)
                            {
                                if (laserrangey >= Soldier[k].y && laserrangey <= Soldier[k].y + soldierframes[0].Height)
                                {
                                    laserrangex -= 40;
                                    Soldier[k].health -= 5;
                                if (Soldier[k].health <= 0)
                                {
                                    Soldier[k].deathcounter++;
                                    enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                    enemysounds.controls.play();
                                }
                            }
                            }
                        }
                    }
            }
            if (laserleft == true)
            { 
                    for (int k = 0; k < Soldier.Count; k++)
                    {
                        if (Soldier[k].x <= Claw[0].x)
                        {
                            if (laserrangex <= Soldier[k].x)
                            {
                                if (laserrangey >= Soldier[k].y && laserrangey <= Soldier[k].y + soldierframes[0].Height)
                                {
                                    laserrangex += 40;
                                    Soldier[k].health -= 5;
                                if (Soldier[k].health <= 0)
                                {
                                    Soldier[k].deathcounter++;
                                    enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                    enemysounds.controls.play();
                                }
                            }
                            }
                        }
                    }
            }
            /*--------------------------------------------------------------  Startscreen Code  --------------------------------------------------------------*/
            if (level==-1)
            {
                countlogoscreen++;
                float opacityvalue = float.Parse(logoopacity.ToString()) / 100;
                startscreen = ChangeOpacity(startscreen, opacityvalue);
                logoopacity -= float.Parse("0.1");
                if(countlogoscreen == 150)
                {
                    level = 0;
                    levelsound.URL = "ClawSounds\\menu.mp3";
                    levelsound.controls.play();
                }
            }
            if (level == 3 || level == 5&&clawframes.Count != 0)
            {
                countkick++;//count el sewar bta3 kick
                countidle++;//count el sewar bta3 idle
                countpistol++;//count el sewar bta3 pistol
                countpunch++;//count el sewar bta3 punch
                countsword++;//count el sewar bta3 sword
                countofficer++;//count el sewar bta3 officer kol kam sanya ye8ayar frame
                counterhealth++;//kol 2d 2eh ynzl health
            }
            /*--------------------------------------------------------------  Loading Level 1 --------------------------------------------------------------*/
            if(level==2)//loding screen for level1
            {
                countloadinglevel1++;//loading el frames bta3 loding screen
                if(countloadinglevel1%7==0)
                {
                    indexloadinglevel1++;
                }   
                if (indexloadinglevel1 == 4)
                {
                    indexloadinglevel1 = 0;
                }
                if (countloadinglevel1==150)
                {
                    level = 3;
                    levelsound.URL = "ClawSounds\\Level_1_Music_Remastered.mp3";
                    levelsound.controls.play();
                    Cursor.Hide();
                    addofficers();
                    addclaw();
                    addcoinslvl1();
                }
            }
            /*--------------------------------------------------------------  Loading Level 2 --------------------------------------------------------------*/
            if (level == 4)//loding screen for level1
            {
                countloadinglevel2++;//loading el frames bta3 loding screen
                if (countloadinglevel2 % 7 == 0)
                {
                    indexloadinglevel2++;
                }
                
                if (indexloadinglevel2 == 4)
                {
                    indexloadinglevel2 = 0;
                }
                if (countloadinglevel2 == 150)
                {
                    level = 5;
                    levelsound.URL = "ClawSounds\\The Battlements MP3 - Claw Original Soundtrack (1997) OST - Download Claw Original Soundtrack (1997) Soundtracks for FREE!.mp3";
                    levelsound.controls.play();
                    Cursor.Hide();
                    if (cterror == 0)
                    {
                        co.Clear();
                        Claw.Clear();
                        addsoldiers();
                        addclaw();
                        elevatorr.Clear();
                        addelevator();
                        floor2 = 300;
                        bgx = 0;
                        bgy = 0;
                        bgcutx = 6;
                        bgcuty = 320;
                        Claw[0].indexdoor = 0;
                        floor1 = 620;
                        floor2temp = 465;
                        doorx = 100;
                        doory = 90;
                        xgroup1 = 400;
                        ygroup1 = 620;
                        xgroup2 = 1000;
                        ygroup2 = 100;
                        addcoinslvl1();
                        if (clawdirection == 1)
                        {
                            laserrangex = Claw[0].x + clawframes[0].Width + 25;
                            laserrangey = Claw[0].y + clawframes[0].Height / 4;
                        }
                        if (clawdirection == -1)
                        {
                            laserrangex = Claw[0].x - clawframes[0].Width;
                            laserrangey = Claw[0].y + clawframes[0].Height / 4;
                        }

                    }
                    cterror++;
                }
            }
            /*--------------------------------------------------------------  Elevator Code  --------------------------------------------------------------*/
            //claw using elevator
            if (level == 5)
            { 
                ////////////////////////////////////////////////  moving the elevator    //////////////////////////////////////////////////////////////////
                if (Claw[0].iup==1)//uppppp
                {
                        elevatorr[0].y--;
                        bgcuty --;
                        doory ++;
                        Claw[0].y--;
                        for (int i = 0; i < Claw[0].bullet.Count; i++)
                        {
                            Claw[0].bullet[i].y ++;
                        }
                        for (int k = 0; k < Soldier.Count; k++)
                        {
                            Soldier[k].y ++;
                        }
                        for (int k = 0; k < Soldier.Count; k++)
                        {
                            for (int i = 0; i < Soldier[k].bullet.Count; i++)
                            {
                                Soldier[k].bullet[i].y ++;
                            }
                        }
                        for (int i = 0; i < heal.Count; i++)
                        {
                            heal[i].y ++;
                        }
                        for (int i = 0; i < Officer.Count; i++)
                        {
                            Officer[i].y++;
                        }
                        for (int i = 0; i < co.Count; i++)
                        {
                            co[i].y++;
                        }
                        if(elevatorr[0].y == floor2temp)
                        {
                            Claw[0].iup = 0;
                            Claw[0].idown = 0;
                            elevatorr[0].y = floor2temp;
                            Claw[0].y = elevatorr[0].y-clawframes[0].Height;
                            floor1 = elevatorr[0].y - clawframes[0].Height;
                        }
                    
                }
                if (Claw[0].idown==1)///down
                {
                    elevatorr[0].y++;
                    bgcuty++;
                    doory--;
                    Claw[0].y++;
                        for (int i = 0; i < Claw[0].bullet.Count; i++)
                        {
                            Claw[0].bullet[i].y --;
                        }
                        for (int k = 0; k < Soldier.Count; k++)
                        {
                            Soldier[k].y --;
                        }
                        for (int k = 0; k < Soldier.Count; k++)
                        {
                            for (int i = 0; i < Soldier[k].bullet.Count; i++)
                            {
                                Soldier[k].bullet[i].y --;
                            }
                        }
                        for (int i = 0; i < heal.Count; i++)
                        {
                            heal[i].y --;
                        }
                        for (int i = 0; i < Officer.Count; i++)
                        {
                            Officer[i].y --;
                        }
                        for (int i = 0; i < co.Count; i++)
                        {
                            co[i].y --;
                        }
                    if (elevatorr[0].y == floor1temp + clawframes[0].Height)
                    {
                        Claw[0].iup = 0;
                        Claw[0].idown = 0;
                        elevatorr[0].y = floor1temp + clawframes[0].Height;
                        Claw[0].y = elevatorr[0].y-clawframes[0].Height-5;
                        floor1 = elevatorr[0].y-clawframes[0].Height;
                    }
                }
            }
            /*--------------------------------------------------------------  Add Health  --------------------------------------------------------------*/
            if (level == 3 || level == 5 && clawframes.Count != 0)
            {
                if (counterhealth == 400)
                {
                    health pnn = new health();
                    pnn.x = r.Next(0, 1500);
                    pnn.y = r.Next(floor1 - 100, floor1);
                    heal.Add(pnn);
                    counterhealth = 0;
                }
                for (int i = 0; i < heal.Count; i++)//claw take coins
                {
                    if (Claw[0].x + clawframes[0].Width >= heal[i].x && Claw[0].x + clawframes[0].Width < heal[i].x + healthimg.Width)
                    {
                        if ((Claw[0].y >= heal[i].y && Claw[0].y <= heal[i].y + healthimg.Height) || (Claw[0].y + clawframes[0].Height >= heal[i].y && Claw[0].y + clawframes[0].Height <= heal[i].y + healthimg.Height))
                        {
                            heal.RemoveAt(i);
                            if (Claw[0].health > 0)
                            {
                                Claw[0].health--;
                            }
                        }
                    }
                }
                /*--------------------------------------------------------------  Coins code  --------------------------------------------------------------*/
                for (int i = 0; i < co.Count; i++)//coins movement
                {
                    co[i].counter++;
                    if (co[i].counter == 5)
                    {
                        co[i].indeximg++;
                        co[i].counter = 0;
                    }
                    if (co[i].indeximg == 8)
                    {
                        co[i].indeximg = 0;
                    }
                }
                for (int i = 0; i < co.Count; i++)//claw take coins
                {
                    if (Claw[0].x + clawframes[0].Width >= co[i].x && Claw[0].x + clawframes[0].Width < co[i].x + coinframes[0].Width)
                    {
                        if ((Claw[0].y >= co[i].y && Claw[0].y <= co[i].y + coinframes[0].Height) || (Claw[0].y + clawframes[0].Height >= co[i].y && Claw[0].y + clawframes[0].Height <= co[i].y + coinframes[0].Height))
                        {
                            clawsound.URL= "ClawSounds\\COIN.WAV";
                            clawsound.controls.play();
                            co.RemoveAt(i);
                            score += 157;
                        }
                    }
                }
                /*--------------------------------------------------------------  Door code  --------------------------------------------------------------*/
                if (openthedoor == true)
                {
                    clawsound.URL = "ClawSounds\\Medieval Castle Wooden Door Opening.mp3";
                    clawsound.controls.play();
                    Claw[0].countdoor++;
                    if (Claw[0].countdoor == 4)
                    {
                        Claw[0].indexdoor++;
                        Claw[0].countdoor = 0;
                    }
                    if (Claw[0].indexdoor == 4)
                    {
                        level++;
                        openthedoor = false;
                    }
                }
            }
            /*--------------------------------------------------------------  Officer code  --------------------------------------------------------------*/
            //check if claw gets closer to the enemy
            //if claw going right
            if (level == 3 && clawframes.Count != 0)
            {
                if (Claw[0].death == 0)
                {
                    for (int i = 0; i < Officer.Count; i++)
                    {
                        if (Claw[0].x < Officer[i].x)
                        {
                            if ((clawdirection == 1 || clawdirection == -1) && (Claw[0].x + clawframes[0].Width + enemynotice >= Officer[i].x))
                            {
                                if (Claw[0].y + 50 >= Officer[i].y && Claw[0].y <= Officer[i].y + officerframes[0].Height)
                                {
                                    Officer[i].attack = 1;
                                    Officer[i].dir = -1;
                                }

                            }
                        }
                        if (Claw[0].x > Officer[i].x)
                        {
                            if ((clawdirection == -1 || clawdirection == 1) && (Claw[0].x - enemynotice <= Officer[i].x + officerframes[0].Width))
                            {
                                if (Claw[0].y + 50 >= Officer[i].y && Claw[0].y <= Officer[i].y + officerframes[0].Height)
                                {
                                    Officer[i].attack = 1;
                                    Officer[i].dir = 1;
                                }

                            }
                        }

                    }
                }
                /*--------------------------------------------------------------  Officer Idle code  --------------------------------------------------------------*/
                for (int i = 0; i < Officer.Count; i++)
                {

                    Officer[i].idlecounter += randomidleofficer[i].num;
                    if (Officer[i].idlecounter >= 40000)
                    {
                        Officer[i].idle = 1;
                        Officer[i].idlecounter = 0;
                    }
                    if (Officer[i].idle == 1)
                    {
                        Officer[i].idleswitchframes++;
                        if (Officer[i].idleswitchframes == 9)
                        {
                            Officer[i].indexidle++;
                            Officer[i].idleswitchframes = 0;
                            if (Officer[i].indexidle == 4)
                            {
                                Officer[i].indexidle = 0;
                                Officer[i].idle = 0;
                            }
                        }

                    }
                }
                /*--------------------------------------------------------------  Officer Death code  --------------------------------------------------------------*/
                //dead by bullet

                for (int i = 0; i < Claw[0].bullet.Count; i++)
                {
                    for (int k = 0; k < Officer.Count; k++)
                    {
                        if (Claw[0].bullet[i].x > Officer[k].x && Claw[0].bullet[i].x < Officer[k].x + officerframes[1].Width + 10)
                        {
                            if (Claw[0].bullet[i].y >= Officer[k].y && Claw[0].bullet[i].y < Officer[k].y + officerframes[0].Height)
                            {

                                Officer[k].health -= 40;
                                if (Officer[k].health <= 0)
                                {
                                    Officer[k].deathcounter++;
                                    enemysounds.URL = "ClawSounds\\officerdeath.WAV";
                                    enemysounds.controls.play();
                                }
                                Claw[0].bullet.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                /*--------------------------------------------------------------  Officer Movement code  --------------------------------------------------------------*/
                for (int i = 0; i < Officer.Count; i++)
                {
                    if (Officer[i].dead == 0 && Officer[i].idle == 0)// if he is alive
                    {
                        if (Officer[i].attack == 0 && Officer[i].dir == 1)// if he is moving right without attack
                        {
                            Officer[i].countframe++;
                            Officer[i].x += 4;
                            Officer[i].dircounter++;
                            if (Officer[i].countframe == 4)
                            {
                                Officer[i].indeximgright++;
                                Officer[i].countframe = 0;
                            }
                            if (Officer[i].dircounter == 90)
                            {
                                Officer[i].indeximgright = 0;
                                Officer[i].dir = -1;
                                Officer[i].dircounter = 0;

                            }
                            if (Officer[i].indeximgright == 8)
                            {
                                Officer[i].indeximgright = 0;
                            }
                        }
                        if (Officer[i].attack == 1 && Officer[i].dir == 1)// if he is attaking right 
                        {
                            Officer[i].countframesword++;
                            if (Officer[i].countframesword == 3)
                            {
                                Officer[i].indexswordright++;
                                Officer[i].countframesword = 0;
                            }
                            if (Officer[i].indexswordright == 8)//if he reaches last sword frame
                            {
                                clawsound.URL = "ClawSounds\\SWORDSWISH.WAV";
                                clawsound.controls.play();
                                if (Officer[i].x + officerswordframes[8].Width >= Claw[0].x - clawframes[0].Width)//if the sword touches claw
                                {
                                    if (Claw[0].y + 50 >= Officer[i].y && Claw[0].y <= Officer[i].y + officerframes[0].Height)
                                    {
                                        Claw[0].health++;
                                        enemysounds.URL = "ClawSounds\\hurt.WAV";
                                        enemysounds.controls.play();
                                        if (Claw[0].health > 9)
                                        {
                                            Claw[0].death = 1;
                                            clawsound.URL = "ClawSounds\\hurt.WAV";
                                            clawsound.controls.play();
                                        }
                                    }
                                }
                                Officer[i].indexswordright = 0;
                                Officer[i].attack = 0;
                            }
                        }
                    }
                }

                for (int i = 0; i < Officer.Count; i++)// to keep his body for a while after death
                {
                    if (Officer[i].deathcounter >= 1)
                    {
                        Officer[i].deathcounter++;
                        Officer[i].y += 4;

                    }
                    if (Officer[i].deathcounter == 12)
                    {
                        Officer[i].dead = 1;
                    }
                }

                for (int i = 0; i < Officer.Count; i++)
                {
                    if (Officer[i].attack == 0 && Officer[i].dir == -1 && Officer[i].idle == 0)// if he is moving right without attack
                    {
                        Officer[i].countframe++;
                        Officer[i].x -= 4;
                        Officer[i].dircounter++;
                        if (Officer[i].countframe == 4)
                        {
                            Officer[i].indeximgleft++;
                            Officer[i].countframe = 0;
                        }
                        if (Officer[i].dircounter == 90)
                        {
                            Officer[i].indeximgleft = 0;
                            Officer[i].dircounter = 0;
                            Officer[i].dir = 1;
                        }
                        if (Officer[i].indeximgleft == 8)
                        {
                            Officer[i].indeximgleft = 0;
                        }
                    }
                    if (Officer[i].attack == 1 && Officer[i].dir == -1 && Officer[i].idle == 0)// if he is attaking left 
                    {
                        Officer[i].countframesword++;
                        if (Officer[i].countframesword == 3)
                        {
                            Officer[i].indexswordleft++;
                            Officer[i].countframesword = 0;
                        }
                        if (Officer[i].indexswordleft == 8)
                        {
                            clawsound.URL = "ClawSounds\\SWORDSWISH.WAV";
                            clawsound.controls.play();
                            Officer[i].x -= 4;
                            if (Officer[i].x - officerswordframes[8].Width <= Claw[0].x + clawframes[0].Width)//if the sword touches claw
                            {
                                if (Claw[0].y + 50 >= Officer[i].y && Claw[0].y <= Officer[i].y + officerframes[0].Height)
                                {
                                    Claw[0].health++;
                                    enemysounds.URL = "ClawSounds\\hurt.WAV";
                                    enemysounds.controls.play();
                                    if (Claw[0].health > 9)
                                    {
                                        Claw[0].death = 1;
                                        clawsound.URL = "ClawSounds\\hurt.WAV";
                                        clawsound.controls.play();
                                    }
                                }
                            }
                            Officer[i].indexswordleft = 0;
                            Officer[i].attack = 0;

                        }
                    }

                }
            }
            /*--------------------------------------------------------------  Soldier code  --------------------------------------------------------------*/
            //check if claw gets closer to the enemy
            //if claw going right
            if (level == 5 && clawframes.Count != 0)
            {
                if (Claw[0].death == 0)
                {
                    for (int i = 0; i < Soldier.Count; i++)
                    {
                        if (Claw[0].x < Soldier[i].x)
                        {
                            if ((clawdirection == 1 || clawdirection == -1) && (Claw[0].x + clawframes[0].Width + enemy2notice >= Soldier[i].x))
                            {
                                if (Claw[0].y + 50 >= Soldier[i].y && Claw[0].y <= Soldier[i].y + officerframes[0].Height)
                                {
                                    Soldier[i].attack = 1;
                                    Soldier[i].dir = -1;
                                }

                            }
                        }
                        if (Claw[0].x > Soldier[i].x)
                        {
                            if ((clawdirection == -1 || clawdirection == 1) && (Claw[0].x - enemy2notice <= Soldier[i].x + soldierframes[0].Width))
                            {
                                if (Claw[0].y + 50 >= Soldier[i].y && Claw[0].y <= Soldier[i].y + soldierframes[0].Height)
                                {
                                    Soldier[i].attack = 1;
                                    Soldier[i].dir = 1;
                                }

                            }
                        }

                    }
                }
                /*--------------------------------------------------------------  Soldier Idle code  --------------------------------------------------------------*/
                for (int i = 0; i < Soldier.Count; i++)
                {

                    Soldier[i].idlecounter += randomidleofficer[i].num;
                    if (Soldier[i].idlecounter >= 40000)
                    {
                        Soldier[i].idle = 1;
                        Soldier[i].idlecounter = 0;
                    }
                    if (Soldier[i].idle == 1)
                    {
                        Soldier[i].idleswitchframes++;
                        if (Soldier[i].idleswitchframes == 9)
                        {
                            Soldier[i].indexidle++;
                            Soldier[i].idleswitchframes = 0;
                            if (Soldier[i].indexidle == 4)
                            {
                                Soldier[i].indexidle = 0;
                                Soldier[i].idle = 0;
                            }
                        }

                    }
                }
                /*--------------------------------------------------------------  Soldier Death code  --------------------------------------------------------------*/
                //dead by bullet

                for (int i = 0; i < Claw[0].bullet.Count; i++)
                {
                    for (int k = 0; k < Soldier.Count; k++)
                    {
                        if (Claw[0].bullet[i].x > Soldier[k].x && Claw[0].bullet[i].x < Soldier[k].x + soldierframes[0].Width + 10)
                        {
                            if (Claw[0].bullet[i].y >= Soldier[k].y && Claw[0].bullet[i].y < Soldier[k].y + soldierframes[0].Height)
                            {

                                Soldier[k].health -= 40;
                                if (Soldier[k].health <= 0)
                                {
                                    Soldier[k].deathcounter++;
                                    enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                    enemysounds.controls.play();
                                }
                                Claw[0].bullet.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                /*--------------------------------------------------------------  Soldier Movement code  --------------------------------------------------------------*/
                for (int i = 0; i < Soldier.Count; i++)
                {
                    if (Soldier[i].dead == 0 && Soldier[i].idle == 0)// if he is alive
                    {
                        if (Soldier[i].attack == 0 && Soldier[i].dir == 1)// if he is moving right without attack
                        {
                            Soldier[i].countframe++;
                            Soldier[i].x += 4;
                            Soldier[i].dircounter++;
                            if (Soldier[i].countframe == 4)
                            {
                                Soldier[i].indeximgright++;
                                Soldier[i].countframe = 0;
                            }
                            if (Soldier[i].dircounter == 90)
                            {
                                Soldier[i].indeximgright = 0;
                                Soldier[i].dir = -1;
                                Soldier[i].dircounter = 0;

                            }
                            if (Soldier[i].indeximgright == 11)
                            {
                                Soldier[i].indeximgright = 0;
                            }
                        }
                        if (Soldier[i].attack == 1 && Soldier[i].dir == 1)// if he is attaking right 
                        {
                            Soldier[i].countframegun++;
                            if (Soldier[i].countframegun == 4)
                            {
                                Soldier[i].indexgunright++;
                                Soldier[i].countframegun = 0;
                            }
                            if (Soldier[i].indexgunright == 5)//if he reaches last sword frame
                            {
                                bullets pnn = new bullets();
                                pnn.x = Soldier[i].x + soldiergunframes[0].Width;
                                pnn.y = Soldier[i].y + soldiergunframes[0].Height / 4;
                                pnn.dir = 1;
                                Soldier[i].bullet.Add(pnn);
                                clawsound.URL = "ClawSounds\\GUNSHOT.WAV";
                                clawsound.controls.play();
                                Soldier[i].indexgunright = 0;
                                Soldier[i].attack = 0;
                            }
                        }
                    }
                }

                for (int i = 0; i < Soldier.Count; i++)// to keep his body for a while after death
                {
                    if (Soldier[i].deathcounter >= 1)
                    {
                        Soldier[i].deathcounter++;
                        Soldier[i].y += 4;

                    }
                    if (Soldier[i].deathcounter == 12)
                    {
                        Soldier[i].dead = 1;
                    }
                }

                for (int i = 0; i < Soldier.Count; i++)
                {
                    if (Soldier[i].attack == 0 && Soldier[i].dir == -1 && Soldier[i].idle == 0)// if he is moving right without attack
                    {
                        Soldier[i].countframe++;
                        Soldier[i].x -= 4;
                        Soldier[i].dircounter++;
                        if (Soldier[i].countframe == 4)
                        {
                            Soldier[i].indeximgleft++;
                            Soldier[i].countframe = 0;
                        }
                        if (Soldier[i].dircounter == 90)
                        {
                            Soldier[i].indeximgleft = 0;
                            Soldier[i].dircounter = 0;
                            Soldier[i].dir = 1;
                        }
                        if (Soldier[i].indeximgleft == 11)
                        {
                            Soldier[i].indeximgleft = 0;
                        }
                    }
                    if (Soldier[i].attack == 1 && Soldier[i].dir == -1 && Soldier[i].idle == 0)// if he is attaking left 
                    {
                        Soldier[i].countframegun++;
                        if (Soldier[i].countframegun == 4)
                        {
                            Soldier[i].indexgunleft++;
                            Soldier[i].countframegun = 0;
                        }
                        if (Soldier[i].indexgunleft == 5)
                        {

                            bullets pnn = new bullets();
                            pnn.x = Soldier[i].x - soldiergunframes[0].Width + bulletimage.Width + 40;
                            pnn.y = Soldier[i].y + soldiergunframes[0].Height / 4;
                            pnn.dir = -1;
                            Soldier[i].bullet.Add(pnn);
                            clawsound.URL = "ClawSounds\\GUNSHOT.WAV";
                            clawsound.controls.play();
                            Soldier[i].x -= 4;
                            Soldier[i].indexgunleft = 0;
                            Soldier[i].attack = 0;
                            
                        }
                    }

                }
            }
            /*--------------------------------------------------------------  Claw Death code from the soldier  --------------------------------------------------------------*/
            //dead by bullet

            for (int k = 0; k < Soldier.Count; k++)
            { 
                for (int i = 0; i < Soldier[k].bullet.Count; i++)
                {
                    if (Soldier[k].bullet[i].x > Claw[0].x && Soldier[k].bullet[i].x < Claw[0].x + clawframes[0].Width + 10)
                    {
                        if (Soldier[k].bullet[i].y >= Claw[0].y && Soldier[k].bullet[i].y < Claw[0].y + clawframes[0].Height)
                        {
                            Soldier[k].bullet.RemoveAt(i);
                            Claw[0].health++;
                            if(Claw[0].health>9)
                            {
                                Claw[0].death = 1;
                                enemysounds.URL = "ClawSounds\\hurt.WAV";
                                enemysounds.controls.play();
                            }

                        }
                    }
                }
            }
            /*--------------------------------------------------------------  Moving Bullets for soldier  --------------------------------------------------------------*/
            for (int k = 0; k < Soldier.Count; k++)
            {
                for (int i = 0; i < Soldier[k].bullet.Count; i++)
                {
                    if (Soldier[k].bullet[i].dir == 1)
                    {
                        Soldier[k].bullet[i].x += 5;
                    }
                    if (Soldier[k].bullet[i].dir == -1)
                    {
                        Soldier[k].bullet[i].x -= 5;
                    }
                }
            }
            /*--------------------------------------------------------------  Claw code  --------------------------------------------------------------*/
            /*--------------------------------------------------------------  Death code  --------------------------------------------------------------*/
            if (level == 3 || level == 5 && clawframes.Count != 0)
            {
                if (Claw[0].health == 9)
                {
                    enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                    enemysounds.controls.play();
                    Claw[0].death = 1;
                    Claw[0].health = 9;
                    Claw[0].y = floor1 + 50;
                }
                if (Claw[0].death == 1)
                {
                    Claw[0].countdead++;
                    if (Claw[0].countdead == 20)
                    {
                        level = 7;
                        Cursor.Show();
                        levelsound.URL = "ClawSounds\\lose.mp3";
                        levelsound.controls.play();
                    }
                }
            }
            if (level == 3 && clawframes.Count != 0)
            {
                if (Claw[0].death == 0)
                {
                       /*--------------------------------------------------------------  Climbing code  --------------------------------------------------------------*/
                        if (climbup == true)
                        {
                            if (Claw[0].x + 10 > ladder1x && Claw[0].x < ladder1x + ladder1.Width)
                            {
                                if (Claw[0].y > ladder1y && Claw[0].y < ladder1y + ladder1.Height + 10)
                                {
                                    Claw[0].indexclimb++;
                                    Claw[0].y -= 4;
                                    bgcuty -= 4;
                                    ladder1y += 4;
                                    doory += 4;
                                for(int i=0;i<Claw[0].bullet.Count;i++)
                                {
                                    Claw[0].bullet[i].y += 4;
                                }
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].y += 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].y += 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].y += 4;
                                    }
                                }
                                if (Claw[0].indexclimb == 12)
                                {
                                    Claw[0].indexclimb = 0;
                                }
                            }
                            if (Claw[0].y <= ladder1y)
                            {
                                temp = floor2;
                                floor2 = floor1;
                                floor1 = temp;
                                Claw[0].y = floor1;
                                climbup = false;
                                stand = 1;
                                Claw[0].indexclimb = 12;
                            }
                        }
                        if (climbdown == true)
                        {
                            if (Claw[0].x + 10 > ladder1x && Claw[0].x < ladder1x + ladder1.Width)
                            {
                                if (Claw[0].y + 15 + climbframes[0].Height > ladder1y && Claw[0].y < ladder1y + ladder1.Height)
                                {
                                    Claw[0].indexclimb--;
                                    Claw[0].y += 4;
                                    bgcuty += 4;
                                    ladder1y -= 4;
                                    doory -= 4;
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].y -= 4;
                                }
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].y -= 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].y -= 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].y -= 4;
                                    }
                                }
                                if (Claw[0].indexclimb == 0)
                                {
                                    Claw[0].indexclimb = 12;
                                }
                            }
                            if (Claw[0].y >= ladder1y + ladder1.Height)
                            {
                                temp = floor1;
                                floor1 = floor2;
                                floor2 = temp;
                                Claw[0].y = floor1;
                                stand = 1;
                                climbdown = false;
                                Claw[0].indexclimb = 0;

                            }
                        }
                    
                }
            }
                if (level == 3 || level == 5 && clawframes.Count != 0)
                {
                    /*--------------------------------------------------------------  sword code  --------------------------------------------------------------*/
                    if (countsword == 3)
                    {
                        Claw[0].indexsword++;
                        if (Claw[0].indexsword == 4)
                        {
                            if (sword == true)//when sword touches the enemy(Officer)
                            {
                            clawsound.URL = "ClawSounds\\SWORDSWISH.WAV";
                            clawsound.controls.play();
                            for (int k = 0; k < Officer.Count; k++)
                                {
                                    if (clawdirection == 1)
                                    {
                                        if (Claw[0].x + clawframes[0].Width >= Officer[k].x && Claw[0].x + clawframes[0].Width < Officer[k].x + officerframes[1].Width + 10)
                                        {
                                            if (Claw[0].y >= Officer[k].y - officerframes[0].Height && Claw[0].y < Officer[k].y + officerframes[0].Height)
                                            {
                                                Officer[k].health -= 40;
                                                if (Officer[k].health <= 0)
                                                {
                                                    Officer[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\FALLDEATH.WAV";
                                                enemysounds.controls.play();
                                            }
                                            }
                                        }
                                    }
                                    if (clawdirection == -1)
                                    {
                                        if (Claw[0].x - clawframes[0].Width / 2 <= Officer[k].x + officerframes[0].Width && Claw[0].x - clawframes[0].Width > Officer[k].x - officerframes[1].Width)
                                        {
                                            if (Claw[0].y >= Officer[k].y - officerframes[0].Height && Claw[0].y < Officer[k].y + officerframes[0].Height)
                                            {
                                                Officer[k].health -= 40;
                                                if (Officer[k].health <= 0)
                                                {
                                                    Officer[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\FALLDEATH.WAV";
                                                enemysounds.controls.play();
                                            }
                                            }
                                        }
                                    }
                                }
                            for (int k = 0; k < Soldier.Count; k++)
                            {
                                if (clawdirection == 1)
                                {
                                    if (Claw[0].x + clawframes[0].Width >= Soldier[k].x && Claw[0].x + clawframes[0].Width < Soldier[k].x + soldierframes[1].Width + 10)
                                    {
                                        if (Claw[0].y >= Soldier[k].y - soldierframes[0].Height && Claw[0].y < Soldier[k].y + soldierframes[0].Height)
                                        {
                                            Soldier[k].health -= 40;
                                            if (Soldier[k].health <= 0)
                                            {
                                                Soldier[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                                enemysounds.controls.play();
                                            }
                                        }
                                    }
                                }
                                if (clawdirection == -1)
                                {
                                    if (Claw[0].x - clawframes[0].Width / 2 <= Soldier[k].x + soldierframes[0].Width && Claw[0].x - clawframes[0].Width > Soldier[k].x - soldierframes[1].Width)
                                    {
                                        if (Claw[0].y >= Soldier[k].y - soldierframes[0].Height && Claw[0].y < Soldier[k].y + soldierframes[0].Height)
                                        {
                                            Soldier[k].health -= 40;
                                            if (Soldier[k].health <= 0)
                                            {
                                                Soldier[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                                enemysounds.controls.play();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                            Claw[0].indexsword = 0;
                            sword = false;
                        }
                        countsword = 0;
                    }
                    /*--------------------------------------------------------------  punch code  --------------------------------------------------------------*/
                    if (countpunch == 4)
                    {
                        Claw[0].indexpunch++;
                        if (Claw[0].indexpunch == 3)
                        {
                            if (punch == true)//when punch touches the enemy(Officer)
                            {
                                for (int k = 0; k < Officer.Count; k++)
                                {
                                    if (clawdirection == 1)
                                    {
                                        if (Claw[0].x + clawframes[0].Width >= Officer[k].x && Claw[0].x + clawframes[0].Width < Officer[k].x + officerframes[1].Width + 10)
                                        {
                                            if (Claw[0].y >= Officer[k].y - officerframes[0].Height && Claw[0].y < Officer[k].y + officerframes[0].Height)
                                            {
                                                Officer[k].health -= 40;
                                                if (Officer[k].health <= 0)
                                                {
                                                    Officer[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\FALLDEATH.WAV";
                                                enemysounds.controls.play();
                                            }
                                            }
                                        }
                                    }
                                    if (clawdirection == -1)
                                    {
                                        if (Claw[0].x - clawframes[0].Width / 2 <= Officer[k].x + officerframes[0].Width && Claw[0].x - clawframes[0].Width > Officer[k].x - officerframes[1].Width)
                                        {
                                            if (Claw[0].y >= Officer[k].y - officerframes[0].Height && Claw[0].y < Officer[k].y + officerframes[0].Height * 2)
                                            {
                                                Officer[k].health -= 40;
                                                if (Officer[k].health <= 0)
                                                {
                                                    Officer[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\FALLDEATH.WAV";
                                                enemysounds.controls.play();
                                            }
                                            }
                                        }
                                    }
                                }
                            for (int k = 0; k < Soldier.Count; k++)
                            {
                                if (clawdirection == 1)
                                {
                                    if (Claw[0].x + clawframes[0].Width >= Soldier[k].x && Claw[0].x + clawframes[0].Width < Soldier[k].x + soldierframes[1].Width + 10)
                                    {
                                        if (Claw[0].y >= Soldier[k].y - soldierframes[0].Height && Claw[0].y < Soldier[k].y + soldierframes[0].Height)
                                        {
                                            Soldier[k].health -= 40;
                                            if (Soldier[k].health <= 0)
                                            {
                                                Soldier[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                                enemysounds.controls.play();
                                            }
                                        }
                                    }
                                }
                                if (clawdirection == -1)
                                {
                                    if (Claw[0].x - clawframes[0].Width / 2 <= Soldier[k].x + soldierframes[0].Width && Claw[0].x - clawframes[0].Width > Soldier[k].x - soldierframes[1].Width)
                                    {
                                        if (Claw[0].y >= Soldier[k].y - soldierframes[0].Height && Claw[0].y < Soldier[k].y + soldierframes[0].Height)
                                        {
                                            Soldier[k].health -= 40;
                                            if (Soldier[k].health <= 0)
                                            {
                                                Soldier[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                                enemysounds.controls.play();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                            Claw[0].indexpunch = 0;
                            punch = false;
                        }
                        countpunch = 0;
                    }
                    /*--------------------------------------------------------------  Moving Bullets  --------------------------------------------------------------*/
                    for (int i = 0; i < Claw[0].bullet.Count; i++)
                    {
                        if (Claw[0].bullet[i].dir == 1)
                        {
                            Claw[0].bullet[i].x += 10;
                        }
                        if (Claw[0].bullet[i].dir == -1)
                        {
                            Claw[0].bullet[i].x -= 10;
                        }
                    }
                    /*--------------------------------------------------------------  Pistol code  --------------------------------------------------------------*/
                    if (countpistol == 4)
                    {
                        
                        Claw[0].indexpistol++;
                        if (Claw[0].indexpistol == 5)
                        {
                        Claw[0].indexpistol = 0;
                            pistol = false;
                        }
                        countpistol = 0;
                    }
                    /*--------------------------------------------------------------  Kick code  --------------------------------------------------------------*/
                    if (countkick == 3)
                    {
                        Claw[0].indexkick++;
                        if (Claw[0].indexkick == 4)
                        {
                            if (kick == true)//when punch touches the enemy(Officer)
                            {
                                for (int k = 0; k < Officer.Count; k++)
                                {
                                    if (clawdirection == 1)
                                    {
                                        if (Claw[0].x + clawframes[0].Width >= Officer[k].x && Claw[0].x + clawframes[0].Width < Officer[k].x + officerframes[1].Width + 10)
                                        {
                                            if (Claw[0].y >= Officer[k].y - officerframes[0].Height && Claw[0].y < Officer[k].y + officerframes[0].Height)
                                            {
                                                Officer[k].health -= 40;
                                                if (Officer[k].health <= 0)
                                                {
                                                    Officer[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\FALLDEATH.WAV";
                                                enemysounds.controls.play();
                                            }
                                            }
                                        }
                                    }
                                    if (clawdirection == -1)
                                    {
                                        if (Claw[0].x - clawframes[0].Width / 2 <= Officer[k].x + officerframes[0].Width && Claw[0].x - clawframes[0].Width > Officer[k].x - officerframes[1].Width)
                                        {
                                            if (Claw[0].y >= Officer[k].y - officerframes[0].Height && Claw[0].y < Officer[k].y + officerframes[0].Height * 2)
                                            {
                                                Officer[k].health -= 40;
                                                if (Officer[k].health <= 0)
                                                {
                                                    Officer[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\FALLDEATH.WAV";
                                                enemysounds.controls.play();
                                            }
                                            }
                                        }
                                    }
                                }
                            for (int k = 0; k < Soldier.Count; k++)
                            {
                                if (clawdirection == 1)
                                {
                                    if (Claw[0].x + clawframes[0].Width >= Soldier[k].x && Claw[0].x + clawframes[0].Width < Soldier[k].x + soldierframes[1].Width + 10)
                                    {
                                        if (Claw[0].y >= Soldier[k].y - soldierframes[0].Height && Claw[0].y < Soldier[k].y + soldierframes[0].Height)
                                        {
                                            Soldier[k].health -= 40;
                                            if (Soldier[k].health <= 0)
                                            {
                                                Soldier[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                                enemysounds.controls.play();
                                            }
                                        }
                                    }
                                }
                                if (clawdirection == -1)
                                {
                                    if (Claw[0].x - clawframes[0].Width / 2 <= Soldier[k].x + soldierframes[0].Width && Claw[0].x - clawframes[0].Width > Soldier[k].x - soldierframes[1].Width)
                                    {
                                        if (Claw[0].y >= Soldier[k].y - soldierframes[0].Height && Claw[0].y < Soldier[k].y + soldierframes[0].Height)
                                        {
                                            Soldier[k].health -= 40;
                                            if (Soldier[k].health <= 0)
                                            {
                                                Soldier[k].deathcounter++;
                                                enemysounds.URL = "ClawSounds\\soldierdeath.WAV";
                                                enemysounds.controls.play();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                            Claw[0].indexkick = 0;
                            kick = false;
                        }
                        countkick = 0;
                    }
                    /*--------------------------------------------------------------  Standing code  --------------------------------------------------------------*/
                    if (countidle == 3)
                    {
                        Claw[0].indexidle++;
                        if (Claw[0].indexidle == 8)
                        {
                            Claw[0].indexidle = 0;
                        }
                        countidle = 0;
                    }
                    /*--------------------------------------------------------------  jumping code  --------------------------------------------------------------*/
                    //jump right
                    if (flagjump == 1 && clawdirection == 1 && jumpagain == 1)
                    {
                        ctjump++;
                        if (ctjump < 14)
                        {
                            if (Claw[0].indexjump <= 5)
                            {
                                if (Claw[0].x + clawframes[0].Width < this.ClientSize.Width)
                                {
                                    ladder1x -= 4;
                                    Claw[0].y -= 20;
                                    Claw[0].x += 4;
                                    doorx -= 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x -= 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x -= 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x -= 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x -= 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x -= 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x -= 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x -= 4;
                                    }
                                    bgcutx += 4;
                                    Claw[0].indexjump++;
                                }
                                else
                                {
                                    ladder1x += 4;
                                    bgcutx -= 4;
                                    Claw[0].x -= 4;
                                    doorx += 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x += 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x += 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x += 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x += 4;
                                }
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x += 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x += 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x += 4;
                                    }
                                    Claw[0].y = floor1;
                                    jumpagain = 1;
                                }
                            }
                            if (Claw[0].indexjump > 5 && Claw[0].indexjump < 13)
                            {
                                if (Claw[0].x + clawframes[0].Width < this.ClientSize.Width)
                                {
                                    ladder1x -= 4;
                                    Claw[0].y += 20;
                                    Claw[0].x += 4;
                                    doorx -= 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x -= 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x -= 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x -= 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x -= 4;
                                }
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x -= 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x -= 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x -= 4;

                                    }
                                    bgcutx += 4;
                                    Claw[0].indexjump++;
                                }
                                else
                                {
                                    ladder1x += 4;
                                    bgcutx -= 4;
                                    Claw[0].x -= 4;
                                    doorx += 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x += 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x += 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x += 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x += 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x += 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x += 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x += 4;

                                    }
                                    Claw[0].y = floor1;
                                    jumpagain = 1;
                                }

                            }
                            if (Claw[0].indexjump == 12)
                            {
                                Claw[0].indexjump = 0;
                            }
                        }
                        else
                        {
                            stand = 1;
                            ctjump = 0;
                            flagjump = 0;
                        }
                    }
                    //jump left
                    if (flagjump == 1 && clawdirection == -1 && jumpagain == 1)
                    {
                        ctjump++;
                        if (ctjump < 14)
                        {
                            if (Claw[0].indexjump <= 5)
                            {
                                if (Claw[0].x > bgx + clawframes[0].Width)//jump up
                                {
                                    ladder1x += 4;
                                    Claw[0].y -= 20;
                                    Claw[0].x -= 4;
                                    doorx += 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x += 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x += 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x += 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x += 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x += 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x += 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x += 4;

                                    }
                                    bgcutx -= 4;
                                    Claw[0].indexjump++;
                                }
                                else
                                {
                                    ladder1x -= 4;
                                    bgcutx += 4;
                                    Claw[0].x += 4;
                                    doorx -= 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x -= 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x -= 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x -= 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x -= 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x -= 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x -= 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x -= 4;
                                    }
                                    Claw[0].y = floor1;
                                    jumpagain = 1;
                                }
                            }
                            if (Claw[0].indexjump > 5 && Claw[0].indexjump < 13)//jump left
                            {
                                if (Claw[0].x > bgx + clawframes[0].Width)
                                {
                                    ladder1x += 4;
                                    Claw[0].y += 20;
                                    Claw[0].x -= 4;
                                    doorx += 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x += 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x += 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x += 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x += 4;
                                }
                               
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x += 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x += 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x += 4;
                                    }
                                    bgcutx -= 4;
                                    Claw[0].indexjump++;
                                }
                                else
                                {
                                    ladder1x -= 4;
                                    bgcutx += 4;
                                    Claw[0].x += 4;
                                    doorx -= 4;
                                if (level == 5)
                                {
                                    elevatorr[0].x -= 4;
                                    for (int k = 0; k < Soldier.Count; k++)
                                    {
                                        for (int i = 0; i < Soldier[k].bullet.Count; i++)
                                        {
                                            Soldier[k].bullet[i].x -= 4;
                                        }
                                    }
                                    for (int i = 0; i < Soldier.Count; i++)
                                    {
                                        Soldier[i].x -= 4;
                                    }
                                }
                                for (int i = 0; i < Claw[0].bullet.Count; i++)
                                {
                                    Claw[0].bullet[i].x -= 4;
                                }
                                
                                for (int i = 0; i < heal.Count; i++)
                                    {
                                        heal[i].x -= 4;
                                    }
                                    for (int i = 0; i < co.Count; i++)
                                    {
                                        co[i].x -= 4;
                                    }
                                    for (int i = 0; i < Officer.Count; i++)
                                    {
                                        Officer[i].x -= 4;
                                    }
                                    Claw[0].y = floor1;
                                    jumpagain = 1;
                                }

                            }
                            if (Claw[0].indexjump == 12)
                            {
                                Claw[0].indexjump = 0;
                            }
                        }
                        else
                        {
                            stand = 1;
                            ctjump = 0;
                            flagjump = 0;
                        }
                    }
                }
            
            if(level==3||level==5 && clawframes.Count != 0)
            {
                gravity(Claw[0].x, Claw[0].y);
            }
            Drawdoublebuffer(this.CreateGraphics());
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            offimage = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            playagain.MakeTransparent();
            playagainhighlighted.MakeTransparent();
            youwin.MakeTransparent();
                /*--------------------------------------------------------------  Officer Frames  --------------------------------------------------------------*/
                // Officer movement frames
                for (int i = 1; i < 9; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\OFFICER\\" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    flippedofficerframes.Add(bim);
                }
                // officer flipped movement frames 
                for (int i = 1; i < 9; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\OFFICER\\" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    officerframes.Add(bim);
                }
                // Officer sword frames
                for (int i = 1; i < 9; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\OFFICER\\sword" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    flippedofficerswordframes.Add(bim);
                }
                // officer flipped sword frames 
                for (int i = 1; i < 9; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\OFFICER\\sword" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    officerswordframes.Add(bim);
                }
                // Officer idle frames
                for (int i = 1; i < 6; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\OFFICER\\idle" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    flippedofficeridleframes.Add(bim);
                }
                // officer idle sword frames 
                for (int i = 1; i < 6; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\OFFICER\\idle" + i.ToString() + ".png");
                    bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bim.MakeTransparent();
                    officeridleframes.Add(bim);
                }
                // door1 frames 
                for (int i = 1; i < 5; i++)
                {
                    Bitmap bim = new Bitmap("Level1\\Doors\\door" + i.ToString() + ".png");
                    bim.MakeTransparent();
                    door1.Add(bim);
                }
            /*--------------------------------------------------------------  Soldier Frames  --------------------------------------------------------------*/
            // Soldier movement frames
            for (int i = 1; i < 12; i++)
            {
                Bitmap bim = new Bitmap("Level2\\SOLDIER\\" + i.ToString() + ".png");
                bim.MakeTransparent();
                flippedsoldierframes.Add(bim);
            }
            // Soldier flipped movement frames 
            for (int i = 1; i < 12; i++)
            {
                Bitmap bim = new Bitmap("Level2\\SOLDIER\\" + i.ToString() + ".png");
                bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bim.MakeTransparent();
                soldierframes.Add(bim);
            }
            // Soldier gun frames
            for (int i = 1; i < 6; i++)
            {
                Bitmap bim = new Bitmap("Level2\\SOLDIER\\gun" + i.ToString() + ".png");
                bim.MakeTransparent();
                flippedsoldiergunframes.Add(bim);
            }
            // Soldier flipped gun frames 
            for (int i = 1; i < 6; i++)
            {
                Bitmap bim = new Bitmap("Level2\\SOLDIER\\gun" + i.ToString() + ".png");
                bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bim.MakeTransparent();
                soldiergunframes.Add(bim);
            }
            // Soldier idle frames
            for (int i = 1; i < 4; i++)
            {
                Bitmap bim = new Bitmap("Level2\\SOLDIER\\idle" + i.ToString() + ".png");
                bim.MakeTransparent();
                flippedsoldieridleframes.Add(bim);
            }
            // Soldier idle flipped frames 
            for (int i = 1; i < 4; i++)
            {
                Bitmap bim = new Bitmap("Level2\\SOLDIER\\idle" + i.ToString() + ".png");
                bim.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bim.MakeTransparent();
                soldieridleframes.Add(bim);
            }
            // door1 frames 
            for (int i = 1; i < 5; i++)
            {
                Bitmap bim = new Bitmap("Level1\\Doors\\door" + i.ToString() + ".png");
                bim.MakeTransparent();
                door1.Add(bim);
            }
            // coins frames 
            for (int i = 1; i < 5; i++)
            {
                Bitmap bim = new Bitmap("Level1\\Coins\\coin" + i.ToString() + ".png");
                bim.MakeTransparent();
                coinframes.Add(bim);
            }
            // loading level 1 frames 
            for (int i = 0; i < 4; i++)
            {
                Bitmap bim = new Bitmap("Level1\\loading" + i.ToString() + ".png");
                bim.MakeTransparent();
                loadinglevel1frames.Add(bim);
            }
            // loading level 2 frames 
            for (int i = 0; i < 4; i++)
            {
                Bitmap bim = new Bitmap("Level2\\loading" + i.ToString() + ".png");
                bim.MakeTransparent();
                loadinglevel2frames.Add(bim);
            }
        }

        private void Form1_Paint1(object sender, PaintEventArgs e)
        {
            
        }

        void Drawdoublebuffer(Graphics g) 
        {
            Graphics g2 = Graphics.FromImage(offimage);
            Drawscene(g2);
            g.DrawImage(offimage, 0, 0);
        }
        void Drawscene(Graphics g) 
        {
            g.Clear(Color.Black);
            if(level==6)
            {
                g.DrawImage(winbg, 1050, 200);
                g.DrawImage(youwin, 480, 0);
                if (highlightplayagain == 0)
                {
                    g.DrawImage(playagain, playagain2x, playagain2y);
                }
                if (highlightplayagain == 1)
                {
                    g.DrawImage(playagainhighlighted, playagain2x, playagain2y);
                }
            }
            if(level==7)//lose
            {
                g.DrawImage(loseimage, 450, 220);
                g.DrawImage(gameover, 550, 0);
                if(highlightplayagain==0)
                {
                    g.DrawImage(playagain, playagain1x, playagain1y);
                }
                if (highlightplayagain == 1)
                {
                    g.DrawImage(playagainhighlighted, playagain1x, playagain1y);
                }

            }
            if(level==2)
            {
                g.DrawImage(loadinglevel1frames[indexloadinglevel1], 250, 50);
            }
            if (level == 4)
            {
                g.DrawImage(loadinglevel2frames[indexloadinglevel2], 250, 50);
            }
            if (level==-1)
            {
                g.DrawImage(startscreen, 300, 150);
            }
            if(level==-0)
            {
                g.DrawImage(menubg, -50, 0);
                if (hightlight == 0)
                {
                    g.DrawImage(playbutton, playx, playy);
                    g.DrawImage(selectlevel, selectlevelx, selectlevely);
                    g.DrawImage(quitbutton, quitx, quity);
                }
                if (hightlight == 1)
                {
                    g.DrawImage(playbuttonhighlited, playx, playy);
                    g.DrawImage(selectlevel, selectlevelx, selectlevely);
                    g.DrawImage(quitbutton, quitx, quity);
                }
                if (hightlight == 2)
                {
                    g.DrawImage(selectlevelhighlited, selectlevelx, selectlevely);
                    g.DrawImage(playbutton, playx, playy);
                    g.DrawImage(quitbutton, quitx, quity);
                }
                if (hightlight == 3)
                {
                    g.DrawImage(quitbuttonhighlited, quitx, quity);
                    g.DrawImage(playbutton, playx, playy);
                    g.DrawImage(selectlevel, selectlevelx, selectlevely);
                }
            }
            if (level == 1)
            {
                g.DrawImage(menubg, -50, 0);
                if (highlight2 == 0)
                {
                    g.DrawImage(level1button, level1x, level1y);
                    g.DrawImage(level2button, level2x, level2y);
                    g.DrawImage(backbutton, backx, backy);
                }
                if (highlight2 == 1)
                {
                    g.DrawImage(level1buttonhighlighted, level1x, level1y);
                    g.DrawImage(level2button, level2x, level2y);
                    g.DrawImage(backbutton, backx, backy);
                }
                if (highlight2 == 2)
                {
                    g.DrawImage(level1button, level1x, level1y);
                    g.DrawImage(level2buttonhighlighted, level2x, level2y);
                    g.DrawImage(backbutton, backx, backy);
                }
                if (highlight2 == 3)
                {
                    g.DrawImage(level1button, level1x, level1y);
                    g.DrawImage(level2button, level2x, level2y);
                    g.DrawImage(backbuttonhighlighted, backx, backy);
                }

            }
            if (level == 5)
            {
                g.DrawImage(level2bg, new Rectangle(bgx, bgy, level2bg.Width, level2bg.Height), new Rectangle(bgcutx, bgcuty, level2bg.Width, level2bg.Height), GraphicsUnit.Pixel);
                g.DrawImage(door1[Claw[0].indexdoor], doorx, doory);
            }
            if (level == 3)
            {
                g.DrawImage(level1bg, new Rectangle(bgx, bgy, level1bg.Width, level1bg.Height), new Rectangle(bgcutx, bgcuty, level1bg.Width, level1bg.Height), GraphicsUnit.Pixel);
                g.DrawImage(door1[Claw[0].indexdoor], doorx, doory);
            }
            if (level == 3)
            {
                g.DrawImage(ladder1, ladder1x, ladder1y);
            }
            if (level == 3 || level == 5)
            {
                /*--------------------------------------------------------------  Coins Drawing  --------------------------------------------------------------*/
                for (int i = 0; i < co.Count; i++)
                {
                    g.DrawImage(coinframes[co[i].indeximg], co[i].x, co[i].y);
                }
                g.DrawImage(scoreimg, 1340, 0);
                g.DrawString(score.ToString(), f1, Brushes.LimeGreen, 1380, 30);
                if(Claw[0].death==0)
                {
                    g.DrawImage(healthbarframes[Claw[0].health], 100, 40);
                }
                g.DrawImage(face, -20, -10);
                for (int i = 0; i < heal.Count; i++)
                {
                    g.DrawImage(healthimg, heal[i].x, heal[i].y);
                }
                /*--------------------------------------------------------------  Claw Drawing  --------------------------------------------------------------*/
                //claw drawing
                
                if (Claw[0].death == 0)
                {
                    /*--------------------------------------------------------------  Laser Drawing  --------------------------------------------------------------*/
                    if (level == 5)
                    {
                        if (clawdirection == 1)
                        {
                            if (laserright == true || laserleft == true)
                            {
                                g.DrawImage(pistolframes[3], Claw[0].x, Claw[0].y);
                                g.DrawLine(p2, Claw[0].x + clawframes[0].Width+25, Claw[0].y + clawframes[0].Height / 4, laserrangex, laserrangey);

                            }
                        }
                        if (clawdirection == -1)
                        {
                            if (laserright == true || laserleft == true)
                            {
                                g.DrawImage(flippedpistolframes[3], Claw[0].x, Claw[0].y);
                                g.DrawLine(p2, Claw[0].x, Claw[0].y + clawframes[0].Height / 4, laserrangex, laserrangey);
                            }
                        }

                    }
                    if (stand == 1 && kick == false && pistol == false && punch == false && sword == false && climbup == false && climbdown == false&& laserright == false && laserleft == false)//idle animation
                    {
                        if (clawdirection == 1)
                        {
                            g.DrawImage(standframes[Claw[0].indexidle], Claw[0].x, Claw[0].y);
                        }
                        if (clawdirection == -1)
                        {
                            g.DrawImage(flippedstandframes[Claw[0].indexidle], Claw[0].x, Claw[0].y);
                        }
                    }
                    if (pistol == true && kick == false && punch == false && sword == false && climbup == false && climbdown == false && laserright == false && laserleft == false)//pistol animation
                    {
                        if (clawdirection == 1)
                        {
                            g.DrawImage(pistolframes[Claw[0].indexpistol], Claw[0].x, Claw[0].y);
                        }
                        if (clawdirection == -1)
                        {
                            g.DrawImage(flippedpistolframes[Claw[0].indexpistol], Claw[0].x, Claw[0].y);
                        }
                    }
                    if (kick == true && pistol == false && punch == false && sword == false && climbup == false && climbdown == false && laserright == false && laserleft == false)//kick animation
                    {
                        if (clawdirection == 1)
                        {
                            g.DrawImage(kickframes[Claw[0].indexkick], Claw[0].x, Claw[0].y);
                        }
                        if (clawdirection == -1)
                        {
                            g.DrawImage(flippedkickframes[Claw[0].indexkick], Claw[0].x, Claw[0].y);
                        }
                    }
                    if (stand == 0 && laserright == false && laserleft == false)
                    {
                        if (flagjump == 0)//if he is not jumping
                        {
                            // if claw looks right
                            if (clawdirection == 1)
                            {
                                for (int i = 0; i < Claw.Count; i++)
                                {
                                    g.DrawImage(clawframes[Claw[i].indeximg], Claw[i].x, Claw[i].y);
                                }
                            }
                            //if claw looks left
                            if (clawdirection == -1)
                            {
                                for (int i = 0; i < Claw.Count; i++)
                                {
                                    g.DrawImage(flippedclawframes[Claw[i].indeximg], Claw[i].x, Claw[i].y);
                                }
                            }
                        }
                        if (flagjump == 1 && clawdirection == 1 && kick == false && pistol == false && punch == false && sword == false && climbup == false && climbdown == false && laserright == false && laserleft == false)//if he is jumping right
                        {
                            for (int i = 0; i < Claw.Count; i++)
                            {
                                g.DrawImage(jumpframes[Claw[i].indexjump], Claw[i].x, Claw[i].y);
                            }
                        }
                        if (flagjump == 1 && clawdirection == -1 && kick == false && pistol == false && punch == false && sword == false && climbup == false && climbdown == false && laserright == false && laserleft == false)//if he is jumping left
                        {
                            for (int i = 0; i < Claw.Count; i++)
                            {
                                g.DrawImage(flippedjumpframes[Claw[i].indexjump], Claw[i].x, Claw[i].y);
                            }
                        }
                    }
                    for (int i = 0; i < Claw[0].bullet.Count; i++)// Draw The Bullets
                    {
                        g.DrawImage(bulletimage, Claw[0].bullet[i].x, Claw[0].bullet[i].y);
                    }
                    if (sword == true && kick == false && pistol == false && punch == false && climbup == false && climbdown == false && laserright == false && laserleft == false)//sword animation
                    {
                        if (clawdirection == 1)
                        {
                            g.DrawImage(swordframes[Claw[0].indexsword], Claw[0].x, Claw[0].y);
                        }
                        if (clawdirection == -1)
                        {
                            g.DrawImage(flippedswordframes[Claw[0].indexsword], Claw[0].x, Claw[0].y);
                        }
                    }
                    if (punch == true && kick == false && pistol == false && sword == false && climbup == false && climbdown == false && laserright == false && laserleft == false)//punch animation
                    {
                        if (clawdirection == 1)
                        {
                            g.DrawImage(punchframes[Claw[0].indexpunch], Claw[0].x, Claw[0].y);
                        }
                        if (clawdirection == -1)
                        {
                            g.DrawImage(flippedpunchframes[Claw[0].indexpunch], Claw[0].x, Claw[0].y);
                        }
                    }
                    if (level == 3)
                    {
                        if (climbup == true)
                        {
                            g.DrawImage(climbframes[Claw[0].indexclimb], Claw[0].x, Claw[0].y);
                        }
                        if (climbdown == true)
                        {
                            g.DrawImage(climbframes[Claw[0].indexclimb], Claw[0].x, Claw[0].y);
                        }
                    }
                }
                if (Claw[0].death == 1)
                {
                    g.DrawImage(clawdead, Claw[0].x, Claw[0].y);
                }
            }
            if (level == 3)
            {
                /*--------------------------------------------------------------  Officer Draw  --------------------------------------------------------------*/
                //officer death
                for (int i = 0; i < Officer.Count; i++)
                {
                    if (Officer[i].health < 0)
                    {
                        Officer[i].dir = 0;
                        g.DrawImage(officerdead, Officer[i].x, Officer[i].y);
                        if (Officer[i].dead == 1)
                        {
                            Officer.RemoveAt(i);
                            score += 123;
                        }
                    }
                }
                //officers and health bar if moving
                for (int i = 0; i < Officer.Count; i++)
                {
                    if (Officer[i].health > 0 && Officer[i].health <= 50)
                    {
                        if (Officer[i].dir == 1)
                        {
                            if (Officer[i].idle == 0)// if he is moving
                            {
                                if (Officer[i].attack == 0)
                                {
                                    g.DrawImage(officerframes[Officer[i].indeximgright], Officer[i].x, Officer[i].y);
                                }
                                if (Officer[i].attack == 1)
                                {
                                    g.DrawImage(officerswordframes[Officer[i].indexswordright], Officer[i].x, Officer[i].y);
                                }
                            }
                            if (Officer[i].idle == 1)
                            {
                                g.DrawImage(officeridleframes[Officer[i].indexidle], Officer[i].x, Officer[i].y);
                            }
                        }
                        if (Officer[i].dir == -1)
                        {
                            if (Officer[i].idle == 0)// if he is moving
                            {
                                if (Officer[i].attack == 0)
                                {
                                    g.DrawImage(flippedofficerframes[Officer[i].indeximgleft], Officer[i].x, Officer[i].y);
                                }
                                if (Officer[i].attack == 1)
                                {
                                    g.DrawImage(flippedofficerswordframes[Officer[i].indexswordleft], Officer[i].x, Officer[i].y);
                                }
                            }
                            if (Officer[i].idle == 1)
                            {
                                g.DrawImage(flippedofficeridleframes[Officer[i].indexidle], Officer[i].x, Officer[i].y);
                            }
                        }
                        g.DrawRectangle(Pens.Green, Officer[i].x, Officer[i].y - 20, healthbarwidth, healthbarheight);
                        g.FillRectangle(Brushes.Red, Officer[i].x + 4, Officer[i].y - 17, Officer[i].health, 5);
                    }
                }
                for (int i = 0; i < Officer.Count; i++)
                {
                    if (Officer[i].health > 50 && Officer[i].health <= 100)
                    {
                        if (Officer[i].dir == 1)
                        {
                            if (Officer[i].idle == 0)// if he is moving
                            {
                                if (Officer[i].attack == 0)
                                {
                                    g.DrawImage(officerframes[Officer[i].indeximgright], Officer[i].x, Officer[i].y);
                                }
                                if (Officer[i].attack == 1)
                                {
                                    g.DrawImage(officerswordframes[Officer[i].indexswordright], Officer[i].x, Officer[i].y);
                                }
                            }
                            if (Officer[i].idle == 1)
                            {
                                g.DrawImage(officeridleframes[Officer[i].indexidle], Officer[i].x, Officer[i].y);
                            }
                        }
                        if (Officer[i].dir == -1)
                        {
                            if (Officer[i].idle == 0)// if he is moving
                            {
                                if (Officer[i].attack == 0)
                                {
                                    g.DrawImage(flippedofficerframes[Officer[i].indeximgleft], Officer[i].x, Officer[i].y);
                                }
                                if (Officer[i].attack == 1)
                                {
                                    g.DrawImage(flippedofficerswordframes[Officer[i].indexswordleft], Officer[i].x, Officer[i].y);
                                }
                            }
                            if (Officer[i].idle == 1)
                            {
                                g.DrawImage(flippedofficeridleframes[Officer[i].indexidle], Officer[i].x, Officer[i].y);
                            }
                        }
                        g.DrawRectangle(Pens.Green, Officer[i].x, Officer[i].y - 20, healthbarwidth, healthbarheight);
                        g.FillRectangle(Brushes.Green, Officer[i].x + 4, Officer[i].y - 17, Officer[i].health, 5);
                    }
                }
            }
            /*--------------------------------------------------------------  Elevator Draw  --------------------------------------------------------------*/
            if (level == 5)
            {
                g.DrawImage(elevatorimage, elevatorr[0].x, elevatorr[0].y);
            }
            if (level == 5)
            {
                /*--------------------------------------------------------------  Soldier Draw  --------------------------------------------------------------*/
                //Soldier death
                for (int i = 0; i < Soldier.Count; i++)
                {
                    if (Soldier[i].health < 0)
                    {
                        Soldier[i].dir = 0;
                        g.DrawImage(soldierdead, Soldier[i].x, Soldier[i].y);
                        if (Soldier[i].dead == 1)
                        {
                            Soldier.RemoveAt(i);
                            score += 164;
                        }
                    }
                }
                //Soldier and health bar if moving
                for (int i = 0; i < Soldier.Count; i++)
                {
                    if (Soldier[i].health > 0 && Soldier[i].health <= 50)
                    {
                        if (Soldier[i].dir == 1)
                        {
                            if (Soldier[i].idle == 0)// if he is moving
                            {
                                if (Soldier[i].attack == 0)
                                {
                                    g.DrawImage(soldierframes[Soldier[i].indeximgright], Soldier[i].x, Soldier[i].y);
                                }
                                if (Soldier[i].attack == 1)
                                {
                                    g.DrawImage(soldiergunframes[Soldier[i].indexgunright], Soldier[i].x, Soldier[i].y);
                                }
                            }
                            if (Soldier[i].idle == 1)
                            {
                                g.DrawImage(soldieridleframes[Soldier[i].indexidle], Soldier[i].x, Soldier[i].y);
                            }
                        }
                        if (Soldier[i].dir == -1)
                        {
                            if (Soldier[i].idle == 0)// if he is moving
                            {
                                if (Soldier[i].attack == 0)
                                {
                                    g.DrawImage(flippedsoldierframes[Soldier[i].indeximgleft], Soldier[i].x, Soldier[i].y);
                                }
                                if (Soldier[i].attack == 1)
                                {
                                    g.DrawImage(flippedsoldiergunframes[Soldier[i].indexgunleft], Soldier[i].x, Soldier[i].y);
                                }
                            }
                            if (Soldier[i].idle == 1)
                            {
                                g.DrawImage(flippedsoldieridleframes[Soldier[i].indexidle], Soldier[i].x, Soldier[i].y);
                            }
                        }
                        g.DrawRectangle(Pens.Green, Soldier[i].x, Soldier[i].y - 20, healthbarwidth, healthbarheight);
                        g.FillRectangle(Brushes.Red, Soldier[i].x + 4, Soldier[i].y - 17, Soldier[i].health, 5);
                    }
                }
                for (int i = 0; i < Soldier.Count; i++)
                {
                    if (Soldier[i].health > 50 && Soldier[i].health <= 100)
                    {
                        if (Soldier[i].dir == 1)
                        {
                            if (Soldier[i].idle == 0)// if he is moving
                            {
                                if (Soldier[i].attack == 0)
                                {
                                    g.DrawImage(soldierframes[Soldier[i].indeximgright], Soldier[i].x, Soldier[i].y);
                                }
                                if (Soldier[i].attack == 1)
                                {
                                    g.DrawImage(soldiergunframes[Soldier[i].indexgunright], Soldier[i].x, Soldier[i].y);
                                }
                            }
                            if (Soldier[i].idle == 1)
                            {
                                g.DrawImage(soldieridleframes[Soldier[i].indexidle], Soldier[i].x, Soldier[i].y);
                            }
                        }
                        if (Soldier[i].dir == -1)
                        {
                            if (Soldier[i].idle == 0)// if he is moving
                            {
                                if (Soldier[i].attack == 0)
                                {
                                    g.DrawImage(flippedsoldierframes[Soldier[i].indeximgleft], Soldier[i].x, Soldier[i].y);
                                }
                                if (Soldier[i].attack == 1)
                                {
                                    g.DrawImage(flippedsoldiergunframes[Soldier[i].indexgunleft], Soldier[i].x, Soldier[i].y);
                                }
                            }
                            if (Soldier[i].idle == 1)
                            {
                                g.DrawImage(flippedsoldieridleframes[Soldier[i].indexidle], Soldier[i].x, Soldier[i].y);
                            }
                        }
                        g.DrawRectangle(Pens.Green, Soldier[i].x, Soldier[i].y - 20, healthbarwidth, healthbarheight);
                        g.FillRectangle(Brushes.Green, Soldier[i].x + 4, Soldier[i].y - 17, Soldier[i].health, 5);
                    }
                }
                for (int k = 0; k < Soldier.Count; k++)
                {
                    for (int i = 0; i < Soldier[k].bullet.Count; i++)
                    {
                            g.DrawImage(bulletimage, Soldier[k].bullet[i].x, Soldier[k].bullet[i].y);
                    }
                }
            }
        }
    }
    class Actor
    {
        public int x;
        public int y;
        public int countdead = 0;
        public int death = 0;
        public int indeximg = 0;
        public int indexjump = 0;
        public int indexidle = 0;
        public int indexkick = 0;
        public int indexpunch = 0;
        public int indexsword = 0;
        public int indexpistol = 0;
        public int indexclimb = 0;
        public int health = 0;
        public int countdoor = 0;
        public int indexdoor = 0;
        public int iup = 0;
        public int idown = 0;
        public List<bullets> bullet = new List<bullets>();
    }
    class Enemy1
    {
        public int x;
        public int y;
        public int indeximgright = 0;
        public int indeximgleft = 0;
        public int dir = 1;
        public int idle = 0;
        public int idleswitchframes = 0;
        public int idlecounter=0;
        public int dircounter = 0;
        public int indexidle = 0;
        public int indexswordright = 0;
        public int indexswordleft = 0;
        public int countframe = 0;
        public int countframesword = 0;
        public int deathcounter = 0;
        public int dead = 0;
        public int attack = 0;
        public int health = 100;
    }
    class Enemy2
    {
        public int x;
        public int y;
        public int indeximgright = 0;
        public int indeximgleft = 0;
        public int dir = 1;
        public int idle = 0;
        public int idleswitchframes = 0;
        public int idlecounter = 0;
        public int dircounter = 0;
        public int indexidle = 0;
        public int indexgunright = 0;
        public int indexgunleft = 0;
        public int countframe = 0;
        public int countframegun = 0;
        public int deathcounter = 0;
        public int dead = 0;
        public int attack = 0;
        public int health = 100;
        public List<bullets> bullet = new List<bullets>();
    }
    class coins
    {
        public int x;
        public int y;
        public int indeximg = 0;
        public int counter = 0;
    }
    class randomnums
    {
        public int num;
    }
    class health
    {
        public int x;
        public int y;
    }
    class bullets
    {
        public int x;
        public int y;
        public int dir;
    }
    class elevator
    {
        public int x;
        public int y;
    }
}
