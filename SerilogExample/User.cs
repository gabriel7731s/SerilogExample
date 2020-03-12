using System;
using Serilog;

namespace SerilogExample
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public User(int id, string name, DateTime birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Log.Information("User created: {@User}", this);
        }
    }
}
