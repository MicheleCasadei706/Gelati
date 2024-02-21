using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casadei.Michele._4i.gelati
{
    public class Gelato
    {
        private int idGelato;
        private string nome;
        private string descrizione;
        private float prezzo;

        public int IdGelato { get => idGelato; set => idGelato = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public float Prezzo { get => prezzo; set => prezzo = value; }

        public Gelato(string riga)
        {
            string[] values = riga.Split(';');

            if (float.TryParse(values[3], out float p ))
            {
                this.idGelato = int.Parse(values[0]);
                this.nome = values[1];
                this.descrizione = values[2];
                this.prezzo = p;
            }
        }
    }

    public class Gelati : List<Gelato>
    {
        public Gelati() { }
        public Gelati(string nomeFile)
        {
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                Add(new Gelato(fin.ReadLine()));
            }
            fin.Close();
        }
    }
}
