using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rts
{
    public partial class Form1 : Form
    {
        public int temperature = 15;
        public int oxigen = 70;
        public int metun = 3;
        public Image myImage;
        public Bitmap bmp;
        public int i = 1;

        public Boolean flagdoor = false;
        public Boolean flagNotification = false;
        public Boolean flagPusk = false;
        public Boolean flagNasos = false;
        public Boolean flagTemperature = false;
        public Boolean flagEarth = false;

        public Form1()
        {
            InitializeComponent();
            Init();
            Draw();
            Draw2();
           // Logic();
        }

        private void Init()
        {
            /*temp1.Text = "" + temperature + " C";
            numericUpDown1.Value = temperature;

            oxigen1.Text = "" + oxigen + " %";
            numericUpDown2.Value = oxigen;

            metan.Text = "" + metun + " %";
            numericUpDown3.Value = metun;*/

            label8.Font = new Font(label1.Font.Name, 12);
            label9.Font = new Font(label1.Font.Name, 12);
            label10.Font = new Font(label1.Font.Name, 12);
            label11.Font = new Font(label1.Font.Name, 12);
            label12.Font = new Font(label1.Font.Name, 12);
            label13.Font = new Font(label1.Font.Name, 12);
            
        }

        private void Initialization()
        {
            temp1.Text = "" + temperature + " C";
            numericUpDown1.Value = temperature;

            oxigen = (int)numericUpDown2.Value;
            oxigen1.Text = "" + oxigen + " %";

            metun = (int)numericUpDown3.Value;
            metan.Text = "" + metun + " %";

            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = true;
            timer7.Enabled = true;
            timer8.Enabled = true;
        }
        private void Draw2()
        {

            bmp = (Bitmap)Bitmap.FromFile("C:/Users/Misha/Downloads/srv3.jpg");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = bmp;
         

        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, 35, 37, 10, 10);
            g.DrawEllipse(p, 35, 55, 10, 10);
            g.DrawEllipse(p, 35, 73, 10, 10);
            g.DrawEllipse(p, 35, 91, 10, 10);
            pictureBox1.Image = bmp;
        }

        private void Draw_2()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.GreenYellow);
            g.DrawEllipse(p, 35, 37, 10, 10);
            g.DrawEllipse(p, 35, 55, 10, 10);
            g.DrawEllipse(p, 35, 73, 10, 10);
            g.DrawEllipse(p, 35, 91, 10, 10);
            if (flagPusk)
                g.FillEllipse(sb, 35, 37, 10, 10);
            if (flagTemperature)
                g.FillEllipse(sb, 35, 55, 10, 10);
            if (flagdoor)
                g.FillEllipse(sb, 35, 73, 10, 10);
            if (flagNasos)
                g.FillEllipse(sb, 35, 91, 10, 10);

           
           
            pictureBox1.Image = bmp;
        }
        private void timer1_Tick(object sender, EventArgs e) //температура
        {
            temperature++;
            temp1.Text = "" + temperature + " C";
            numericUpDown1.Value = temperature;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            temperature = (int)numericUpDown1.Value;
            temp1.Text = "" + temperature + " C";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            oxigen = (int)numericUpDown2.Value;
            oxigen1.Text = "" + oxigen + " %";
        }

        private void timer2_Tick(object sender, EventArgs e) //воздух
        {
            oxigen--;
            oxigen1.Text = "" + oxigen + " %";
            numericUpDown2.Value = oxigen;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            metun = (int)numericUpDown3.Value;
            metan.Text = "" + metun + " %";
        }

        private void timer3_Tick(object sender, EventArgs e) //метан
        {
            metun++;
            metan.Text = "" + metun + " %";
            numericUpDown3.Value = metun;
        }

        private void button5_Click(object sender, EventArgs e) //вентилятор
        {
            if (!flagdoor)
            {
                timer4.Enabled = true;
                pictureBox5.Image = Image.FromFile("C:/Users/Misha/Downloads/srv3d1.jpg");

                //timer1.Enabled = false;
                timer2.Enabled = false;
                //timer3.Enabled = false;
                timer6.Enabled = true;

                flagdoor = true;
                Draw_2();
            }
            else
            {
                timer4.Enabled = false;
                pictureBox5.Image = Image.FromFile("C:/Users/Misha/Downloads/srv3d2.jpg");

                timer1.Enabled = true;
                timer2.Enabled = true;
                //timer3.Enabled = true;
                //timer6.Enabled = false;

                flagdoor = false;
                Draw_2();
            }
            
        }

        private void timer4_Tick(object sender, EventArgs e) //анимация вентилятора
        {
           
            switch (i)
            {
                case 1:
                    pictureBox4.Image = Image.FromFile("C:/Users/Misha/Downloads/srv32.jpg");
                    i++;
                    break;
                case 2:
                    pictureBox4.Image = Image.FromFile("C:/Users/Misha/Downloads/srv33.jpg");
                    i++;
                    break;
                case 3:
                    pictureBox4.Image = Image.FromFile("C:/Users/Misha/Downloads/srv34.jpg");
                    i++;
                    break;
                case 4:
                    pictureBox4.Image = Image.FromFile("C:/Users/Misha/Downloads/srv35.jpg");
                    i++;
                    break;
                case 5:
                    pictureBox4.Image = Image.FromFile("C:/Users/Misha/Downloads/srv36.jpg");
                    i++;
                    break;
                case 6:
                    pictureBox4.Image = Image.FromFile("C:/Users/Misha/Downloads/srv31.jpg");
                    i=1;
                    break;
            }

        }

        private void timer5_Tick(object sender, EventArgs e) //сигнал
        {
            if (!flagNotification)
            {
                pictureBox6.Image = Image.FromFile("C:/Users/Misha/Downloads/lamp2.jpg");
                pictureBox7.Image = Image.FromFile("C:/Users/Misha/Downloads/s1.jpg");
                flagNotification = true;
            }
            else
            {
                pictureBox6.Image = Image.FromFile("C:/Users/Misha/Downloads/lamp.jpg");
                pictureBox7.Image = Image.FromFile("C:/Users/Misha/Downloads/s2.jpg");
                flagNotification = false;
            }
               

            if(!flagEarth && oxigen >= 50 && metun <= 15|| !flagEarth && metun <= 15 && oxigen >= 50)
            {
                pictureBox6.Image = Image.FromFile("C:/Users/Misha/Downloads/lamp.jpg");
                pictureBox7.Image = Image.FromFile("C:/Users/Misha/Downloads/s2.jpg");
                timer5.Enabled = false;
                flagPusk = false;
                Draw_2();
            }
        }

        private void button1_Click(object sender, EventArgs e) //пуск
        {
            if (!flagPusk)
            {
                timer5.Enabled = true;
                flagPusk = true;
                Draw_2();
            }
            else
            {
                timer5.Enabled = false;
                flagPusk = false;
                flagEarth = false;
                Draw_2();
            }
        }

        private void timer6_Tick(object sender, EventArgs e) // вентилятор в работе
        {
            if (oxigen <= 65)
            {
                flagdoor = true;
                timer2.Enabled = false;
                timer4.Enabled = true;

                oxigen++;
                oxigen1.Text = "" + oxigen + " %";
                numericUpDown2.Value = oxigen;

                pictureBox5.Image = Image.FromFile("C:/Users/Misha/Downloads/srv3d1.jpg");

                Draw_2();
            }
            else
            {
                timer4.Enabled = false;
                pictureBox5.Image = Image.FromFile("C:/Users/Misha/Downloads/srv3d2.jpg");

                //timer1.Enabled = true;
                timer2.Enabled = true;
                //timer3.Enabled = true;
                
                flagdoor = false;
                //timer6.Enabled = false;
                Draw_2();
            }

            if (oxigen <= 50)
            {
                timer5.Enabled = true;
                flagPusk = true;
                Draw_2();
            }
        }

        private void button4_Click(object sender, EventArgs e) //двери
        {
            if (!flagdoor)
            {
                pictureBox5.Image = Image.FromFile("C:/Users/Misha/Downloads/srv3d1.jpg");
                flagdoor = true;
            }
            else
            {
                pictureBox5.Image = Image.FromFile("C:/Users/Misha/Downloads/srv3d2.jpg");
                flagdoor = false;
            }
        }

        private void button2_Click(object sender, EventArgs e) //стоп
        {
            
            timer5.Enabled = false;
            flagPusk = false;
            Draw_2();

        }

        private void button6_Click(object sender, EventArgs e) //землетрясение 
        {
            timer5.Enabled = true;
            flagPusk = true;
            flagEarth = true;
            Draw_2();
        }

        private void button3_Click(object sender, EventArgs e) //насос
        {
            if (!flagNasos)
            {
                
                //timer1.Enabled = false;
                //timer2.Enabled = false;
                timer3.Enabled = false;
                timer7.Enabled = true;

                flagNasos = true;
                Draw_2();
            }
            else
            {
                //timer1.Enabled = true;
                //timer2.Enabled = true;
                timer3.Enabled = true;
                //timer7.Enabled = false;

                flagNasos = false;
                Draw_2();
            }
        }

        private void timer7_Tick_1(object sender, EventArgs e) //насос в работе
        {
            if (metun >= 7)
            {
                flagNasos = true;
                timer3.Enabled = false;

                metun--;
                metan.Text = "" + metun + " %";
                numericUpDown3.Value = metun;

                Draw_2();
            }
            else
            {
                //timer1.Enabled = true;
                //timer2.Enabled = true;
                timer3.Enabled = true;

                flagNasos = false;
                //timer7.Enabled = false;
                Draw_2();
            }

            if(metun >= 15)
            {
                timer5.Enabled = true;
                flagPusk = true;
                Draw_2();
            }
        }

        private void button7_Click(object sender, EventArgs e) //корман газа
        {
            metun = 50;
            metan.Text = "" + metun + " %";
            numericUpDown3.Value = metun;

            timer5.Enabled = true;
            flagPusk = true;
            Draw_2();
        }

        private void timer8_Tick(object sender, EventArgs e) //холодидьные установки
        {
            if (temperature >= 30)
            {
                timer1.Enabled = false;

                temperature--;
                temp1.Text = "" + temperature + " C";
                numericUpDown1.Value = temperature;

                flagTemperature = true;
                Draw_2();
            }
            else
            {
                timer1.Enabled = true;
                //timer2.Enabled = true;
                //timer3.Enabled = true;
                flagTemperature = false;
                Draw_2();
            }
        }

        private void button8_Click(object sender, EventArgs e) //потеря воздуха
        {
            oxigen = 30;
            oxigen1.Text = "" + oxigen + " %";
            numericUpDown2.Value = oxigen;

            timer5.Enabled = true;
            flagPusk = true;
            Draw_2();
        }

        private void button9_Click(object sender, EventArgs e) //старт
        {
            Initialization();
        }
    }
}
