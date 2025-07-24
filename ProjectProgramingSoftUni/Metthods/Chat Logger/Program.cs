namespace Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command=Console.ReadLine().Split().ToList();
            var listOfChats=new List<string>();
            string message = "";
            int index = 0;
            string searchMessage = "";
            while (command[0]!= "end")
            {
                if (command[0]== "Chat")
                {
                    message = command[1];
                    listOfChats.Add(message);
                }
                else if (command[0]== "Delete")
                {
                    message=command[1];
                    searchMessage=listOfChats.FirstOrDefault(x=>x==message);
                    if (searchMessage != null) 
                    { 
                        index=listOfChats.IndexOf(searchMessage);
                        listOfChats.RemoveAt(index);
                    }
                }
                else if (command[0]== "Edit")
                {
                    message = command[1];
                    string editedVersion=command[2];
                    searchMessage = listOfChats.FirstOrDefault(x => x == message);
                    if (searchMessage != null) 
                    {
                        index = listOfChats.IndexOf(searchMessage);
                        listOfChats[index] = editedVersion;
                    }
                }
                else if (command[0]== "Pin")
                {
                    message = command[1];
                    searchMessage = listOfChats.FirstOrDefault(x => x == message);
                    if (searchMessage != null)
                    {
                        index = listOfChats.IndexOf(searchMessage);
                        string tempMessage=listOfChats[index];
                        listOfChats.RemoveAt(index);
                        listOfChats.Add(tempMessage);
                    }
                }
                else if (command[0]=="Spam")
                {
                    List<string>listOfSpam=command.Skip(1).ToList();
                    //listOfChats.AddRange(listOfSpam);
                    foreach (var item in listOfSpam)
                    {
                        listOfChats.Add(item);
                    }

                }
                command = Console.ReadLine().Split().ToList();
            }
            //Print Chat History
            foreach (var chat in listOfChats)
            {
                Console.WriteLine(chat);
            }
        }
    }
}
