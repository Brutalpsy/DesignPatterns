namespace NullObject.Entities
{
    internal class NullLearner : ILearner
    {
        public int Id => -1;

        public string UserName => "Just Browsing";

        public int CoursesCompeleted => 0;
   }
}
