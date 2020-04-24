using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allattartok
{
    class Pet
    {
        private int id;
        private string name;
        private string race;
        private int age;
        private Boolean favorite;
        private PetOwner owner;

        public Pet(int id, string name, string race, int age, bool favorite)
        {
            this.Id = id;
            this.Name = name;
            this.Race = race;
            this.Age = age;
            this.Favorite = favorite;
          
        }

        public override string ToString()
        {
            return name + " " + race + " " + age;
        }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Race { get => race; set => race = value; }
        public int Age { get => age; set => age = value; }
        public bool Favorite { get => favorite; set => favorite = value; }
        internal PetOwner Owner { get => owner; set => owner = value; }

        public void addOwner(PetOwner owner) {
            this.Owner = owner;
        }

        public Boolean isOlderThanOwner() {
            if (owner.Age < age)
            {
                return true;
            }
            else {
                return false;
            }
        }



    }
}
