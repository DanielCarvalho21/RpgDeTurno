using System.Runtime.ConstrainedExecution;

namespace RpgTurno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Player
            Player jogador = new Player(100.0f, 15, 5);

            // Inimigos
            Inimigo mob1 = new Inimigo(70, 12, 8, 0, 0);
            Inimigo mob2 = new Inimigo(50, 15, 8, 0, 25);
            Inimigo mob3 = new Inimigo(50, 12, 8, 15, 0);

            string mobQueFoiCurado;
            Random random = new Random();

            // Armas

            int Vaan = 10;
            float VaanLifeSteal = 2.3f;

            int Gladius = 20;

            int Force = 12;
            int ForceCrit;

            // Jogo

            while (jogador.playerHp > 0)
            {
                Console.WriteLine("Escolha sua arma:");
                Console.WriteLine();

                Console.WriteLine("Adaga Vann");
                Console.WriteLine("Atk = " + Vaan);
                Console.WriteLine("Atributo especial: Life steal de = " + VaanLifeSteal);
                Console.WriteLine();

                Console.WriteLine("Espada Gladius");
                Console.WriteLine("Atk: " + Gladius);
                Console.WriteLine("Atributo especial = None");
                Console.WriteLine();

                Console.WriteLine("Adaga Force");
                Console.WriteLine("Atk = " + Force);
                Console.WriteLine("Atributo especial = Critico de: 33.3%");
                Console.WriteLine();

                Console.Write("Digite V para Vaan, G para Gladius e F para Force: ");
                string arma = Console.ReadLine();
                Console.WriteLine();

                if (arma == "V" || arma == "v")
                {
                    jogador.playerAtk = Vaan;
                }
                else if (arma == "G" || arma == "g")
                {
                    jogador.playerAtk = Gladius;
                }
                else if (arma == "F" || arma == "f") ;
                {
                    jogador.playerAtk = Force;
                }

                Console.WriteLine();
                Console.WriteLine("Começa a batalha");
                Console.WriteLine();

                while (jogador.playerHp > 0 && mob1.inimigoHp > 0)
                {
                    Console.WriteLine("Player Hp: " + jogador.playerHp + " | Enemys Hp is: " + mob1.inimigoHp);
                    Console.WriteLine("--- Seu turno!!---");

                    Console.WriteLine("Digite A para atacar e H para recuperar hp");
                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    if (choice == "a" || choice == "A")
                    {
                        if (arma == "V" || arma == "v")
                        {
                            mob1.removeHp(jogador.playerAtk);
                            Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                            Console.WriteLine("Players heals 2.3 of hp");
                            Console.WriteLine();
                            jogador.playerHp += 2.3f;
                        }
                        else if (arma == "F" || arma == "f")
                        {
                            ForceCrit = random.Next(1, 3);
                            if (ForceCrit == 2)
                            {
                                float critico = 10;
                                mob1.removeHp(jogador.playerAtk);
                                mob1.removeHp(10);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine("Player deu 10 de dano Critico!!");
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
                            mob1.removeHp(jogador.playerAtk);
                            Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        jogador.addHp(jogador.playerCure);
                        Console.WriteLine("Player heals : " + jogador.playerCure + " hp");
                        Console.WriteLine();
                    }

                    // Enemy Turn

                    if (mob1.inimigoHp > 0)
                    {
                        Console.WriteLine("--- Turno do inimigo ---");
                        int enemyChoice = random.Next(1, 2);

                        if (enemyChoice == 1)
                        {
                            jogador.removeHp(mob1.inimigoAtk);
                            Console.WriteLine("Enemys Atack and deals = " + mob1.inimigoAtk + " damage");
                            Console.WriteLine();
                        }
                        else
                        {
                            mob1.addHp(mob1.addHp(mob1.inimigoCure));
                            Console.WriteLine("Enemys heals : " + mob1.inimigoCure + " hp");
                            Console.WriteLine();
                        }
                    }

                }

                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("PASSOU PARA O PRÓXIMO LEVEL!!!");
                Console.WriteLine();
                jogador.playerHp = 100;
                bool a = true;

                while (a)
                {
                    if(jogador.playerHp <= 0)
                    {
                        break;
                    }

                    if(mob2.inimigoHp <= 0 && mob3.inimigoHp <= 0)
                    {
                        jogador.playerHp = 0;
                        break ;
                    }

                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Player Hp: " + jogador.playerHp + " | MOB1 Hp is: " + mob2.inimigoHp + " | MOB2 Hp is: " + mob3.inimigoHp);
                    Console.WriteLine("--- Seu turno!!---");
                    Console.WriteLine();

                    Console.WriteLine("Digite 1 para atacar o primeiro inimigo e 2 para atacar o segundo");
                    string choiceEnemy = Console.ReadLine();

                    if (choiceEnemy == "1")
                    {
                        Console.WriteLine("Digite A para atacar e H para recuperar hp");
                        string choice = Console.ReadLine();
                        Console.WriteLine();

                        if (choice == "a" || choice == "A")
                        {
                            if (arma == "V" || arma == "v")
                            {
                                mob2.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine("Players heals 2.3 of hp");
                                Console.WriteLine();
                                jogador.playerHp += 2.3f;
                            }
                            else if (arma == "F" || arma == "f")
                            {
                                ForceCrit = random.Next(1, 3);
                                if (ForceCrit == 2)
                                {
                                    float critico = 10;
                                    mob2.removeHp(jogador.playerAtk);
                                    mob2.removeHp(10);
                                    Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                    Console.WriteLine("Player deu 10 de dano Critico!!");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    mob2.removeHp(jogador.playerAtk); ;
                                    Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                mob2.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }

                        }
                        else
                        {
                            jogador.addHp(jogador.playerCure);
                            Console.WriteLine("Player heals : " + jogador.playerCure + " hp");
                            Console.WriteLine();
                        }
                    }

                    if (choiceEnemy == "2")
                    {
                        Console.WriteLine("Digite A para atacar e H para recuperar hp");
                        string choice = Console.ReadLine();
                        Console.WriteLine();

                        if (choice == "a" || choice == "A")
                        {
                            if (arma == "V" || arma == "v")
                            {
                                mob3.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine("Players heals 2.3 of hp");
                                Console.WriteLine();
                                jogador.playerHp += 2.3f;
                            }
                            else if (arma == "F" || arma == "f")
                            {
                                ForceCrit = random.Next(0, 3);
                                if (ForceCrit == 2)
                                {
                                    float critico = 10;
                                    mob3.removeHp(jogador.playerAtk);
                                    mob3.removeHp(10);
                                    Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                    Console.WriteLine("Player deu 10 de dano Critico!!");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    mob3.removeHp(jogador.playerAtk);
                                    Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                mob3.removeHp(jogador.playerAtk);
                                Console.WriteLine("Player atacou inimigo e causou = " + jogador.playerAtk + " de dano");
                                Console.WriteLine();
                            }

                        }
                        else
                        {
                            jogador.addHp(jogador.playerCure);
                            Console.WriteLine("Player heals : " + jogador.playerCure + " hp");
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
                            Console.WriteLine("Enemys Atack and deals = " + mob2.inimigoAtk + " damage");
                            Console.WriteLine();
                        }
                        else if (enemyChoice == 2)
                        {
                            mob2.addHp(mob2.inimigoCure);
                            Console.WriteLine("Enemys heals : " + mob2.inimigoCure + " hp");
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
                        int enemyChoice = random.Next(1, 3);

                        if (enemyChoice == 1)
                        {
                            jogador.removeHp(mob3.inimigoAtk);
                            Console.WriteLine("Enemys Atack and deals = " + mob3.inimigoAtk + " damage");
                            Console.WriteLine();
                        }
                        else if (enemyChoice == 2)
                        {
                            mob3.addHp(mob3.inimigoCure);
                            Console.WriteLine("Enemys heals : " + mob3.inimigoHp + " hp");
                            Console.WriteLine();
                        }
                        else
                        {
                            int mobCure = random.Next(0, 2);
                            if (mobCure == 1)
                            {
                                mob3.addHp(mob3.inimigoBigCure);
                            }
                            else
                            {
                                mob2.addHp(mob3.inimigoBigCure);
                            }

                            if (mobCure == 1)
                            {
                                mobQueFoiCurado = "Mob1";
                            }
                            else
                            {
                                mobQueFoiCurado = "Mob2";
                            }

                            Console.WriteLine("Mob 2 usou grande cura e curou" + mob3.inimigoBigCure + "de " + mobQueFoiCurado);
                            Console.WriteLine();
                        }
                    }

                }

                if (jogador.playerHp < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player Hp: 0" + "| MOB1 Hp is: " + mob2 + " | MOB2 Hp is: " + mob3);
                    Console.WriteLine();
                    Console.WriteLine("GAME OVER");
                }

            }

            Console.WriteLine();
            Console.WriteLine("Player Hp: 0" + "| MOB1 Hp is: " + mob2.inimigoHp + " | MOB2 Hp is: " + mob3.inimigoHp);
            Console.WriteLine();
            Console.WriteLine("GAME OVER");
        }
    }
}