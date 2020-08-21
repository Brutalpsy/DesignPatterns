namespace NullObject.Entities
{
    public class Learner : ILearner
    {
        public Learner()
        {
        }

        public Learner(int id, string userName, int coursesCompeleted)
        {
            Id = id;
            UserName = userName;
            CoursesCompeleted = coursesCompeleted;
        }

        public int Id { get; private set; }

        public string UserName { get; private set; }

        public int CoursesCompeleted { get; private set; }
    }
}
