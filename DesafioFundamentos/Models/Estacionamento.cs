namespace DesafioFundamentos.Models
{

    public class DetalhesVeiculos
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string data { get; set; }
        public string hora { get; set; }

    }

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        public string placa = "";
        public string modelo = "";

        public string placaARemover = "";

        public string permanencia = "";

        public List<DetalhesVeiculos> veiculos = new List<DetalhesVeiculos>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veiculo:");
            modelo = Console.ReadLine();
            Console.WriteLine("Veiculo regitrado com secesso!");

            DetalhesVeiculos detalhes = new DetalhesVeiculos();
            detalhes.Placa = placa.ToString();
            // detalhes.Modelo ={modelo != null ? modelo.ToString() : "Modelo não informado";} 
            detalhes.Modelo = modelo.ToString();
            detalhes.data = DateTime.Now.ToShortDateString();
            detalhes.hora = DateTime.Now.ToString("hh:mm");

            permanencia = detalhes.hora;


            veiculos.Add(detalhes);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            placaARemover = Console.ReadLine();

            if (veiculos.Any(x => (x.Placa.ToString()).ToUpper() == placaARemover.ToUpper()))
            {
                int horarioSaida = 0;
                decimal valorTotal = 0;
                Console.WriteLine("Digite o horario de saida do veiculo:");
                horarioSaida = int.Parse(Console.ReadLine());
                // valorTotal = precoInicial + (precoPorHora * horas);

                //calcular com base nas horas


                TimeSpan horaEntrada = new TimeSpan(long.Parse(permanencia));

                TimeSpan horaSaida = new TimeSpan(horarioSaida);

                TimeSpan horaTotal = new TimeSpan(horaSaida.Ticks - horaEntrada.Ticks);


                veiculos.RemoveAt(veiculos.FindIndex(x => x.Placa.Contains(placaARemover)));
                Console.WriteLine(horaTotal);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
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
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine(" " + " Placa    Modelo    Data    Hora");

                foreach (DetalhesVeiculos detalhe in veiculos)
                {
                    Console.WriteLine(contador + "  " + detalhe.Placa.ToString() + "   " + detalhe.Modelo + "   " + detalhe.data + "   " + detalhe.hora);
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
