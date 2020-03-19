using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalkulatorOOP
{
    public partial class Form1 : Form
    {
        public Form1(){
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            this.textBox.Text += button1.Text;
        }
        private void button2_Click(object sender, EventArgs e){
            this.textBox.Text += button2.Text;
        }
        private void button3_Click(object sender, EventArgs e){
            this.textBox.Text += button3.Text;
        }
        private void button4_Click(object sender, EventArgs e){
            this.textBox.Text += button4.Text;
        }
        private void button5_Click(object sender, EventArgs e) {
            this.textBox.Text += button5.Text;
        }
        private void button6_Click(object sender, EventArgs e){
            this.textBox.Text += button6.Text;
        }
        private void button7_Click(object sender, EventArgs e){
            this.textBox.Text += button7.Text;
        }
        private void button8_Click(object sender, EventArgs e) {
            this.textBox.Text += button8.Text;
        }
        private void button9_Click(object sender, EventArgs e){
            this.textBox.Text += button9.Text;
        }
        private void button0_Click(object sender, EventArgs e){
            this.textBox.Text += button0.Text;
        }
        private void buttonT_Click(object sender, EventArgs e){
            this.textBox.Text += buttonT.Text;
        }
        private void buttonPLUS_Click(object sender, EventArgs e){
            this.textBox.Text += buttonPLUS.Text;
        }
        private void buttonMINUS_Click(object sender, EventArgs e){
            this.textBox.Text += buttonMINUS.Text;
        }
        private void buttonMulti_Click(object sender, EventArgs e){
            this.textBox.Text += buttonMulti.Text;
        }
        private void buttonBAGI_Click(object sender, EventArgs e){
            this.textBox.Text += buttonBAGI.Text;
        }
        private void buttonAkar_Click(object sender, EventArgs e){
            this.textBox.Text += buttonAkar.Text;
        }
        private void buttonCLEAR_Click(object sender, EventArgs e){
            textBox.Clear();
        }
        private void buttonSin_Click(object sender, EventArgs e){
            this.textBox.Text += buttonSin.Text;
        }
        private void buttonCos_Click(object sender, EventArgs e){
            this.textBox.Text += buttonCos.Text;
        }
        private void buttonTan_Click(object sender, EventArgs e){
            this.textBox.Text += buttonTan.Text;
        }
        private void buttonBK_Click(object sender, EventArgs e){
            this.textBox.Text += buttonBK.Text;
        }
        private void buttonTK_Click(object sender, EventArgs e){
            this.textBox.Text += buttonTK.Text;
        }
        private void buttonPangkat_Click(object sender, EventArgs e){
            this.textBox.Text += buttonPangkat.Text;
        }
        private void buttonAns_Click(object sender, EventArgs e){

        }
        private void buttonMC_Click(object sender, EventArgs e){

        }
        private void buttonMR_Click(object sender, EventArgs e){

        }
        private void buttonSD_Click(object sender, EventArgs e){

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
