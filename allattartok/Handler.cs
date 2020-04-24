using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allattartok
{
	class Handler
	{
		private List<PetOwner> petOwners = new List<PetOwner>();
		private List<Pet> Pets = new List<Pet>();

		public Handler() {
			try
			{
				List<int> own = new List<int>();
				using (StreamReader sr = new StreamReader("petowners.txt"))
				{
					while (!sr.EndOfStream)
					{
						string[] line = sr.ReadLine().Split(',');
						string name = line[0];
						int age = int.Parse(line[1]);
						bool sex;
						if (line[2].Equals("ffi"))
						{
							sex = true;
						}
						else
						{
							sex = false;
						}
						own.Clear();
						for (int i = 3; i < line.Length; i++)
						{
							own.Add(int.Parse(line[i]));
						}

						petOwners.Add(new PetOwner(name, age, sex, own, own[0]));
					}
				}
				using (StreamReader sr = new StreamReader("pets.txt"))
				{
					while (!sr.EndOfStream)
					{
						string[] line = sr.ReadLine().Split(',');
						int id = int.Parse(line[0]);
						string name = line[1];
						string race = line[2];
						int age = int.Parse(line[3]);
						Pets.Add(new Pet(id, name, race, age, false));
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}


		public void writeowner() {
			for (int i = 0; i < petOwners.Count; i++)
			{
				Console.WriteLine(petOwners[i].Name + " " + petOwners[i].Age + " " + petOwners[i].Sex + " " + petOwners[i].petsList());
			}
		}

		public void writePets()
		{
			for (int i = 0; i < Pets.Count; i++)
			{
				Console.WriteLine(Pets[i].Id + " " + Pets[i].Name + " " + Pets[i].Race + " " + Pets[i].Age + " " + Pets[i].Favorite);
			}
		}

		public void setter() {
			setOwnerPets();
			setPetsOwner();
			setFav();
		}

		private void setOwnerPets() {
			for (int i = 0; i < petOwners.Count; i++)
			{
				for (int y = 0; y < petOwners[i].TempPetID.Count; y++)
				{
					for (int z = 0; z < Pets.Count; z++)
					{
						if (petOwners[i].TempPetID[y] == Pets[z].Id)
						{
							petOwners[i].addpets(Pets[z]);
						}
					}

				}
			}
		}

		private void setPetsOwner() {
			for (int i = 0; i < Pets.Count; i++)
			{
				for (int y = 0; y < petOwners.Count; y++)
				{
					for (int z = 0; z < petOwners[y].Pets1.Count; z++)
					{
						if (Pets[i].Id == petOwners[y].Pets1[z].Id)
						{
							Pets[i].addOwner(petOwners[y]);
						}
					}
					
				}
			}
		}

		private void setFav() {
			for (int i = 0; i < petOwners.Count; i++)
			{
				for (int y = 0; y < Pets.Count; y++)
				{
					if (petOwners[i].FavID ==Pets[y].Id)
					{
						Pets[y].Favorite = true;
					}
				}
				
			}
		}

		public void ownersAgeListASC() {
			List<PetOwner> ASCOrder = petOwners;
			/*
			PetOwner temp;
			for (int i = 0; i <= ASCOrder.Count-2; i++)
			{
				for (int y = 0; y <= ASCOrder.Count-2; y++)
				{
					if (ASCOrder[i].Age>(ASCOrder[i].Age+1))
					{
						temp = ASCOrder[i + 1];
						ASCOrder[i + 1] = ASCOrder[i];
						ASCOrder[i] = temp;
					}
				}
			}
			*/
			List<PetOwner> SortedList = ASCOrder.OrderBy(o => o.Age).ToList();

			for (int i = 0; i < ASCOrder.Count; i++)
			{
				Console.WriteLine(SortedList[i].Age+" "+ SortedList[i].Name+": "+SortedList[i].petsNameList());
			}

		}

		public void ownersAgeListDESC()
		{
			List<PetOwner> DESCOrder = petOwners;
			List<PetOwner> SortedList = DESCOrder.OrderByDescending(o => o.Age).ToList();

			for (int i = 0; i < DESCOrder.Count; i++)
			{
				Console.WriteLine(SortedList[i].Age + " " + SortedList[i].Name + ": " + SortedList[i].petsNameList());
			}

		}
		public void ownerOlderThanPet() {
			List<PetOwner> temp=new List<PetOwner>();
			for (int i = 0; i < petOwners.Count; i++)
			{
				for (int y = 0; y < petOwners[i].Pets1.Count; y++)
				{
					if (petOwners[i].Pets1[y].Age>petOwners[i].Age)
					{
						temp.Add(petOwners[i]);
					}
				}
			}
			for (int z = 0; z < temp.Count; z++)
			{
				Console.WriteLine(temp[z].ToString());
			}
		}

		public void searchByPetName(string petVSowner)
		{
			if (petVSowner.Equals("pet"))
			{
				string name = input().Trim().ToLower();
				if (petNameSeacrh(name) != null)
				{
					Console.WriteLine(petNameSeacrh(name));
				}
				else
				{
					Console.WriteLine("Not found");
				}
			}
			else
			{
				string name = input().Trim().ToLower();
				if (ownerNameSearch(name) != null)
				{
					for (int i = 0; i < ownerNameSearch(name).Count; i++)
					{
						Console.WriteLine(ownerNameSearch(name)[i].Name);
					}
				}
				else
				{
					Console.WriteLine("Not found");
				}


			}
		}


		private string input() {
			Console.WriteLine("Name:");
			string input = Console.ReadLine();
			return input;
		}

		private string petNameSeacrh(string name) {
			for (int i = 0; i < Pets.Count; i++)
			{
				if (Pets[i].Name.ToLower().Trim().Equals(name))
				{
					return Pets[i].Owner.Name;
				}
			}
			return null;
		}

		private List<Pet> ownerNameSearch(string name) {
			for (int i = 0; i < petOwners.Count; i++)
			{
				if (petOwners[i].Name.Trim().ToLower().Equals(name))
				{
					List<Pet> pets= petOwners[i].Pets1;
					List<Pet> SortedList = pets.OrderByDescending(o => o.Age).ToList();
					return SortedList;

				}
			}
			return null;


		}

		public void ownerPetsMax() {
			PetOwner max = petOwners[0];
			for (int i = 0; i < petOwners.Count; i++)
			{
				if (petOwners[i].Pets1.Count>max.Pets1.Count)
				{
					max = petOwners[i];
				}
			}
			Console.WriteLine("most(max):"+max.Name);
		}

		public void oldest() {
			Pet max=Pets[0];
			for (int i = 0; i < Pets.Count; i++)
			{
				if (Pets[i].Age>max.Age)
				{
					max = Pets[i];
				}
			}
			Console.WriteLine(max.Owner.Name);
		}

		public void youngest() {
			Pet min=Pets[0];
			for (int i = 0; i < Pets.Count; i++)
			{
				if (Pets[i].Favorite)
				{
					if (Pets[i].Age<min.Age)
					{
						min = Pets[i];
					}
				}
			}
			Console.WriteLine(min.Owner.Name);

		}

		public String getPopularFirstLetter() {
			List<record> rec = new List<record>();
			for (int i = 0; i < Pets.Count; i++)
			{
				char actChar = Pets[i].Name[0];
				int count = 0;
				for (int y = 0; y < Pets.Count; y++)
				{
					if (actChar==Pets[y].Name[0])
					{
						count++;
					}
				}
				rec.Add(new record(actChar,count));
			}
			record max=rec[0];
			for (int i = 0; i < rec.Count; i++)
			{
				if (rec[i].Count>max.Count)
				{
					max = rec[i];
				}
			}
			string ch = $"{max.Character}";
			return ch;
			
			
		}


		
	}

	internal class record
	{
		private char character;
		private int count;

		public record(char character, int count)
		{
			this.character = character;
			this.Count = count;
		}

		public char Character { get => character; set => character = value; }
		public int Count { get => count; set => count = value; }
	}



}
