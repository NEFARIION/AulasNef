using System;
using System.Threading; // Importei a função "Threading" para ser utilizada no meu namespace.
using System.Text.RegularExpressions; // Importei a função de Regex para filtrar o que o usuário pode digitar no nome e nos valores numéricos do dado.

namespace My_Awesome_Program
{
    class Loops
    {
        static void Main(string[] args)
        {
            Console.Title = "CHAT D100"; // Muda o título do App
            Console.ForegroundColor = ConsoleColor.Cyan; // Muda a cor da fonte
            Console.WindowHeight = 40; // Muda a altura da janela
            Console.WindowWidth = 160; // Muda a largura da janela

            string playerName;
            int roll;
            int tentativas = 0;

            Console.WriteLine("Olá, seja bem vindo(a) ao CHATNATOR! Vou tentar adivinhar o número que você digitar.");
            Console.WriteLine("Antes de começarmos, me diga, qual é o seu nome?");
            playerName = Console.ReadLine();

            Regex userName = new Regex("^[A-Z][a-zA-Z]*$"); // Crio uma RegularExpression para verificar se o nome de usuário contém numeral de 0 à 9.
            if (userName.IsMatch(playerName))
            {
                Console.WriteLine("Prazer em te conhecer, " + playerName + ". Para jogar, digite um número de 1 à 100. Tentarei adivinhar o número. Caso queira sair, aperte 0.");
                int count = Convert.ToInt32(Console.ReadLine()); //Pego o número do usário como String (texto) e converto em um Int (número inteiro)

                if (count == 0) // Crio uma condição onde caso o usuário coloque o valor ZERO (0), ele sairá em até 10 segundos.
                {
                    for (int segundos = 10; segundos > 0; segundos--)
                    { // Loop para a contagem de 10 segundos
                        Console.WriteLine("Você decidiu sair. Saindo em " + segundos + " segundos..."); // Mensagem do Loop
                        Console.Beep();
                        Thread.Sleep(1000); // Tempo em milisegundos do spam da mensagem        
                    }
                    Environment.Exit(0);
                }
                else if (count > 100 || count < 1) // Verificador da trollagem de count
                {
                    Console.WriteLine("Eu pedi um número entre 1 e 100. Você digitou " + count + ". Aperte qualquer coisa pare reiniciar o jogo, bobão.");
                }
                else
                {
                    Console.WriteLine("Perfeito! Vamos começar então. Eu acredito que seu número seja...");
                    Random numberGen = new Random();
                    roll = numberGen.Next(1, 101);
                    Console.WriteLine(roll);
                    Console.WriteLine("Está correto? S para Sim e N para não");

                    var yesOrNo = Console.ReadKey();

                    if (yesOrNo.Key == ConsoleKey.N && roll == count)
                    {
                        Console.WriteLine("\nEntão você tentou roubar?...Muito feio viu. Bom, eu ganhei e você é um mal perdedor.");
                        Console.WriteLine("Obrigado por ter jogado");
                        Console.WriteLine("Pressione qualquer tecla para sair do jogo.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else if (yesOrNo.Key == ConsoleKey.S && roll != count)
                    {
                        Console.WriteLine("\nEntão você tentou roubar?...Muito feio viu. Bom, eu ganhei e você é um mal perdedor.");
                        Console.WriteLine("Obrigado por ter jogado");
                        Console.WriteLine("Pressione qualquer tecla para sair do jogo.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        while (yesOrNo.Key != ConsoleKey.S && yesOrNo.Key == ConsoleKey.N)
                        {
                            roll = numberGen.Next(1, 101);
                            Console.WriteLine("\n Droga! Errei? Então seu número deve ser " + roll + ". Acertei?");
                            yesOrNo = Console.ReadKey();
                            tentativas++;
                        }
                        Console.WriteLine("Acertei? Maravilha! Só precisei pensar " + tentativas + " vezes. Quer jogar novamente?");
                        yesOrNo = Console.ReadKey();
                        if (yesOrNo.Key == ConsoleKey.S)
                        {
                            Console.WriteLine("Então vamos lá!");
                        }
                        else if (yesOrNo.Key == ConsoleKey.N)
                        {
                            Console.WriteLine("Tudo bem! Obrigado por ter jogado!");
                            for (var segundos = 5; segundos > 0; segundos--)
                            {
                                Console.WriteLine("Sainddo em " + segundos + " segundos...");
                                Thread.Sleep(1000);
                            }
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Droga, esqueci de avisar. Numerais e caracteres especiais não são válidos no seu nome. Tente novamente");
                Console.WriteLine("Aperte qualquer botão para reiniciar o jogo.");
            }
            Console.ReadKey();

        }
    }
}