using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allattartok
{
    class PetOwner
    {
        private string name;
        private int age;
        private Boolean sex;
        private List<Pet> Pets = new List<Pet>();
        private int favID;
        private List<int> tempPetID=new List<int>();

        public PetOwner(string name, int age, bool sex, List<int> pets,int favorite)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.FavID = favorite;
            for (int i = 0; i < pets.Count; i++)
            {
                tempPetID.Add(pets[i]);
            }
            //Console.WriteLine(favorite);
        }

        public override string ToString()
        {
            string temp="";
            if (sex)
            {
                temp = "ffi";
            }
            else
            {
                temp = "nő";
            }

            return name+" "+age+" "+temp;
        }


        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public bool Sex { get => sex; set => sex = value; }
        public List<int> TempPetID { get => tempPetID; set => tempPetID = value; }
        internal List<Pet> Pets1 { get => Pets; set => Pets = value; }
        public int FavID { get => favID; set => favID = value; }
        public string petsNameList()
        {
            string s = "";
            for (int i = 0; i < Pets.Count; i++)
            {
                s += Pets[i].Name + ",";
            }
            return s;
        }


        public string petsList() {
            string s = "";
            for (int i = 0; i < tempPetID.Count; i++)
            {
                    s += tempPetID[i]+" ";
            }
            return s;
        }

        public void addpets(Pet pet) {
            Pets.Add(pet);
        }


        public int getPetCount() {
            return Pets.Count;
        }

        
    }
}
