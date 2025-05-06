using System;
using System.Text;
using System.Security.Cryptography;


class Program
{
    static Dictionary<string, (string, string)> dictionary = new Dictionary<string, (string, string)>();
    public static void Main(){
        while(true){

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Please select one of the following options");
            Console.WriteLine("Store Password [1] Retrieve Password [2] Read txt file  [3] Exit [4]");
            Console.WriteLine("-------------------------------------------------------------------");
            int userInput;
            try{

                userInput = Convert.ToInt32(Console.ReadLine());
                if(userInput == 1){
                    Console.WriteLine("Please enter the password you would like to store");
                    try{
                        string userPassword = Console.ReadLine()!;
                        string hashedPassword = Hash.HashAlgorithm(userPassword);
                        string masterKey = GenerateMasterKey.GenerateKey();
                        StorePassword(masterKey, userPassword, hashedPassword);

                        Console.WriteLine("Your MasterKey is:");
                        Console.WriteLine(masterKey);
                        Console.WriteLine("Use this Key to retrieve your password!");
                    }
                    catch(Exception e){
                        Console.WriteLine("Please try again");
                        Console.WriteLine(e.Message);
                    } 
            } else if(userInput == 2){
                Console.WriteLine("Please enter your masterkey");
                string userMasterkey = Console.ReadLine()!;
                
                if(dictionary.ContainsKey(userMasterkey)){
                    var storedHashedPassword = dictionary[userMasterkey];
                    Console.WriteLine("Your stored password is:");
                    Console.WriteLine(storedHashedPassword.Item1);
                }else {
                    Console.WriteLine("No password with that masterkey exists");
                }
            }else if(userInput == 3){
                string text = File.ReadAllText("myfile.txt");
                Console.WriteLine(text);
                Console.Write("Do you want to clear the text file? [Enter 1 for Yes] [Enter 2 for No] ");
                int userResponse = Convert.ToInt32(Console.ReadLine());

                if(userResponse == 1){
                    File.WriteAllText("myfile.txt","");
                    dictionary.Clear();
                    Console.WriteLine("Data cleared");
                }else{
                    Console.WriteLine("Data kept");
                }
            }else if(userInput == 4){
                Console.WriteLine("See ya next time!");
                break;
            }else{
                Console.WriteLine("Please only enter a number 1-4");
            }
            }catch(FormatException){
                Console.WriteLine("Please only enter a number 1-4");
            }
        }  
    }
    public class Hash {
        public static string HashAlgorithm(string userPassword){
            using(SHA256 sha256Hash = SHA256.Create()){
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(userPassword));

                StringBuilder hash = new StringBuilder();
                for(int i = 0; i < bytes.Length;i++){
                    hash.Append(bytes[i].ToString("x2"));
                }
                string hashedPassword = hash.ToString();
                return hashedPassword;
            }
        } 
    }
    public static class GenerateMasterKey {
        public static string GenerateKey() {
            Random rand = new Random();
            int keyLength = rand.Next(5,7);
            string masterKey = "";
            int randomValue;
            for(int i = 0; i < keyLength; i++){
                randomValue = rand.Next(0,50);
                masterKey += randomValue;
            }
            return masterKey;
        }
    }
    public static void StorePassword(string masterkey, string userPassword, string hashedPassword){
        dictionary.Add(masterkey, (userPassword, hashedPassword));

        using(StreamWriter file = new StreamWriter("myfile.txt", append: true)){
            foreach(var entry in dictionary){
                file.WriteLine("Hashed Password: {1}]", entry.Key, entry.Value.Item2);
            }
        }
    }
}

// Sources:
    // https://www.w3schools.com/cs/cs_variables_display.php
    // https://www.w3schools.com/cs/cs_user_input.php
    // https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
    // https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
    // https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
    // https://www.geeksforgeeks.org/c-sharp-randomly-generating-strings/
    // https://www.c-sharpcorner.com/UploadFile/mahesh/dictionary-in-C-Sharp/
    // https://stackoverflow.com/questions/3067282/how-to-write-the-content-of-a-dictionary-to-a-text-file
// Sources:
