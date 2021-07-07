using System.ComponentModel.DataAnnotations;

namespace Zaion_API.Models
{
    public class Personagem
    {
        [Key]
        public int IdPersonagem { get; set; }
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Tendencia { get; set; }
        public int Idade { get; set; }
        public string Olhos { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Pele { get; set; }
        public string Cabelos { get; set; }

        public int XpLevel { get; set; }
        public int Inspiracao { get; set; }
        public int ClasseArmadura { get; set; }
        public int Iniciativa { get; set; }
        public int Deslocamento { get; set; }
        public int VidaTotal { get; set; }
        public int VidaAtual { get; set; }
        public int Forca { get; set; }
        public int Destreza { get; set; }
        public int Constituicao { get; set; }
        public int Inteligencia { get; set; }
        public int Sabedoria { get; set; }
        public int Carisma { get; set; }
        public string Historia { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public string Nescionalidade { get; set; }
        public string PericiasEsp { get; set; }
        public string DetalhesEsp { get; set; }

    }
}