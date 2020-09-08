using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using todo_list.Models;
using MongoDB.Driver.Builders;

namespace todo_list.Services
{
    public class TodoService
    {
        MongoClient _client;
        MongoServer _server;
        IMongoCollection<Todo> _todos;

        public TodoService()
        {
            MongoClient client = new MongoClient("mongodb+srv://demo2020:demo2020password@cluster0.e5bf3.mongodb.net/todo_list?retryWrites=true&w=majority");
            IMongoDatabase database = client.GetDatabase("todo_list");
            _todos = database.GetCollection<Todo>("todos");
        }
        public List<Todo> GetTodos()
        {
            return _todos.Find(Todo => true).ToList();
        }

        public Todo GetTodo(string id)
        {
            return _todos.Find(todo => todo.Id == id).FirstOrDefault();
        }
        public Todo Create(Todo todo)
        {
            _todos.InsertOne(todo);
            return todo;
        }
        public void Update(string id, Todo todoIn)
        {
            _todos.ReplaceOne(todo => todo.Id == id, todoIn);
        }

        public void Remove(Todo todoIn)
        {
            _todos.DeleteOne(todo => todo.Id == todoIn.Id);
        }

        public void Remove(string id)
        {
            _todos.DeleteOne(todo => todo.Id == id);
        }
    }
}