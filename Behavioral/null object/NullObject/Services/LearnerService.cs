using NullObject.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NullObject.Services
{
    public class LearnerService
    {
        private readonly LearnerRepository _learnerRepository = new LearnerRepository();

        public LearnerService()
        {
        }

        internal ILearner GetCurrentLearner()
        {
            // get learner's id from somewhere

            int learnerId = 3;
            var learner = _learnerRepository.GetLearner(learnerId);

            if (learner == null) return new NullLearner();
            return learner;
        }

        public class LearnerRepository
        {
            readonly IList<Learner> _learners = new List<Learner>();
            public LearnerRepository()
            {
                _learners.Add(new Learner(1, "Danijel", coursesCompeleted: 89));
                _learners.Add(new Learner(1, "Milica", coursesCompeleted: 95));
            }

            public Learner GetLearner(int Id)
            {
                var exists = _learners.Any(l => l.Id == Id);

                if (exists) return _learners.FirstOrDefault(l => l.Id == Id);

                return null;
               //return _learners.FirstOrDefault(l => l.Id == Id);
            }
        }
    }
}
