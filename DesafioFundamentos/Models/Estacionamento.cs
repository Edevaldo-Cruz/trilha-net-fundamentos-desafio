using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        public int cupom;
        public string placa, modelo, placaARemover;
        public DateTime dataEntrada;
        public List<DetalhesVeiculos> veiculos = new List<DetalhesVeiculos>();
        public bool placaRepedida = false;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar: (ex: abc-1234 ou abc-1a23)");
            placa = Console.ReadLine();

            foreach (DetalhesVeiculos detalhe in veiculos)
            {
                placaRepedida = placa == detalhe.Placa;
                if (placaRepedida == true)
                {
                    break;
                }
            }

            if (placaRepedida == false)
            {
                string placaVerificar = placa.Replace("-", "").Trim();
                bool placaNova = Regex.IsMatch(placaVerificar, "[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                bool placaAntiga = Regex.IsMatch(placaVerificar, "[a-zA-Z]{3}[0-9]{4}");

                if (placa.Length == 8)
                {
                    if (placaAntiga == true || placaNova == true)
                    {
                        Console.WriteLine("Digite o modelo do veiculo: (opcional)");
                        modelo = Console.ReadLine();

                        DetalhesVeiculos detalhes = new DetalhesVeiculos();

                        detalhes.Placa = placa.ToString();

                        if (modelo == "")
                        {
                            detalhes.Modelo = "Modelo não informado";
                        }
                        else
                        {
                            detalhes.Modelo = modelo.ToString();
                        }

                        detalhes.DataHora = DateTime.Now.ToString("dd/MM/yy HH:mm");

                        dataEntrada = DateTime.Parse(detalhes.DataHora);

                        Random numeroRandom = new Random();
                        detalhes.Cupom = numeroRandom.Next(10000, 99999);
                        cupom = detalhes.Cupom;

                        veiculos.Add(detalhes);
                        Console.WriteLine("Veiculo regitrado com secesso!");
                        Console.WriteLine($"Cupom numero: {cupom}");
                    }
                    else
                    {
                        Console.WriteLine("Placa invalida.");
                    }
                }
                else
                {
                    Console.WriteLine("Digite uma placa valida.");
                }
            }
            else
            {
                Console.WriteLine("A placa já foi cadastrada. \n Por favor verifique a placa.");
            }


        }

        public void RemoverVeiculo()
        {
            decimal valorMinuto, valorTotal;

            Console.WriteLine("Digite a placa do veículo para remover:");
            placaARemover = Console.ReadLine();

            if (veiculos.Any(x => (x.Placa.ToString()).ToUpper() == placaARemover.ToUpper()))
            {
                DateTime dataSaida;
                TimeSpan tempoDePermanencia;


                Console.WriteLine("Digite a data e hora da saida do veiculo: \n Ex: Somente o horario (hh:mm) quando veiculo é retido no mesmo dia ou a data e o horaio (dd/mm/aa hh:mm) quando é retido em outro dia.");
                dataSaida = DateTime.Parse(Console.ReadLine());


                tempoDePermanencia = dataSaida - dataEntrada;

                valorMinuto = precoPorHora / 60;

                valorTotal = (decimal)tempoDePermanencia.TotalMinutes * valorMinuto + precoInicial;

                veiculos.RemoveAt(veiculos.FindIndex(x => x.Placa.Contains(placaARemover)));

                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("           Estacionamento Pottencial Seguradora S.A");
                Console.WriteLine("====================================================================");
                Console.WriteLine("                       11.699.534/0001-74");
                Console.WriteLine("       Av. Rio Branco, 12 - Centro, Rio de Janeiro - RJ");
                Console.WriteLine("                       Tel (21) 3090-5180");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("                         Cupom de Saida");
                Console.WriteLine("  ");
                Thread.Sleep(100);
                Console.WriteLine($"Cupom Numero: {cupom}");
                Console.WriteLine($"Entrada: {dataEntrada}");
                Console.WriteLine($"Saida: {dataSaida}");
                Console.WriteLine($"Permanencia: {tempoDePermanencia.TotalMinutes} min");
                Console.WriteLine($"Valor por minuto: {valorMinuto.ToString("N2")}");
                Console.WriteLine($"Valor: R$ {valorTotal.ToString("N2")}");
                Console.WriteLine($"Placa: {placa}");
                Console.WriteLine($"Modelo: {modelo}");
                Console.WriteLine("Cobrança: Por minutos");
                Console.WriteLine("  ");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("                  Dev Full Stack Edevaldo Cruz Antonio");
                Console.WriteLine("                https://www.linkedin.com/in/edevaldo-cruz/");
                Console.WriteLine("  ");
                Console.WriteLine("  ");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                int contador = 1;
                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("           Estacionamento Pottencial Seguradora S.A");
                Console.WriteLine("====================================================================");
                Console.WriteLine("                     Relátorio de veiculos:");
                Console.WriteLine("  ");
                Console.WriteLine("  " + " Cupom     Placa    Modelo    Data/Hora");

                foreach (DetalhesVeiculos detalhe in veiculos)
                {
                    Console.WriteLine(contador + "  " + detalhe.Cupom.ToString() + "    " + detalhe.Placa.ToString() + "    " + detalhe.Modelo + "    " + detalhe.DataHora);
                    contador++;
                }

                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("                  Dev Full Stack Edevaldo Cruz Antonio");
                Console.WriteLine("                https://www.linkedin.com/in/edevaldo-cruz/");
                Console.WriteLine("  ");
                Console.WriteLine("  ");
            }
            else
            {
                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("           Estacionamento Pottencial Seguradora S.A");
                Console.WriteLine("====================================================================");
                Console.WriteLine("               Relátorio de veiculos registrado:");
                Console.WriteLine("  ");
                Console.WriteLine("                 **Não há veículos estacionados**");
                Console.WriteLine("  ");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("                  Dev Full Stack Edevaldo Cruz Antonio");
                Console.WriteLine("                https://www.linkedin.com/in/edevaldo-cruz/");
                Console.WriteLine("  ");
                Console.WriteLine("  ");

            }
        }
    }
}
