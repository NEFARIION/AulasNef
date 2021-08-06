using System;
using System.Threading; // Importei a função "Threading" para ser utilizada no meu namespace.
using System.Text.RegularExpressions; // Importei a função de Regex para filtrar o que o usuário pode digitar no nome e nos valores numéricos do dado.

namespace My_Awesome_Program
{
    class Loops
    {
        static void Main(string[] args)
        {

            Console.Title = "CHAT D100";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WindowHeight = 40;
            Console.WindowWidth = 160;

            bool continuarSair;
            string playerName;
            int roll = 0; //Defino um valor inicial para o roll do dado, começando em 0.

            Console.WriteLine("Olá, qual é o seu nome?");
            playerName = Console.ReadLine();

            Regex userName = new Regex("^[A-Z][a-zA-Z]*$"); // Crio uma RegularExpression para verificar se o nome de usuário contém numeral de 0 à 9.
            if (userName.IsMatch(playerName))
            {
                Console.WriteLine("Numerais e caracteres especiais não são válidos no seu nome. Tente novamente");
            }
            else
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
                    Random numberGen = new Random(); //Inicialização do RNG

                    while (roll != count) //Enquanto ROLL for DIFERENTE do COUNT (número colocado pelo usuário), eu rolo o dado novamente
                    {
                        roll = numberGen.Next(1, 101); //Defino que meu roll pode ser qualquer número entre 0 e o selecionado pelo usuário
                        Console.WriteLine("Seu número é " + roll + ". Acertei?");
                        Console.WriteLine("Aperte S para Sim e N para Não.");
                        Console.ReadKey();

                        var yesOrNo = Console.ReadKey();

                        if (yesOrNo.Key == ConsoleKey.S)
                        {

                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}