using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32;

namespace hkey0 {

    public partial class Form1 : Form {

        Task KeyMon;

        public Form1() {

            InitializeComponent();

            KeyMon = new Task( WaitMouseKey );
            KeyMon.Start();
        }


        private void WaitMouseKey() {

            bool IsPres( Keys key ) {

                return ( User32.GetAsyncKeyState( (int)key ) < 0 );

                //int mb5 = Convert.ToInt32( User32.GetAsyncKeyState( (int)Keys.XButton1 ).ToString() );
                //if (mb5 != 0) Application.OpenForms[0].Text = DateTime.Now.ToString();

            }

            while (this.IsHandleCreated) {

                Thread.Sleep( 1 );

                if (IsPres( Keys.P )) {

                    Win32.POINT p;

                    User32.GetCursorPos(out p);

                    textBox1.AppendText( String.Format("{0} {1} {2}", p.x, p.y, Environment.NewLine) );


                }
            }
        }
    }
}
