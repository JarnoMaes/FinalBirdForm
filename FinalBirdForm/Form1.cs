using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalBirdForm
{
    public partial class Form1 : Form
    {

                                  //HOLD SPACEBAR TO GO UP !!!!!!
        int pipeSpeed = 8; 
        int gravity = 15;
        int score = 0;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            { 
                gravity = -15;
            }

        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void EndGame()
        {
            GameTimer.Stop();
            Score.Text += "   Game Over !";
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity; 
            PipeBottom.Left -= pipeSpeed; 
            PipeTop.Left -= pipeSpeed; 
            Score.Text = $"Score: {score}"; 

            if (PipeBottom.Left < -50)
            {  
                PipeBottom.Left = 800;
                score++;
            }
            if (PipeTop.Left < -80)
            { 
                PipeTop.Left = 950;
                score++;
            }

            if (FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Ground.Bounds) || FlappyBird.Top < -25
                )
            {
                EndGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }
    }
}
