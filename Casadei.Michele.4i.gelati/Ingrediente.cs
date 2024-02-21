using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casadei.Michele._4i.gelati
{
    public enum TipoIngrediente {Panna, Colorante, Aroma, PannaSoia, Cacao, Latte, Caffe, Mascarpone, Uovo}
    public class Ingrediente
    {
        public int idGelato { get; set; }
        public TipoIngrediente Tipo { get; set; }
        public string Valore { get; set; }

        public Ingrediente() { }

        public Ingrediente (string riga)
        {
            
            string[] values = riga.Split(';');

            if (int.TryParse(values[0],out int id) && Enum.TryParse(values[1], out TipoIngrediente i))
            {
                this.idGelato = id;
                this.Tipo = i;
                this.Valore = values[2];
            }
        }

        public static Ingrediente MakeIngrediente(string riga)
        {
            string[] values = riga.Split(';');

            TipoIngrediente i;
            Enum.TryParse(values[1], out i);

            switch (i)
            {
                case TipoIngrediente.Panna:
                    return new IngredientePanna(riga);
                    break;
                case TipoIngrediente.Colorante:
                    return new IngredienteColorante(riga);
                    break;
                case TipoIngrediente.Aroma:
                    return new IngredienteAroma(riga);
                    break;
                case TipoIngrediente.PannaSoia:
                    return new IngredientePannaSoia(riga);
                    break;
                case TipoIngrediente.Cacao:
                    return new IngredienteCacao(riga);
                    break;
                case TipoIngrediente.Latte:
                    return new IngredienteLatte(riga);
                    break;
                case TipoIngrediente.Caffe:
                    return new IngredienteCaffe(riga);
                    break;
                case TipoIngrediente.Mascarpone:
                    return new IngredienteMascarpone(riga);
                    break;
                case TipoIngrediente.Uovo:
                    return new IngredienteUovo(riga);
                    break;
                default: 
                    return new Ingrediente(riga);
                    break;
            }
            return new Ingrediente(riga);
        }
    }
    public class IngredientePanna : Ingrediente
    {
        public IngredientePanna() { }
        public IngredientePanna(string riga)
            : base(riga) { }
    }
    public class IngredienteColorante : Ingrediente
    {
        public IngredienteColorante() { }
        public IngredienteColorante(string riga)
            : base(riga) { }
    }
    public class IngredienteAroma : Ingrediente
    {
        public IngredienteAroma() { }
        public IngredienteAroma(string riga)
            : base(riga) { }
    }
    public class IngredientePannaSoia : Ingrediente
    {
        public IngredientePannaSoia() { }
        public IngredientePannaSoia(string riga)
            : base(riga) { }
    }
    public class IngredienteCacao : Ingrediente
    {
        public IngredienteCacao() { }
        public IngredienteCacao(string riga)
            : base(riga) { }
    }
    public class IngredienteLatte : Ingrediente
    {
        public IngredienteLatte() { }
        public IngredienteLatte(string riga)
            : base(riga) { }
    }

    public class IngredienteCaffe : Ingrediente
    {
        public IngredienteCaffe() { }
        public IngredienteCaffe(string riga)
            : base(riga) { }
    }

    public class IngredienteMascarpone : Ingrediente
    {
        public IngredienteMascarpone() { }
        public IngredienteMascarpone(string riga)
            : base(riga) { }
    }

    public class IngredienteUovo : Ingrediente
    {
        public IngredienteUovo() { }
        public IngredienteUovo(string riga)
            : base(riga) { }
    }
    public class Ingredienti : List<Ingrediente>
    {
        public Ingredienti() { }

        public Ingredienti(string nomeFile)
        {
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                Add(Ingrediente.MakeIngrediente((fin.ReadLine())));
            }
            fin.Close();
        }
    }
}


