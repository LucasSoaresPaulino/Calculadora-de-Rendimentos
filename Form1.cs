using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_rendimentos
{
    public partial class design : Form
    {
        public design()
        {
            InitializeComponent();
        }

        private void calcular_Click(object sender, EventArgs e)
        {
        // o metodo de variaveis em decimal, permite q o usuario utilize vergulas, numero quebrados, etc;   
            decimal aporte;
            decimal prazo;
            decimal taxa;
            decimal valorfinal;
            
        // variaveis apenas armazena texto, portanto precisa ser utilizado a função convert.Todecimal(); 
            aporte = Convert.ToDecimal(aporteTextBox.Text);
            prazo = Convert.ToDecimal (prazoTextBox.Text);
            taxa = Convert.ToDecimal (taxaTextBox.Text);
            
            taxa = taxa / 100;  // taxa é igual o numero digitado pelo usuario, dividido por 100.

            valorfinal = aporte;

        //   a variavel chamada de "i" vai ficar executando repetidamente o nosso calculo, com base no numero de meses que o usuario colocou na nossa variavel chamada "prazo".
            for (int i = 0; i<prazo; i++)
            {
                valorfinal = valorfinal + (valorfinal * taxa);
        //      valorfinal =    100     + (  100      * 0,01)
        //      valorfinal =    100     +            1       =    101  
            }

        // string é um tipo de variavel. o simbolo "[]" significa Array. que basicamente permite ser armazenada muitas informações dentro de uma variavel, e tambem permite uma organização melhor da mesma.
            string[] vf;

            vf = Convert.ToString(valorfinal).Split(','); // o "split" vc pode cortar a variavel, ou seja; por exemplo vc pode cortar um numero ou um nome que nao quer utilizar
           valorTotalTextBox.Text = "R$" + vf[0] + "," + vf[1].Substring(0,2);
            // É necessario o ".text" para poder dizer q o resultado aparecera em formato de texto dentro da TextBox. O "Convert.ToString" é necessario para transformar os numeros declarados na varialvel valorfinal em texto dentro da TextBox    

            decimal lucro = valorfinal - aporte;

            lucroTextBox.Text = Convert.ToString(lucro);

            string[] lf;

            lf = Convert.ToString(lucro).Split(',');
            lucroTextBox.Text = "R$" + lf[0] + "," + lf[1].Substring(0, 2);

        }
    }
}
