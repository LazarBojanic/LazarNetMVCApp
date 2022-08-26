namespace LazarNetMVCApp.Models{
    public class SuperheroViewModel{
        public string id { get; set; }
        public string name { get; set; }
        public string intelligence { get; set; }
        public string strength { get; set; }
        public string speed { get; set; }
        public string durability { get; set; }
        public string power { get; set; }
        public string combat { get; set; }
        public string fullname { get; set; }
        public string alteregos { get; set; }
        public string[] aliases { get; set; }
        public string placeofbirth { get; set; }
        public string firstappearance { get; set; }
        public string publisher { get; set; }
        public string alignment { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public string[] height { get; set; }
        public string[] weight { get; set; }
        public string eyecolor { get; set; }
        public string haircolor { get; set; }
        public string occupation { get; set; }
        public string _base { get; set; }
        public string groupaffiliation { get; set; }
        public string relatives { get; set; }
        public string url { get; set; }

        public SuperheroViewModel(string id, string name, string intelligence, string strength, string speed, string durability,
            string power, string combat, string fullname, string alteregos, string[] aliases, string placeofbirth, string firstappearance, string publisher,
            string alignment, string gender, string race, string[] height, string[] weight, string eyecolor, string haircolor, string occupation, string _base,
            string groupaffiliation, string relatives, string url) {

            this.id = id;
            this.name = name;
            this.intelligence = intelligence;
            this.strength = strength;
            this.speed = speed;
            this.durability = durability;
            this.power = power;
            this.combat = combat;
            this.fullname = fullname;
            this.alteregos = alteregos;
            this.aliases = aliases;
            this.placeofbirth = placeofbirth;
            this.firstappearance = firstappearance;
            this.publisher = publisher;
            this.alignment = alignment;
            this.gender = gender;
            this.race = race;
            this.height = height;
            this.weight = weight;
            this.eyecolor = eyecolor;
            this.haircolor = haircolor;
            this.occupation = occupation;
            this._base = _base;
            this.groupaffiliation = groupaffiliation;
            this.relatives = relatives;
            this.url = url;
        }
        public String superheroToString() {
            return "Id: " + this.id + "\nName: " + this.name + "\nIntelligence: " + this.intelligence + "\nStrength: " + this.strength + "\nSpeed: " + this.speed + "\nDurability: " + this.durability
             + "\nPower: " + this.power + "\nCombat: " + this.combat + "\nFull Name: " + this.fullname + "\nAlter-Egos: " + this.alteregos + "\nAliases: " + getItemsFromArray(this.aliases) + "\nPlaceofbirth: " + this.placeofbirth
             + "\nFirstappearance: " + this.firstappearance + "\nPublisher: " + this.publisher + "\nAlignment: " + this.alignment + "\nGender: " + this.gender + "\nRace: " + this.race
             + "\nHeight: " + getItemsFromArray(this.height) + "\nWeight: " + getItemsFromArray(this.weight) + "\nEye Color: " + this.eyecolor + "\nHair Color: " + this.haircolor + "\nOccupation: " + this.occupation + "\nBase: " + this._base
             + "\nGroup Affiliation: " + this.groupaffiliation + "\nRelatives: " + this.relatives;
        }

        public String getItemsFromArray(String[] array) {
            String output = "";
            foreach(String item in array) {
                output += item + ", ";
            }
            output = output.Substring(0, output.Length - 2);
            return output;
        }
    }
}

