﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicio_Num_Pessoas_Por_Faixa_Etaria
{
    public partial class Form1 : Form
    {
        int contadorPessoas, ctdidade1, ctdidade2, ctdidade3, ctdidade4, ctdidade5; //A principio quando tentei inicialia-las deu erro, então deixei assim e o Programa funciona.
        double resultPorc = 0;
     
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "Em Execução";
            notifyIcon1.ShowBalloonTip(6000);
        }

        private void btmAdicionar_Click(object sender, EventArgs e)
        {
            if(txtIdade.Text != "")
            {
                // Eis um modo alternativo e mais economico de cód. tbm pode ser feito dessa maneira: Habilitei novamente a parte abaixo
                //pois preciso dela para o tratamento da letra no lugar de um número, caso o user digite errado.
                    int numero = 0;
                    bool validar = int.TryParse(txtIdade.Text, out numero);

                //    if (validar == true && numero != 0)
                //    {
                //        if (numero > 0 && numero <= 15) ctdidade1++;
                //        else if (numero <= 30) ctdidade2++;
                //        else if (numero <= 45) ctdidade3++;
                //        else if (numero <= 60) ctdidade4++;
                //        else if (numero > 60) ctdidade5++;

                //        contadorPessoas++;

                //        lbl1a15.Text = ctdidade1.ToString();
                //        lbl1a15por.Text = ((double)ctdidade1 * ((double)contadorPessoas)/100).ToString("P2");
                //    }
                //    else
                //        MessageBox.Show("Insira um valor válido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //    MessageBox.Show("Insira um valor.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //{
                if (validar == true)
                {
                    if (int.Parse(txtIdade.Text) > 0 && int.Parse(txtIdade.Text) <= 15)
                    {
                        ++ctdidade1;
                        ++contadorPessoas;
                        resultPorc = (double)ctdidade1 * ((double)contadorPessoas / 100);//Podemos evitar esta linha fazendo o calculo
                                                                                         //no lbl1a15por.

                        lbl1a15.Text = ctdidade1.ToString();
                        lbl1a15por.Text = resultPorc.ToString("P2");
                    }
                    else if (int.Parse(txtIdade.Text) > 15 && int.Parse(txtIdade.Text) <= 30)
                    {
                        ++ctdidade2;
                        ++contadorPessoas;

                        resultPorc = (double)ctdidade2 * ((double)contadorPessoas / 100);

                        lbl16a30.Text = ctdidade2.ToString();
                        lbl16a30por.Text = resultPorc.ToString();
                    }
                    //contadorTotal.Text = contadorPessoas.ToString(); para ver se estava a a contar certo
                    else if (int.Parse(txtIdade.Text) > 30 && int.Parse(txtIdade.Text) <= 45)
                    {
                        contadorPessoas++;
                        ctdidade3++;

                        resultPorc = (double)ctdidade3 * ((double)contadorPessoas / 100);

                        lbl31a45.Text = ctdidade3.ToString();
                        lbl31a45por.Text = resultPorc.ToString();
                    }

                    else if (int.Parse(txtIdade.Text) > 45 && int.Parse(txtIdade.Text) <= 60)
                    {
                        contadorPessoas++;
                        ctdidade4++;

                        resultPorc = (double)ctdidade4 * ((double)contadorPessoas / 100);

                        lbl46a60.Text = ctdidade4.ToString();
                        lbl46a60por.Text = resultPorc.ToString();
                    }

                    else if (int.Parse(txtIdade.Text) > 60)
                    {
                        contadorPessoas++;
                        ctdidade5++;

                        resultPorc = (double)ctdidade5 * ((double)contadorPessoas / 100);

                        lbl60mais.Text = ctdidade5.ToString();
                        lbl60maispor.Text = resultPorc.ToString();
                    }
                    else
                        MessageBox.Show("Número inválido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdade.Clear();    
                    txtIdade.Focus();
                }
                else
                    MessageBox.Show("Número inválido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdade.Clear();
                    txtIdade.Focus();
            }


        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
