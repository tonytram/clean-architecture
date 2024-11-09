namespace Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, Email email) : base(id)
        {
            Email = email;
        }

        private User()
        {
        }

        public Email Email { get; private set; }

        public Name Name { get; set; }

        public static User Create(Email email, Name name)
        {
            var user = new User(Guid.NewGuid(), email);

            user.Raise(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
