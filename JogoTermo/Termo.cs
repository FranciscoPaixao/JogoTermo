using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTermo
{
    internal class Termo
    {
        protected string[] palavras = new string[]
{
    "ácido", "adiar", "ímpar", "algar", "amado", "amigo", "anexo", "anuir", "aonde", "apelo",
    "aquém", "argil", "arroz", "assar", "atrás", "ávido", "azeri", "babar", "bagre", "banho",
    "barco", "bicho", "bolor", "brasa", "brava", "brisa", "bruto", "bulir", "caixa", "cansa",
    "chato", "chave", "chefe", "choro", "chulo", "claro", "cobre", "corBotaote", "curar", "deixo",
    "dizer", "dogma", "dores", "duque", "enfim", "estou", "exame", "falar", "fardo", "farto",
    "fatal", "feliz", "ficar", "fogue", "força", "forno", "fraco", "fugir", "fundo", "fúria",
    "gaita", "gasto", "geada", "gelar", "gosto", "grito", "gueto", "honra", "humor", "idade",
    "ideia", "ídolo", "igual", "imune", "índio", "íngua", "irado", "isola", "janta", "jovem",
    "juizo", "largo", "laser", "leite", "lento", "lerdo", "levar", "lidar", "lindo", "lírio",
    "longe", "luzes", "magro", "maior", "malte", "mamar", "manto", "marca", "matar", "meigo",
    "meios", "melão", "mesmo", "metro", "mimos", "moeda", "moita", "molho", "morno", "morro",
    "motim", "muito", "mural", "naipe", "nasci", "natal", "naval", "ninar", "nível", "nobre",
    "noite", "norte", "nuvem", "oeste", "ombro", "ordem", "órgão", "ósseo", "ossos", "outro",
    "ouvir", "palma", "pardo", "passe", "pátio", "peito", "pêlos", "perdo", "períl", "perto",
    "pezar", "piano", "picar", "pilar", "pingo", "pione", "pista", "poder", "porém", "prado",
    "prato", "prazo", "preço", "prima", "primo", "pular", "quero", "quota", "raiva", "rampa",
    "rango", "reais", "reino", "rezar", "risco", "roçar", "rosto", "roubo", "russo", "saber",
    "sacar", "salto", "samba", "santo", "selar", "selos", "senso", "serão", "serra", "servo",
    "sexta", "sinal", "sobra", "sobre", "sócio", "sorte", "subir", "sujei", "sujos", "talão",
    "talha", "tanga", "tarde", "tempo", "tenho", "terço", "terra", "tesão", "tocar", "lacre",
    "laico", "lamba", "lambo", "largo", "larva", "lasca", "laser", "laura", "lavra", "leigo",
    "leite", "leito", "leiva", "lenho", "lento", "leque", "lerdo", "lesão", "lesma", "levar",
    "libra", "limbo", "lindo", "líneo", "lírio", "lisar", "lista", "livro", "logar", "lombo",
    "lotes", "louca", "louco", "louro", "lugar", "luzes", "macio", "maçom", "maior", "malha",
    "malte", "mamar", "mamãe", "manto", "março", "maria", "marra", "marta", "matar", "medir",
    "meigo", "meios", "melão", "menta", "menti", "mesmo", "metro", "miado", "mídia", "mielo",
    "mielo", "milho", "mimos", "minar", "minha", "miolo", "mirar", "missa", "mitos", "moeda",
    "moído", "moita", "molde", "molho", "monar", "monja", "moral", "morar", "morda", "morfo",
    "morte", "mosca", "mosco", "motim", "motor", "mudar", "muito", "mular", "mulas", "múmia",
    "mural", "extra", "falar", "falta", "fardo", "farol", "farto", "fatal", "feixe", "festa",
    "feudo", "fezes", "fiapo", "fibra", "ficha", "fidel", "filão", "filho", "firma", "fisco",
    "fisga", "fluir", "força", "forma", "forte", "fraco", "frade", "friso", "frito", "fugaz",
    "fugir", "fundo", "furor", "furto", "fuzil", "gabar", "gaita", "galho", "ganho", "garoa",
    "garra", "garro", "garvo", "gasto", "gaupe", "gazua", "geada", "gemer", "germe", "gigas",
    "girar", "gizar", "globo", "gosto", "grãos", "graça", "grava", "grito", "grude", "haver",
    "haver", "hiato", "hidra", "hífen", "hímel", "horas", "hotel", "humor", "ideal", "ídolo",
    "igual", "ileso", "imune", "irado", "isola", "jarra", "jaula", "jegue", "jeito", "jogar",
    "jovem", "juíza", "juizo", "julho", "junho", "jurar", "justa"
};
        protected string palavraSorteada;
        protected string palavraSorteadaSemAcento;
        protected bool[] letrasAcertadas;
        protected int tentativa;

        public Termo()
        {
            this.palavraSorteada = "";
            this.palavraSorteadaSemAcento = "";
            this.tentativa = 1;
            this.letrasAcertadas = new bool[5];

        }
        public void SortearPalavra()
        {
            Random random = new Random();
            int indice = random.Next(0, palavras.Length);
            palavraSorteada = palavras[indice].ToUpper();
            palavraSorteadaSemAcento = RemoveAcentos(palavraSorteada);
            tentativa = 1;
        }
        public string ObterPalavraSorteada()
        {
            return palavraSorteada;
        }
        public bool TemProximaTentativa()
        {
            if(tentativa <= 5)
            {
                return true;
            }
            return false;
        }
        public string RemoveAcentos(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            var charsSemAcentos = textoNormalizado
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            string textoSemAcentos = new string(charsSemAcentos);
            return textoSemAcentos;
        }
        public bool VerificarBotao(string botao, bool maiorIgualTamanho = false)
        {
            int auxBtnTentativa = Convert.ToInt32(botao[3].ToString());
            int auxBtnPosicao = Convert.ToInt32(botao[5].ToString());
            if (auxBtnTentativa == tentativa && auxBtnPosicao < 5)
            {
                return true;
            }
            if (auxBtnTentativa == tentativa && auxBtnPosicao <= 5 && maiorIgualTamanho)
            {
                return true;
            }
            return false;
        }
        public string UltimoBotao()
        {
            Console.WriteLine($"btn{tentativa}_5");
            return $"btn{tentativa}_5";
        }
        public string PrimeiroBotao()
        {
            return $"btn{tentativa}_1";
        }
        public void IrParaProximaTentativa()
        {
            tentativa++;
        }
        public bool VerificarSeGanhou()
        {
            foreach (bool letra in letrasAcertadas)
            {
                if (!letra)
                {
                    return false;
                }
            }
            return true;
        }
        public Color VerificarExistencia(string letra, int posicao)
        {
            Color corBotao;
            if (palavraSorteadaSemAcento.Contains(letra))
            {
                corBotao = Color.Yellow;
                if (letra.Equals(palavraSorteadaSemAcento[posicao - 1].ToString()))
                {
                    corBotao = Color.Green;
                    letrasAcertadas[posicao - 1] = true;
                }
            }
            else
            {
                corBotao = Color.Red;
            }
            return corBotao;
        }
    }
}
