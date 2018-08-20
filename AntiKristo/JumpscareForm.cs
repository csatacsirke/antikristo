using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiKristo {
    public partial class JumpscareForm : Form {

        public Action OnClose;

        public JumpscareForm() {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.bsodwin10;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Cursor.Hide();
        }

        private void OnResize(object sender, EventArgs e) {
            this.pictureBox1.Bounds = this.Bounds;
        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            if(OnClose != null) {
                OnClose();
            }
        }

        protected override void OnLostFocus(EventArgs e) {
            base.OnLostFocus(e);
            if (OnClose != null) {
                OnClose();
            }
        }
    }
}
