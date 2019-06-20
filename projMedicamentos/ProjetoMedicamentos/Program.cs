using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Program
    {
        public static Medicamentos med = new Medicamentos();
        static void Main(string[] args)
        {
            int opcao;
            bool opcaoMenu;

            do
            {
                #region MENU
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("|                 MENU                   |");
                Console.WriteLine("|                                        |");
                Console.WriteLine("|  0. Finalizar processo                 |");
                Console.WriteLine("|  1. Cadastrar medicamento              |");
                Console.WriteLine("|  2. Consultar medicamento (Sintetico)  |");
                Console.WriteLine("|  3. Consultar medicamento (analítico)  |");
                Console.WriteLine("|  4. Comprar medicamento                |");
                Console.WriteLine("|  5. Vender medicamento                 |");
                Console.WriteLine("|  6. Listar medicamentos                |");
                Console.WriteLine("|                                        |");
                Console.WriteLine("------------------------------------------");
                Console.Write("Escolha sua Opção: ");



                opcaoMenu = int.TryParse(Console.ReadLine(), out opcao);

                #endregion

                if (opcaoMenu)
                {
                    #region Atributos 
                    Medicamento mAux = new Medicamento();
                    bool aux;
                    int Mid, Lid = 0, qtd = 0;
                    DateTime venc;
                    string Mlab, Mnome;
                    Lote mLote = new Lote();
                    #endregion

                    switch (opcao)
                    {
                        #region 0. Finalizar processo
                        case 0:
                            return;
                        #endregion

                        #region 1. Cadastrar medicamento
                        case 1:
                            Console.WriteLine("insira as informações para cadastro:");
                            do
                            {
                                Console.Write(" digite o ID: ");
                                aux = int.TryParse(Console.ReadLine(), out Mid);
                                if (!aux)
                                    Console.WriteLine("tem que ser numero!");
                            } while (!aux);

                            Console.Write("digite o nome do  medicamento: ");
                             Mnome = Console.ReadLine();
                            Console.Write("digite o laboratório do medicamento: ");
                            Mlab = Console.ReadLine();
                            Medicamento m1 = new Medicamento(Mid, Mnome, Mlab);
                            med.adicionar(m1);
                            Console.WriteLine("dados inseridos!");
                            Console.ReadKey();
                            break;
                        #endregion

                        #region 2. Consultar medicamento (Sintetico)
                        case 2:
                            do
                            {
                                Console.Write("digite o ID:");
                                aux = int.TryParse(Console.ReadLine(), out Mid);
                                if (aux)
                                {
                                    mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                                    if (mAux.Id == 0)
                                        Console.WriteLine("Medicamento não encontrado!");
                                    else
                                        Console.WriteLine(mAux.ToString());
                                }
                                else
                                    Console.WriteLine("tem que ser numero! ");
                            } while (!aux);
                            Console.ReadKey();
                            break;

                        #endregion

                        #region 3. Consultar medicamento (analítico)
                        case 3:
                            do
                            {
                                Console.Write("digite o ID: ");
                                aux = int.TryParse(Console.ReadLine(), out Mid);
                                if (aux)
                                {
                                    mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                                    if (mAux.Id == 0)
                                        Console.WriteLine("Medicamento não encontrado!");
                                    else
                                        Console.WriteLine(mAux.ToString());

                                    foreach (Lote l in mAux.Lotes)
                                    {
                                        Console.WriteLine(l.ToString());
                                    }
                                }
                                else
                                    Console.WriteLine("tem que ser numero! ");
                            } while (!aux);
                            Console.ReadKey();
                            break;

                        #endregion

                        #region 4. Comprar medicamento
                        case 4:
                            venc = DateTime.Now;
                            Console.Write("Digite o ID do medicamento: ");
                            aux = int.TryParse(Console.ReadLine(), out Mid);
                            Console.Write("Deseja comprar quantos? ");
                            mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                            if (mAux.Id == 0)
                                Console.WriteLine("medicamento não encontrado! ");
                            else
                            {
                                Console.WriteLine("Informações do lote:");
                                do
                                {
                                    Console.Write("ID do Lote: ");
                                    aux = int.TryParse(Console.ReadLine(), out Lid);
                                    if (!aux)
                                        Console.WriteLine("tem que ser numero!");
                                } while (!aux);
                                do
                                {
                                    Console.Write("quantidade: ");
                                    aux = int.TryParse(Console.ReadLine(), out qtd);
                                    if (!aux)
                                        Console.WriteLine("tem que ser numero!");
                                } while (!aux && Lid < 0);

                                do
                                {
                                    Console.Write("digite a data de vencimento (DD/MM/AAAA): ");
                                    aux = DateTime.TryParse(Console.ReadLine(), out venc);
                                    if (!aux)
                                    {
                                        Console.WriteLine("Data Invalida!");
                                        Console.WriteLine("A data deve possuir dia, mes e ano separados conforme o exemplo...");
                                    }
                                } while (!aux);
                                Console.WriteLine("Compra realizada com sucesso!!!");
                            }

                            Lote nLote = new Lote(Lid, qtd, venc);
                            mAux.comprar(nLote);
                            
                            Console.ReadKey();
                            break;

                        #endregion

                        #region 5. Vender medicamento
                        case 5:
                            Console.Write("Digite o id do medicamento:");
                            aux = int.TryParse(Console.ReadLine(), out Mid);
                            mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                            if (mAux.Id == 0)
                                Console.WriteLine("Medicamento não encontrado!");
                            else
                            {
                                do
                                {
                                    Console.Write("Quantidade de produtos:");
                                    aux = int.TryParse(Console.ReadLine(), out qtd);
                                    if (!aux && Lid < 0)
                                        Console.WriteLine("A quantidade precisa ser um numero positivo!");

                                } while (!aux && Lid < 0);
                                mAux.vender(qtd);
                                Console.WriteLine("produto vendido!");
                            }
                            Console.ReadKey();
                            break;

                        #endregion

                        #region 6. Listar medicamentos
                        case 6:
                            foreach (Medicamento m in med.ListaMedicamentos)
                            {
                                Console.WriteLine(m.ToString());
                            }
                            Console.ReadKey();
                            break;
                        #endregion

                        #region Default
                        default:
                            Console.WriteLine("a Opção que escolheu está invalida!");
                            Console.WriteLine("as opções são numeros de 0 à 6.");
                            Console.ReadKey();

                            break;
                            #endregion
                    }

                }
                        #region Opcao invalida
                else
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    Console.WriteLine("Insira um número entre 0 e 6.");
                    opcao = 7;
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion

            } while (opcao != 0);

          

        }
    }
}
