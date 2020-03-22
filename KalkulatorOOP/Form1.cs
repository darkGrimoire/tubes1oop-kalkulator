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
        MCMRQueue<double> queue = new MCMRQueue<double>();
        // VARIABLES
        double ans = 0;
        bool hasPassedOperator = false;
        bool hasPassedNegative = false;
        bool hasPassedNum = false;
        bool hasPassedPoint = false;
        bool hasPassedUnary = false;
        int semaphore = 0;

        public Form1(){
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            this.textBox.Text += button1.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button2_Click(object sender, EventArgs e){
            this.textBox.Text += button2.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button3_Click(object sender, EventArgs e){
            this.textBox.Text += button3.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button4_Click(object sender, EventArgs e){
            this.textBox.Text += button4.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button5_Click(object sender, EventArgs e) {
            this.textBox.Text += button5.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button6_Click(object sender, EventArgs e){
            this.textBox.Text += button6.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button7_Click(object sender, EventArgs e){
            this.textBox.Text += button7.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button8_Click(object sender, EventArgs e) {
            this.textBox.Text += button8.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button9_Click(object sender, EventArgs e){
            this.textBox.Text += button9.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void button0_Click(object sender, EventArgs e){
            this.textBox.Text += button0.Text;
            hasPassedNum = true;
            hasPassedOperator = false;
            hasPassedNegative = false;
        }
        private void buttonT_Click(object sender, EventArgs e){
            if (!hasPassedPoint)
            {
                this.textBox.Text += buttonT.Text;
                hasPassedPoint = true;
            }
        }
        private void buttonPLUS_Click(object sender, EventArgs e){
            if (hasPassedNegative)
            {
                // do nothing
            }
            else if (hasPassedOperator)
            {
                this.textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                this.textBox.Text += buttonPLUS.Text;
            }
            else
            {
                this.textBox.Text += buttonPLUS.Text;
                hasPassedOperator = true;
                hasPassedNum = false;
                hasPassedPoint = false;
            }
        }
        private void buttonMINUS_Click(object sender, EventArgs e){
            if (hasPassedNegative)
            {
                // do nothing
            }
            else if (hasPassedOperator && ! hasPassedNegative)
            {
                this.textBox.Text += buttonMINUS.Text;
                hasPassedNegative = true;
            }
            else
            {
                this.textBox.Text += buttonMINUS.Text;
                hasPassedOperator = true;
                hasPassedNum = false;
                hasPassedPoint = false;
            }
        }
        private void buttonMulti_Click(object sender, EventArgs e){
            if (hasPassedNegative)
            {
                // do nothing
            }
            else if (hasPassedOperator)
            {
                this.textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                this.textBox.Text += buttonMulti.Text;
            }
            else
            {
                this.textBox.Text += buttonMulti.Text;
                hasPassedOperator = true;
                hasPassedNum = false;
                hasPassedPoint = false;
            }
        }
        private void buttonBAGI_Click(object sender, EventArgs e){
            if (hasPassedNegative)
            {
                // do nothing
            }
            else if (hasPassedOperator)
            {
                this.textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                this.textBox.Text += buttonBAGI.Text;
            }
            else
            {
                this.textBox.Text += buttonBAGI.Text;
                hasPassedOperator = true;
                hasPassedNum = false;
                hasPassedPoint = false;
            }
        }
        private void buttonAkar_Click(object sender, EventArgs e){
            this.textBox.Text += buttonAkar.Text;
        }
        private void buttonCLEAR_Click(object sender, EventArgs e){
            textBox.Clear();
            queue.Clear();
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
            semaphore++;
        }
        private void buttonTK_Click(object sender, EventArgs e){
            if (semaphore > 0)
            {
                this.textBox.Text += buttonTK.Text;
                semaphore--;
            }
        }
        private void buttonPangkat_Click(object sender, EventArgs e){
            this.textBox.Text += buttonPangkat.Text;
        }
        private void buttonAns_Click(object sender, EventArgs e){
            ans = this.ans;
            textBox.Clear();
            this.textBox.Text = ans.ToString();
        }
        private void buttonMC_Click(object sender, EventArgs e){
            queue.Push(Convert.ToDouble(textBox.Text));
        }
        private void buttonMR_Click(object sender, EventArgs e){
            double mR;
            mR = queue.Peek();
            queue.Pop();
            textBox.Clear();
            this.textBox.Text = mR.ToString();
        }
        private void buttonSD_Click(object sender, EventArgs e){
            Parser parseExpression = new Parser(textBox.Text);
            ans = parseExpression.Solve();
            textBox.Clear();
            textBox.Text = ans.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
