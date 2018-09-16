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

namespace mutex_test {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
      for (int i = 0; i < 5; i++) {
        Thread t = new Thread(func);
        t.Start();
        t = new Thread(func2);
        t.Start();
      }
      MessageBox.Show("ok,to wait!");
    }


    static Mutex m = new Mutex();
    static int glb_i = 0;
    static void func() {
      try {
        System.Console.WriteLine("--------------------" + System.Threading.Thread.CurrentThread.GetHashCode() + "---------------" + glb_i);
        lock (m) {
          glb_i++;
          System.Console.WriteLine(System.Threading.Thread.CurrentThread.GetHashCode() + "--before sleep--" + glb_i);
          System.Threading.Thread.Sleep(5000);
          System.Console.WriteLine(System.Threading.Thread.CurrentThread.GetHashCode() + "--after--" + glb_i);
        }
      } finally {

      }
    }
    static void func2() {
      try {
        System.Console.WriteLine("*****************" + System.Threading.Thread.CurrentThread.GetHashCode() + "******************" + glb_i);
        lock (m) {
          glb_i++;
          System.Console.WriteLine(System.Threading.Thread.CurrentThread.GetHashCode() + "--before #############-" + glb_i);
          System.Threading.Thread.Sleep(5000);
          System.Console.WriteLine(System.Threading.Thread.CurrentThread.GetHashCode() + "--after-##########-" + glb_i);
        }
      } finally {

      }
    }

  }
}
