using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Runtime.InteropServices;

namespace AntiKristo {
    public partial class Form1 : Form {

        private bool isArmed = false;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


        public Form1() {
            InitializeComponent();
        }


        // Arm
        private void button1_Click(object sender, EventArgs e) {
            isArmed = true;
            Hide();
        }


        public void OnKeyPressed() {
            if(isArmed) {
                isArmed = false;

                
                timer.Interval = 5000; // specify interval time as you want
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
                
                
            }

        }

        void timer_Tick(object sender, EventArgs e) {
            timer.Stop();
            Jumpscare();
            //Show();
        }

        void Jumpscare() {
            JumpscareForm jumpscareForm = new JumpscareForm();
            jumpscareForm.FormBorderStyle = FormBorderStyle.None;
            jumpscareForm.WindowState = FormWindowState.Maximized;
            jumpscareForm.OnClose = OnJumpscareClosed;


            jumpscareForm.Show();
            
        }

        int closeCount = 0;
        void OnJumpscareClosed() {
            if(closeCount == 0) {
                LockWorkStation();
                isArmed = false;
                Show();
            }
            ++closeCount;
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();

    }
}
