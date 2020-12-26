using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace OpenGl_1
{
    public partial class Form1 : Form
    {
        float yatay = 0; 
        public Form1()
        {
            InitializeComponent();
            OpenGlControl.InitializeContexts();
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity(); 
            Gl.glOrtho(2.0, 2.0 , 2.0,2.0,-2.0,2.0); 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // M harfine basınca +5 derece döndürüyor. A harifne basında -5 derece döndürüyor. Döndürmesi için siyah ekrana basın. 
        }

        private void MyPaint(object sender, PaintEventArgs e)
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, 0.0f); 
            Gl.glRotatef(yatay, 0, 1, 0);
            Gl.glTranslatef(-0.0f, -0.0f, 0.0f);

            Gl.glBegin(Gl.GL_TRIANGLES);

            
            //ön
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);
            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);


            //sağ
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);
            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);


            //arka
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);
            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);


            //sol
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);
            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

            Gl.glEnd();
            Gl.glPopMatrix();
        }

        private void buttonDondur_Click(object sender, EventArgs e)
        {          
            yatay = (yatay+10) % 360; 
            OpenGlControl.Refresh(); 
        }

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
                yatay = (yatay + 5) % 360;
            if (e.KeyCode == Keys.A)
                yatay = (yatay - 5) % 360;

            OpenGlControl.Refresh();
        }
    }
}
