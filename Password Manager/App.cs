using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager
{
    /* 
       [Password Manager]
       1. List all paswords
       2. Add or change password
       3. Get password
       4. Delete password 
    */
    public static class App
    {
        private static readonly Dictionary<string, string> Password_Entries = new();
        public static void Run(string[] args)
        {
            // website name = password => Dictionary

            Read_Passwords();

            while (true)
            {
                Console.WriteLine("Please select an option");
                Console.WriteLine("1 - List all passwords");
                Console.WriteLine("2 - Add/change password");
                Console.WriteLine("3 - Get password");
                Console.WriteLine("4 - Delete password");

                var Selected_Option = Console.ReadLine();

                if (Selected_Option == "1")
                    List_All_Passwords();
                else if (Selected_Option == "2")
                    Add_Change_Password();
                else if (Selected_Option == "3")
                    Get_Password();
                else if (Selected_Option == "4")
                    Delete_Password();
                else
                    Console.WriteLine("Invalid Option");

                Console.WriteLine("--------------------------");
            }
        }

        private static void List_All_Passwords()
        {
            foreach(var Entry in Password_Entries)
            {
                Console.WriteLine($"{Entry.Key} = {Entry.Value}");
            }
        }

        private static void Add_Change_Password()
        {
            Console.Write("Please enter website/app name");
            var Name = Console.ReadLine();
            Console.Write("Please enter your password");
            var Password = Console.ReadLine();

            if (Password_Entries.ContainsKey(Name))
                Password_Entries[Name] = Password;
            else
                Password_Entries.Add(Name, Password);
            Save_Passwords();
        }

        private static void Get_Password()
        {
            Console.Write("Please enter website/app name");
            var Name = Console.ReadLine();
            if (Password_Entries.ContainsKey(Name))
                Console.WriteLine($"Your password is: {Password_Entries[Name]}");
            else
                Console.WriteLine("Not Found");
        }

        private static void Delete_Password()
        {
            Console.Write("Please enter website/app name");
            var Name = Console.ReadLine();
            if  (Password_Entries.ContainsKey(Name))
            {
                Password_Entries.Remove(Name);
                Save_Passwords();
            }
            else
                Console.WriteLine("Not Found");
        }

        private static void Read_Passwords()
        {
            if (File.Exists("Password.txt"))
            {
                var Pass_Lines = File.ReadAllText("Password.txt");

                foreach(var Line in Pass_Lines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(Line))
                    {
                        var Equal_Index = Line.IndexOf("=");
                        var App_Name = Line.Substring(0, Equal_Index);
                        var Password = Line.Substring(Equal_Index + 1);
                        Password_Entries.Add(App_Name, Encryption_Utility.Decrypt(Password));
                    }
                }
            }
        }

        private static void Save_Passwords()
        {
            var sb_SavePassword = new StringBuilder();
            foreach (var Entry in Password_Entries)
                sb_SavePassword.Append($"{Entry.Key} = {Encryption_Utility.Encrypt(Entry.Value)}");

            File.WriteAllText("Passwords.txt", sb_SavePassword.ToString());
        }

    }
}
