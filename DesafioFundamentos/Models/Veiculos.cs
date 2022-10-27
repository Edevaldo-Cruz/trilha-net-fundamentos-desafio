namespace DesafioFundamentos.Models
{
    public class Veiculos
    {
        public Veiculos() { }

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Data { get; set; }

        public Veiculos(string placa, string modelo, string data)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Data = data;
        }
    }
}


//  public veiculos() {}

//         public string Placa { get; set; }
//         public string Modelo { get; set; }
//         public string Data { get; set; }

//         public veiculos(string placa, string modelo, string data)
//         {
//             this.Placa = placa;
//             this.Modelo = modelo;
//             this.Data = data;
//         }
