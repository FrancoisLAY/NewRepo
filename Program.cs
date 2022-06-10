using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{

    public class Eleve
    {
        public string nom;
        public string prenom;
        public Classe classe;
        public List<Note> notes;

        public Eleve(string nom, string prenom, Classe classe, List<Note> notes)//Constructeur
        {
            this.nom = nom;
            this.prenom = prenom;
            this.classe = classe;
            this.notes = notes;
        }
        public Eleve(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.notes = new List<Note>();
        }
        public void ajouterNote(Note note)//Ajouter les notes
        {
            this.notes.Add(note);
        }
        public double Moyenne(int matiere)
        {
            float total = 0;
            int compteur = 0;
            for (int note = 0; note < this.notes.Count; note++)
            {
                if (this.notes[note].matiere == matiere)
                {
                    total = total + this.notes[note].note;
                    compteur++;
                }
            }
            return Math.Round(total / compteur, 2);
            //Calcul la moyenne, Math.Round(3.555,2)=>3.56 pour arroundir
        }
        public double Moyenne()
        {
            float total = 0;
            for (int note = 0; note < this.notes.Count; note++)
            {
                total = total + this.notes[note].note;
            }
            return Math.Round(total / this.notes.Count, 2);
            //Calcul la moyenne, //Math.Round(3.555,2)=>3.56 pour arroundir
        }
    }

    public class Classe
    {
        public string nomClasse; //quelle classe?
        public List<Eleve> eleves; //Je crée un liste d'eleves
        public List<string> matieres; //Je crée un liste de matieres

        public Classe(string nomClasse, List<Eleve> eleves, List<string> matieres)  //Constructeur
        {
            this.nomClasse = nomClasse;
            this.eleves = eleves;
            this.matieres = matieres;
        }
        public Classe(string nomClasse) //Constructeur
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        public void ajouterEleve(string Prenom, string Nom) //Ajouter un Eleve à la Classe
        {
            Eleve eleve = new Eleve(Prenom, Nom);
            eleves.Add(eleve);//J'ajoute un éleve à ma liste d'éleves
        }
        public void ajouterMatiere(string Matiere)//Ajouter une matière
        {
            this.matieres.Add(Matiere);//J'ajoute une matière à ma liste de matières
        }

        public double Moyenne(int matiere)
        {
            double total = 0;
            for (int ieleve = 0; ieleve < this.eleves.Count; ieleve++)
            {
                total = total + this.eleves[ieleve].Moyenne(matiere);
            }
            return Math.Round(total / this.eleves.Count, 2);
            //Calcul la moyenne, //Math.Round(3.555,2)=>3.56 pour arroundir
        }
        public double Moyenne()
        {
            double total = 0;
            for (int ieleve = 0; ieleve < this.eleves.Count; ieleve++)
            {
                total = total + this.eleves[ieleve].Moyenne();
            }
            return Math.Round(total / this.eleves.Count, 2);
            //Calcul la moyenne, //Math.Round(3.555,2)=>3.56 pour arroundir
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.Moyenne(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.Moyenne() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.Moyenne(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.Moyenne() + "\n");
            Console.Read();
        }
    }
}
// Classes fournies par HNI Institut
public class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }
    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}


