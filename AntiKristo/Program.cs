using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiKristo {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Form1 myForm = new Form1();

            InterceptKeys.OnKeyPressed = myForm.OnKeyPressed;
            InterceptKeys.Init();

            Application.Run(myForm);

            InterceptKeys.Destory();

        }
        
    }
}
