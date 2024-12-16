using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mediator_Pattern
{
    public class ChatMediator
    {
        private List <User> users = new List <User> ();
        private Hashtable History = new Hashtable(); //история того кто писал
        private Hashtable History2 = new Hashtable(); // история кому писали
        public string Name {  get; set; }
        public ChatMediator(string name)
        {
            Name = name;
        }
        public void AddUser(User user)
        {
            if (!users.Contains(user))
            {
                users.Add(user);
                History[user] = "";
            }
        }
        public void deleteUser(User user)
        {
            if (users.Contains(user))
                users.Remove(user);
        }
        public void SMS (User name1, User name2, string s)
        {
            if (!users.Contains(name1))
                Console.WriteLine("Пользователя "+ name1.Name+" нет в чате");
            else
            {
                History[name2] += "\n";
                History[name2] += s;
                History2[name1] += "\n";
                History2[name1] += s;
                name1.receiveMessage(s);
            }
        }
        public void ReadHistory (User user)
        {
            if (users.Contains(user))
                Console.WriteLine(user.Name + ":" + History[user]);
        }
    }
    public class User
    {
        private List<ChatMediator> chats = new List <ChatMediator> ();
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
        public void AddChat (ChatMediator chat)
        {
            if (!chats.Contains(chat))
            {
                chats.Add(chat);
                chats[chats.IndexOf(chat)].AddUser(this);
            }
            else
                Console.WriteLine(this.Name + ", вы уже состоите в этом чате");
        }
        public void deleteChat(ChatMediator chat)
        {
            if (chats.Contains(chat))
            {
                chats.Remove(chat);
                Console.WriteLine(this.Name + ", вы больше не состоите в чате " + chat.Name);
            }
            else
                Console.WriteLine(this.Name + ", вы не состоите в  чате" + chat.Name);
        }
        public void sendMessage(string s, User nameS, ChatMediator chat)
        {
            if (chats.Contains(chat))
            {
                chats[chats.IndexOf(chat)].SMS(nameS, this, s);
            }
            else
                Console.WriteLine(this.Name + ", вы не состоите в  чате" + chat.Name);
        }
        public void receiveMessage(string s)
        {
            Console.WriteLine(this.Name + " принял сообщение: " + s);
        }
        public void ReadHistory(ChatMediator chat)
        {
            if (chats.Contains(chat))
               chats[chats.IndexOf(chat)].ReadHistory(this);
        }
        public void ReadHistory(ChatMediator chat, User user)
        {
            if (chats.Contains(chat))
                chats[chats.IndexOf(chat)].ReadHistory(user);
        }
    }
}
