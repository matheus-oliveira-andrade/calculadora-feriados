using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feriados
{
    public partial class FrmFeriados : Form
    {
        public FrmFeriados()
        {
            InitializeComponent();
        }

        private void FeriadosFixos(string Nferiado, int ano, int mes, int dia) {

            richTxtB_resultado.AppendText(Nferiado + ": " + DiaDaSemana(ano, mes, dia) + ", "
                + new DateTime(ano, mes, dia).ToShortDateString() + Environment.NewLine);
        }

        private void FeriadosMoveis(string Nferiado, int ano, int feriadoOrdinal) {

            DateTime DataOrdinal = OrdinalParaData(feriadoOrdinal, ano);
            richTxtB_resultado.AppendText(Nferiado + ": " + DiaDaSemana(DataOrdinal.Year, DataOrdinal.Month, DataOrdinal.Day) + ", " + DataOrdinal.ToShortDateString() 
                + Environment.NewLine);
        }
        private string DiaDaSemana(double ano, double mes, double dia) {
            // Obrigatório o uso de array de string para retornar o dia da semana                       
            //d = (k + [(13m - 1) / 5] + d + [d/4] + [c/4] - 2c) % 7   
            // k dia do mês, d os dois ultimos digitos do ano, c é o século, m mês tendo como base janeiro e feveiro 13 e 14 e março como 1      
          
            string[] dias = {"Domingo","Segunda","Terça","Quarta","Quinta","Sexta","Sábado"}; //Array com os dias da semana como solicitado na documentação do trabalho

            int Dia = Convert.ToInt32(dia);// Converte dia que esta em ponto flutuante em inteiro
            int Mes = Convert.ToInt32(mes);// Converte mes que esta em ponto flutuante em inteiro
            int Ano = Convert.ToInt32(ano);// Converte ano que esta em ponto flutuante em inteiro
            // Congruencia de Zeller
            int a = (14 - Mes) / 12;
            int y = Ano - a;
            int m = Mes + 12 * a - 2;
            int d = (Dia + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;

            return dias[d]; // Retorna uma posição do array de string 



        }
        private DateTime Pascoa(double ano)
        {

            int anoA = Convert.ToInt32(ano), // Conversao do ano em inteiro
            // Algoritmo de Meeus/Jones/Butcher
            a = anoA % 19,
            b = anoA / 100,
            c = anoA % 100,
            d = b / 4,
            e = b % 4,
            f = (b + 8) / 25,
            g = (b - f + 1) / 3,
            h = (19 * a + b - d - g + 15) % 30,
            i = c / 4,
            k = c % 4,
            L = (32 + 2 * e + 2 * i - h - k) % 7,
            m = (a + 11 * h + 22 * L) / 451,
            mes = (h + L - 7 * m + 114) / 31,
            dia = ((h + L - 7 * m + 114) % 31) +1;

            
            return new DateTime(anoA, mes, dia); // Retorna um dateTime 
        }
        private Boolean Bissexto(int ano) {

            bool bi = true; // Criação de váriavel (Opcional)
            // Codifica um teste para saber se o ano é ou não bissexto
            if ((ano % 4 != 0) && (ano % 400 != 0) || ano % 100 != 0) // O ano é Bissexto quando é divisivel por 4 e 400
            {
                bi = true;
            }          
            else {
                bi = false;
            }
            return bi; // Retorna true ou false 
        }

        private int[] GeraTabelaMeses(int ano) {
            // Gera um array de inteiros aonde cada posição corresponde ao numero de dia mês 
            // Para gerar corretamente precisa-se saber se o ano é bissexto ou não
            int[] meses = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // Array de meses como solicitado na documentação
            if (Bissexto(ano) == true) { // se o ano for bissexto a posoção 1 do array de inteiros é alterado para 29 que é equivalente ao ano bissexto
                meses[1] = 29;
            } // issexto(ano) == true ? meses[1] = 29
            return meses; // retorna o array meses
        }

        private int[] GeraTabelaOrdinais(int ano) {
            // Não pode inserir nem um valor a mão 
            // Gera um array para calculo de data ordinal 
            // Precisa do GeraTabelaMeses
            int[] meses = GeraTabelaMeses(ano);
            int[] ordinal = new int[12];
            ordinal[0] = 0;
            for (int i= 1; i < 12; i++) // For que gera a tabela de ordinais
            {              
                ordinal[i] += ordinal[i - 1] + meses[i - 1];
            }                   
            
            return ordinal; // Retorna um array de inteiros
        }

        private int DataParaOrdinal(int ano, int mes, int dia) {

            // Com base em GeraTabelaOrdinais retorna o dia (ordinal) do ano para uma data
            int[] TabOrdinais = GeraTabelaOrdinais(ano);
            int DOrdinais = TabOrdinais[mes - 1] + dia; 
            return DOrdinais; // Retirna os dia ordinais
            
        }

        private DateTime OrdinalParaData(int diaOrdinal, int ano) {
            // Usando GeraTabelaOrdinais retorna uma data a partir de um dia ordinal recebido
            // correr array de ordinais verificando se os dias corridos é maior que a posição verificada         
            int[] ordinal = GeraTabelaOrdinais(ano);
            int i = 0, dia = 1;
            while (diaOrdinal > ordinal[i]) { // Enquanto o calor de dias ordinais for maior que o q tem na posição i do array ordinal FAÇA
                i++;
            }
            dia =  diaOrdinal - ordinal[i-1] ;
            return new DateTime(ano, i, dia); // Retorna um dateTime
           
        }
        private void button_calcular_Click(object sender, EventArgs e)
        {
            int ano = Convert.ToInt32(maskedTxtB_ano.Text);
            DateTime pascoa = Pascoa(ano);
            richTxtB_resultado.Clear();

            // ----------------- Feriados móveis -----------------

            // Sexta feira santa
            int sextaSantaOrdinal = DataParaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day) - 2;
            FeriadosMoveis("Sexta-feira santa", ano, sextaSantaOrdinal);
            
            // Carnaval
            
            int carnavalOrdinal = DataParaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day) - 47;
            FeriadosMoveis("Carnaval", ano, carnavalOrdinal); ;

            // Corpus christi
            int corpusChristiOrdinal = DataParaOrdinal(pascoa.Year, pascoa.Month, pascoa.Day) + 60;
            FeriadosMoveis("Corpus christi", ano, corpusChristiOrdinal);

            // ----------------- Fim Feriados móveis ---------------





            // ------------------ Feriados fixos -----------------------

            // tiradentes
            FeriadosFixos("Tiradentes", ano, 04, 21);

            // Ano novo
            FeriadosFixos("Ano novo", ano, 01, 01);

            //  Dia do trabalhador
            FeriadosFixos("Dia do trabalhador", ano, 05, 01);

            // Dia da pátria
            FeriadosFixos("Dia da patria", ano, 09, 07);

            //Dia de Nossa senhora aparecida
            FeriadosFixos("Dia de nossa senhora aparecida", ano, 10, 12);

            //Dia de finados
            FeriadosFixos("Dia de finados", ano, 11, 02);

            // Proclamação da república
            FeriadosFixos("Proclamação dda republica", ano, 11, 15);

            //Natal
            FeriadosFixos("Natal", ano, 12, 25);

            // ------------------ Fim Feriados fixos ------------------------



        }
        private string MostrarExtenso(int ano, int mes, int dia) {

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            string meses = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(mes));
            string diasemana = DiaDaSemana(ano, mes, dia);
            string data = diasemana + ", " + dia + " de " + meses + " de " + ano;
            return data;
        }






    }
}
