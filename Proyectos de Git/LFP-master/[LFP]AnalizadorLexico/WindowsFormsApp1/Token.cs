namespace WindowsFormsApp1
{
    public class Token
    {
       public enum Tipo {
            NUMERO_ENTERO,
            NUMERO_REAL,
            SIGNO_MAS,
            SIGNO_MEN,
            SIGNO_POR,
            SIGNO_DIV,
            SIGNO_POW,
            PARENTESIS_IZQ,
            PARENTESIS_DER,
            PALABRA
        };

        private Tipo tipoToken;
        private string valor;
        public Token(Tipo tipo, string auxLex)
        {
            this.tipoToken = tipo;
            this.valor = auxLex;
        }
        public string getValor()
        {
            return valor;
        }
        public string getTipoEnString()
        {
            switch (tipoToken)
            {
                case Tipo.NUMERO_ENTERO:
                    {
                        return "Numero Entero ";
                    }

                case Tipo.NUMERO_REAL:
                    {
                        return "Numero Real   ";
                    }

                case Tipo.SIGNO_MAS:
                    {
                        return "Signo Mas     ";
                    }

                case Tipo.SIGNO_MEN:
                    {
                        return "Signo Menos   ";
                    }

                case Tipo.SIGNO_POR:
                    {
                        return "Signo Por     ";
                    }

                case Tipo.SIGNO_DIV:
                    {
                        return "Signo Division";
                    }

                case Tipo.SIGNO_POW:
                    {
                        return "Signo Potencia";
                    }

                case Tipo.PARENTESIS_IZQ:
                    {
                        return "Parentesis Izq";
                    }

                case Tipo.PARENTESIS_DER:
                    {
                        return "Parentesis Der";
                    }
                case Tipo.PALABRA:
                    {
                        return "Palabra";
                    }
                default:
                    {
                        return "Desconocido";
                    }
            }
        }
    }
}