using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace SistemaNotas
{

    public class Sistema
    {
        public class Segurança{
            public double VerifNota(string nota)
            {
                if (!double.TryParse(nota, out double d) || d > 10 || d < 0)
                {
                    Console.WriteLine("Nota inválida. Digite apenas números positivos menores que 10.");
                    return 0;               
                }
                else
                {
                    return 1;
                }
            }
        }
        public class Mensagem
        {
            public void Initial()
            {
                Console.WriteLine("Olá, Pressione ENTER para começar a digitar as notas.");
                Console.Read();
            }

            public void NomeAluno()
            {
                Console.WriteLine("Escreva o nome do aluno");
            }

            public void NotaAluno()
            {
                Console.WriteLine("");
            }

        }
    }

    public class Professor
    {
        Sistema.Mensagem mensagem = new Sistema.Mensagem();
        public void Digitar()
        {
            int qntalunos;
            Console.WriteLine("Insira a quantidade de alunos\n");
            qntalunos = Convert.ToInt32(Console.ReadLine());
            double verificacao, notas = 0, media;
            string nota, tipodanota, nomealuno;
            string[,] MatrizTipoNotas = new string[qntalunos,5];
            Double[,] MatrizNotas = new Double[qntalunos, 5];
            string[] VetorNomes = new string[qntalunos];
            Double[] VetorMedias = new Double[qntalunos];

            Sistema.Segurança segurança = new Sistema.Segurança();
            for (int i = 0; i < qntalunos; i++)
            {
                notas = 0;
                mensagem.NomeAluno(); 
                nomealuno = Console.ReadLine();
                VetorNomes[i] = nomealuno;
    
                if (string.IsNullOrWhiteSpace(VetorNomes[i]))
                {
                    Console.WriteLine("Nome inválido. O nome do aluno não pode estar vazio.");
                    i--; 
                    continue;
                }
                else{
                    for (int j = 0; j<5; j++)
                    {
                        Console.WriteLine("Essa nota corresponde a o que?");
                        tipodanota = Console.ReadLine();
                        MatrizTipoNotas[i,j]=tipodanota;
                        Console.Write($"Digite a nota {tipodanota}\n");
                        nota = Console.ReadLine();
                        verificacao = segurança.VerifNota(nota);
                        if (verificacao == 0)
                        {
                            j--;
                        }
                        else
                        {
                            notas = notas + Convert.ToDouble(nota);
                            MatrizNotas[i,j] = Convert.ToDouble(nota);
                            
                            Console.WriteLine("\nProxima nota...\n");
                        }



                    }  
                    media = notas/5;
                    VetorMedias[i] = media;
                }
                
            }
            for (int g = 0; g < qntalunos; g++)
                {
                    Console.WriteLine($"\n\nNotas do aluno(a) {VetorNomes[g]}:");
                    for (int h = 0; h < 5; h++)
                    {
                        Console.WriteLine($"Nota {MatrizTipoNotas[g,h]} - {MatrizNotas[g, h]}");
                    }
                    if (VetorMedias[g] >= 6)
                    {
                        Console.WriteLine("ALUNO APROVADO!\n");
                    }
                    else
                    {
                        Console.WriteLine("ALUNO REPROVADO...\n");
                    }
                }
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Professor professor = new Professor();
            professor.Digitar();
        }
    }
}
