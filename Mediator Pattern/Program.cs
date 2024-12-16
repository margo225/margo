// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Mediator_Pattern;

ChatMediator chat = new ChatMediator("БД");
ChatMediator chat2 = new ChatMediator("2");
User Max = new User("Max");
User Oleg = new User("Oleg");
Max.AddChat(chat);
Oleg.AddChat(chat);
Max.AddChat(chat2);
Oleg.AddChat(chat2);
Max.sendMessage("Привет", Oleg, chat);
Oleg.sendMessage("Привет",Max, chat2);
Oleg.sendMessage("Ой, ошибся чатом", Max, chat);
Oleg.sendMessage("Привет", Max, chat);
Max.ReadHistory(chat);
Max.ReadHistory(chat, Oleg);