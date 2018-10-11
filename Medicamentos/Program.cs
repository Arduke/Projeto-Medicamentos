using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projeto_Medicamento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Medicamentos listaMedicamentos;
            listaMedicamentos = new Medicamentos();

            Medicamento m1 = new Medicamento();
            Queue<Lote> lotes = new Queue<Lote>();


            int op;

            #region display
            Console.WriteLine("0. Finalizar");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento sintético");
            Console.WriteLine("3. Consultar medicamento analítico");
            Console.WriteLine("4. Comprar medicamento");
            Console.WriteLine("5. Vender medicamento");
            Console.WriteLine("6. Listar medicamentos");
            Console.WriteLine("7. Deletar medicamento");
            #endregion

            #region processo
            do
            {

                Console.WriteLine("Escolha a opção desejada: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:

                        int idMain; string nomeMain, nomeLaboratorio;
                        Console.WriteLine("Informe o ID do medicamento");
                        idMain = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o Nome do Medicamento");
                        nomeMain = Console.ReadLine();

                        Console.WriteLine("Informe o Nome do Laboratorio");
                        nomeLaboratorio = Console.ReadLine();

                        listaMedicamentos.adicionar(new Medicamento(idMain, nomeMain, nomeLaboratorio));
                        break;

                    case 2:

                        Console.WriteLine("Informe o ID");
                        idMain = int.Parse(Console.ReadLine());
                        m1.Id = idMain;

                        Medicamento medPesqSint;
                        medPesqSint = listaMedicamentos.pesquisar(new Medicamento(idMain, "", ""));
                        
                        if (medPesqSint.Id.Equals(""))
                            Console.WriteLine("ID não encontrado");
                        else
                            Console.WriteLine(medPesqSint.ToString());
                        break;

                    case 3:
                        Console.WriteLine("Digite o ID");
                        idMain = int.Parse(Console.ReadLine());
                        m1.Id = idMain;
                        Medicamento medPesqAnalit;
                        medPesqAnalit = listaMedicamentos.pesquisar(m1);
                        Console.WriteLine(medPesqAnalit.ToString());
                       
                        foreach (Lote lt in medPesqAnalit.GetLotes())
                        {
                            if (idMain.Equals(lt.Id))
                            {
                                Console.WriteLine(lt.ToString());
                            }                 
                        }
                        break;
                    case 4:
                        int id, qtde;
                        DateTime dataVenc;
                        Console.WriteLine("Digite o ID do medicamento: ");
                        idMain = Int32.Parse(Console.ReadLine());
                        m1.Id = idMain;
                        Medicamento pesquisa = listaMedicamentos.pesquisar(m1);
                        Console.WriteLine(" Digite o código:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(" Digite a quantidade:");
                        qtde = int.Parse(Console.ReadLine());
                        Console.WriteLine(" Digite a data de validade:");
                        dataVenc = DateTime.Parse(Console.ReadLine());
                        Lote lo = new Lote(id, qtde, dataVenc);
                        pesquisa.comprar(lo);

                        break;

                    case 5:
                        int qtdeMedicamento, idMedicamento;
                        Console.WriteLine("Informe o ID do medicamento");
                        idMedicamento = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual quantidade ira vender?");
                        qtdeMedicamento = int.Parse(Console.ReadLine());

                        Medicamento medicamentoEncontrado = listaMedicamentos.pesquisar(new Medicamento(idMedicamento, "", ""));
                        listaMedicamentos.MeusMedicamentos.ElementAt(idMedicamento).vender(qtdeMedicamento);
                        break;

                    case 6:
                        foreach (Medicamento med in listaMedicamentos.MeusMedicamentos)
                        {
                            Console.WriteLine(med.ToString());
                        }
                        break;
                    case 7:
                        Console.WriteLine("Informe o ID do medicamento");
                        idMain = int.Parse(Console.ReadLine());
                        m1.Id = idMain;
                        if(m1.qtdeDisponivel() > 0)
                        {
                            Console.WriteLine("Sem medicamento");
                        }
                        else { 

                        listaMedicamentos.deletar(m1);
                            }

                        break;

                    default:
                        Console.WriteLine("");
                        break;


                }
            } while (op != 0);
                    Console.ReadKey();
            #endregion
        }
    }
}
    

