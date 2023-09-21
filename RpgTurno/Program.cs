using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace RpgTurno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Player
            Player jogador = new Player(100f, 0, 10);

            // Inimigos
            Inimigo mob1 = new Inimigo(100, 12, 10, 0, 0);
            Inimigo mob2 = new Inimigo(50, 15, 8, 0, 25);
            Inimigo mob3 = new Inimigo(50, 12, 8, 15, 0);

            Random random = new Random();

            // Armas
            Arma vampire = new Arma(12);
            Arma gladius = new Arma(19);
            Arma force = new Arma(15);
            Arma Hack = new Arma(9999);

            // Jogo
            while (jogador.playerHp > 0)
            {
                Console.WriteLine("Escolha sua arma:");
                Console.WriteLine();

                Console.WriteLine("Adaga Vampire");
                Console.WriteLine("Atk = " + vampire.ArmaDamage);
                Console.WriteLine("Atributo especial: Life steal de = 2.3");
                Console.WriteLine();

                Console.WriteLine("Espada Gladius");
                Console.WriteLine("Atk: " + gladius.ArmaDamage);
                Console.WriteLine("Atributo especial = None");
                Console.WriteLine();

                Console.WriteLine("Adaga Force");
                Console.WriteLine("Atk = " + force.ArmaDamage);
                Console.WriteLine("Atributo especial = Critico de: 33.3%");
                Console.WriteLine();

                Console.Write("Digite V para Vampire, G para Gladius e F para Force: ");
                string arma = Console.ReadLine();
                arma = arma.ToUpper();

                if(arma == "")
                {
                    arma = "V";
                }

                Console.WriteLine();

                if (arma == "V")
                {
                    jogador.playerAtk = vampire.ArmaDamage;
                }
                else if (arma == "G")
                {
                    jogador.playerAtk = gladius.ArmaDamage;
                }
                else if (arma == "F")
                {
                    jogador.playerAtk = force.ArmaDamage;
                }
                else if(arma == "HACK")
                {
                    jogador.playerAtk = Hack.ArmaDamage;
                }

                Console.WriteLine();
                Console.WriteLine("Começa a batalha");
                Console.WriteLine();
                while (jogador.playerHp > 0 && mob1.inimigoHp > 0)
                {
                    Console.WriteLine("Player Hp: " + jogador.playerHp.ToString("F1") + " | Enemys Hp is: " + mob1.inimigoHp);
                    Console.WriteLine("--- Seu turno!!---");

                    Console.WriteLine("Digite A para atacar e H para recuperar hp");
                    string escolha = Console.ReadLine();

                    if (escolha == "")
                    {
                        escolha = "A";
                    }

                    escolha = escolha.ToUpper();

                    Console.WriteLine();

                    if (escolha == "A")
                    {
                        if (arma == "V")
                        {
                            mob1.removeHp(jogador.playerAtk);
                            Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                            Console.WriteLine("Players curou 2.3 of hp");
                            Console.WriteLine();
                            jogador.addHp(2.3f);
                        }
                            else if (arma == "F")
                            {
                            mob1.removeHp(jogador.playerAtk);
                            Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");

                            int receba = force.Critico();
                            mob1.removeHp(receba);
                            if (receba == 12)
                            {
                                Console.WriteLine("Você deu 12 de dano critico!!");
                               
                            }
                            else
                            {
                                Console.WriteLine("Você não acertou dano critico");
                            }
                            Console.WriteLine();
                            }

                            else if(arma == "G")
                            {
                                mob1.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }
                            
                            else if(arma == "HACK")
                            {
                            mob1.removeHp(jogador.playerAtk);
                            Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                            Console.WriteLine();
                            }

                            else if(arma != "V" || arma != "F" || arma != "G")
                            {
                                mob1.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }
                        
                        else
                        {
                            mob1.removeHp(jogador.playerAtk);
                            Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        jogador.addHp(jogador.playerCure);
                        Console.WriteLine("Player curou: " + jogador.playerCure + " hp");
                        Console.WriteLine();
                    }

                    // Enemy Turn

                    if (mob1.inimigoHp > 0)
                    {
                        Console.WriteLine("--- Turno do inimigo ---");
                        int enemyChoice = random.Next(0, 2);

                        if (enemyChoice == 1)
                        {
                            jogador.removeHp(mob1.inimigoAtk);
                            Console.WriteLine("Inimigo atacou e causou = " + mob1.inimigoAtk + " dano");
                            Console.WriteLine();
                        }
                        else
                        {
                            mob1.addHp();
                            Console.WriteLine("Inimigo curou : " + mob1.inimigoCure + " hp");
                            Console.WriteLine();
                        }
                    }

                }

                if (jogador.playerHp <= 0)
                {
                    break;
                }

                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("PASSOU PARA O PRÓXIMO LEVEL!!!");
                Console.WriteLine();
                jogador.playerHp = 100;
                bool game = true;

                while (game)
                {
                    if(jogador.playerHp <= 0)
                    {
                        break;
                    }

               //*     if(mob2.inimigoHp <= 0 && mob3.inimigoHp <= 0)
                 //   {
                //        jogador.playerHp = 0;
                //        break ;
               //*     }

                    if (mob2.inimigoHp <= 0)
                    {
                        mob2.inimigoHp = 0;
                    }
                    else if (mob3.inimigoHp <= 0)
                    {
                        mob3.inimigoHp = 0;
                    }

                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Player Hp: " + jogador.playerHp.ToString("F1") + " | MOB1 Hp is: " + mob2.inimigoHp + " | MOB2 Hp is: " + mob3.inimigoHp);
                    Console.WriteLine("--- Seu turno!!---");
                    Console.WriteLine();

                    Console.WriteLine("Digite 1 para atacar o primeiro inimigo e 2 para atacar o segundo");
                    string choiceEnemy = Console.ReadLine();

                    if (choiceEnemy == "1")
                    {
                        Console.WriteLine("Digite A para atacar e H para recuperar hp");
                        string escolha = Console.ReadLine();

                        if(escolha == null)
                        {
                            escolha = "A";
                        }

                        Console.WriteLine();

                        if (escolha == "a" || escolha == "A")
                        {
                            if (arma == "V" || arma == "v")
                            {
                                mob2.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine("Players curou 2.3 of hp");
                                Console.WriteLine();
                                jogador.addHp(2.3f);
                            }
                            else if (arma == "F" || arma == "f")
                            {
                                {
                                    mob2.removeHp(jogador.playerAtk);
                                    Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");

                                    int receba = force.Critico();
                                    mob2.removeHp(receba);
                                    if (receba == 12)
                                    {
                                        Console.WriteLine("Você deu 12 de dano critico!!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Você não acertou dano critico");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else if (arma == "G" || arma == "g")
                            {
                                mob2.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }
                            else if (arma == "HACK")
                            {
                                mob2.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }


                        }
                        else
                        {
                            jogador.addHp(jogador.playerCure);
                            Console.WriteLine("Player curou : " + jogador.playerCure + " hp");
                            Console.WriteLine();
                        }
                    }

                    if (choiceEnemy == "2")
                    {
                        Console.WriteLine("Digite A para atacar e H para recuperar hp");
                        string escolha = Console.ReadLine();

                        if (escolha == null)
                        {
                            escolha = "A";
                        }

                        Console.WriteLine();

                        if (escolha == "a" || escolha == "A")
                        {
                            if (arma == "V" || arma == "v")
                            {
                                mob3.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine("Players curou 2.3 of hp");
                                Console.WriteLine();
                                jogador.addHp(2.3f);
                            }
                            else if (arma == "F" || arma == "f")
                            {
                                mob3.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");

                                int receba = force.Critico();
                                mob3.removeHp(receba);
                                if (receba == 12)
                                {
                                    Console.WriteLine("Você deu 12 de dano critico!!");
                                }
                                else
                                {
                                    Console.WriteLine("Você não acertou dano critico");
                                }
                                Console.WriteLine();
                            }
                            else if (arma == "G" || arma == "g")
                            {
                                mob3.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }
                            else if (arma == "HACK")
                            {
                                mob3.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            jogador.addHp(jogador.playerCure);
                            Console.WriteLine("Player curou : " + jogador.playerCure + " hp");
                            Console.WriteLine();
                        }
                    }



                    // Enemy Turn

                    if (mob2.inimigoHp > 0)
                    {
                        Console.WriteLine("--- Turno do inimigo 1 ---");
                        int enemyChoice = random.Next(0, 3);

                        if (enemyChoice == 1)
                        {
                            jogador.removeHp(mob2.inimigoAtk);
                            Console.WriteLine("Inimigo atacou e causou = " + mob2.inimigoAtk + " dano");
                            Console.WriteLine();
                        }
                        else if (enemyChoice == 2)
                        {
                            Console.WriteLine(mob2.inimigoCure);
                            mob2.addHp();
                            Console.WriteLine("Inimigo curou : " + mob2.inimigoCure + " hp");
                            Console.WriteLine();
                        }
                        else
                        {
                            jogador.removeHp(mob2.inimigoCritico);
                            Console.WriteLine("Mob1 acertou um ataque critico!! = " + mob2.inimigoCritico + " damage");
                            Console.WriteLine();
                        }
                    }

                    if (mob3.inimigoHp > 0)
                    {
                        Console.WriteLine("--- Turno do inimigo 2 ---");
                        int inimigoEscolha = random.Next(1, 4);

                        if (inimigoEscolha == 1)
                        {
                            jogador.removeHp(mob3.inimigoAtk);
                            Console.WriteLine("Inimigo atacou e causou = " + mob3.inimigoAtk + " dano");
                            Console.WriteLine();
                        }
                        else if (inimigoEscolha == 2)
                        {
                            mob3.addHp();
                            Console.WriteLine("Inimigo curou : " + mob3.inimigoCure + " hp");
                            Console.WriteLine();
                        }
                        else
                        {
                            mob3.addCurePlus();
                            Console.WriteLine("Mob 2 usou grande cura e curou " + mob3.inimigoBigCure + " hp");
                            Console.WriteLine();
                        }
                    }

                }

            }

            if (jogador.playerHp <= 0 && mob2.inimigoHp == 50 && mob3.inimigoHp == 50)
            {
                Console.WriteLine();
                Console.WriteLine("Player Hp: 0" + "| MOB1 Hp : " + mob1.inimigoHp);
                Console.WriteLine();
                Console.WriteLine("GAME OVER");
            }
            else if(jogador.playerHp <= 0 && mob2.inimigoHp >= 0 || mob3.inimigoHp >= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Player Hp: 0" + "| MOB1 Hp: " + mob2.inimigoHp + " | MOB2 Hp: " + mob3.inimigoHp);
                Console.WriteLine();
                Console.WriteLine("GAME OVER");
            }
            else if(jogador.playerHp >= 0 && mob2.inimigoHp <=0 && mob3.inimigoHp <= 0)
            {
                Console.WriteLine("Fim de jogo!!Você ganhou");
            }
        }
    }
}