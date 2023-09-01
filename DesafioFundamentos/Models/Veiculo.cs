using System.Text.RegularExpressions;
using DesafioFundamentos.Enums;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public Veiculo(string placa)
        {
            Placa = placa;
        }
        public Veiculo(string placa, Marca marca)
        {
            Placa = placa;
            Marca = marca;
        }
        public string Placa
        {
            get => _placa;
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException("O valor da placa não pode ser vazio."); }
                if (value.Length > 8) { throw new ArgumentException("Os caracteres da placa não deve ser mais de 8."); }

                value = value.Replace("-", "").Trim();

                if (char.IsLetter(value, 4))
                {
                    Regex placaMercorsul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                    if (placaMercorsul.IsMatch(value))
                    {
                        _placa = value;
                    }
                    {
                        throw new ArgumentException("A placa não corresponde ao padrão de placas do mercorsul");
                    }


                }
                else
                {
                    Regex placaNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                    if (placaNormal.IsMatch(value))
                    {
                        _placa = value;
                    }
                    else
                    {
                        throw new ArgumentException("A placa não corresponde ao padrão de placas do padrão do Brasil.");
                    }
                }
            }
        }
        private string _placa;
        public Marca Marca { get; set; }

        // private static string ValidarPlaca(string placa)
        // {
        //     if (string.IsNullOrEmpty(placa)) { throw new ArgumentNullException("O valor da placa não pode ser vazio."); }
        //     if (placa.Length > 8) { throw new ArgumentException("Os caracteres da placa não deve ser mais de 8."); }

        //     placa = placa.Replace("-", "").Trim();

        //     if (char.IsLetter(placa, 4))
        //     {
        //         Regex placaMercorsul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
        //         if (placaMercorsul.IsMatch(placa))
        //         {
        //             return placa;
        //         }

        //         throw new ArgumentException("A placa não corresponde ao padrão de placas do mercorsul");

        //     }
        //     else
        //     {
        //         Regex placaNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
        //         if (placaNormal.IsMatch(placa))
        //         {
        //             return placa;
        //         }

        //         throw new ArgumentException("A placa não corresponde ao padrão de placas do padrão do Brasil.");
        //     }
        // }

        public override string ToString()
        {
            return $"Marca: {Marca} \nPlaca: {Placa}\n";
        }
    }
}